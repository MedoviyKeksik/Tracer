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
        public int Id { get; internal set; }
        [DataMember]
        public long Time { get; internal set; }
        public IReadOnlyList<MethodInfo> Methods { get => _methods; }
    }
}
