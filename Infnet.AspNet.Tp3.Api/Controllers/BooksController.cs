using Infnet.AspNet.Tp3.Data;
using Infnet.AspNet.Tp3.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Infnet.AspNet.Tp3.Api.Controllers
{
    public class BooksController : ApiController
    {
        private DataBooks DbBook { get; } = new DataBooks();

        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return DbBook.GetAll();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Get(int id)
        {
            var book = DbBook.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult Post([FromBody]Book book)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var success = DbBook.Insert(book);

            if (!success) { return BadRequest(); }

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                var success = DbBook.Update(id, book);
                if (success)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Delete(int id)
        {
            var success = DbBook.Delete(id);
            if (!success) { return NotFound(); }

            return Ok(success);
        }
    }
}
