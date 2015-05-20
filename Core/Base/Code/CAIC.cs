using System.Collections.Generic;
using System.Linq;

namespace EPII.Code
{
    /// <summary>
    /// compact auto increment code
    /// </summary>
    public class CAIC
    {
        private object _SyncRoot = new object();
        private ulong _Max = 0;
        private List<ulong> _Nexts = new List<ulong>();
        private bool _Ordered = false;

        public bool Ordered
        {
            get { return _Ordered; }
            set
            {
                lock (_SyncRoot) {
                    _Ordered = value;
                    if (value)
                        _Nexts.Sort();
                }
            }
        }

        public ulong Next()
        {
            var count = _Nexts.LongCount();
            var next = 0UL;
            if (count > 0) {
                next = _Nexts[0];
                _Nexts.RemoveAt(0);
            } else {
                next = _Max++;
            }
            return next;
        }

        public void Revert(ulong code)
        {
            lock (_SyncRoot) {
                if (code == _Max - 1) {
                    _Max = code;
                } else {
                    if (!_Nexts.Contains(code)) {
                        _Nexts.Add(code);
                        if (_Ordered)
                            _Nexts.Sort();
                    }
                }
            }
        }
    }
}
