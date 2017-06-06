using Infnet.AspNet.Tp3.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infnet.AspNet.Tp3.Data
{
    internal class DataContext : DbContext
    {
        internal DataContext() : base("DefaultConnection") { }

        internal DbSet<Author> Authors { get; set; }

        internal DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
