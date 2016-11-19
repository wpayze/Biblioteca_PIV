using System.Collections.Generic;

namespace Biblioteca.Data.Modelos
{
    public class Libro
    {
        public Libro()
        {
            this.Autores = new List<Autor>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public Editorial Editorial { get; set; }

        public IList<Autor> Autores { get; set; }

        public void AgregarAutor(Autor nuevoAutor)
        {
            this.Autores.Add(nuevoAutor);
        }
    }
}
