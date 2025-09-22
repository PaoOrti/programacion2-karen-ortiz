using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Biblioteca
{
    internal class Autor
    {
        // Atributos
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Constructor
        public Autor(string nombre, string nacionalidad, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Nacionalidad = nacionalidad;
            FechaNacimiento = fechaNacimiento;
        }

        // Método: Calcular la edad del autor
        public int GetEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;
            if (FechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;
            return edad;
        }
    }

}
