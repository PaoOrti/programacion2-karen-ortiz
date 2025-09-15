using System;

namespace CalculadoraEdad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            int anio;
            int mes;  // Cambio: Agregada variable para el mes de nacimiento
            int dia;  // Cambio: Agregada variable para el día de nacimiento
            int anioActual = DateTime.Now.Year;
            String nombre;
            int edad;
            #endregion

            #region Calculos
            Console.WriteLine("Cual es tu nombre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Cual es tu anio de nacimiento:");
            anio = Int32.Parse(Console.ReadLine());
            
            // Cambio: Se agregan las líneas para capturar el mes y el día de nacimiento
            Console.WriteLine("Cual es tu mes de nacimiento? (1-12):");
            mes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Cual es tu dia de nacimiento?");
            dia = Int32.Parse(Console.ReadLine());

            // Calcular la edad solo con el año
            edad = anioActual - anio;
            #endregion

            // Mostrar la fecha actual y la edad calculada
            Console.WriteLine($"Hoy es {DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy")}");  // Cambio: Mostrar la fecha actual en formato completo
            Console.WriteLine($"Tu nombre es {nombre} y tienes {edad} años.");
        }
    }
}
