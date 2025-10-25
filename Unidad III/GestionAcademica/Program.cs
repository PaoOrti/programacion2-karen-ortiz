using GestionAcademica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GestionAcademicaApp
{
    internal class Program
    {
        static Dictionary<string, Estudiante> estudiantes = new Dictionary<string, Estudiante>();
        static Dictionary<string, Curso> cursos = new Dictionary<string, Curso>();

        static void Main(string[] args)
        {
            CargarDatos();

            bool salir = false;
            // Menú principal del programa
            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Mostrar estudiantes aprobados (nota >= 70)");
                Console.WriteLine("2. Mostrar top 5 estudiantes por curso");
                Console.WriteLine("3. Mostrar promedio por curso");
                Console.WriteLine("4. Mostrar top 10 estudiantes (todos los cursos)");
                Console.WriteLine("5. Mostrar ranking general de estudiantes");
                Console.WriteLine("6. Mostrar mejor estudiante por curso");
                Console.WriteLine("7. Mostrar estudiantes por intervalos de nota");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarEstudiantesAprobados();
                        break;
                    case "2":
                        MostrarTop5PorCurso();
                        break;
                    case "3":
                        MostrarPromedioPorCurso();
                        break;
                    case "4":
                        MostrarTop10General();
                        break;
                    case "5":
                        MostrarRankingGeneral();
                        break;
                    case "6":
                        MostrarMejorEstudiantePorCurso();
                        break;
                    case "7":
                        MostrarEstudiantesPorIntervalos();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intenta de nuevo.");
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
        //MÉTODO PARA CARGAR LOS DATOS DESDE UN CSV
        static void CargarDatos()
        {
            try
            {
                string filePath = @"C:\Users\ortiz\OneDrive - Universidad Panamericana UPANA\Clases\Segundo año\4to semestre\Programacion II\Unidad III\GestionAcademica\students_with_grades.csv";
                var lines = File.ReadAllLines(filePath).Skip(1);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    if (parts.Length < 5)
                        continue;

                    string nombreCurso = parts[0].Trim();
                    string carnet = parts[1].Trim();
                    string nombre = parts[2].Trim();
                    string apellido = parts[3].Trim();
                    string nombreCompleto = $"{nombre} {apellido}";

                    if (!float.TryParse(parts[4], NumberStyles.Float, CultureInfo.InvariantCulture, out float nota))
                    {
                        Console.WriteLine($"Nota inválida para estudiante {carnet} en curso {nombreCurso}. Se ignora.");
                        continue;
                    }

                    if (!cursos.ContainsKey(nombreCurso))
                    {
                        cursos[nombreCurso] = new Curso(nombreCurso, nombreCurso);
                    }

                    var cursoActual = cursos[nombreCurso];

                    if (!estudiantes.ContainsKey(carnet))
                    {
                        estudiantes[carnet] = new Estudiante(nombreCompleto, "", "", carnet);
                    }

                    var estudianteActual = estudiantes[carnet];
                    cursoActual.AgregarEstudiante(estudianteActual);
                    cursoActual.RegistrarNota(estudianteActual, nota);
                }

                Console.WriteLine("Datos cargados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos: " + ex.Message);
            }
        }
        //MÉTODO PARA EXPORTAR RESULTADOS A UN ARCHIVO .TXT
        static void ExportarResultados(IEnumerable<string> resultados, string nombreArchivo)
        {
            Console.WriteLine("¿Deseas exportar los resultados a un archivo .txt? (sí/no)");
            string respuesta = Console.ReadLine()?.ToLower();

            if (respuesta == "si" || respuesta == "sí")
            {
                try
                {
                    if (!nombreArchivo.EndsWith(".txt"))
                        nombreArchivo += ".txt";

                    string rutaBase = @"C:\Users\ortiz\OneDrive - Universidad Panamericana UPANA\Clases\Segundo año\4to semestre\Programacion II\Unidad III\GestionAcademica";
                    string rutaArchivo = Path.Combine(rutaBase, nombreArchivo);

                    using (StreamWriter sw = new StreamWriter(rutaArchivo))
                    {
                        foreach (var resultado in resultados)
                        {
                            sw.WriteLine(resultado);
                        }
                    }

                    Console.WriteLine($"Resultados exportados a {rutaArchivo}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al exportar el archivo: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No se exportaron los resultados. Regresando al menú...");
            }
        }
        //OPCIÓN 1:
        static void MostrarEstudiantesAprobados()
        {
            var query = from curso in cursos.Values
                        from nota in curso.Notas
                        where nota.Value >= 70
                        select new
                        {
                            Curso = curso.Nombre,
                            Carnet = nota.Key.Carnet,
                            Nombre = nota.Key.Nombre,
                            Nota = nota.Value
                        };

            Console.WriteLine("\nEstudiantes aprobados (nota >= 70):");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Curso} - {item.Carnet} - {item.Nombre} - Nota: {item.Nota}");
            }
            // Opción para exportar
            ExportarResultados(query.Select(i => $"{i.Curso} - {i.Carnet} - {i.Nombre} - Nota: {i.Nota}"), "aprobados");
        }
        //OPCIÓN 2:
        static void MostrarTop5PorCurso()
        {
            foreach (var curso in cursos.Values)
            {
                // Ordena las notas descendente y toma los 5 primeros
                var top5 = curso.Notas
                            .OrderByDescending(n => n.Value)
                            .Take(5)
                            .Select(n => new
                            {
                                Carnet = n.Key.Carnet,
                                Nombre = n.Key.Nombre,
                                Nota = n.Value
                            });

                Console.WriteLine($"\nTop 5 estudiantes - Curso: {curso.Nombre}");
                int pos = 1;
                foreach (var item in top5)
                {
                    Console.WriteLine($"{pos}. {item.Carnet} - {item.Nombre} - Nota: {item.Nota}");
                    pos++;
                }

                ExportarResultados(top5.Select(i => $"{i.Carnet} - {i.Nombre} - {i.Nota}"), $"top5_{curso.Nombre}");
            }
        }
        //OPCIÓN 3:
        static void MostrarPromedioPorCurso()
        {
            var promedios = from curso in cursos.Values
                            select new
                            {
                                Curso = curso.Nombre,
                                Promedio = curso.Notas.Any() ? curso.Notas.Values.Average() : 0
                            };

            Console.WriteLine("\nPromedio por curso:");
            foreach (var item in promedios)
            {
                Console.WriteLine($"Curso: {item.Curso} - Promedio: {item.Promedio:F2}");
            }

            ExportarResultados(promedios.Select(p => $"{p.Curso} - Promedio: {p.Promedio:F2}"), "promedios_por_curso");
        }
        //OPCIÓN 4:
        static void MostrarTop10General()
        {
            var todasNotas = from curso in cursos.Values
                             from nota in curso.Notas
                             select new
                             {
                                 Estudiante = nota.Key,
                                 Curso = curso.Nombre,
                                 Nota = nota.Value
                             };

            var top10 = todasNotas
                        .OrderByDescending(t => t.Nota)
                        .Take(10);

            Console.WriteLine("\nTop 10 estudiantes (todos los cursos):");
            int rank = 1;
            foreach (var item in top10)
            {
                Console.WriteLine($"{rank}. {item.Estudiante.Carnet} - {item.Estudiante.Nombre} - Curso: {item.Curso} - Nota: {item.Nota}");
                rank++;
            }

            ExportarResultados(top10.Select(i => $"{i.Estudiante.Carnet} - {i.Estudiante.Nombre} - {i.Curso} - Nota: {i.Nota}"), "top10_general");
        }
        //OPCIÓN 5:
        static void MostrarRankingGeneral()
        {
            var todasNotas = from curso in cursos.Values
                             from nota in curso.Notas
                             select new
                             {
                                 Estudiante = nota.Key,
                                 Curso = curso.Nombre,
                                 Nota = nota.Value
                             };

            var ranking = todasNotas.OrderByDescending(t => t.Nota);

            Console.WriteLine("\nRanking general de estudiantes (todos los cursos):");
            int pos = 1;
            foreach (var item in ranking)
            {
                Console.WriteLine($"{pos}. {item.Estudiante.Carnet} - {item.Estudiante.Nombre} - Curso: {item.Curso} - Nota: {item.Nota}");
                pos++;
            }

            ExportarResultados(ranking.Select(i => $"{i.Estudiante.Carnet} - {i.Estudiante.Nombre} - {i.Curso} - Nota: {i.Nota}"), "ranking_general");
        }
        //OPCIÓN 6:
        static void MostrarMejorEstudiantePorCurso()
        {
            var mejorPorCurso = from curso in cursos.Values
                                where curso.Notas.Any()
                                let mejorNota = curso.Notas.Values.Max()
                                let mejorEstudiante = curso.Notas.First(n => n.Value == mejorNota).Key
                                select new
                                {
                                    Curso = curso.Nombre,
                                    Carnet = mejorEstudiante.Carnet,
                                    Nombre = mejorEstudiante.Nombre,
                                    Nota = mejorNota
                                };

            Console.WriteLine("\nMejor estudiante por curso:");
            foreach (var item in mejorPorCurso)
            {
                Console.WriteLine($"{item.Curso} - {item.Carnet} - {item.Nombre} - Nota: {item.Nota}");
            }

            ExportarResultados(mejorPorCurso.Select(i => $"{i.Curso} - {i.Carnet} - {i.Nombre} - Nota: {i.Nota}"), "mejor_por_curso");
        }
        //OPCIÓN 7:
        static void MostrarEstudiantesPorIntervalos()
        {
            // Definición de los intervalos globales
            var intervalos = new Dictionary<string, Func<float, bool>>
    {
        { "0-59", n => n >= 0 && n <= 59 },
        { "60-79", n => n >= 60 && n <= 79 },
        { "80-100", n => n >= 80 && n <= 100 }
    };

            // Lista para guardar todos los resultados para exportación
            List<string> resultadosTotales = new List<string>();

            Console.WriteLine("\n========== ESTUDIANTES POR INTERVALOS (TODOS LOS CURSOS) ==========");

            // Recolectamos todas las notas de todos los cursos
            var todasLasNotas = from curso in cursos.Values
                                from nota in curso.Notas
                                select new
                                {
                                    Curso = curso.Nombre,
                                    Carnet = nota.Key.Carnet,
                                    Nombre = nota.Key.Nombre,
                                    Nota = nota.Value
                                };

            // Recorremos cada intervalo definido
            foreach (var intervalo in intervalos)
            {
                Console.WriteLine($"\nIntervalo {intervalo.Key}:");
                resultadosTotales.Add($"\nIntervalo {intervalo.Key}:");

                // Filtramos los estudiantes que caen en este rango
                var estudiantesIntervalo = todasLasNotas
                                           .Where(n => intervalo.Value(n.Nota))
                                           .OrderByDescending(n => n.Nota); // ordena de mayor a menor

                if (!estudiantesIntervalo.Any())
                {
                    Console.WriteLine("  No hay estudiantes en este intervalo.");
                    resultadosTotales.Add("  No hay estudiantes en este intervalo.");
                }
                else
                {
                    foreach (var est in estudiantesIntervalo)
                    {
                        string linea = $"  {est.Carnet} - {est.Nombre} - Curso: {est.Curso} - Nota: {est.Nota}";
                        Console.WriteLine(linea);
                        resultadosTotales.Add(linea);
                    }
                }
            }

            Console.WriteLine("\n========== FIN DEL REPORTE ==========");

            // Exporta todo el reporte en un solo archivo
            ExportarResultados(resultadosTotales, "reporte_estudiantes_por_intervalos_global");


        }
    }
}
