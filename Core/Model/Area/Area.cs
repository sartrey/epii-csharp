using System;
using System.Collections.Generic;
using System.Linq;

namespace EPII.Area
{
    public abstract class Area
    {
        protected Site[] _Sites = null;
        protected Table<object> _Shares 
            = new Table<object>();

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public Table<object> Shares 
        {
            get { return _Shares; }
        }

        public Area() 
        {
            CreateSites();
        }

        public Site GetSite(string name)
        {
            return _Sites.FirstOrDefault(
                (e) => { return e.Name == name; });
        }

        protected void CreateSites() 
        {
            var assembly = GetType().Assembly;
            var types = assembly.GetTypes();
            var sites = new List<Site>();
            foreach (var type in types) {
                if (type.BaseType == typeof(Site)) {
                    var site = (Site)Activator.CreateInstance(type);
                    site.CacheHandlers();
                    sites.Add(site);
                }
            }
            _Sites = sites.ToArray();
        }

        internal DataContext[] CreateDataContexts()
        {
            var assembly = GetType().Assembly;
            var types = assembly.GetTypes();
            var contexts = new List<DataContext>();
            foreach (var type in types) {
                if (type.BaseType == typeof(DataContext))
                    contexts.Add(
                        (DataContext)Activator.CreateInstance(type));
            }
            return contexts.ToArray();
        }
    }
}