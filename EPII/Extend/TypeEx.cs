using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPII
{
    public class TypeEx
    {
        private Type _Root;

        /// <summary>
        /// get root type
        /// </summary>
        public Type Root 
        {
            get { return _Root; }
        }

        /// <summary>
        /// get path for assembly with type
        /// </summary>
        public string Path 
        {
            get { return _Root.Assembly.Location; }
        }

        public TypeEx(Type root)
        {
            _Root = root;
        }

        /// <summary>
        /// test if root implemented target
        /// </summary>
        public bool HasInterface(Type target)
        {
            var temp = _Root.GetInterface(target.Name);
            return temp == target;
        }

        /// <summary>
        /// test if root is derived from target
        /// </summary>
        public bool HasBaseType(Type target)
        {
            var temp = _Root;
            while (temp != null && temp != target)
                temp = temp.BaseType;
            return temp != null;
        }

        /// <summary>
        /// get types derived from root
        /// </summary>
        public IEnumerable<Type> GetDerivedTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var typex = new TypeEx(type);
                if (typex.HasInterface(_Root))
                    yield return type;
                if (typex.HasBaseType(_Root))
                    yield return type;
            }
        }
    }
}
