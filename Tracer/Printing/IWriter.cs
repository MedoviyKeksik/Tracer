using Tracer.DataTypes;
using Tracer.Serialization;

namespace Tracer.Printing
{
    public interface IWriter
    {
        public void Write(TraceResult traceResult, ISerializer serializer);
    }
}
