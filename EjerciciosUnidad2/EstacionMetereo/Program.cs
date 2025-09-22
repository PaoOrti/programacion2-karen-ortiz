namespace EstacionMetereo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region INICIALIZACION DE VARIABLES
            bool continuar = true;
            int opcion;
            int sensorSelect;
            #endregion

            #region INICIALIZACION DE OBJETOS

        
            var sensores = new List<Sensor>
            {
                new SenseDirviento(), //opc 1
                new SenseEnersolar(), //opc 2
                new SenseHumedad(), //opc 3
                new SenseLluviaNieve(), //opc 4
                new SenseNivelLluvia(), //opc 5
                new SenseTemp(), //opc 6
                new SenseVelviento(), //opc 7
            };
            #endregion

            while (continuar)
            {
                Console.WriteLine("Seleccione una opcion: \n"
                    + "1. Ingresar lectura a sensor \n"
                    + "2. Obtener lectura de sensor \n"
                    + "3. Ver todos los sensores instalados \n"
                    + "4. Funciones especiales\n"
                    + "0. Salir"
                    );

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Clear();
                    Console.WriteLine("Intente de nuevo");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        continuar = false;
                        break;
                    case 1:
                        //TO DO: Deberia preguntar a que sensor se refiere...
                        sensorSelect = MenuSensor();
                        Console.WriteLine("Ingrese su valor:");
                        sensores[sensorSelect].setLectura(
                            double.Parse(Console.ReadLine())
                            );
                        Console.ReadKey();
                        break;
                    case 2:
                        sensorSelect = MenuSensor();
                        Console.WriteLine(sensores[sensorSelect].GetLectura());
                        Console.ReadKey();
                        break;
                     case 3:
                        //TO DO: Mostrar un listado de mis sensores
                        break;

                    default:
                        Console.WriteLine("La opcion no esta disponible");
                        Console.Clear();
                        Console.ReadKey();
                        break;

                }
            }
        }

        static int MenuSensor()
        {
            bool continuar = true;
            int opcion;

            while(continuar)
            {
                Console.WriteLine("Seleccione el sensor: \n"
                    + "1. Direccion de viento \n"
                    + "2. Energia Solar \n"
                    + "3. Humedad \n"
                    + "4. Lluvia-Nieve \n"
                    + "5. Nivel de Lluvia \n"
                    + "6. Temperatura \n"
                    + "7. Velocidad de Viento \n"
                    );

                if (!int.TryParse(Console.ReadLine(),out opcion))
                {
                    Console.Clear();
                    Console.WriteLine("Intente de nuevo");
                    Console.ReadKey();
                    Console.Clear();
                    continue;

                }

                switch (opcion)
                {
                    case 1:
                        return 0;
                    case 2: 
                        return 1;
                    case 3: 
                        return 2;
                    case 4:
                        return 3;
                    case 5:
                        return 4;
                    case 6:
                        return 5;
                    case 7:
                        return 6;
                    default:
                        Console.Clear();
                        Console.WriteLine("Intente de nuevo");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
            }
            return 0;
        }
    }
}
