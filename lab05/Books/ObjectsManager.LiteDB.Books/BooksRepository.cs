using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Model;
using ObjectsManager.LiteDB.Books.Model;
using ObjectsManager.Interfaces.Books;

namespace ObjectsManager.LiteDB.Books
{
    public class BooksRepository : IBooksRepository
    {
        private readonly string _booksConnection = DatabaseConnections.BookConnection;

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<BookDB>("book");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Book book)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var dbObject = InverseMap(book);


                var repository = db.GetCollection<BookDB>("book");
                repository.Insert(dbObject);

                return dbObject.ID;
            }
        }

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<BookDB>("book");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Book> Get(string query)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<BookDB>("book");
                var results = repository.Find(x => x.BookTitle.Contains(query));
                return results.Select(x => Map(x)).ToList(); ;
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var dbObject = InverseMap(book);

                var repository = db.GetCollection<BookDB>("book");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._booksConnection))
            {
                var repository = db.GetCollection<BookDB>("book");
                return repository.Delete(id);
            }
        }

        private Book Map(BookDB dbBook)
        {
            if (dbBook == null)
                return null;

            return new Book() { ID = dbBook.ID, BookTitle = dbBook.BookTitle, ISBN = dbBook.ISBN };
        }

        private BookDB InverseMap(Book book)
        {
            if (book == null)
                return null;
            return new BookDB()
            {
                ID = book.ID,
                BookTitle = book.BookTitle,
                ISBN = book.ISBN
            };
        }
    }
}

