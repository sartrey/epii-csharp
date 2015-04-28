using System;

namespace EPII.Test.Data
{
    public class Person
    {
        private string _Name;
        private DateTime _Birth;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime Birth
        {
            get { return _Birth; }
            set { _Birth = value; }
        }

        public Person(string name, DateTime birth)
        {
            _Name = name;
            _Birth = birth;
        }
    }
}
