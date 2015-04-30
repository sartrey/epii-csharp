namespace EPII
{
    using System;
    using System.Linq.Expressions;
    using System.Threading;

    public static class EventEx
    {
        /// <summary>
        /// raise event thread-safe
        /// </summary>
        public static void Raise<T>(
            this T e, object sender, ref EventHandler<T> handler)
            where T : EventArgs
        {
            var temp = Interlocked.CompareExchange(
                ref handler, null, null);
            if (temp != null) {
                temp(sender, e);
            }
        }
    }
}
