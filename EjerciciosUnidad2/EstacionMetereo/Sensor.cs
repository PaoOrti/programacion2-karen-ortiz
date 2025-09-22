using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionMetereo
{
    internal class Sensor
    {
        #region ATRIBUTOS
        private string sensorName;
        private string fechaLectura;
        private int identificador;
        protected double lectura;
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METODOS
        //Cambiar nombre

        public void SetSensorName(string sensorName)
        {
            this.sensorName = sensorName;
        }

        public string GetSensorName()
        {
            return this.sensorName;
        }

        //Cambiar identificador
        public void SetIdentificador(int identificador)
        {
            this.identificador = identificador;
        }

        public int GetIdentificador()
        {
            return this.identificador;
        }
        public void setLectura(double lectura)
        {
            this.lectura = lectura;
        }

        public double GetLectura()
        {
            return lectura;
        }
        #endregion

    }
}
