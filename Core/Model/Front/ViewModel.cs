namespace EPII.Front
{
    using System;
    using System.Linq.Expressions;

    public abstract class ViewModel : IViewModel
    {
        protected abstract void OnPropertyChanged<T>(string name, T value);

        public void Notice<T>(
            Expression<Func<T>> property)
        {
            var member_expr = property.Body as MemberExpression;
            if (member_expr != null) {
                OnPropertyChanged(
                    member_expr.Member.Name,
                    property.Compile()());
            }
        }
    }
}
