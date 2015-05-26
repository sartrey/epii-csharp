using System.Collections.Generic;

namespace EPII
{
    /// <summary>
    /// easy and thread-safe {string:object} dictionary
    /// </summary>
    public class Table<T>
    {
        protected object sync_mutex_ = new object();
        protected Dictionary<string, T> data_
            = new Dictionary<string, T>();

        public IEnumerable<string> Keys
        {
            get
            {
                lock (sync_mutex_) {
                    foreach (var kvp in data_)
                        yield return kvp.Key;
                }
            }
        }

        public T this[string key]
        {
            get
            {
                T result = default(T);
                lock (sync_mutex_) {
                    if (data_.ContainsKey(key))
                        result = data_[key];
                }
                return result;
            }
            set
            {
                lock (sync_mutex_) {
                    if (data_.ContainsKey(key))
                        data_[key] = value;
                    else
                        data_.Add(key, value);
                }
            }
        }

        public Table()
        {
        }

        public bool Contains(string key)
        {
            bool result = false;
            lock (sync_mutex_) {
                result = data_.ContainsKey(key);
            }
            return result;
        }

        public void Add(string key, T value)
        {
            lock (sync_mutex_) {
                if (!data_.ContainsKey(key))
                    data_.Add(key, value);
            }
        }

        public void Remove(string key)
        {
            lock (sync_mutex_) {
                if (data_.ContainsKey(key))
                    data_.Remove(key);
            }
        }

        public void Clear()
        {
            lock (sync_mutex_) {
                data_.Clear();
            }
        }
    }
}