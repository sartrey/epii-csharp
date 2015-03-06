using System;

namespace EPII
{
    public class ArrayEx<T>
        where T : struct
    {
        protected T[] _Data;

        public T[] Data 
        {
            get { return _Data; }
        }

        public ArrayEx(int size) 
        {
            _Data = new T[size];
        }

        public ArrayEx(T[] data) 
        {
            _Data = data;
        }

        public void Resize(int size, bool left = false)
        {
            var data = new T[size];
            var old_size = _Data.Length;
            if (size < old_size)
                Array.Copy(_Data, left ? old_size - size : 0, data, 0, size);
            else
                Array.Copy(_Data, 0, data, left ? size - old_size : 0, old_size);
        }

        public void Fill(T data, int start = 0) 
        {
            if (start < 0 || start >= _Data.Length)
                throw new ArgumentOutOfRangeException();
            for (int i = start; i < _Data.Length; i++)
                _Data[i] = data;
        }

        public void Fill(T[] data, int start = 0)
        {
            if (start < 0 || start >= _Data.Length)
                throw new ArgumentOutOfRangeException();
            int size = _Data.Length - start;
            var round = size / data.Length;
            var rest = size % data.Length;
            for (int i = 0; i < round; i++)
                data.CopyTo(_Data, start + i * data.Length);
            Array.Copy(data, 0, _Data, _Data.Length - rest, rest);
        }
    }
}
