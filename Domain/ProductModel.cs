using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class ProductModel
    {
        WebServiceProduct product = new WebServiceProduct();
        public List<Producto> ObtenerProductos()
        {
            return product.ObtenerProductos();
        }
    }
}
