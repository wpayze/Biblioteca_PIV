using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Http.Description;

namespace Biblioteca.Host.Controllers
{
    public class LibroController : ApiController
    {
        BibliotecaContext bibliotecaContext = new BibliotecaContext("BibliotecaMaestro");

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibliotecaContext.Dispose();
            }

            base.Dispose(disposing);
        }
        
        // GET: api/Libro
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Libro/5
        public string Get(int id)
        {
            return "value";
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
            bibliotecaContext.Entry(libro).State = System.Data.Entity.EntityState.Modified;

            return Ok(libro);
        }

        [ResponseType(typeof(Libro))]
        // POST: api/Libro
        public IHttpActionResult Post(Libro nuevoLibro)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            bibliotecaContext.Libros.Add(nuevoLibro);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoLibro);
        }

        // PUT: api/Libro/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Libro/5
        public void Delete(int id)
        {
        }
    }
}
