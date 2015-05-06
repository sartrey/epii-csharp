namespace EPII.Front
{
    public interface IView 
    {
    }

    public interface IWindowView : IView
    {
        void OnWindowClosed();

        void OnWindowOpened();
        
        bool CanClose();
    }

    public interface IView<in T> : IView
        where T : IViewModel
    {
        void Bind(T viewmodel);
    }
}
