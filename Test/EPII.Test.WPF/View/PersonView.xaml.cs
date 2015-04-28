using EPII.FEA;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EPII.Test.WPF
{
    public partial class PersonView : UserControl, IView
    {
        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
        }

        public PersonView()
        {
            InitializeComponent();
        }

        public void Bind(IViewModel viewmodel)
        {
            var vm = viewmodel as PersonViewModel;
            TxtName.SetBinding(TextBox.TextProperty, new Binding("Name"));
            TxtBirth.SetBinding(TextBox.TextProperty, new Binding("BirthText"));
            BtnNext.Click += new RoutedEventHandler(
                (sender, e) => { vm.GetNextPerson(); });
            this.DataContext = viewmodel;
        }
    }
}
