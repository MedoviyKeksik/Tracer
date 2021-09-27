using System;
using Tracer;

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
            System.Threading.Thread.Sleep(1000);
            _tracer.StopTrace();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tracer.Tracer tracer = new Tracer.Tracer();
            var foo = new Foo(tracer);
            foo.Method();
            var result = tracer.GetTraceResult();
            Console.WriteLine("Hello World!");
        }
    }
}
