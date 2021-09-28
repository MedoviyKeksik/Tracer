using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.DataTypes
{
    [DataContract(Name = "Methods")]
    public class MethodInfo
    {
        [DataMember(Name = "Methods")]
        internal List<MethodInfo> _methods = new List<MethodInfo>();
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public long Time { get; set; }
        public IReadOnlyList<MethodInfo> Methods { get => _methods; }
    }
}
