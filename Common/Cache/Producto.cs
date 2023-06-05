using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Cache
{
    public class Producto
    {
        [JsonProperty("Codigo")]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        [JsonProperty("Id_Genero_Literario")]
        public int IdGeneroLiterario { get; set; }
        public string NombreGenero { get; set; }
        [JsonProperty("Id_Tipo_Producto")]
        public int IdTipoProducto { get; set; }

        public Producto()
        {
        }

        public Producto(int idProducto, string nombre, string autor, string descripcion, int precio, int stock, string imagen, int idGeneroLiterario, string nombreGenero, int idTipoProducto)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Autor = autor;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Imagen = imagen;
            IdGeneroLiterario = idGeneroLiterario;
            NombreGenero = nombreGenero;
            IdTipoProducto = idTipoProducto;
        }
    }
}
