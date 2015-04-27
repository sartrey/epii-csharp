using System;
using System.Collections.Generic;

namespace EPII.Area
{
    public abstract class Area
    {
        private Service[] _Services = null;
        private Table<object> _Shares = null;

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
            _Services = services.ToArray();
        }

        private void CreateShares()
        {
            _Shares = new Table<object>();
            UseShares(_Shares);
        }

        /// <summary>
        /// used to fill shares
        /// </summary>
        protected abstract void UseShares(Table<object> shares);

        public Service GetService(string name)
        {
            foreach (var service in _Services) {
                var type = service.GetType();
                var fullname = name + "Service";
                if (type.Name == fullname)
                    return service;
            }
            return null;
        }

        public Service GetService<T>()
        {
            foreach (var service in _Services) {
                if (typeof(T).IsInstanceOfType(service))
                    return service;
            }
            return null;
        }

        public object GetShare(string key)
        {
            return _Shares[key];
        }

        public abstract DataAccess[] CreateDataAccesses();
    }
}