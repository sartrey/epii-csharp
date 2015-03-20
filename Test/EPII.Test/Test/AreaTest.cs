using EPII.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.Test
{
    public class AreaTest : Test
    {
        public override string Id
        {
            get { return "area"; }
        }

        public override void Prepare()
        {
            //AddAction(SetupData);
            //AddAction(GetHandler);
        }

        public void SetupData()
        {
            var runtime = Runtime.Instance;
            var areas = runtime.Use<AreaModel>().AreaHub;
            var area = areas["Identity"];
            var context = AreaContext.GetCurrentContext(area);
            var data = context.GetDataAccess("EntityFramework");
            data.Install();
            data.Uninstall();
        }

        public void GetHandler()
        {
            var runtime = Runtime.Instance;
            var areas = runtime.Use<AreaModel>().AreaHub;
            var area = areas["Identity"];
            var user_service = area.GetService("User");
            //var user_service = area.GetService<IUserService>();
            var data = user_service.X("Login",
                new { username = "test", password = "test" });
        }
    }
}