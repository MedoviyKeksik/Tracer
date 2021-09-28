using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Tracer.DataTypes;

namespace Tracer.DataTypes
{
    [DataContract]
    public class TraceResult
    {
        [DataMember(Name = "Threads")]   
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
