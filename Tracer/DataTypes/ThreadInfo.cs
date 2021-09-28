using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tracer.DataTypes
{
    [DataContract(Name = "Thread")]
    public class ThreadInfo
    {
        [DataMember(Name = "Methods")]
        internal List<MethodInfo> _methods = new List<MethodInfo>();
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public long Time { get; set; }
        public IReadOnlyList<MethodInfo> Methods { get => _methods; }
    }
}
