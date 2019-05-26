using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class PersonFactory
    {
        private int count = 0;

        public PersonFactory()
        {

        }

        public Person CreatePerson(string name)
        {
            Person person = new Person(count, name);
            count += 1;
            return person;
        }
    }
}
