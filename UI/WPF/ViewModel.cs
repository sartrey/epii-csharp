namespace EPII.UI.WPF
{
    using System.ComponentModel;

    public class ViewModel : EPII.Front.ViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged<T>(string name, T value)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}