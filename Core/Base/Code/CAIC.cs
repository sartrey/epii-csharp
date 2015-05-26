using System.Collections.Generic;
using System.Linq;

namespace EPII.Code
{
    /// <summary>
    /// compact auto increment code
    /// </summary>
    public class CAIC
    {
        private object sync_mutex_ = new object();
        private ulong max_ = 0;
        private List<ulong> nexts_ = new List<ulong>();
        private bool ordered_ = false;

        public bool IsOrdered
        {
            get { return ordered_; }
            set
            {
                lock (sync_mutex_) {
                    ordered_ = value;
                    if (value)
                        nexts_.Sort();
                }
            }
        }

        public ulong Next()
        {
            var count = nexts_.LongCount();
            var next = 0UL;
            if (count > 0) {
                next = nexts_[0];
                nexts_.RemoveAt(0);
            } else {
                next = max_++;
            }
            return next;
        }

        public void Revert(ulong code)
        {
            lock (sync_mutex_) {
                if (code == max_ - 1) {
                    max_ = code;
                } else {
                    if (!nexts_.Contains(code)) {
                        nexts_.Add(code);
                        if (ordered_)
                            nexts_.Sort();
                    }
                }
            }
        }
    }
}
