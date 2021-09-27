using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.DataTypes
{
    public class MethodInfo
    {
        internal List<MethodInfo> _methods = new List<MethodInfo>();
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time { get; set; }
        public IReadOnlyList<MethodInfo> Methods { get => _methods; }
    }
}
