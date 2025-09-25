using System;
using System.Collections.Generic;

public class Estudiante : Persona
{
    #region Atributos
    public string Carnet { get; set; }                      // Atributo: carnet del estudiante
    public Dictionary<string, float> Notas { get; set; } = new Dictionary<string, float>(); // Atributo: notas del estudiante
    #endregion

    #region Métodos
    // Sobrescribimos el método para mostrar información del estudiante
    public override void MostrarInformacion()
    {
        base.MostrarInformacion(); // Llamamos al método de la clase base para mostrar nombre, DPI y correo
        Console.WriteLine($"Carnet: {Carnet}");
        foreach (var nota in Notas)  // Mostramos todas las notas del estudiante
        {
            Console.WriteLine($"Curso: {nota.Key}, Nota: {nota.Value}");
        }
    }
    #endregion

    #region Constructor
    // Constructor para inicializar los atributos del estudiante
    public Estudiante(string nombre, string dpi, string correo, string carnet) : base(nombre, dpi, correo)
    {
        Carnet = carnet;
    }
    #endregion
}
