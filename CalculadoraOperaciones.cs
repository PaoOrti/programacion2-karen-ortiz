namespace CalculadoraOperaciones
{
    internal class Calculadora
    {
        // Métodos existentes
        static double Sumar(double num1, double num2) => num1 + num2;
        static double Restar(double num1, double num2) => num1 - num2;
        static double Multiplicar(double num1, double num2) => num1 * num2;
        static double Dividir(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("No se puede dividir entre cero.");
                return 0;
            }
            return num1 / num2;
        }

        // Nueva función de potencia (Cambio)
        static double Potencia(double baseNum, double exponente) => Math.Pow(baseNum, exponente);

        static void Main(string[] args)
        {
            double num1, num2;
            int operacion;

            // Solicitar los dos números
            Console.WriteLine("Ingrese el primer número: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo número: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            // Mostrar el menú de opciones
            Console.WriteLine("\nSelecciona una operación:");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Potencia");  // Cambio: Nueva opción agregada para potencia

            // Leer la opción seleccionada
            operacion = Convert.ToInt32(Console.ReadLine());

            // Ejecutar la operación seleccionada
            double resultado = 0;
            switch (operacion)
            {
                case 1:
                    resultado = Sumar(num1, num2);
                    Console.WriteLine($"El resultado de la suma es: {resultado}");
                    break;
                case 2:
                    resultado = Restar(num1, num2);
                    Console.WriteLine($"El resultado de la resta es: {resultado}");
                    break;
                case 3:
                    resultado = Multiplicar(num1, num2);
                    Console.WriteLine($"El resultado de la multiplicación es: {resultado}");
                    break;
                case 4:
                    resultado = Dividir(num1, num2);
                    if (num2 != 0)
                        Console.WriteLine($"El resultado de la división es: {resultado}");
                    break;
                case 5:  // Cambio: Caso para la operación de potencia
                    resultado = Potencia(num1, num2);
                    Console.WriteLine($"El resultado de {num1} elevado a la potencia de {num2} es: {resultado}");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }
}
