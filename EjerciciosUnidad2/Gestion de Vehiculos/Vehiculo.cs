using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Vehiculos
{
    public abstract class Vehiculo
    {
        #region Atributos
        protected string marca;
        protected string modelo;
        protected int anio;
        #endregion
        #region Constructor

        public Vehiculo(string marca, string modelo, int anio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.anio = anio;
        }
        #endregion

        #region Métodos
        public abstract double calcularImpuesto();
        #endregion
    }
}
