using NUnit.Framework;
using System.Threading;
using Tracer;

namespace TracerTests
{
    internal class Foo
    {
        private ITracer _tracer;
        internal Foo(ITracer tracer) 
        {
            _tracer = tracer;
        }

        public int Sum1ToN(int n)
        {
            _tracer.StartTrace();
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += i;
            }
            _tracer.StopTrace();
            return result;
        }

        public int SumRange(int l, int r)
        {
            _tracer.StartTrace();
            int result = Sum1ToN(r) - Sum1ToN(l - 1);
            _tracer.StopTrace();
            return result;
        }

        public void Timeout(int time)
        {
            _tracer.StartTrace();
            Thread.Sleep(time);
            _tracer.StopTrace();
        }
    }

    public class Tests
    {
        private ITracer _tracer;
        private Foo _foo;
        [SetUp]
        public void Setup()
        {
            _tracer = new Tracer.Tracer();
            _foo = new Foo(_tracer);
        }

        [Test]
        public void TestSingleThread()
        {
            // Arrange
            const int callCount = 5;
            const int N = 1000;
            // Act
            for (int i = 0; i < callCount; i++)
                _foo.Sum1ToN(N);
            var result = _tracer.GetTraceResult();
            // Assert
            Assert.AreEqual(1, result.Threads.Count, "Number of threads in result not equeal to 1");
            Assert.AreEqual(callCount, result.Threads[0].Methods.Count, "Number of called methods not equal to methods count in result");
        }

        [Test]
        public void TestInnerMethods()
        {
            // Arrange
            const int a = 1000;
            const int b = 10000;
            // Act
            _foo.SumRange(a, b);
            var result = _tracer.GetTraceResult();
            // Assert
            Assert.AreEqual(1, result.Threads.Count, "Number of threads in result not equeal to 1");
            Assert.IsNotNull(result.Threads[0].Methods?[0], "Threre is no method calls in thread");
            Assert.AreEqual(2, result.Threads[0].Methods[0].Methods.Count, "Number of inner methods is not equal to number of called inner methods");
        }

        [Test]
        public void TestMultiThread()
        {
            // Arrange
            const int threadsNumber = 10;
            const int a = 1000;
            const int b = 100000;
            System.Collections.Generic.List<Thread> threads = new System.Collections.Generic.List<Thread>();
            // Act
            for (int i = 0; i < threadsNumber; i++)
            {
                var thread = new Thread(() => { _foo.SumRange(a, b); });
                thread.Start();
                threads.Add(thread);
            }
            for (int i = 0; i < threadsNumber; i++)
            {
                threads[i].Join();
            }
            var result = _tracer.GetTraceResult();
            // Assert
            Assert.AreEqual(threadsNumber, result.Threads.Count);
        }

        [Test]
        public void TestTimings()
        {
            // Arrange
            const int time1 = 100;
            const int time2 = 200;
            const int time3 = 300;
            const int threshold = 50;
            // Act
            _foo.Timeout(time1);
            _foo.Timeout(time2);
            _foo.Timeout(time3);
            var result = _tracer.GetTraceResult();
            // Assert
            Assert.AreEqual(time1, result.Threads[0].Methods[0].Time, threshold, "First method call is not equal to its time");
            Assert.AreEqual(time2, result.Threads[0].Methods[1].Time, threshold, "Second method call is not equal to its time");
            Assert.AreEqual(time3, result.Threads[0].Methods[2].Time, threshold, "Third method call is not equal to its time");
            Assert.AreEqual(time1 + time2 + time3, result.Threads[0].Time, threshold * 3, "Thread time is not equal to sum of method time");
        }
    }
}