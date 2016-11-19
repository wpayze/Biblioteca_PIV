using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Configuration;

namespace Biblioteca.Host.Controllers
{
    public class EditorialController : ApiController
    {
        BibliotecaContext bibliotecaContext =
            new BibliotecaContext(WebConfigurationManager.AppSettings["connectionStringParaUsar"]);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibliotecaContext.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: api/Editorial
        public IEnumerable<Editorial> Get()
        {
            return bibliotecaContext.Editoriales;
        }

        // GET: api/Editorial/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Get(int id)
        {
            var editorial = bibliotecaContext.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(editorial);
            }
        }

        // POST: api/Editorial
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Post(Editorial nuevoEditorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bibliotecaContext.Editoriales.Add(nuevoEditorial);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoEditorial);
        }

        // PUT: api/Editorial/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Put(int id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
                return BadRequest(ModelState);
            }

            bibliotecaContext.Entry(editorial).State = 
                EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(editorial);
        }

        // DELETE: api/Editorial/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var editorial = 
                bibliotecaContext.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            bibliotecaContext.Editoriales.Remove(editorial);
            bibliotecaContext.SaveChanges();
            return Ok();
        }
    }
}
