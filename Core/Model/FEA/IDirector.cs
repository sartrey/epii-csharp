namespace EPII.FEA
{
    public interface IDirector
    {
        IView Activate(IViewModel viewmodel);

        IView Activate(IViewModel viewmodel, IView view);
    }
}
