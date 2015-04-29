namespace EPII
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class TypeEx
    {
        private Type _Type;

        /// <summary>
        /// get core type
        /// </summary>
        public Type Type
        {
            get { return _Type; }
        }

        /// <summary>
        /// get path for assembly with type
        /// </summary>
        public string Path
        {
            get { return _Type.Assembly.Location; }
        }

        public TypeEx(Type type)
        {
            _Type = type;
        }

        /// <summary>
        /// test if type implemented target
        /// </summary>
        public bool HasInterface(Type target)
        {
            var temp = _Type.GetInterface(target.Name);
            return temp == target;
        }

        /// <summary>
        /// test if type inherited from target
        /// </summary>
        public bool HasBaseType(Type target)
        {
            var temp = _Type;
            while (temp != null && temp != target)
                temp = temp.BaseType;
            return temp != null;
        }

        /// <summary>
        /// get types derived from type in assembly
        /// </summary>
        public IEnumerable<Type> GetDerivedTypes(Assembly assembly)
        {
            var types = assembly.GetTypes();
            foreach (var type in types) {
                var typex = new TypeEx(type);
                if (typex.HasInterface(_Type))
                    yield return type;
                if (typex.HasBaseType(_Type))
                    yield return type;
            }
        }
    }
}