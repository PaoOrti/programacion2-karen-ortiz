namespace LINQ_Filtrar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista de enteros
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6};

            // Usar LINQ para filtrar solo los números pares
            var numerosPares = from num in numeros
                               where num % 2 == 0
                               select num;

            // Mostrar los resultados
            Console.WriteLine("Números pares:");
            foreach (var num in numerosPares)
            {
                Console.WriteLine(num);
            }
        }
    }
}
