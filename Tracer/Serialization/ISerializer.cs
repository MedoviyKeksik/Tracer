using System;

namespace Tracer.Serialization
{
    public interface ISerializer
    {
        public string Serialize(TraceResult traceResult);
    }
}
