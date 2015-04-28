using EPII.FEA;
using System;
using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    public partial class PersonView : UserControl, IView
    {
        private PersonViewModel _ViewModel;

        public IViewModel ViewModel
        {
            get { return _ViewModel; }
        }

        public PersonView()
        {
            InitializeComponent();
        }

        public void Bind(IViewModel viewmodel)
        {
            var vm = viewmodel as PersonViewModel;
            //todo: bind data with vm
            //todo: bind behavior with vm
            _ViewModel = vm;
        }
    }
}
