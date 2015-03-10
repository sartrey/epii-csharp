using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EPII.Test
{
    public class Runner
    {
        private List<Test> _Tests = new List<Test>();

        public void Push(Test test)
        {
            test.Prepare();
            _Tests.Add(test);
        }

        public void Run(int loop = 1)
        {
            foreach (var test in _Tests) {
                test.Reset();
                while (test.HasNext()) {
                    try {
                        var watch = new Stopwatch();
                        watch.Start();
                        for (int i = 0; i < loop; i++)
                            test.Perform();
                        test.MoveNext();
                        watch.Stop();
                        Console.WriteLine(
                            string.Format(
                                "<elapsed time:{0}(ms)>",
                                    watch.ElapsedMilliseconds));
                    } catch (Exception ex) {
                        Console.WriteLine(
                            string.Format("<test error in {0}>:{1}",
                                test.Id, ex.Message));
                    }
                }
            }
        }
    }
}
