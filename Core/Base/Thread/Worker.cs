using System;
using System.Diagnostics;
using System.Threading;

namespace EPII
{
    public class Worker
    {
        private Pipe<Action> _Jobs
            = new Pipe<Action>();
        private Loop _Loop = null;

        public Worker()
        {
            _Loop = new Loop(new Action(Routine));
        }

        private void Routine()
        {
            Action job = null;
            if (_Jobs.Count != 0)
                job = _Jobs.Pull();
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
                _Jobs.Push(job);
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