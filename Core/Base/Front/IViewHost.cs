namespace EPII.Front
{
    public interface IViewHost
    {
        bool HasView { get; }

        IView View { get; set; }
    }
}
