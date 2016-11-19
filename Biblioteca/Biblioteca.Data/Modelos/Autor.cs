using System.Collections.Generic;

namespace Biblioteca.Data.Modelos
{
    public class Autor
    {
        public Autor()
        {
            this.Libros = new List<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public IList<Libro> Libros { get; set; }

        public void AgregarLibro(Libro nuevoLibro)
        {
            this.Libros.Add(nuevoLibro);
        }
    }
}
