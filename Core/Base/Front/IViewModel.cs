namespace EPII.Front
{
    using System;
    using System.Linq.Expressions;

    public interface IViewModel
    {
        void Notice<T>(Expression<Func<T>> property);
    }
}