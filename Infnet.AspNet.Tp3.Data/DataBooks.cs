using Infnet.AspNet.Tp3.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infnet.AspNet.Tp3.Data
{
    public class DataBooks : IData<Book>
    {
        public bool Delete(int id)
        {
            using (var db = new DataContext())
            {
                var book = db.Books.Find(id);
                if (book == null) { return false; }
                db.Books.Remove(book);
                return db.SaveChanges() > 0;
            }
        }

        public Book Get(int id)
        {
            using (var db = new DataContext())
            {
                var book = db.Books.Find(id);
                return book;
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Books.ToList();
            }
        }

        public bool Insert(Book entry)
        {
            using (var db = new DataContext())
            {
                db.Books.Add(entry);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(int id, Book entry)
        {
            using (var db = new DataContext())
            {
                db.Books.Attach(entry);
                db.Entry(entry).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
