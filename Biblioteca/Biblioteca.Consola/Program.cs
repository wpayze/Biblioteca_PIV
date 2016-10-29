using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;

namespace Biblioteca.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BibliotecaContext("BibliotecaMaestro"))
            {
                var nuevoLibro = new Libro();
                nuevoLibro.Nombre = "Libro de Wilfredo";
                nuevoLibro.Año = 2016;
                context.Libros.Add(nuevoLibro);
                context.SaveChanges();

                Console.WriteLine("Hola Mundo");
                Console.ReadKey();
            }
        }
    }
}
