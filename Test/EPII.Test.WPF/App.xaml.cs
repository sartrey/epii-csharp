using System.Windows;

namespace EPII.Test.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var runtime = Runtime.Instance;
            var front = runtime.Use<Front.Startup>(
                startup => {
                    startup.SearchAllViews();
                    return true;
                });
            
            var view = front.Director.Activate(new PersonViewModel());
            if (view != null) {
                var window = front.WindowPool.One<EPII.UI.WPF.Window>();
                window.View = view;
                window.Open();
            } else {
                MessageBox.Show("null view");
                App.Current.Shutdown();
            }
        }
    }
}
