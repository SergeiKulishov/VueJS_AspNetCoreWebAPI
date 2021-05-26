using System.Collections.Generic;
using System.Linq;

namespace VueJS_AspNetCoreWebAPI
{
    public class Person
    {
        public Person(string name, List<string> organization, int id = 0)
        {
            Id = id;
            Name = name;
            Organization = organization;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Organization { get; set; }

        public string OrganizationsToString()
        {
            string listOfOrgs;
            listOfOrgs = Organization.Aggregate("", (current, org) => current + (org + ","));
            listOfOrgs = listOfOrgs.Remove(listOfOrgs.Length - 1);
            return listOfOrgs;
        }
    }
}
