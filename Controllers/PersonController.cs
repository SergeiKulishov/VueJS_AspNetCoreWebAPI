using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        [HttpGet]
        [Route("{id:int}")]
        public Person GetById(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public string CreatePerson(string name, string[] organization)
        {
            Person person = new Person(name, organization);
            _repository.Add(person);
            return $"Object has created id={person.Id}, Name = {person.Name}, Org = {person.OrganizationsToString()}";
        }
        
        [HttpPut]
        public string UpdatePerson(int id, string newName, string[] newOrganization)
        {
            Person personToUpdate = new Person(newName,newOrganization,id);
            _repository.Update(personToUpdate);
            return
                $"Object has updated id={personToUpdate.Id}, Name = {personToUpdate.Name}, Org = {personToUpdate.OrganizationsToString()}"; 
        } 
        [HttpDelete]
        public string DeletePerson(int id)
        {
            _repository.Delete(id);
            return $"Object has removed id={id}";
        }

    }
}


