using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Configuration;

namespace Biblioteca.Host.Controllers
{
    public class LibroController : ApiController
    {
        BibliotecaContext bibliotecaContext = new BibliotecaContext(WebConfigurationManager.AppSettings["connectionStringParaUsar"]);

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibliotecaContext.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: api/Libro
        public IEnumerable<Libro> Get()
        {
            return bibliotecaContext.Libros;
        }

        // GET: api/Libro/5
        [ResponseType(typeof(Libro))]
        public IHttpActionResult Get(int id)
        {
            var libro = bibliotecaContext.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(libro);
            }
        }

        [Route("api/Libro/{idLibro}/editorial/{idEditorial}")]
        [HttpPut]
        [ResponseType(typeof(Libro))]
        public IHttpActionResult AgregarEditorial(int idLibro, int idEditorial)
        {
            var libro = bibliotecaContext.Libros.Find(idLibro);
            var editorial = bibliotecaContext.Editoriales.Find(idEditorial);

            if (libro == null || editorial == null)
            {
                return NotFound();
            }

            libro.Editorial = editorial;
            bibliotecaContext.Entry(libro).State = 
                EntityState.Modified;

            return Ok(libro);
        }

        // POST: api/Libro
        [ResponseType(typeof(Libro))]
        public IHttpActionResult Post(Libro nuevoLibro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bibliotecaContext.Libros.Add(nuevoLibro);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoLibro);
        }

        // PUT: api/Libro/5
        [ResponseType(typeof(Libro))]
        public IHttpActionResult Put(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest(ModelState);
            }

            bibliotecaContext.Entry(libro).State =
                EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(libro);
        }

        [ResponseType(typeof(Libro))]
        [HttpPut]
        [Route("api/Libro/{idLibro}/Autor/{idAutor}")]
        public IHttpActionResult AgregarLibro(int idLibro, int idAutor)
        {
            var autor = bibliotecaContext.Autores.Find(idAutor);
            var libro = bibliotecaContext.Libros.Find(idLibro);

            if (autor == null || libro == null)
            {
                return NotFound();
            }

            libro.AgregarAutor(autor);

            bibliotecaContext.Entry(libro).State =
                EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(libro);
        }

        // DELETE: api/Libro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var libro =
                bibliotecaContext.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            bibliotecaContext.Libros.Remove(libro);
            bibliotecaContext.SaveChanges();
            return Ok();
        }
    }
}
