using System;
using System.Collections.Generic;

public class Profesor : Persona
{
    #region Atributos
    public string Especialidad { get; set; }  // Atributo: especialidad del profesor
    public List<Curso> CursosAsignados { get; set; } = new List<Curso>(); // Atributo: lista de cursos asignados al profesor
    #endregion

    #region Métodos
    // Sobrescribimos el método para mostrar información del profesor
    public override void MostrarInformacion()
    {
        base.MostrarInformacion();  // Llamamos al método de la clase base para mostrar nombre, DPI y correo
        Console.WriteLine($"Especialidad: {Especialidad}");
    }
    #endregion

    #region Constructor
    // Constructor para inicializar los atributos del profesor
    public Profesor(string nombre, string dpi, string correo, string especialidad) : base(nombre, dpi, correo)
    {
        Especialidad = especialidad;
    }
    #endregion
}
