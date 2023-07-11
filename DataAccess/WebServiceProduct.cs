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
                    producto.NombreTipo = ObtenerNombreTipo(producto.IdTipoProducto);
                    if (producto.IdGeneroLiterario.HasValue)
                    {
                        string nombreGenero = ObtenerNombreGenero(producto.IdGeneroLiterario.Value);
                        producto.NombreGenero = nombreGenero;
                    }
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

        private string ObtenerNombreTipo(int idTipo)
        {
            HttpResponseMessage response = cliente.GetAsync("TipoProducto/" + idTipo).Result;

            if (response.IsSuccessStatusCode)
            {
                var cadena = response.Content.ReadAsStringAsync().Result;
                var tipoProduto = JsonConvert.DeserializeObject<TipoProducto>(cadena);
                return tipoProduto.Nombre;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool descontarStock(int productoId, int cantidad, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
                var data = new { cantidad = cantidad };
                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync($"http://127.0.0.1:8000/Libros/{productoId}/descontar-stock/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("El stock se ha modificado correctamente.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error al modificar el stock. Código de estado: " + response.StatusCode);
                    return false;
                }
            }
        }

    }
}
