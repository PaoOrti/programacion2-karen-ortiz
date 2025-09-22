using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca
{
    internal class Biblioteca
    {
        // Atributos
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Libro> Libros { get; set; }

        // Constructor
        public Biblioteca(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            Libros = new List<Libro>();
        }

        // Método: Agregar un libro
        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
        }

        // Método: Buscar por autor
        public void BuscarPorAutor(string nombreAutor)
        {
            var librosAutor = Libros.FindAll(libro => libro.Autor.Nombre.ToLower().Contains(nombreAutor.ToLower()));
            if (librosAutor.Count == 0)
            {
                Console.WriteLine($"No se encontraron libros del autor: {nombreAutor}");
            }
            else
            {
                foreach (var libro in librosAutor)
                {
                    libro.MostrarInformacion();
                }
            }
        }

        // Método: Listar todos los libros
        public void ListarLibros()
        {
            if (Libros.Count == 0)
            {
                Console.WriteLine("No hay libros registrados en la biblioteca.");
            }
            else
            {
                foreach (var libro in Libros)
                {
                    libro.MostrarInformacion();
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
    }
}
