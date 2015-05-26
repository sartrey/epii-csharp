namespace EPII
{
    using System;

    public class Cache : ObjectEx
    {
        private object sync_mutex_ = new object();
        private object data_ = null;
        private bool editable_ = false;
        private int max_ticks_ = 16;
        private int ticks_ = 0;

        private event Action<object> cache_commit_ = null;

        public event Action<object> CacheCommit
        {
            add
            {
                if (value != null)
                    cache_commit_ += value;
            }
            remove
            {
                if (value != null)
                    cache_commit_ -= value;
            }
        }

        public object Data
        {
            get { return data_; }
            set
            {
                if (value == null)
                    return;
                lock (sync_mutex_) {
                    if (data_ == value)
                        return;
                    if (!editable_)
                        return;
                    data_ = value;
                    ticks_ = 0;
                }
            }
        }

        public int MaxTicks
        {
            get { return max_ticks_; }
            set
            {
                lock (sync_mutex_) {
                    max_ticks_ = value;
                }
            }
        }

        public bool IsNull
        {
            get { return data_ == null; }
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
            if (cache_commit_ != null) {
                try {
                    cache_commit_(data_);
                } catch (Exception ex) {
                    Diagnose.TraceError(
                        "Cache", "InnerCommit", ex.Message);
                }
                ticks_ = 0;
            }
        }

        public bool BeginEdit()
        {
            if (Disposed)
                return false;
            lock (sync_mutex_) {
                if (editable_)
                    return false;
                editable_ = true;
                return true;
            }
        }

        public void EndEdit(bool changed = true)
        {
            if (Disposed)
                return;
            lock (sync_mutex_) {
                if (!editable_)
                    return;
                if (changed) {
                    if (++ticks_ == max_ticks_)
                        InnerCommit();
                }
                editable_ = false;
            }
        }

        public void Commit()
        {
            if (Disposed)
                return;
            lock (sync_mutex_) {
                if(ticks_ > 0)
                    InnerCommit();
            }
        }

        public void Clear()
        {
            lock (sync_mutex_) {
                if (editable_)
                    return;
                data_ = null;
                ticks_ = 0;
            }
        }

        protected override void DisposeManaged()
        {
            lock (sync_mutex_) {
                if (ticks_ > 0)
                    InnerCommit();
                data_ = null;
            }
        }

        protected override void DisposeNative()
        {
        }
    }
}