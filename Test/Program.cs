using EPII.Code;

namespace EPII.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            //runner.Push(new CodeTest());
            runner.Push(new AreaTest());
            runner.Run();
        }
    }
}