using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Vehiculos
{
    public class Camion : Vehiculo
    {
        #region Atributos
        private double capacidadToneladas;
        #endregion

        #region Constructor
        public Camion(string marca, string modelo, int anio, double capacidadToneladas)
            : base(marca, modelo, anio)
        {
            this.capacidadToneladas = capacidadToneladas;
        }
        #endregion

        #region Métodos
        public override double calcularImpuesto()
        {
            return (capacidadToneladas * 100) + (50 * anio);
        #endregion
        }
    } 
}