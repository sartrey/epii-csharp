using EPII.Front;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EPII.Test.WPF
{
    public partial class PersonView 
        : UserControl, IView<PersonViewModel>
    {
        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
        }

        public PersonView()
        {
            InitializeComponent();
        }

        public void Bind(PersonViewModel viewmodel)
        {
            TxtName.SetBinding(TextBox.TextProperty, new Binding("Name"));
            TxtBirth.SetBinding(TextBox.TextProperty, new Binding("BirthText"));
            BtnNext.Click += new RoutedEventHandler(
                (sender, e) => { viewmodel.GetNextPerson(); });
            this.Loaded += new RoutedEventHandler(
                (sender, e) => { viewmodel.GetNextPerson(); });
            this.DataContext = viewmodel;
        }
    }
}
