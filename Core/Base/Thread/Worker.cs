namespace EPII
{
    using System;
    using System.Threading;

    public class Worker
    {
        private Pipe<Action> jobs_
            = new Pipe<Action>();
        private Loop loop_ = null;

        public Worker()
        {
            loop_ = new Loop(new Action(Routine));
        }

        private void Routine()
        {
            Action job = null;
            if (jobs_.Count != 0)
                job = jobs_.Pull();
            if (job == null)
                Thread.Sleep(50);
            else {
                try {
                    job();
                } catch (Exception ex) {
                    Diagnose.TraceError(
                        "Worker", "Routine", ex.Message);
                }
            }
        }

        public void Push(Action job)
        {
            if (job != null) {
                jobs_.Push(job);
            }
        }

        public void Start()
        {
            loop_.Start();
        }

        public void Stop(int timeout = 10000)
        {
            loop_.Stop(timeout);
        }
    }
}