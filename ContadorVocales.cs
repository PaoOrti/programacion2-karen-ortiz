using System;

namespace ContadorVocales
{
    internal class ContadorVocalesFrases
    {
        // Método para contar las repeticiones de una vocal
        static int ContarVocales(string frase, char vocal)
        {
            int contador = 0;
            // Convertimos la frase a minúsculas para ignorar la distinción entre mayúsculas y minúsculas
            frase = frase.ToLower();

            foreach (char c in frase)
            {
                if (c == vocal)
                {
                    contador++;
                }
            }

            return contador;
        }

        // **Nuevo**: Método para contar las consonantes
        static int ContarConsonantes(string frase)
        {
            int contador = 0;
            frase = frase.ToLower();

            foreach (char c in frase)
            {
                // Verificamos si el carácter es una letra y no es una vocal
                if ("bcdfghjklmnpqrstvwxyz".Contains(c))
                {
                    contador++; // Aumentamos el contador si es una consonante
                }
            }

            return contador; // Retornamos el total de consonantes encontradas
        }

        // **Nuevo**: Método para contar todas las vocales en la frase
        static int ContarTodasVocales(string frase)
        {
            int totalVocales = 0;
            // Llamamos al método ContarVocales para cada una de las vocales
            totalVocales += ContarVocales(frase, 'a');
            totalVocales += ContarVocales(frase, 'e');
            totalVocales += ContarVocales(frase, 'i');
            totalVocales += ContarVocales(frase, 'o');
            totalVocales += ContarVocales(frase, 'u');

            return totalVocales; // Retornamos el total de vocales encontradas
        }

        static void Main(string[] args)
        {
            // Solicitar una frase al usuario
            Console.WriteLine("Ingrese una frase: ");
            string frase = Console.ReadLine();

            // Contar las vocales específicas
            int contadorA = ContarVocales(frase, 'a');
            int contadorE = ContarVocales(frase, 'e');
            int contadorI = ContarVocales(frase, 'i');
            int contadorO = ContarVocales(frase, 'o');
            int contadorU = ContarVocales(frase, 'u');

            // **Nuevo**: Contar las consonantes en la frase
            int contadorConsonantes = ContarConsonantes(frase);

            // **Nuevo**: Contar el total de vocales en la frase
            int totalVocales = ContarTodasVocales(frase);

            // Mostrar los resultados
            Console.WriteLine($"La vocal 'a' aparece {contadorA} veces.");
            Console.WriteLine($"La vocal 'e' aparece {contadorE} veces.");
            Console.WriteLine($"La vocal 'i' aparece {contadorI} veces.");
            Console.WriteLine($"La vocal 'o' aparece {contadorO} veces.");
            Console.WriteLine($"La vocal 'u' aparece {contadorU} veces.");
            Console.WriteLine($"El total de vocales en la frase es: {totalVocales}."); // Se muestra el total de vocales
            Console.WriteLine($"El total de consonantes en la frase es: {contadorConsonantes}."); // Se muestra el total de consonantes
        }
    }
}
