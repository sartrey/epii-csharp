using EPII.FEA;
using System;
using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    public partial class TestView : UserControl, IView
    {
        private TestViewModel _ViewModel;

        public IViewModel ViewModel
        {
            get { return _ViewModel; }
        }

        public TestView()
        {
            InitializeComponent();
        }

        public void Bind(IViewModel viewmodel)
        {
            var director = Director.For(this);
            var vm = viewmodel as TestViewModel;
            director.BindView(
                () => { vm.Time = Dtp1.Value; },
                () => { Dtp1.Value = vm.Time; });
            director.BindView(
                () => { vm.Text = Tbx1.Text; },
                () => { Tbx1.Text = vm.Text; });
        }
    }
}
