using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class Venta
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public string Rut { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public Venta()
        {
        }

        public Venta(int id, int orden, string rut, int precioTotal, DateTime fecha)
        {
            Id = id;
            Orden = orden;
            Rut = rut;
            PrecioTotal = precioTotal;
            Fecha = fecha;
        }
    }
}
