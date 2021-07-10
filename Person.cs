using System.Collections.Generic;
using System.Linq;

namespace VueJS_AspNetCoreWebAPI
{
    public class Person
    {
        public Person(string name, List<string> organizations, int id = 0)
        {
            Id = id;
            Name = name;
            Organizations = organizations;
        }

        public Person(string name, string organizations, int id = 0)
        {
            Id = id;
            Name = name;
            Organizations = organizations.Split(",").ToList();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Organizations { get; set; }

        public string OrganizationsToString()
        {
            var listOfOrgs = Organizations.Aggregate("", (current, org) => current + (org + ","));
            listOfOrgs = listOfOrgs.Remove(listOfOrgs.Length - 1);
            return listOfOrgs;
        }
    }
}
