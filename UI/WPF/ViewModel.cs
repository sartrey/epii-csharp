namespace EPII.UI.WPF
{
    using EPII.FEA;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    public class ViewModel : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Conditional("DEBUG")]
        public void ValidProperty(string name)
        {
            var type = this.GetType();
            var prop = type.GetProperty(name);
            if (prop == null)
                throw new MissingMemberException();
        }

        public void RaisePropertyChanged(string name)
        {
            ValidProperty(name);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
