using System;

namespace Tracer.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            return new JsonSerializer().Serialize(traceResult);
        }
    }
}
