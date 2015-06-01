namespace EPII
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public static class LinqEx
    {
        public static void ForEach<T>(
            this IEnumerable<T> data, Action<T> action)
        {
            foreach (var item in data)
                action(item);
        }
    }
}
