using EPII.Code;
using System;

namespace EPII.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            //runner.Push(new CodeTest());
            //runner.Push(new DynDictTest());
            runner.Push(new ReflectionTest());
            runner.Run(1);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}