using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.DataTypes
{
    public class MethodInfo
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time { get; set; }
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();
    }
}
