using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    internal class Producto
    {
        #region ATRIBUTOS
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Nombre} - {Categoria} - Q{Precio} - Stock: {Stock}";
        }

        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METODOS
        #endregion
    }
}
