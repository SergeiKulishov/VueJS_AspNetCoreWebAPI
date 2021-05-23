using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJS_AspNetCoreWebAPI.Repository
{
    public class LocalRepository : IPersonRepository
    {
        public void Add(Person person)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
                Console.WriteLine("Object has added!");
            }
        }

        public void Delete(int Id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Person personToDelete = db.Persons.Find(Id);
                db.Persons.Remove(personToDelete);
                db.SaveChanges();
            }
            Console.WriteLine("Object has removed!");
        }

        public void Update(Person person)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                db.Persons.Update(person);
                db.SaveChanges();
            }
            Console.WriteLine("Object has updated!");

        }

        public IEnumerable<Person> GetAll()
        {
            List<Person> allPersons;

            using (ApplicationContext db = new ApplicationContext())
            {
                allPersons = db.Persons.ToList();
            }
            return allPersons;
        }

        public Person GetById(int PersonId)
        {
            List<Person> allPersons;

            using (ApplicationContext db = new ApplicationContext())
            {
                allPersons = db.Persons.ToList();
            }
            Person searchResult = allPersons.Find(p => p.Id == PersonId);

            return searchResult;
        }
    }
}
