using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionMetereo
{
    internal class SenseEnersolar : Sensor
    {
        #region ATRIBUTOS
        // Usa el atributo lectura heredado de Sensor
        #endregion

        #region CONSTRUCTOR
        public SenseEnersolar() : base("Energía Solar", "W/m²") { }
        #endregion

        #region MÉTODOS
        public bool AltaRadiacion()
        {
            return lectura > 800; // umbral de ejemplo
        }

        public override string GetLectura()
        {
            string estado = AltaRadiacion()
                ? "⚠️ Alta radiación detectada"
                : "Radiación dentro de rango";

            return $"{nombre}: {lectura} {unidad} | {estado}";
        }
        #endregion
    }
}

