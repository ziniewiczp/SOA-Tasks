using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Model;
using ObjectsManager.LiteDB.ReviewPerson.Model;
using ObjectsManager.Intefaces.RevPer;

namespace ObjectsManager.LiteDB.ReviewPerson
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _personConnection = DatabaseConnections.PersonConnection;
        public List<Person> GetAll()
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("persons");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Person person)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var dbObject = InverseMap(person);

                var repository = db.GetCollection<PersonDB>("authors");
                if (repository.FindById(person.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Person Get(int id)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("authors");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Person Update(Person person)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var dbObject = InverseMap(person);

                var repository = db.GetCollection<PersonDB>("persons");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("persons");
                return repository.Delete(id);
            }
        }

        internal List<PersonDB> GetPersons(int[] ids)
        {
            using (var db = new LiteDatabase(this._personConnection))
            {
                var repository = db.GetCollection<PersonDB>("persons");
                var results = repository.FindAll().Where(x => ids.Contains(x.Id));

                return results.ToList();
            }
        }

        internal Person Map(PersonDB dbPerson)
        {
            if (dbPerson == null)
                return null;
            return new Person() { Id = dbPerson.Id, Name = dbPerson.Name, Surname = dbPerson.Surname };
        }

        internal PersonDB InverseMap(Person person)
        {
            if (person == null)
                return null;
            return new PersonDB() { Id = person.Id, Name = person.Name, Surname = person.Surname };
        }
    }
}
