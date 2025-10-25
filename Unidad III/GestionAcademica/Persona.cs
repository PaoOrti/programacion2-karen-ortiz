using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAcademica
{
    public class Persona
    {
        #region Atributos
        public string Nombre { get; set; }  // Atributo: nombre de la persona
        public string Dpi { get; set; }     // Atributo: DPI de la persona
        public string Correo { get; set; }  // Atributo: correo de la persona
        #endregion

        #region Métodos
        // Método para mostrar la información de la persona
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, DPI: {Dpi}, Correo: {Correo}");
        }
        #endregion

        #region Constructor
        // Constructor para inicializar los atributos de la persona
        public Persona(string nombre, string dpi, string correo)
        {
            Nombre = nombre;
            Dpi = dpi;
            Correo = correo;
        }
        #endregion
    }
}