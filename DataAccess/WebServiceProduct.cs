using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Cache;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace DataAccess
{
    public class WebServiceProduct
    {
        private HttpClient cliente;

        public WebServiceProduct()
        {
            cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://127.0.0.1:8000/");
        }
        public List<Producto> ObtenerProductos()
        {
            HttpResponseMessage response = cliente.GetAsync("Libros/").Result;

            if (response.IsSuccessStatusCode)
            {
                var cadena = response.Content.ReadAsStringAsync().Result;
                var productos = JsonConvert.DeserializeObject<List<Producto>>(cadena);

                foreach (var producto in productos)
                {
                    string nombreGenero = ObtenerNombreGenero(producto.IdGeneroLiterario);
                    producto.NombreGenero = nombreGenero;
                }

                return productos;
            }
            else
            {
                return null;
            }
        }

        private string ObtenerNombreGenero(int idGeneroLiterario)
        {
            HttpResponseMessage response = cliente.GetAsync("GeneroLiterario/" + idGeneroLiterario).Result;

            if (response.IsSuccessStatusCode)
            {
                var cadena = response.Content.ReadAsStringAsync().Result;
                var generoLiterario = JsonConvert.DeserializeObject<GeneroLiterario>(cadena);
                return generoLiterario.Nombre;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
