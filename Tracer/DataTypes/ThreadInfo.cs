using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.DataTypes
{
    public class ThreadInfo
    {
        public int Id { get; set; }
        public long Time { get; set; }
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();
    }
}
