using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Tracer.DataTypes
{
    [DataContract(Name = "Method")]
    public class MethodInfo
    {
        [DataMember(Name = "Methods")]
        internal List<MethodInfo> _methods = new List<MethodInfo>();
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Class { get; internal set; }
        [DataMember]
        public long Time { get; internal set; }
        public IReadOnlyList<MethodInfo> Methods { get => _methods; }
    }
}
