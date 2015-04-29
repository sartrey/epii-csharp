using System;
using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var runtime = Runtime.Instance;
            var front = runtime.Use<Front.Startup>(
                startup => {
                    startup.SearchAllViews();
                    return true;
                });

            var view = front.Director.Activate(new PersonViewModel());
            if (view != null) {
                var window = front.WindowPool.One<EPII.UI.WinForms.Window>();
                window.View = view;
                window.Open();
                Application.Run();
            } else {
                MessageBox.Show("null view");
            }
        }
    }
}
