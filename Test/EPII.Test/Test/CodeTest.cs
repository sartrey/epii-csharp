using EPII.Code;
using System;
using System.Collections.Generic;

namespace EPII.Test
{
    public class CodeTest : Test
    {
        public override string Id 
        {
            get { return "code"; }
        }

        public override void Prepare()
        {
            AddAction(MakeLUC);
            AddAction(RepeatLUC);
        }

        public void MakeLUC() 
        {
            var luc = new LUC();
            for (int i = 0; i < 20; i++) {
                var v = luc.Next();
                Console.WriteLine(
                    v + " " + LUC.Safe62ToDec(v) + " " + 
                    LUC.DecToSafe62(LUC.Safe62ToDec(v)));
            }
        }

        public void RepeatLUC() 
        {
            var luc = new LUC();
            var strs1 = new List<string>();
            for (int i = 0; i < 50000; i++)
                strs1.Add(luc.Next());

            var strs2 = new List<string>();
            foreach (var s in strs1) {
                if (strs2.Contains(s))
                    continue;
                strs2.Add(s);
            }
            Console.WriteLine("repeat:" + (strs1.Count - strs2.Count));
        }
    }
}
