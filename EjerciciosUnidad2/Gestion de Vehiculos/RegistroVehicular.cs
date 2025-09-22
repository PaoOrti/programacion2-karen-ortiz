using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Vehiculos
{
    public class RegistroVehicular
    {
        #region Atributos
        private List<Vehiculo> listaVehiculos;
        #endregion

        #region Constructor
        public RegistroVehicular()
        {
            listaVehiculos = new List<Vehiculo>();
        }
        #endregion

        #region Métodos
        public void agregarVehiculo(Vehiculo v)
        {
            listaVehiculos.Add(v);
        }

        public void mostrarImpuestos()
        {
            foreach (var vehiculo in listaVehiculos)
            {
                Console.WriteLine($"Vehículo: {vehiculo.GetType().Name}, Impuesto: {vehiculo.calcularImpuesto()}");
            }
        #endregion
        }
    }
}