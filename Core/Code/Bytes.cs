using System;
using System.Text;

namespace EPII
{
    public class Bytes
    {
        public static Bytes FromBase64(string source)
        {
            var data = Convert.FromBase64String(source);
            return new Bytes(data);
        }

        public static Bytes FromHex(string source)
        {
            int length = source.Length / 2;
            var data = new byte[length];
            for (int i = 0; i < length; i++)
                data[i] = byte.Parse(source.Substring(i * 2, 2));
            return new Bytes(data);
        }

        private byte[] _Data
            = null;

        public byte[] Data
        {
            get { return _Data; }
        }

        public Bytes(int size)
        {
            _Data = new byte[size];
        }

        public Bytes(byte[] data)
        {
            _Data = data;
        }

        public void Resize(int size, bool left = false)
        {
            var bytes = new byte[size];
            var old_size = _Data.Length;
            if (size < old_size)
                Array.Copy(_Data, left ? old_size - size : 0, bytes, 0, size);
            else
                Array.Copy(_Data, 0, bytes, left ? size - old_size : 0, old_size);
        }

        public void Fill(byte[] bytes)
        {
            var round = _Data.Length / bytes.Length;
            var rest = _Data.Length % bytes.Length;
            for (int i = 0; i < round; i++)
                bytes.CopyTo(_Data, i * bytes.Length);
            for (int i = 0; i < rest; i++)
                _Data[i + round * bytes.Length] = bytes[i];
        }

        public void Write(int value, int start = 0)
        {
            for (byte i = 0; i < 4; i++) {
                _Data[i + start] = (byte)(value & 0xF);
                value >>= 4;
            }
        }

        public void Write(long value, int start = 0)
        {
            for (byte i = 0; i < 8; i++) {
                _Data[i + start] = (byte)(value & 0xF);
                value >>= 4;
            }
        }

        public void WriteRandom(int size, int start = 0)
        {
            var random = new Random();
            for (byte i = 0; i < size; i++)
                _Data[i + start] = (byte)random.Next(256);
        }

        public string ToBase64()
        {
            string result = Convert.ToBase64String(_Data);
            return result;
        }

        public string ToHex()
        {
            var sbd = new StringBuilder();
            for (int i = 0; i < _Data.Length; i++)
                sbd.Append(_Data[i].ToString("x2"));
            return sbd.ToString();
        }
    }
}