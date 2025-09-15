using System;

namespace ClasificacionNumeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un número entero: ");
            string entrada = Console.ReadLine();

            int numero;
            if (int.TryParse(entrada, out numero))
            {
                string resultado = $"El número {numero} es";

                // Par o impar
                if (numero % 2 == 0)
                {
                    resultado += " par";
                }
                else
                {
                    resultado += " impar";
                }

                // Positivo, negativo o cero
                if (numero > 0)
                {
                    resultado += ", positivo";
                }
                else if (numero < 0)
                {
                    resultado += ", negativo";
                }
                else
                {
                    resultado += ", cero";
                }

                // Múltiplo de 5
                if (numero % 5 == 0)
                {
                    resultado += ", múltiplo de 5";
                }
                else
                {
                    resultado += ", no es múltiplo de 5";
                }

                Console.WriteLine(resultado + ".");
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número entero válido.");
            }
        }
    }
}