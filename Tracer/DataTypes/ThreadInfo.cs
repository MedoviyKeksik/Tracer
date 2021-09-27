using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.DataTypes
{
    public class ThreadInfo
    {
        internal List<MethodInfo> _methods = new List<MethodInfo>();
        public int Id { get; set; }
        public long Time { get; set; }
        public IReadOnlyList<MethodInfo> Methods { get => _methods; }
    }
}
