using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class TipoProducto
    {
        public int idTipoProducto { get; set; }
        public string Nombre { get; set; }

        public TipoProducto()
        {
        }

        public TipoProducto(int idTipoProducto, string nombre)
        {
            this.idTipoProducto = idTipoProducto;
            Nombre = nombre;
        }
    }
}
