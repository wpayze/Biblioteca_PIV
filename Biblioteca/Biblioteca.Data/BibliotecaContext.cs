using System.Data.Entity;
using Biblioteca.Data.Modelos;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Biblioteca.Data
{
    public class BibliotecaContext: DbContext
    {
        public BibliotecaContext() { }
        public BibliotecaContext(string ConnectionName):base(ConnectionName)
        {

        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
