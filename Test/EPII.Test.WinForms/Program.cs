using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var runtime = Runtime.Instance;
            var ui = runtime.Use<UI.UIModel>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var window = ui.WindowPool.GetWindow();
            var view = new TestView1();
            ui.ViewHub.Add("test", view);
            window.View = view;
            window.Show();

            Application.Run();
        }
    }
}
