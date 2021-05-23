using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJS_AspNetCoreWebAPI.Repository;

namespace VueJS_AspNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository personRepository)
        {
            _repository = personRepository;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            IEnumerable<Person> persons = _repository.GetAll();
            return persons;
        }

        [HttpGet("id")]
        public Person GetById(int id)
        {
            return _repository.GetById(id);
        }


        [HttpPost]
        public string CreatePerson(string name, string organization)
        {
            Person person = new Person(name, organization);
            _repository.Add(person);
            return $"Объект создан id={person.Id}, Name = {person.Name}, Org = {person.Organization}";
        }


        [HttpDelete]
        public string DeletePerson(int id)
        {
            _repository.Delete(id);
            return $"Объект удален id={id}";
        }

    }
}


