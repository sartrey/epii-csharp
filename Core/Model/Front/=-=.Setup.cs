namespace EPII.Front
{
    using System;
    using System.Reflection;

    public partial class Startup
    {
        public void SearchAllViews() 
        {
            var domain = AppDomain.CurrentDomain;
            var assemblies = domain.GetAssemblies();
            foreach (var assembly in assemblies) {
                Director.SearchViews(assembly);
            }
        }
    }
}
