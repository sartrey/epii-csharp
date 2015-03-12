using System.Collections.Generic;

namespace EPII
{
    /// <summary>
    /// easy and thread-safe {string:object} dictionary
    /// </summary>
    public class Table<T>
    {
        protected object _SyncRoot = new object();
        protected Dictionary<string, T> _Data
            = new Dictionary<string, T>();

        public IEnumerable<string> Keys
        {
            get
            {
                lock (_SyncRoot) {
                    foreach (var kvp in _Data)
                        yield return kvp.Key;
                }
            }
        }

        public T this[string key]
        {
            get
            {
                T result = default(T);
                lock (_SyncRoot) {
                    if (_Data.ContainsKey(key))
                        result = _Data[key];
                }
                return result;
            }
            set
            {
                lock (_SyncRoot) {
                    if (_Data.ContainsKey(key))
                        _Data[key] = value;
                    else
                        _Data.Add(key, value);
                }
            }
        }

        public Table()
        {
        }

        public bool Contains(string key)
        {
            bool result = false;
            lock (_SyncRoot) {
                result = _Data.ContainsKey(key);
            }
            return result;
        }

        public void Add(string key, T value)
        {
            lock (_SyncRoot) {
                if (!_Data.ContainsKey(key))
                    _Data.Add(key, value);
            }
        }

        public void Remove(string key)
        {
            lock (_SyncRoot) {
                if (_Data.ContainsKey(key))
                    _Data.Remove(key);
            }
        }

        public void Clear()
        {
            lock (_SyncRoot) {
                _Data.Clear();
            }
        }
    }
}