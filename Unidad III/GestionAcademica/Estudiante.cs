using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionAcademica
{
    public class Estudiante : Persona
    {
        #region Atributos
        public string Carnet { get; set; }
        public Dictionary<string, float> Notas { get; set; } = new Dictionary<string, float>(); // Notas por curso
        #endregion

        #region Constructor
        public Estudiante(string nombre, string dpi, string correo, string carnet)
            : base(nombre, dpi, correo)
        {
            Carnet = carnet;
        }
        #endregion

        #region Métodos
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Carnet: {Carnet}");
            if (Notas.Count == 0)
            {
                Console.WriteLine("No tiene notas registradas.");
            }
            else
            {
                foreach (var nota in Notas)
                {
                    Console.WriteLine($"Curso: {nota.Key}, Nota: {nota.Value}");
                }
            }
        }
        #endregion
    }
}
