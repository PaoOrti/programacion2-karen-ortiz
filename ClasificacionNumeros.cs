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

                // **Nuevo**: Verificar si el número es primo
                if (EsPrimo(numero))
                {
                    resultado += ", primo"; // Si es primo, se agrega al resultado
                }
                else
                {
                    resultado += ", no es primo"; // Si no es primo, se agrega esto
                }

                // **Nuevo**: Clasificación por rango (pequeño, mediano, grande)
                if (numero >= 0 && numero <= 10)
                {
                    resultado += ", pequeño"; // Número entre 0 y 10 se clasifica como pequeño
                }
                else if (numero > 10 && numero <= 100)
                {
                    resultado += ", mediano"; // Número entre 11 y 100 se clasifica como mediano
                }
                else
                {
                    resultado += ", grande"; // Número mayor que 100 se clasifica como grande
                }

                // **Nuevo**: Sumar las cifras del número
                int sumaCifras = SumarCifras(numero);
                resultado += $". La suma de sus cifras es: {sumaCifras}"; // Se muestra la suma de las cifras

                Console.WriteLine(resultado + ".");
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número entero válido.");
            }
        }

        // **Nuevo**: Método para verificar si un número es primo
        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false; // Los números menores o iguales a 1 no son primos
            for (int i = 2; i <= Math.Sqrt(numero); i++) // Solo se verifica hasta la raíz cuadrada del número
            {
                if (numero % i == 0) return false; // Si el número es divisible por algún valor, no es primo
            }
            return true; // Si no se encontró divisor, es primo
        }

        // **Nuevo**: Método para sumar las cifras de un número
        static int SumarCifras(int numero)
        {
            int suma = 0;
            numero = Math.Abs(numero); // Convertimos a valor absoluto para manejar números negativos
            while (numero > 0)
            {
                suma += numero % 10; // Extraemos la última cifra
                numero /= 10; // Eliminamos la última cifra
            }
            return suma; // Retornamos la suma total de las cifras
        }
    }
}
