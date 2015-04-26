namespace EPII.FEA
{
    public interface IViewHost
    {
        bool HasView { get; }

        IView View { get; set; }
    }
}
