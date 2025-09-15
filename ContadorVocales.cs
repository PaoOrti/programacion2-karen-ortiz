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

        static void Main(string[] args)
        {
            // Solicitar una frase al usuario
            Console.WriteLine("Ingrese una frase: ");
            string frase = Console.ReadLine();

            // Contar las vocales
            int contadorA = ContarVocales(frase, 'a');
            int contadorE = ContarVocales(frase, 'e');
            int contadorI = ContarVocales(frase, 'i');
            int contadorO = ContarVocales(frase, 'o');
            int contadorU = ContarVocales(frase, 'u');

            // Mostrar los resultados
            Console.WriteLine($"La vocal 'a' aparece {contadorA} veces.");
            Console.WriteLine($"La vocal 'e' aparece {contadorE} veces.");
            Console.WriteLine($"La vocal 'i' aparece {contadorI} veces.");
            Console.WriteLine($"La vocal 'o' aparece {contadorO} veces.");
            Console.WriteLine($"La vocal 'u' aparece {contadorU} veces.");
        }
    }
}
