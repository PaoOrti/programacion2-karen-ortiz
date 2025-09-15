namespace ConversionTemperatura
{
    internal class ConversionTemperatura
    {
        static void Main(string[] args)
        {
            float gradosCelsius=0;
            float gradosFahrenheit=0;
            float gradosKelvin = 0; 

            Console.WriteLine("Ingrese la temperatura en Grados Celsius");
            gradosCelsius = float.Parse(Console.ReadLine());

            gradosFahrenheit = (gradosCelsius * 9) / 5 + 32;
            gradosKelvin = gradosCelsius + 273.15f;
            Console.WriteLine($"La Temperatura en Farenheit: {gradosFahrenheit}");
            Console.WriteLine($"La Temperatura en Kelvin: {gradosKelvin}");
           
        }
    }
}
