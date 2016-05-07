using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces.Books
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        List<Book> Get(string query);
        int Add(Book book);
        Book Get(int id);
        Book Update(Book book);
        bool Delete(int id);
    }
}
