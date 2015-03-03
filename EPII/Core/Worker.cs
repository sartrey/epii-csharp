using System;
using System.Collections.Generic;
using System.Threading;

namespace EPII
{
    public class Worker
    {
        private Queue<Action> _Jobs
            = new Queue<Action>();
        private Thread _Thread = null;
        private bool _IsBusy = false;
        private object _SyncRoot = new object();

        public Worker()
        {
        }

        private void WorkLoop()
        {
            while (true)
            {
                if (!_IsBusy)
                    break;
                Action job = null;
                lock (_SyncRoot)
                {
                    if (_Jobs.Count != 0)
                        job = _Jobs.Dequeue();
                }
                if (job == null)
                {
                    Thread.Sleep(50);
                    continue;
                }
                try
                {
                    job.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Push(Action job)
        {
            if (job != null)
            {
                lock (_SyncRoot)
                {
                    _Jobs.Enqueue(job);
                }
            }
        }

        public void Start()
        {
            if (_Thread == null)
                _Thread = new Thread(
                    new ThreadStart(WorkLoop));
            _IsBusy = true;
            _Thread.Start();
        }

        public void Stop(int timeout = 10000)
        {
            if (_Thread == null)
                return;
            lock (_SyncRoot)
            {
                _IsBusy = false;
            }
            _Thread.Join(timeout);
            if (_Thread.ThreadState != ThreadState.Stopped)
                _Thread.Abort();
        }
    }
}