namespace EPII.Front
{
    public class ViewPool : Table<IView>
    {
        public T One<T>(string name)
            where T : class, IView, new()
        {
            var view = this[name] as T;
            if (view != null)
                return view;
            var new_view = new T();
            this[name] = new_view;
            return new_view;
        }
    }
}
