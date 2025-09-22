using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Vehiculos
{
    public class Motocicleta : Vehiculo
    {
        #region Atributos
        private double cilindraje;
        #endregion

        #region Constructor
        public Motocicleta(string marca, string modelo, int anio, double cilindraje)
            : base(marca, modelo, anio)
        {
            this.cilindraje = cilindraje;
        }
        #endregion
        #region Métodos
        public override double calcularImpuesto()
        {
            return (cilindraje * 0.03) * anio;
        #endregion
        }
    }
}

