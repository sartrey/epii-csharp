using EPII.Code;

namespace EPII.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var stc = new STC();
            var luc = new LUC();
            /*
            for (int i = 0; i < 20; i++)
            {
                var v = luc.Next();
                Console.WriteLine("");
                Console.WriteLine(v);
                Console.WriteLine(LUC.Safe62ToDec(v));
                Console.WriteLine(LUC.DecToSafe62(LUC.Safe62ToDec(v)));
            }
            */

            /*
            var strs1 = new List<string>();
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 50000; i++)
                strs1.Add(luc.Next());
            watch.Stop();
            Console.WriteLine("time(ms):" + watch.ElapsedMilliseconds);
            
            var strs2 = new List<string>();
            foreach(var s in strs1)
            {
                if (strs2.Contains(s))
                    continue;
                strs2.Add(s);
            }
            Console.WriteLine("repeat:" + (strs1.Count - strs2.Count));
            */
        }
    }
}