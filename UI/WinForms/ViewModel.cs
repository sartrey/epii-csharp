namespace EPII.UI.WinForms
{
    using System;

    public class ViewModel : EPII.Front.ViewModel 
    {
        private event EventHandler PropertyChanged;

        protected override void OnPropertyChanged<T>(string name, T value)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new EventArgs());
        }
    }
}