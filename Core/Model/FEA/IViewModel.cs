namespace EPII.FEA
{
    using System;

    public interface IViewModel
    {
        event Action<string> PropertyChanged;

        void RelayPropertyChanged(string name);

        void RaisePropertyChanged(string name);

        void Undo(string name);
    }
}
