using System;
using System.Collections.Generic;

public class Curso
{
    #region Atributos
    public string Codigo { get; set; }  // Atributo: código del curso
    public string Nombre { get; set; }  // Atributo: nombre del curso
    public Profesor Profesor { get; set; }  // Atributo: profesor asignado al curso
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>(); // Atributo: lista de estudiantes en el curso
    #endregion

    #region Métodos
    // Método para agregar un estudiante al curso
    public void AgregarEstudiante(Estudiante e)
    {
        Estudiantes.Add(e);
    }

    // Método para asignar un profesor al curso
    public void AsignarProfesor(Profesor p)
    {
        Profesor = p;
    }

    // Método para registrar una nota para un estudiante
    public void RegistrarNota(Estudiante e, float nota)
    {
        e.Notas[Nombre] = nota; // Asocia la nota al curso y al estudiante
    }

    // Método para calcular el promedio de las notas de los estudiantes
    public float CalcularPromedio()
    {
        float totalNotas = 0;
        foreach (var estudiante in Estudiantes)
        {
            if (estudiante.Notas.ContainsKey(Nombre))
            {
                totalNotas += estudiante.Notas[Nombre]; // Suma las notas del curso
            }
        }
        return Estudiantes.Count > 0 ? totalNotas / Estudiantes.Count : 0; // Devuelve el promedio de las notas
    }

    // Método para mostrar la información del curso
    public void MostrarInformacionCurso()
    {
        Console.WriteLine($"Curso: {Nombre} (Código: {Codigo})");
        if (Profesor != null)
        {
            Console.WriteLine($"Profesor asignado: {Profesor.Nombre} - Especialidad: {Profesor.Especialidad}");
        }
        else
        {
            Console.WriteLine("Profesor no asignado.");
        }

        Console.WriteLine($"Estudiantes inscritos: {Estudiantes.Count}");
        foreach (var estudiante in Estudiantes)
        {
            estudiante.MostrarInformacion();  // Muestra la información de cada estudiante
        }

        Console.WriteLine($"Promedio del curso: {CalcularPromedio()}");
    }
    #endregion

    #region Constructor
    // Constructor para inicializar los atributos del curso
    public Curso(string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
    }
    #endregion
}
