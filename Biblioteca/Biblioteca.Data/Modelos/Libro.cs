using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Año { get; set; }

        public Editorial Editorial { get; set; }
    }
}
