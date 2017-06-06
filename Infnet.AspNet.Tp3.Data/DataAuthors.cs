using Infnet.AspNet.Tp3.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infnet.AspNet.Tp3.Data
{
    public class DataAuthors : IData<Author>
    {
        public bool Delete(int id)
        {
            using (var db = new DataContext())
            {
                var author = db.Authors.Find(id);
                if (author == null) { return false; }
                db.Authors.Remove(author);
                return db.SaveChanges() > 0;
            }
        }

        public Author Get(int id)
        {
            using (var db = new DataContext())
            {
                var author = db.Authors.Find(id);
                return author;
            }
        }

        public List<Author> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Authors.ToList();
            }
        }

        public bool Insert(Author entry)
        {
            using (var db = new DataContext())
            {
                db.Authors.Add(entry);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(int id, Author entry)
        {
            using (var db = new DataContext())
            {
                db.Authors.Attach(entry);
                db.Entry(entry).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
