using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJS_AspNetCoreWebAPI.Repository.ADORepository
{
    public class ADORepository : IPersonRepository
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TESTADODB;Trusted_Connection=True;";
        string sqlInsertPersonExpression = "INSERT INTO Persons (name, organizations) VALUES (@name, @organizations)";
        string sqlUpdatePersonExpression = "UPDATE Persons SET name=@name, organizations=@organizations WHERE id=@id";
        string sqlDeletePersonExpression = "DELETE FROM Persons WHERE id=@id";
        string sqlSelectPersonByIdExpression = "SELECT id, name, organizations FROM Persons WHERE id=@id";
        string sqlGetAllPersonExpression = "SELECT * FROM Persons";

        public async void AddAsync(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlInsertPersonExpression, connection);

                SqlParameter nameParam = new SqlParameter("@name", person.Name);
                command.Parameters.Add(nameParam);
                SqlParameter orgParam = new SqlParameter("@organizations", person.OrganizationsToString());
                command.Parameters.Add(orgParam);

                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Objects has added: {number}");
            }
        }

        public async void Update(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlUpdatePersonExpression, connection);

                SqlParameter nameParam = new SqlParameter("@name", person.Name);
                command.Parameters.Add(nameParam);
                SqlParameter orgParam = new SqlParameter("@organizations", person.OrganizationsToString());
                command.Parameters.Add(orgParam);
                SqlParameter idParam = new SqlParameter("@id", person.Id);
                command.Parameters.Add(idParam);


                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Objects has updated: {number}");
            }
        }
        public async void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlDeletePersonExpression, connection);

                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Objects has deleted: {number}");
            }
        }

        public  IEnumerable<Person> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Person> Persons = new List<Person>();

                SqlCommand command = new SqlCommand(sqlGetAllPersonExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    { 
                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            string name = (string)reader["name"];
                            string orgs = (string)reader["organizations"];

                            Persons.Add(new Person(name, orgs, id));
                            Console.WriteLine($"Id:{id} Name:{name} Org: {orgs}");
                        }
                    }
                }
                return Persons;
            }
        }

        public Person GetById(int personId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Person Person = new Person("","");

                SqlCommand command = new SqlCommand(sqlSelectPersonByIdExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", personId);
                command.Parameters.Add(idParam);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            string name = (string)reader["name"];
                            string orgs = (string)reader["organizations"];

                            Console.WriteLine($"Id:{id} Name:{name} Org: {orgs}");
                            Person = new Person(name, orgs, id);

                            return Person;

                        }
                    }
                }
                return Person;
            }
        }

        
    }
}
