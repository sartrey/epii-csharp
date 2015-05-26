using System;

namespace EPII
{
    //todo: thread safe dispose ???
    public abstract class ObjectEx : IDisposable
    {
        private bool disposed_ = false;

        public bool Disposed 
        {
            get { return disposed_; }
        }

        ~ObjectEx()
        {
            if (disposed_)
                return;
            DisposeNative();
            disposed_ = true;
        }

        protected abstract void DisposeManaged();

        protected abstract void DisposeNative();

        public void Dispose()
        {
            if (disposed_)
                return;
            DisposeManaged();
            DisposeNative();
            disposed_ = true;
            GC.SuppressFinalize(this);
        }
    }
}