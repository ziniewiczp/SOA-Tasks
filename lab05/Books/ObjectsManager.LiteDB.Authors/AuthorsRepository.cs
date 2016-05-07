using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Model;
using ObjectsManager.LiteDB.Authors.Model;
using ObjectsManager.Interfaces.Authors;

namespace ObjectsManager.LiteDB.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly string _authorsConnection = DatabaseConnections.AuthorConnection;

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<AuthorDB>("author");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var dbObject = InverseMap(author);


                var repository = db.GetCollection<AuthorDB>("author");
                repository.Insert(dbObject);

                return dbObject.ID;
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Author Update(Author author)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var dbObject = InverseMap(author);

                var repository = db.GetCollection<AuthorDB>("author");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._authorsConnection))
            {
                var repository = db.GetCollection<AuthorDB>("author");
                return repository.Delete(id);
            }
        }

        private Author Map(AuthorDB dbAuthor)
        {
            if (dbAuthor == null)
                return null;

            return new Author() { ID = dbAuthor.ID, AuthorName = dbAuthor.AuthorName, AuthorSurname = dbAuthor.AuthorSurname };
        }

        private AuthorDB InverseMap(Author author)
        {
            if (author == null)
                return null;
            return new AuthorDB()
            {
                ID = author.ID,
                AuthorName = author.AuthorName,
                AuthorSurname = author.AuthorSurname
            };
        }
    }
}

