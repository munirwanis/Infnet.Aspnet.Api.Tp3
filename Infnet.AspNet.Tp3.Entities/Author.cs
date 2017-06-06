using System.Collections.Generic;

namespace Infnet.AspNet.Tp3.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual IList<Book> Books { get; set; }
    }
}
