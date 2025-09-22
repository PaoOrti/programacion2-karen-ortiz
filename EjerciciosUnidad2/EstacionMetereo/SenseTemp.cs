using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EstacionMetereo
{
    internal class SenseTemp : Sensor
    { 
        #region ATRIBUTOS
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METODOS
        public double TempKelvin()
        {
            return lectura + 273;
        }
        public double TempFarenheit()
        {
            return (lectura * 9) / 5 + 32;
        }

        public void CompararTemp(SenseTemp sensorTemp)
        {
            if (this.lectura > sensorTemp.lectura)
            {
                Console.WriteLine("La temperatura del sensor 1 es mayor a la del sensor 2");

            }
            //TO DO: el resto de comparaciones
        }

        public double PromedioTemp(SenseTemp sensorTemp)
        {
            return (this.lectura + sensorTemp.lectura) / 2;

        }
        #endregion
    }
}
