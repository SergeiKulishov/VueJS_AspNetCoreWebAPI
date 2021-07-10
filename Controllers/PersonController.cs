using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public string CreatePerson(PersonData data)
        {
            try
            {
                Person person = new Person(data.Name,data.Organizations);
                _repository.AddAsync(person);
                return $"Object has created id={person.Id}, Name = {person.Name}, Org = {person.OrganizationsToString()}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Something went wrong with creating";
            }
            
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public string UpdatePerson(int id, PersonData newdata)
        {
            try
            {
                Person personToUpdate = new Person(newdata.Name, newdata.Organizations, id);
                _repository.Update(personToUpdate);
                return
                    $"Object has updated id={personToUpdate.Id}, Name = {personToUpdate.Name}, Org = {personToUpdate.OrganizationsToString()}"; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Something went wrong with updating";

            }
            
        } 
        [HttpDelete]
        [Route("{id:int}")]
        public string DeletePerson(int id)
        {
            _repository.Delete(id);
            return $"Object has removed id={id}";
        }

    }
}


