namespace EPII.Data
{
    using System;

    public static class NotNullValidator
    {
        public static Guard<T> NotNull<T>(this Guard<T> source) 
        {
            if (source.Data != null)
                return source;
            throw new ArgumentNullException();
        }
    }
}
