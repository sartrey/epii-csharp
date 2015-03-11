using EPII.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.Test
{
    public class ReflectionTest : Test
    {
        public override string Id
        {
            get { return "reflection"; }
        }

        public override void Prepare()
        {
            AddAction(ReflectMethod);
        }

        public void ReflectMethod() 
        {
            var methods = GetType().GetMethods();
            foreach (var method in methods) {
                Console.WriteLine("method:" + method.Name);
                Console.WriteLine("return:" + method.ReturnType.ToString());
                var para_text = "";
                var paras = method.GetParameters();
                foreach (var para in paras) {
                    para_text += para.ParameterType.ToString() + " ";
                }
                Console.WriteLine("parameters:" + para_text);
                Console.WriteLine();
                try {
                    Delegate.CreateDelegate(typeof(Action), method);
                } catch {
                    continue;
                }
            }
        }

        public dynamic TestMethod(DataContext context, dynamic data) 
        {
            return null;
        }
    }
}
