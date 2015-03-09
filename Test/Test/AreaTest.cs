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
            AddAction(GetArea);
        }

        public void GetArea() 
        {
            var runtime = Runtime.Instance;
            var areas = runtime.Use<AreaModel>();
            var area = areas["Identity"];
            var data = area.GetDataContext("EF");
            data.Setup();
            var user_handler = area.GetHandler("User");
            user_handler.X("Login", "{username}", "{password}");
        }
    }
}
