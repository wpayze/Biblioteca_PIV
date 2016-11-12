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
    public class AutorController : ApiController
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

        [Route("api/Autor/{idAutor}/libro")]
        public IHttpActionResult AgregarLibro(int idAutor, Libro nuevoLibro)
        {
            Autor autor = bibliotecaContext.Autores.Find(idAutor);

            if (autor == null)
            {
                return NotFound();
            }

            autor.AgregarLibro(nuevoLibro);
            bibliotecaContext.SaveChanges();
            return Ok(autor);
        }

        // GET: api/Autor
        public IEnumerable<Autor> Get()
        {
            return bibliotecaContext.Autores;
        }

        // GET: api/Autor/5
        public IHttpActionResult Get(int id)
        {
            var autores = bibliotecaContext.Autores.Find(id);

            if (autores == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(autores);
            }
        }

        [ResponseType(typeof(Autor))]

        // POST: api/Autor
        public IHttpActionResult Post(Autor nuevoAutor)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
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
                BadRequest(ModelState);
            }

            bibliotecaContext.Entry(autor).State = System.Data.Entity.EntityState.Modified;
            bibliotecaContext.SaveChanges();

            return Ok(autor);
        }

        // DELETE: api/Autor/5
        public IHttpActionResult Delete(int id)
        {

            var autor = bibliotecaContext.Autores.Find(id);

            if (autor == null)
            {
                return NotFound();
            }

            bibliotecaContext.Autores.Remove(autor);
            bibliotecaContext.SaveChanges();
            return Ok();

        }
    }
}
