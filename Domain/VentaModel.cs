using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class VentaModel
    {
        VentaDAO ventaDAO = new VentaDAO();

        public List<Carrito> ObtenerCarritos()
        {
            return ventaDAO.ObtenerCarritos();
        }

        public bool EliminarCarrito(int idCarrito)
        {
            return ventaDAO.EliminarCarrito(idCarrito);
        }

        public bool RegistrarCarrito(int codigo, string rut, string nombre, int precio, int cantidad)
        {
            return ventaDAO.RegistrarCarrito(codigo, rut, nombre, precio, cantidad);
        }

        public bool RegistrarVenta(int orden, string rut, int total, DateTime fecha)
        {
            return ventaDAO.RegistrarVenta(orden, rut, total, fecha);
        }

        public List<Venta> ObtenerVentas()
        {
            return ventaDAO.ObtenerVentas();
        }

        public Carrito ObtenerCarrito(int idCarrito)
        {
            return ventaDAO.ObtenerCarrito(idCarrito);
        }
    }
}
