using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJS_AspNetCoreWebAPI.Repository
{
    public interface IPersonRepository
    {
        public void Add(Person person);

        public void Update(Person person);

        public void Delete(int id);

        public IEnumerable<Person> GetAll();

        public Person GetById(int personId);
    }
}
