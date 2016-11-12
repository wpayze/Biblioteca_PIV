using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Nacionalidad { get; set; }

        public IList<Libro> Libros { get; set; }

        public void AgregarLibro(Libro nuevoLibro)
        {
            this.Libros.Add(nuevoLibro);
        }
    }
}
