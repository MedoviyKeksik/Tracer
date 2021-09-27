using System;
using System.IO;
using Tracer.DataTypes;

namespace Tracer.Serialization
{
    public class XmlSerializer : ISerializer
    {
        private System.Xml.Serialization.XmlSerializer _serializer;
        public XmlSerializer()
        {
            _serializer = new System.Xml.Serialization.XmlSerializer(typeof(TraceResult));
        }
        public string Serialize(TraceResult traceResult)
        {
            using var stringWriter = new StringWriter();
            _serializer.Serialize(stringWriter, traceResult);
            return stringWriter.ToString();
        }
    }
}
