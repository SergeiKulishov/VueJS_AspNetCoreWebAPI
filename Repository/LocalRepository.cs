using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJS_AspNetCoreWebAPI.Repository
{
    public class LocalRepository : IPersonRepository
    {
        public void AddAsync(Person person)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
                Console.WriteLine($"Object has added with ID = {person.Id}!");
            }
        }

        public void Delete(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Person personToDelete = db.Persons.Find(id);
                db.Persons.Remove(personToDelete);
                db.SaveChanges();
            }
            Console.WriteLine($"Object with ID = {id} has removed!");
        }

        public void Update(Person person)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                db.Persons.Update(person);
                db.SaveChanges();
            }
            Console.WriteLine($"Object with ID = {person.Id} has updated!");

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

        public Person GetById(int personId)
        {
            Person personToGet;
            using (ApplicationContext db = new ApplicationContext())
            {
                personToGet = db.Persons.Find(personId);
            }

            return personToGet;
        }
    }
}
