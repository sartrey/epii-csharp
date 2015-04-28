namespace EPII.FEA
{
    public interface IViewModel
    {
        //void DelayPropertyChanged(string name);

        //void UndoPropertyChanged(string name);

        void RaisePropertyChanged(string name);
    }
}