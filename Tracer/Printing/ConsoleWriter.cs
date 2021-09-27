using System;
using Tracer.DataTypes;
using Tracer.Serialization;

namespace Tracer.Printing
{
    public class ConsoleWriter : IWriter
    {
        public void Write(TraceResult traceResult, ISerializer serializer)
        {
            Console.WriteLine(serializer.Serialize(traceResult));
        }
    }
}
