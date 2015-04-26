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
            var fea = runtime.Use<FEA.FEAModel>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new TestView1();
            fea.ViewHub.Add("test", view);
            
            var window = fea.WindowPool.GetWindow();
            window.View = view;
            window.Open();

            Application.Run();
        }
    }
}
