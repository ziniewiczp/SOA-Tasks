using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectsManager.Model;

namespace WebApplication1.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>
            {
                new Book() {BookTitle = "Ogniem i mieczem", ISBN = "12345"},
                new Book() {BookTitle = "Potop", ISBN = "54321"}

            };
            books.ForEach(i => context.Books.Add(i));
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author() {AuthorName = "Adam", AuthorSurname = "Mickiewicz"},
                new Author() {AuthorName = "Henryk", AuthorSurname = "Sienkiewicz"}
            };
            authors.ForEach(g => context.Authors.Add(g));
            context.SaveChanges();
        }
    }
}