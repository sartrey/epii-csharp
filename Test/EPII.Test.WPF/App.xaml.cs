using System.Windows;
using EPII.UI.WPF;

namespace EPII.Test.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var runtime = Runtime.Instance;
            var fea = runtime.Use<FEA.FEAModel>();
            var director = fea.GetDirector<UI.WPF.Director>();

            //director.Activate(new PersonViewModel());
            //var view = director.Activate(new PersonViewModel(), new PersonView());
            var viewmodel = new PersonViewModel();
            var view = new PersonView();
            view.Bind(viewmodel);

            var window = fea.WindowPool.One<EPII.UI.WPF.Window>();
            window.View = view;
            window.Open();

            base.OnStartup(e);
        }
    }
}
