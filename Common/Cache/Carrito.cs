using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class Carrito
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public Carrito()
        {
        }

        public Carrito(int id, int codigo, string rut, string nombre, int precio, int cantidad)
        {
            Id = id;
            Codigo = codigo;
            Rut = rut;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
