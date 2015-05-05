namespace EPII.Front
{
    public interface IView { }

    public interface IWindowView : IView
    {
        bool CanClose();
    }

    public interface IView<in T> : IView
        where T : IViewModel
    {
        void Bind(T viewmodel);
    }
}
