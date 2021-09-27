using System;
using System.IO;
using Tracer.DataTypes;
using Tracer.Serialization;

namespace Tracer.Printing
{
    public class FileWriter : IWriter
    {
        public void Write(TraceResult traceResult, ISerializer serializer)
        {
            using var sw = new StreamWriter("Result-" + DateTime.Now.ToString("HH-mm-dd-MM-yyyy") + ".txt");
            sw.WriteLine(serializer.Serialize(traceResult));
        }
    }
}
