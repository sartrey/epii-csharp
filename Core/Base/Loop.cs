using System;
using System.Threading;

namespace EPII
{
    public class Loop
    {
        private object _SyncRoot = new object();
        private Action _Action = null;
        private Thread _Thread = null;
        private bool _IsRunning = false;
        private int _MaxTimes = 0;
        private int _Times = 0;

        public int MaxTimes
        {
            get { return _MaxTimes; }
            set
            {
                lock (_SyncRoot) {
                    _MaxTimes = value;
                }
            }
        }

        public int Times
        {
            get { return _Times; }
        }

        public Loop(Action action)
        {
            if (action == null)
                throw new ArgumentNullException();
            _Action = action;
        }

        private void Routine()
        {
            while (true) {
                if (!_IsRunning)
                    break;
                _Action();
                if (_MaxTimes > 0 && ++_Times == _MaxTimes)
                    break;
            }
            _IsRunning = false;
        }

        public void Start()
        {
            if (_Thread == null)
                _Thread = new Thread(
                    new ThreadStart(Routine));
            _IsRunning = true;
            _Thread.Start();
        }

        public void Stop(int timeout = 10000)
        {
            if (_Thread == null)
                return;
            lock (_SyncRoot) {
                _IsRunning = false;
            }
            _Thread.Join(timeout);
            if (_Thread.ThreadState != ThreadState.Stopped)
                _Thread.Abort();
        }
    }
}