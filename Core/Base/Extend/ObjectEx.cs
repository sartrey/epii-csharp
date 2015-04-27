using System;

namespace EPII
{
    //todo: thread safe dispose ???
    public abstract class ObjectEx : IDisposable
    {
        private bool _Disposed = false;

        public bool Disposed 
        {
            get { return _Disposed; }
        }

        ~ObjectEx()
        {
            if (_Disposed)
                return;
            DisposeNative();
            _Disposed = true;
        }

        protected abstract void DisposeManaged();

        protected abstract void DisposeNative();

        public void Dispose()
        {
            if (_Disposed)
                return;
            DisposeManaged();
            DisposeNative();
            _Disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}