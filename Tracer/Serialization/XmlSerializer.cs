using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Tracer.DataTypes;

namespace Tracer.Serialization
{
    public class XmlSerializer : ISerializer
    {
        private DataContractSerializer _serializer;
        public XmlSerializer()
        {
            _serializer = new DataContractSerializer(typeof(TraceResult));
        }
        public string Serialize(TraceResult traceResult)
        {
            using var stringWriter = new StringWriter();
            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(stringWriter, settings);
            _serializer.WriteObject(writer, traceResult);
            writer.Close();
            return stringWriter.ToString();
        }
    }
}
