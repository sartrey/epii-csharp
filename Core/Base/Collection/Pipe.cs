using System;
using System.Collections.Generic;

namespace EPII
{
    /// <summary>
    /// easy and thread-safe queue
    /// </summary>
    public class Pipe<T>
    {
        protected object _SyncRoot = new object();
        protected Queue<T> _Contents
            = new Queue<T>();
        protected int _Volume = 1000;

        public int Volume 
        {
            get { return _Volume; }
            set 
            {
                lock (_SyncRoot) {
                    _Volume = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock (_SyncRoot) {
                    return _Contents.Count;
                }
            }
        }

        public Pipe()
        {
        }

        public void Push(T item)
        {
            if (item == null)
                return;
            lock (_SyncRoot) {
                if (_Volume > _Contents.Count)
                    _Contents.Enqueue(item);
            }
        }

        public T Pull()
        {
            lock (_SyncRoot) {
                if (_Contents.Count > 0)
                    return _Contents.Dequeue();
            }
            throw new Exception();
        }
    }
}
