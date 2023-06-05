using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class GeneroLiterario
    {
        public int IdGeneroLiterario { get; set; }
        public string Nombre { get; set; }

        public GeneroLiterario()
        {
        }

        public GeneroLiterario(int idGeneroLiterario, string nombre)
        {
            IdGeneroLiterario = idGeneroLiterario;
            Nombre = nombre;
        }
    }
}
