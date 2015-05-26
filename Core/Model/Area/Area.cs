using System;
using System.Collections.Generic;

namespace EPII.Area
{
    public abstract class Area
    {
        private Service[] services_ = null;
        private Table<object> shares_ = null;

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public Area()
        {
            CreateServices();
            CreateShares();
        }

        private void CreateServices()
        {
            var assembly = GetType().Assembly;
            var types = assembly.GetTypes();
            var services = new List<Service>();
            foreach (var type in types) {
                if (type.BaseType == typeof(Service))
                    services.Add((Service)
                        Activator.CreateInstance(type, this));
            }
            services_ = services.ToArray();
        }

        private void CreateShares()
        {
            shares_ = new Table<object>();
            UseShares(shares_);
        }

        /// <summary>
        /// used to fill shares
        /// </summary>
        protected abstract void UseShares(Table<object> shares);

        public Service GetService(string name)
        {
            foreach (var service in services_) {
                var type = service.GetType();
                var fullname = name + "Service";
                if (type.Name == fullname)
                    return service;
            }
            return null;
        }

        public Service GetService<T>()
        {
            foreach (var service in services_) {
                if (typeof(T).IsInstanceOfType(service))
                    return service;
            }
            return null;
        }

        public object GetShare(string key)
        {
            return shares_[key];
        }

        public abstract DataAccess[] CreateDataAccesses();
    }
}