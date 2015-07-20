using System;
using System.Threading;

namespace EPII
{
    public class Loop
    {
        private object sync_mutex_ = new object();
        private Action action_ = null;
        private Thread thread_ = null;
        private bool running_ = false;
        private int max_times_ = 0;
        private int times_ = 0;

        public int MaxTimes
        {
            get { return max_times_; }
            set
            {
                lock (sync_mutex_) {
                    max_times_ = value;
                }
            }
        }

        public int Times
        {
            get { return times_; }
        }

        public Loop(Action action)
        {
            if (action == null)
                throw new ArgumentNullException();
            action_ = action;
        }

        private void Routine()
        {
            while (true) {
                lock (sync_mutex_) {
                    if (!running_)
                        break;
                }
                action_();
                lock (sync_mutex_) {
                    if (max_times_ > 0 && ++times_ == max_times_)
                        break;
                }
            }
        }

        public void Start()
        {
            lock (sync_mutex_) {
                if (thread_ == null)
                    thread_ = new Thread(
                        new ThreadStart(Routine));
                thread_.Start();
                running_ = true;
            }
        }

        public void TryStop() 
        {
            lock (sync_mutex_) {
                if (thread_ == null)
                    return;
                running_ = false;
            }
        }

        public void Stop(int timeout = 10000)
        {
            lock (sync_mutex_) {
                if (thread_ == null)
                    return;
                running_ = false;
                thread_.Join(timeout);
                if (thread_.ThreadState != ThreadState.Stopped)
                    thread_.Abort();
            }
        }
    }
}