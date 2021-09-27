using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Tracer.DataTypes;

namespace Tracer.DataTypes
{
    public class TraceResult
    {
        internal List<ThreadInfo> _threads;
        internal TraceResult()
        {
        }
        internal TraceResult(List<ThreadInfo> threads)
        {
            _threads = threads;
        }
        public IReadOnlyList<ThreadInfo> Threads { get => _threads; }
    }
}
