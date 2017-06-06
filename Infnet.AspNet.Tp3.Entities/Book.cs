using System.Collections.Generic;

namespace Infnet.AspNet.Tp3.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Isbn { get; set; }

        public string Title { get; set; }

        public virtual IList<Author> Authors { get; set; }
    }
}
