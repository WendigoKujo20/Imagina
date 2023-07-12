using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class ProductoModel
    {
        ProductDAO productDAO = new ProductDAO();

        public List<Producto> ListarProductos()
        {
            return productDAO.listarProductos();
        }

        public List<GeneroLiterario> ObtenerGeneros()
        {
            return productDAO.ObtenerGenerosLiterarios();
        }

        public List<TipoProducto> ObtenerTipos()
        {
            return productDAO.ObtenerTiposProductos();
        }

        public bool RegistrarProductos(string nombre, string autor, string descripcion, int precio, int stock, Byte[] imagen, int idGenero, int idTipo)
        {
            return productDAO.RegistrarProducto(nombre, autor, descripcion, precio, stock, imagen, idGenero, idTipo);
        }

        public bool EliminarProducto(int idProducto)
        {
            return productDAO.EliminarProducto(idProducto);
        }

        public bool ModificarProducto(int idProducto, string nombre, string autor, string descripcion, int precio, int stock, Byte[] imagen, int idGenero, int idTipo)
        {
            return productDAO.ModificarProducto(idProducto, nombre, autor, descripcion, precio, stock, imagen, idGenero, idTipo);
        }

        public Producto ObtenerProducto(int idProducto)
        {
            return productDAO.ObtenerProducto(idProducto);
        }

        public bool DescontarStock(int idProducto, int nuevoStock)
        {
            return productDAO.DescontarStock(idProducto, nuevoStock);
        }

        public bool RegistrarProductosWS(int id, string nombre, string autor, string descripcion, int precio, int stock, Byte[] imagen, int? idGenero, int idTipo)
        {
            return productDAO.RegistrarProductoWS(id, nombre, autor, descripcion, precio, stock, imagen, idGenero, idTipo);
        }
    }
}
