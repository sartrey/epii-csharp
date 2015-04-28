using System;
using System.Collections.Generic;

namespace EPII.Test.Data
{
    public class FakeDataSource
    {
        private List<Person> _Persons 
            = new List<Person>();

        public List<Person> Persons
        {
            get { return _Persons; }
        }

        public FakeDataSource()
        {
            _Persons.Add(new Person("Ayaya", new DateTime(2000, 12, 31)));
            _Persons.Add(new Person("Bruno", new DateTime(1995, 10, 15)));
            _Persons.Add(new Person("Candy", new DateTime(2003, 8, 25)));
            _Persons.Add(new Person("Danto", new DateTime(1997, 7, 13)));
            _Persons.Add(new Person("Evonu", new DateTime(2001, 9, 8)));
        }
    }
}
