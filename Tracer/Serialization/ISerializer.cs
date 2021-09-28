using System;
using Tracer.DataTypes;

namespace Tracer.Serialization
{
    public interface ISerializer
    {
        public string Serialize(TraceResult traceResult);
    }
}
