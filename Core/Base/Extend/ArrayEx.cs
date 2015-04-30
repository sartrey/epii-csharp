namespace EPII
{
    using System;

    public static class ArrayEx
    {
        public static T[] Resize<T>(this T[] source, int size, bool left = false)
            where T : struct
        {
            var data = new T[size];
            var old_size = source.Length;
            if (size < old_size)
                Array.Copy(source, left ? old_size - size : 0, data, 0, size);
            else
                Array.Copy(source, 0, data, left ? size - old_size : 0, old_size);
            return data;
        }

        public static void Fill<T>(this T[] source, T data, int start = 0)
            where T : struct
        {
            if (start < 0 || start >= source.Length)
                throw new ArgumentOutOfRangeException();
            for (int i = start; i < source.Length; i++)
                source[i] = data;
        }

        public static void Fill<T>(this T[] source, T[] data, int start = 0)
            where T : struct
        {
            if (start < 0 || start >= source.Length)
                throw new ArgumentOutOfRangeException();
            int size = source.Length - start;
            var round = size / data.Length;
            var rest = size % data.Length;
            for (int i = 0; i < round; i++)
                data.CopyTo(source, start + i * data.Length);
            Array.Copy(data, 0, source, source.Length - rest, rest);
        }
    }
}
