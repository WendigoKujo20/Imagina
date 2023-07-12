using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class Genero
    {
        public int IdGenero { get; set; }
        public string Nombre { get; set; }

        public Genero()
        {
        }
        public Genero(int idGenero, string nombre)
        {
            IdGenero = idGenero;
            Nombre = nombre;
        }
    }
}
