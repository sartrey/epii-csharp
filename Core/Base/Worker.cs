using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace EPII
{
    public class Worker
    {
        private object _SyncRoot = new object();
        private Queue<Action> _Jobs
            = new Queue<Action>();
        private Loop _Loop = null;

        public Worker()
        {
            _Loop = new Loop(new Action(Routine));
        }

        private void Routine()
        {
            Action job = null;
            lock (_SyncRoot) {
                if (_Jobs.Count != 0)
                    job = _Jobs.Dequeue();
            }
            if (job == null)
                Thread.Sleep(50);
            else {
                try {
                    job();
                } catch (Exception ex) {
                    Trace.TraceError(ex.Message);
                }
            }
        }

        public void Push(Action job)
        {
            if (job != null) {
                lock (_SyncRoot) {
                    _Jobs.Enqueue(job);
                }
            }
        }

        public void Start()
        {
            _Loop.Start();
        }

        public void Stop(int timeout = 10000)
        {
            _Loop.Stop(timeout);
        }
    }
}