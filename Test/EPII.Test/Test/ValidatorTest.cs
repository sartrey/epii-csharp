using EPII.Data;
using System;

namespace EPII.Test
{
    public class ValidatorTest : Test
    {
        public override string Id
        {
            get { return "validator"; }
        }

        public override void Prepare()
        {
            AddAction(TestNotNull);
        }

        public void TestNotNull()
        {
            new Guard<string>("test").NotNull();
            Console.WriteLine("pass");
            new Guard<string>(null).NotNull();
            Console.WriteLine("not pass");
        }
    }
}
