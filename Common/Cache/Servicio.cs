using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class Servicio
    {
        public string Id { get; set; }
        public string EstadoLibro { get; set; }
        public string RutTecnico { get; set; }
        public string RutCliente { get; set; }
        public int? Costo { get; set; }
        public DateTime FechaServicio { get; set; }
        public int IdTipoServicio { get; set; }

        public Servicio()
        {
        }

        public Servicio(string id, string estadoLibro, string rutTecnico, string rutCliente, int costo, DateTime fechaServicio, int idTipoServicio)
        {
            Id = id;
            EstadoLibro = estadoLibro;
            RutTecnico = rutTecnico;
            RutCliente = rutCliente;
            Costo = costo;
            FechaServicio = fechaServicio;
            IdTipoServicio = idTipoServicio;
        }
    }
}
