using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class ServiceModel
    {
        ServiceDAO serviceDAO = new ServiceDAO();
        public List<Servicio> ObtenerServicios()
        {
            return serviceDAO.ObtenerServicios();
        }

        public bool RegistrarServicio(string idServicio, string estadoLibro, string rutTecnico, string rutCliente, int? costo, DateTime fechaServicio, int idTipoServicio)
        {
            return serviceDAO.RegistrarServicio(idServicio, estadoLibro, rutTecnico, rutCliente, costo, fechaServicio, idTipoServicio);
        }

        public bool ModificarServicio(string idServicio, DateTime fechaServicio, int idTipoServicio)
        {
            return serviceDAO.ModificarServicio(idServicio, fechaServicio, idTipoServicio);
        }

        public bool AgregarCosto(string idServicio, int costo)
        {
            return serviceDAO.AgregarCosto(idServicio, costo);
        }

        public bool EliminarServicio(string idServicio)
        {
            return serviceDAO.EliminarServicio(idServicio);
        }

        public bool Rechazar(string idServicio, string estadoLibro)
        {
            return serviceDAO.Rechazar(idServicio, estadoLibro);
        }
    }
}
