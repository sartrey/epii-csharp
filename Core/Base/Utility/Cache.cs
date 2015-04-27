namespace EPII
{
    using System;

    public class Cache : ObjectEx
    {
        private object _SyncRoot = new object();
        private object _Data = null;
        private bool _IsEditable = false;
        private int _MaxTicks = 16;
        private int _Ticks = 0;

        private event Action<object> _ChangeCommitted = null;

        public event Action<object> ChangeCommitted
        {
            add
            {
                if (value != null)
                    _ChangeCommitted += value;
            }
            remove
            {
                if (value != null)
                    _ChangeCommitted -= value;
            }
        }

        public object Data
        {
            get { return _Data; }
            set
            {
                if (value == null)
                    return;
                lock (_SyncRoot) {
                    if (_Data == value)
                        return;
                    if (!_IsEditable)
                        return;
                    _Data = value;
                    _Ticks = 0;
                }
            }
        }

        public int MaxTicks
        {
            get { return _MaxTicks; }
            set
            {
                lock (_SyncRoot) {
                    _MaxTicks = value;
                }
            }
        }

        public bool IsNull
        {
            get { return _Data == null; }
        }

        public Cache()
        {
        }

        /// <summary>
        /// commit without any guards
        /// </summary>
        protected void InnerCommit()
        {
            if (Disposed)
                return;
            if (_ChangeCommitted != null) {
                try {
                    _ChangeCommitted(_Data);
                } catch (Exception ex) {
                    Diagnose.TraceError(
                        "Cache", "InnerCommit", ex.Message);
                }
                _Ticks = 0;
            }
        }

        public bool BeginEdit()
        {
            if (Disposed)
                return false;
            lock (_SyncRoot) {
                if (_IsEditable)
                    return false;
                _IsEditable = true;
                return true;
            }
        }

        public void EndEdit(bool changed = true)
        {
            if (Disposed)
                return;
            lock (_SyncRoot) {
                if (!_IsEditable)
                    return;
                if (changed) {
                    if (++_Ticks == _MaxTicks)
                        InnerCommit();
                }
                _IsEditable = false;
            }
        }

        public void Commit()
        {
            if (Disposed)
                return;
            lock (_SyncRoot) {
                if(_Ticks > 0)
                    InnerCommit();
            }
        }

        public void Clear()
        {
            lock (_SyncRoot) {
                if (_IsEditable)
                    return;
                _Data = null;
                _Ticks = 0;
            }
        }

        protected override void DisposeManaged()
        {
            lock (_SyncRoot) {
                if (_Ticks > 0)
                    InnerCommit();
                _Data = null;
            }
        }

        protected override void DisposeNative()
        {
        }
    }
}