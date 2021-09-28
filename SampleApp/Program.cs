using System;
using Tracer;
using Tracer.Printing;
using Tracer.Serialization;

namespace SampleApp
{
    class Foo
    {
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Method()
        {
            _tracer.StartTrace();
            System.Threading.Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }

    class Bar
    {
        private ITracer _tracer;
        private Foo _foo;
        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
            _foo = new Foo(tracer);
        }

        public void OuterMethod(int a, int b) 
        {
            _tracer.StartTrace();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    _foo.Method();
                }
            }
            _tracer.StopTrace();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tracer.Tracer tracer = new Tracer.Tracer();

            var bar = new Bar(tracer);
            var thread = new System.Threading.Thread(() =>
            {
                var innerBar = new Bar(tracer);
                innerBar.OuterMethod(2, 3);
            });
            thread.Start();
            bar.OuterMethod(4, 4);
            thread.Join();

            var result = tracer.GetTraceResult();
            var cw = new ConsoleWriter();
            ISerializer serializer = new XmlSerializer();
            cw.Write(result, serializer);
            var fw = new FileWriter();
            serializer = new JsonSerializer();
            fw.Write(result, serializer);
        }
    }
}
