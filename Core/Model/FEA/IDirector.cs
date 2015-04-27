namespace EPII.FEA
{
    public interface IDirector
    {
        void Activate(IViewModel viewmodel);

        void Activate(IViewModel viewmodel, IView view);
    }
}
