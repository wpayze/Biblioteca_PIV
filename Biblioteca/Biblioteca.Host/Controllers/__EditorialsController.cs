using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;

namespace Biblioteca.Host.Controllers
{
    public class __EditorialsController : ApiController
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: api/Editorials
        public IQueryable<Editorial> GetEditoriales()
        {
            return db.Editoriales;
        }

        // GET: api/Editorials/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult GetEditorial(int id)
        {
            Editorial editorial = db.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            return Ok(editorial);
        }

        // PUT: api/Editorials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEditorial(int id, Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editorial.Id)
            {
                return BadRequest();
            }

            db.Entry(editorial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Editorials
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult PostEditorial(Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Editoriales.Add(editorial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = editorial.Id }, editorial);
        }

        // DELETE: api/Editorials/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult DeleteEditorial(int id)
        {
            Editorial editorial = db.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            db.Editoriales.Remove(editorial);
            db.SaveChanges();

            return Ok(editorial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditorialExists(int id)
        {
            return db.Editoriales.Count(e => e.Id == id) > 0;
        }
    }
}