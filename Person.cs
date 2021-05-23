using System;

namespace VueJS_AspNetCoreWebAPI
{
    public class Person
    {
        public Person(string name,string organization, int id = 0)
        {
            Id = id;
            Name = name;
            Organization = organization;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Organization { get; set; }
    }
}
