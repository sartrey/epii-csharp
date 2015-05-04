using EPII.Front;
using System;
using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    public partial class PersonView : UserControl, IView<PersonViewModel>
    {
        private PersonViewModel _ViewModel;

        public PersonView()
        {
            InitializeComponent();
        }

        public void Bind(PersonViewModel viewmodel)
        {
            //todo: bind data with vm
            BtnNext.Click += new EventHandler(
                (sender, e) => { viewmodel.GetNextPerson(); });
            this.Load += new EventHandler(
                (sender, e) => { viewmodel.GetNextPerson(); });
            _ViewModel = viewmodel;
        }
    }
}
