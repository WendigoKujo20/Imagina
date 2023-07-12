using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }

        public TipoUsuario()
        {
        }
        public TipoUsuario(int idTipoUsuario, string nombre)
        {
            IdTipoUsuario = idTipoUsuario;
            Nombre = nombre;
        }
    }
}
