using System;
using System.Collections.Generic;

namespace EPII
{
    /// <summary>
    /// easy and thread-safe queue
    /// </summary>
    public class Pipe<T>
    {
        protected object sync_mutex_ = new object();
        protected Queue<T> data_
            = new Queue<T>();
        protected int volume_ = 1000;

        public int Volume 
        {
            get { return volume_; }
            set 
            {
                lock (sync_mutex_) {
                    volume_ = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock (sync_mutex_) {
                    return data_.Count;
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
            lock (sync_mutex_) {
                if (volume_ > data_.Count)
                    data_.Enqueue(item);
            }
        }

        public T Pull()
        {
            lock (sync_mutex_) {
                if (data_.Count > 0)
                    return data_.Dequeue();
            }
            throw new Exception();
        }
    }
}
