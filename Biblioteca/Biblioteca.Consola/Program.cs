using System;
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
                nuevoLibro.Nombre = "Otro libro";
                nuevoLibro.Año = 2000;
                context.Libros.Add(nuevoLibro);
                context.SaveChanges();

                Console.WriteLine("Hola mundo");
                Console.ReadKey();
            }   
        }
    }
}
