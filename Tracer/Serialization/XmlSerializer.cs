using System;

namespace Tracer.Serialization
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            return new XmlSerializer().Serialize(traceResult);
        }
    }
}
