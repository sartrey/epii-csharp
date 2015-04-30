namespace EPII.Front
{
    using System;
    using System.Reflection;

    public partial class Startup
    {
        public void SearchViews(Assembly assembly) 
        {
            Director.SearchViews(assembly);
        }
    }
}
