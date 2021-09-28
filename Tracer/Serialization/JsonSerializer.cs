using System;
using System.Text.Json;
using Tracer.DataTypes;

namespace Tracer.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return System.Text.Json.JsonSerializer.Serialize(traceResult, options);
        }
    }
}
