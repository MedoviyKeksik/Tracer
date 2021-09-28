using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
