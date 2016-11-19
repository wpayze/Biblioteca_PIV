using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Configuration;

namespace Biblioteca.Host.Controllers
{
    public class AutorController : ApiController
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

        // GET: api/Autor
        public IEnumerable<Autor> Get()
        {
            return bibliotecaContext.Autores;
        }

        // GET: api/Autor/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Get(int id)
        {
            var autor = bibliotecaContext.Autores.Find(id);
            if (autor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(autor);
            }
        }

        // POST: api/Autor
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Post(Autor nuevoAutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bibliotecaContext.Autores.Add(nuevoAutor);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoAutor);
        }

        // PUT: api/Autor/5
        [ResponseType(typeof(Autor))]
        public IHttpActionResult Put(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest(ModelState);
            }

            bibliotecaContext.Entry(autor).State =
                EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(autor);
        }

        [ResponseType(typeof(Autor))]
        [HttpPut]
        [Route("api/Autor/{idAutor}/Libro/{idLibro}")]
        public IHttpActionResult AgregarLibro(int idAutor, int idLibro)
        {
            var autor = bibliotecaContext.Autores.Find(idAutor);
            var libro = bibliotecaContext.Libros.Find(idLibro);

            if (autor == null || libro == null)
            {
                return NotFound();
            }

            autor.AgregarLibro(libro);

            bibliotecaContext.Entry(autor).State =
                EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(autor);
        }

        // DELETE: api/Autor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var Autor =
                bibliotecaContext.Autores.Find(id);
            if (Autor == null)
            {
                return NotFound();
            }

            bibliotecaContext.Autores.Remove(Autor);
            bibliotecaContext.SaveChanges();
            return Ok();
        }
    }
}
