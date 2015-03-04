using System;
using System.Diagnostics;

namespace EPII
{
    public class Cache : ObjectEx
    {
        private object _SyncRoot = new object();
        private object _Data = null;
        private bool _IsBusy = false;
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
                lock (_SyncRoot) {
                    if (_Data == value)
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

        public bool BeginEdit()
        {
            lock (_SyncRoot) {
                if (_IsBusy)
                    return false;
                _IsBusy = true;
                return true;
            }
        }

        public void EndEdit(bool changed = true)
        {
            if (!_IsBusy)
                return;
            if (changed) {
                lock (_SyncRoot) {
                    if (++_Ticks == _MaxTicks) {
                        if (_ChangeCommitted != null) {
                            try {
                                _ChangeCommitted(_Data);
                            } catch (Exception ex) {
                                Trace.TraceError(ex.Message);
                            }
                            _Ticks = 0;
                        }
                    }
                }
            }
            _IsBusy = false;
        }

        public void Commit()
        {
            lock (_SyncRoot) {
                if (_ChangeCommitted != null) {
                    try {
                        _ChangeCommitted.Invoke(_Data);
                    } catch (Exception ex) {
                        Trace.TraceError(ex.Message);
                    }
                    _Ticks = 0;
                }
                _IsBusy = false;
            }
        }

        public void Clear()
        {
            lock (_SyncRoot) {
                _Data = null;
                _Ticks = 0;
            }
        }

        protected override void DisposeManaged()
        {
            lock (_SyncRoot) {
                if (_Data != null && _Ticks > 0)
                    Commit();
                _Data = null;
            }
        }

        protected override void DisposeNative()
        {
        }
    }
}