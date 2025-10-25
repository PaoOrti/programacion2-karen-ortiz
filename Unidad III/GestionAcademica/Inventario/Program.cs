using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Inventario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Lee las lineas del archivo CSV y las convierte en una lista de productos
            var productos = File.ReadAllLines(@"C:\Users\ortiz\OneDrive - Universidad Panamericana UPANA\Clases\Segundo año\4to semestre\Programacion II\Unidad III\Inventario\inventario_productos.csv")
            .Skip(1)
            .Select(line =>
            {
                var parts = line.Split(',');
                return new Producto
                {
                    Id = int.Parse(parts[0]),
                    Nombre = parts[1],
                    Categoria = parts[2],
                    Precio = double.Parse(parts[3], CultureInfo.InvariantCulture),
                    Stock = int.Parse(parts[4])
                };
            }).ToList();

            while (true)
            {
                Console.WriteLine("Selecciona una opción:");
                Console.WriteLine("1. Ver productos con stock menor a 10");
                Console.WriteLine("2. Ver productos ordenados por precio descendente");
                Console.WriteLine("3. Ver total del valor del inventario");
                Console.WriteLine("4. Agrupar productos por categoría");
                Console.WriteLine("5. Salir");

                int opcion;
                bool esNumero = int.TryParse(Console.ReadLine(), out opcion);

                if (!esNumero || opcion < 1 || opcion > 5)
                {
                    Console.WriteLine("Opción no válida. Por favor, selecciona un número entre 1 y 5.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        // Consulta: stock menor a 10 unidades
                        var q1 = from p in productos
                                 where p.Stock < 10
                                 select p;
                        // Muestra los resultados en consola.
                        foreach (var p in q1)
                        {
                            Console.WriteLine($"{p.Nombre} - {p.Categoria} - Q{p.Precio} - Stock: {p.Stock}");
                        }
                        ExportarResultados(q1.Select(p => $"{p.Nombre} - {p.Categoria} - Q{p.Precio} - Stock: {p.Stock}"));
                        break;

                    case 2:
                        // Consulta: Ordenados por precio descendente
                        var q2 = from p in productos
                                 orderby p.Precio descending
                                 select p;
                        // Muestra los resultados en consola.
                        foreach (var p in q2)
                        {
                            Console.WriteLine($"{p.Nombre} - {p.Categoria} - Q{p.Precio} - Stock: {p.Stock}");
                        }
                        ExportarResultados(q2.Select(p => $"{p.Nombre} - {p.Categoria} - Q{p.Precio} - Stock: {p.Stock}"));
                        break;

                    case 3:
                        // Consulta: Total del valor del inventario
                        var q3 = from p in productos
                                 select p.Precio;

                        double totalInventario = q3.Sum();
                        Console.WriteLine($"El valor total del inventario es: Q{totalInventario:F2}");
                        ExportarResultados(new List<string> { $"El valor total del inventario es: Q{totalInventario:F2}" });
                        break;

                    case 4:
                        // Consulta: Agrupar productos por categoría
                        var q4 = from p in productos
                                 group p by p.Categoria into grupo
                                 select grupo;

                        List<string> resultadosAgrupados = new List<string>();
                        foreach (var grupo in q4)
                        {
                            resultadosAgrupados.Add($"Categoría: {grupo.Key}");
                            foreach (var p in grupo)
                            {
                                resultadosAgrupados.Add($"  {p.Nombre} - Q{p.Precio} - Stock: {p.Stock}");
                            }
                        }

                        foreach (var resultado in resultadosAgrupados)
                        {
                            Console.WriteLine(resultado);
                        }
                        ExportarResultados(resultadosAgrupados);
                        break;

                    case 5:
                        Console.WriteLine("¡Hasta luego!");
                        return;
                }
            }
        }
        // Método para preguntar al usuario si desea exportar y exportar los resultados
        static void ExportarResultados(IEnumerable<string> resultados)
        {
            Console.WriteLine("¿Deseas exportar los resultados a un archivo .txt? (sí/no)");
            string respuesta = Console.ReadLine()?.ToLower();

            if (respuesta == "si")
            {
                try
                {
                    string rutaArchivo = @"C:\Users\ortiz\OneDrive - Universidad Panamericana UPANA\Clases\Segundo año\4to semestre\Programacion II\Unidad III\Inventario\archivo_resultados.txt"; // Especifica la ruta de destino
                    using (StreamWriter sw = new StreamWriter(rutaArchivo))
                    {
                        foreach (var resultado in resultados)
                        {
                            sw.WriteLine(resultado);
                        }
                    }
                    Console.WriteLine("Resultados exportados a archivo.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al exportar el archivo: {ex.Message}");
                }
            }
        }
    }
}
