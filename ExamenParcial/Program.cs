using System;
using System.Collections.Generic;

public class Programa
{
    #region Atributos
    static List<Curso> cursos = new List<Curso>();
    static List<Estudiante> estudiantes = new List<Estudiante>();
    static List<Profesor> profesores = new List<Profesor>();
    #endregion

    #region Métodos

    public static void Main()
    {
        // Crear profesores iniciales
        Profesor profesor1 = new Profesor("Ana López", "123456789", "ana@universidad.com", "Ingeniería de Software");
        Profesor profesor2 = new Profesor("Carlos Pérez", "987654321", "carlos@universidad.com", "Matemáticas");
        profesores.Add(profesor1);
        profesores.Add(profesor2);

        // Crear cursos iniciales
        Curso curso1 = new Curso("C001", "Programación 2");
        Curso curso2 = new Curso("C002", "Matemáticas Avanzadas");
        Curso curso3 = new Curso("C003", "Base de Datos");
        cursos.Add(curso1);
        cursos.Add(curso2);
        cursos.Add(curso3);

        // Menú interactivo
        int opcion;
        do
        {
            MostrarMenu();
            opcion = Int32.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    AsignarProfesorACurso();
                    break;
                case 3:
                    RegistrarNotas();
                    break;
                case 4:
                    MostrarInformacionEstudiantes();
                    break;
                case 5:
                    MostrarPromedioCurso();
                    break;
                case 6:
                    MostrarInformacionCurso();  // Opción para mostrar la información del curso
                    break;
                case 7:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor elige una opción entre 1 y 7.");
                    break;
            }

        } while (opcion != 7);  // El menú se repite hasta que se elige la opción 7
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n--- Sistema de Gestión Académica ---");
        Console.WriteLine("1. Agregar Estudiante");
        Console.WriteLine("2. Asignar Profesor a un Curso");
        Console.WriteLine("3. Registrar Notas");
        Console.WriteLine("4. Mostrar Información de Estudiantes");
        Console.WriteLine("5. Mostrar Promedio del Curso");
        Console.WriteLine("6. Mostrar Información del Curso");
        Console.WriteLine("7. Salir");
        Console.Write("Elige una opción (1-7): ");
    }

    static void AgregarEstudiante()
    {
        Console.WriteLine("\n--- Agregar Estudiante ---");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("DPI: ");
        string dpi = Console.ReadLine();

        Console.Write("Correo: ");
        string correo = Console.ReadLine();

        Console.Write("Carnet: ");
        string carnet = Console.ReadLine();

        Estudiante estudiante = new Estudiante(nombre, dpi, correo, carnet);
        estudiantes.Add(estudiante);

        // Agregar al curso
        Console.WriteLine("Selecciona el curso al que deseas agregar al estudiante:");
        for (int i = 0; i < cursos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cursos[i].Nombre}");
        }
        int cursoSeleccionado = Int32.Parse(Console.ReadLine()) - 1;
        if (cursoSeleccionado >= 0 && cursoSeleccionado < cursos.Count)
        {
            cursos[cursoSeleccionado].AgregarEstudiante(estudiante);
            Console.WriteLine($"Estudiante {estudiante.Nombre} agregado al curso {cursos[cursoSeleccionado].Nombre}.");
        }
        else
        {
            Console.WriteLine("Curso no válido.");
        }
    }

    static void AsignarProfesorACurso()
    {
        Console.WriteLine("\n--- Asignar Profesor a un Curso ---");

        Console.WriteLine("Cursos disponibles:");
        foreach (var curso in cursos)
        {
            Console.WriteLine($"Codigo: {curso.Codigo}, Nombre: {curso.Nombre}");
        }

        Console.Write("Ingresa el código del curso al que deseas asignar un profesor: ");
        string codigoCurso = Console.ReadLine();

        Curso cursoSeleccionado = cursos.Find(c => c.Codigo == codigoCurso);

        if (cursoSeleccionado != null)
        {
            Console.WriteLine("Profesores disponibles:");
            foreach (var profesor in profesores)
            {
                Console.WriteLine($"Nombre: {profesor.Nombre}, Especialidad: {profesor.Especialidad}");
            }

            Console.Write("Ingresa el nombre del profesor que deseas asignar: ");
            string nombreProfesor = Console.ReadLine();

            Profesor profesorSeleccionado = profesores.Find(p => p.Nombre == nombreProfesor);

            if (profesorSeleccionado != null)
            {
                cursoSeleccionado.AsignarProfesor(profesorSeleccionado);
                Console.WriteLine("Profesor asignado correctamente.");
            }
            else
            {
                Console.WriteLine("Profesor no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Curso no encontrado.");
        }
    }

    static void RegistrarNotas()
    {
        Console.WriteLine("\n--- Registrar Notas ---");

        Console.WriteLine("Cursos disponibles:");
        foreach (var curso in cursos)
        {
            Console.WriteLine($"Codigo: {curso.Codigo}, Nombre: {curso.Nombre}");
        }

        Console.Write("Ingresa el código del curso para registrar notas: ");
        string codigoCurso = Console.ReadLine();

        Curso cursoSeleccionado = cursos.Find(c => c.Codigo == codigoCurso);

        if (cursoSeleccionado != null)
        {
            Console.WriteLine("Estudiantes disponibles:");
            foreach (var estudiante in cursoSeleccionado.Estudiantes)
            {
                Console.WriteLine($"Nombre: {estudiante.Nombre}, Carnet: {estudiante.Carnet}");
            }

            Console.Write("Ingresa el carnet del estudiante al que deseas registrar la nota: ");
            string carnetEstudiante = Console.ReadLine();

            Estudiante estudianteSeleccionado = cursoSeleccionado.Estudiantes.Find(e => e.Carnet == carnetEstudiante);

            if (estudianteSeleccionado != null)
            {
                Console.Write("Ingresa la nota: ");
                float nota = float.Parse(Console.ReadLine());
                cursoSeleccionado.RegistrarNota(estudianteSeleccionado, nota);
                Console.WriteLine("Nota registrada correctamente.");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Curso no encontrado.");
        }
    }

    static void MostrarInformacionEstudiantes()
    {
        Console.WriteLine("\n--- Información de Estudiantes ---");

        foreach (var curso in cursos)
        {
            Console.WriteLine($"\nCurso: {curso.Nombre}");
            foreach (var estudiante in curso.Estudiantes)
            {
                estudiante.MostrarInformacion();
            }
        }
    }

    static void MostrarPromedioCurso()
    {
        Console.WriteLine("\n--- Promedio del Curso ---");

        Console.WriteLine("Cursos disponibles:");
        foreach (var curso in cursos)
        {
            Console.WriteLine($"Codigo: {curso.Codigo}, Nombre: {curso.Nombre}");
        }

        Console.Write("Ingresa el código del curso para calcular el promedio: ");
        string codigoCurso = Console.ReadLine();

        Curso cursoSeleccionado = cursos.Find(c => c.Codigo == codigoCurso);

        if (cursoSeleccionado != null)
        {
            float promedio = cursoSeleccionado.CalcularPromedio();
            Console.WriteLine($"Promedio del curso {cursoSeleccionado.Nombre}: {promedio}");
        }
        else
        {
            Console.WriteLine("Curso no encontrado.");
        }
    }

    static void MostrarInformacionCurso()
    {
        Console.WriteLine("\n--- Información del Curso ---");

        Console.WriteLine("Cursos disponibles:");
        foreach (var curso in cursos)
        {
            Console.WriteLine($"Codigo: {curso.Codigo}, Nombre: {curso.Nombre}");
        }

        Console.Write("Ingresa el código del curso para mostrar su información: ");
        string codigoCurso = Console.ReadLine();

        Curso cursoSeleccionado = cursos.Find(c => c.Codigo == codigoCurso);

        if (cursoSeleccionado != null)
        {
            cursoSeleccionado.MostrarInformacionCurso();  // Llamamos al método para mostrar la información del curso
        }
        else
        {
            Console.WriteLine("Curso no encontrado.");
        }
    }

    #endregion
}
