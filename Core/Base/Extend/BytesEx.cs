namespace EPII
{
    using System;
    using System.Text;

    public static class BytesEx
    {
        public static void Write(this byte[] data, int value, int start = 0)
        {
            for (byte i = 0; i < 4; i++) {
                data[i + start] = (byte)(value & 0xF);
                value >>= 4;
            }
        }

        public static void Write(this byte[] data, long value, int start = 0)
        {
            for (byte i = 0; i < 8; i++) {
                data[i + start] = (byte)(value & 0xF);
                value >>= 4;
            }
        }

        public static void WriteRandom(this byte[] data, int size, int start = 0)
        {
            var random = new Random();
            for (byte i = 0; i < size; i++)
                data[i + start] = (byte)random.Next(256);
        }

        public static byte[] FromHex(string source)
        {
            int length = source.Length / 2;
            var data = new byte[length];
            for (int i = 0; i < length; i++)
                data[i] = byte.Parse(source.Substring(i * 2, 2));
            return data;
        }

        public static string ToHex(byte[] data)
        {
            var sbd = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbd.Append(data[i].ToString("x2"));
            return sbd.ToString();
        }
    }
}