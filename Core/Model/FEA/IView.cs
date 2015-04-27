namespace EPII.FEA
{
    public interface IView
    {
        IViewModel ViewModel { get; }

        void Bind(IViewModel viewmodel);
    }
}
