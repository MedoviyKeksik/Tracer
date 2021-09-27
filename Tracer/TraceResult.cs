using System;
using System.Collections.Generic;
using Tracer.DataTypes;

namespace Tracer
{
    public class TraceResult
    {
        private IEnumerable<ThreadInfo> _threads;
        internal TraceResult(IEnumerable<ThreadInfo> threads)
        {
            _threads = threads;
        }

        public IEnumerable<ThreadInfo> Threads { get => _threads; }
    }
}
