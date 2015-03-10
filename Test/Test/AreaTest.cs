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
            var data = area.GetDataContext("EF");
            data.Setup();
            data.Reset();
        }

        public void GetHandler() 
        {
            var runtime = Runtime.Instance;
            var areas = runtime.Use<AreaModel>().AreaHub;
            var area = areas["Identity"];
            var user_handler = area.GetHandler("User");
            var data = user_handler.X("Login", new { username = "test", password = "test" });
        }
    }
}
