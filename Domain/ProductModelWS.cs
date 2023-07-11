using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class ProductModelWS
    {
        WebServiceProduct product = new WebServiceProduct();
        public List<Producto> ObtenerProductos()
        {
            return product.ObtenerProductos();
        }

        public bool descontarStock(int id, int cantidad)
        {
            string token = "b67cbd88370f80f9daa76671b94668c73e07bd58";
            return product.descontarStock(id, cantidad, token);
        }
    }
}
