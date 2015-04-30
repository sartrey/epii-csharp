namespace EPII
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class TypeEx
    {
        /// <summary>
        /// get path for assembly with type
        /// </summary>
        public static string GetAssemblyPath(this Type type)
        {
            return type.Assembly.Location;
        }

        /// <summary>
        /// test if type implemented target
        /// </summary>
        public static bool HasInterface(this Type type, Type target)
        {
            var temp = type.GetInterface(target.Name);
            return temp == target;
        }

        /// <summary>
        /// test if type inherited from target
        /// </summary>
        public static bool HasBaseType(this Type type, Type target)
        {
            var temp = type;
            while (temp != null && temp != target)
                temp = temp.BaseType;
            return temp != null;
        }

        /// <summary>
        /// get types derived from type in assembly
        /// </summary>
        public static IEnumerable<Type> GetDerivedTypes(
            this Type type, Assembly assembly)
        {
            var types = assembly.GetTypes();
            if (type.IsInterface) {
                foreach (var t in types) {
                    if (t.HasInterface(type))
                        yield return t;
                }
            } else {
                foreach (var t in types) {
                    if (t.HasBaseType(type))
                        yield return t;
                }
            }
        }
    }
}