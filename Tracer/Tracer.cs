using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using Tracer.DataTypes;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private class ThreadRecord
        {
            public ThreadInfo ThreadInfo;
            public Stack<MethodInfo> Methods;
        }
        private ConcurrentDictionary<int, ThreadRecord> _threadRecords;
        private Stopwatch _stopwatch;
        public Tracer()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _threadRecords = new ConcurrentDictionary<int, ThreadRecord>();
        }
        public TraceResult GetTraceResult()
        {
            var tmp = new List<ThreadInfo>();
            foreach (var record in _threadRecords.Values)
            {
                tmp.Add(record.ThreadInfo);
            }
            return new TraceResult(tmp);
        }

        public MethodInfo GetPreviousMethodInfo()
        {
            var method = new StackFrame(2).GetMethod();
            return new MethodInfo
            {
                Name = method.Name,
                Class = method.ReflectedType?.Name
            };
        }

        public void StartTrace()
        {
            var currentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            var methodInfo = GetPreviousMethodInfo();
            if (_threadRecords.TryGetValue(currentThreadId, out var currentRecord))
            {
                if (currentRecord.Methods.Count == 0)
                {
                    currentRecord.ThreadInfo._methods.Add(methodInfo);
                }
                else
                {
                    var tmp = currentRecord.Methods.Peek();
                    tmp._methods.Add(methodInfo);
                }
                currentRecord.Methods.Push(methodInfo);
            } 
            else
            {
                currentRecord = new ThreadRecord();
                currentRecord.ThreadInfo = new ThreadInfo();
                currentRecord.ThreadInfo.Id = currentThreadId;
                currentRecord.ThreadInfo._methods.Add(methodInfo);
                currentRecord.Methods = new Stack<MethodInfo>();
                currentRecord.Methods.Push(methodInfo);
                _threadRecords.TryAdd(currentThreadId, currentRecord);
            }
            methodInfo.Time = _stopwatch.ElapsedMilliseconds;
        }

        public void StopTrace()
        {
            var currentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            var methodInfo = _threadRecords[currentThreadId].Methods.Pop();
            methodInfo.Time = _stopwatch.ElapsedMilliseconds - methodInfo.Time;
        }

    }
}
