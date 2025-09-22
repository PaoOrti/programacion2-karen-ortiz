namespace Sistema_de_Biblioteca
{
    internal class Program
    {
        static void Main()
        {
            Biblioteca biblioteca = new Biblioteca("Biblioteca Central", "Calle Ficticia, 123");

            int opcion;
            do
            {
                // Menú de opciones
                Console.Clear();
                Console.WriteLine("Sistema de Gestión de Biblioteca");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Buscar por autor");
                Console.WriteLine("3. Listar todos los libros");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // Agregar un nuevo libro
                        Console.WriteLine("\n--- Ingresar datos del autor ---");
                        Console.Write("Nombre del autor: ");
                        string nombreAutor = Console.ReadLine();
                        Console.Write("Nacionalidad del autor: ");
                        string nacionalidad = Console.ReadLine();
                        Console.Write("Fecha de nacimiento del autor (YYYY-MM-DD): ");
                        DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

                        Autor autor = new Autor(nombreAutor, nacionalidad, fechaNacimiento);

                        Console.WriteLine("\n--- Ingresar datos del libro ---");
                        Console.Write("Título del libro: ");
                        string titulo = Console.ReadLine();
                        Console.Write("ISBN del libro: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Año de publicación del libro: ");
                        int anioPublicacion = int.Parse(Console.ReadLine());

                        Libro libro = new Libro(titulo, isbn, anioPublicacion, autor);
                        biblioteca.AgregarLibro(libro);

                        Console.WriteLine("¡Libro agregado con éxito!");
                        break;

                    case 2:
                        // Buscar por autor
                        Console.Write("\nIngrese el nombre del autor: ");
                        string nombreAutorBuscar = Console.ReadLine();
                        biblioteca.BuscarPorAutor(nombreAutorBuscar);
                        break;

                    case 3:
                        // Listar todos los libros
                        Console.WriteLine("\nListado de todos los libros en la biblioteca:");
                        biblioteca.ListarLibros();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida, intente nuevamente.");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 4);
        }
    }
}