using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca
{
    internal class Libro
    {
        // Atributos
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int AnioPublicacion { get; set; }
        public Autor Autor { get; set; }  // Composición con la clase Autor

        // Constructor
        public Libro(string titulo, string isbn, int anioPublicacion, Autor autor)
        {
            Titulo = titulo;
            ISBN = isbn;
            AnioPublicacion = anioPublicacion;
            Autor = autor;
        }

        // Método: Mostrar información del libro y del autor
        public void MostrarInformacion()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Año de Publicación: {AnioPublicacion}");
            Console.WriteLine($"Autor: {Autor.Nombre}");
            Console.WriteLine($"Edad del Autor: {Autor.GetEdad()} años");
        }
    }
}
