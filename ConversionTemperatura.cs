namespace ConversionTemperatura
{
    internal class ConversionTemperatura
    {
        static void Main(string[] args)
        {
            float gradosCelsius = 0;
            float gradosFahrenheit = 0;
            float gradosKelvin = 0;

            // Solicitar al usuario que ingrese la temperatura en grados Celsius
            Console.WriteLine("Ingrese la temperatura en Grados Celsius");
            gradosCelsius = float.Parse(Console.ReadLine());

            // Convertir de Celsius a Fahrenheit y Kelvin
            gradosFahrenheit = (gradosCelsius * 9) / 5 + 32;
            gradosKelvin = gradosCelsius + 273.15f;

            // Mostrar las temperaturas convertidas
            Console.WriteLine($"La Temperatura en Fahrenheit: {gradosFahrenheit}");
            Console.WriteLine($"La Temperatura en Kelvin: {gradosKelvin}");

            // **Nueva función**: Convertir Grados Fahrenheit a Celsius
            float gradosFahrenheitInput;
            Console.WriteLine("Ingrese la temperatura en Grados Fahrenheit");
            gradosFahrenheitInput = float.Parse(Console.ReadLine());
            float celsiusFromFahrenheit = ConvertirFahrenheitACelsius(gradosFahrenheitInput);

            // Mostrar el resultado de la conversión
            Console.WriteLine($"La Temperatura en Celsius es: {celsiusFromFahrenheit}");
        }

        // **Nueva Función**: Convertir Grados Fahrenheit a Grados Celsius
        // La fórmula de conversión es: (°F - 32) * 5/9 = °C
        static float ConvertirFahrenheitACelsius(float gradosFahrenheit)
        {
            // Convertimos la temperatura de Fahrenheit a Celsius
            float gradosCelsius = (gradosFahrenheit - 32) * 5 / 9;
            return gradosCelsius;  // Retornamos el valor convertido en Celsius
        }
    }
}
