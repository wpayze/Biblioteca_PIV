using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Biblioteca.Data.Modelos;

namespace Biblioteca.Data
{
    public class BibliotecaContext: DbContext
    {
        public DbSet<Libro> Libro { get; set; }
    }
}
