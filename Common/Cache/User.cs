using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class User
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int AniosExperiencia { get; set; }
        public int IdGenero { get; set; }
        public int IdComuna { get; set; }
        public string NombreComuna { get; set; }
        public int IdTipoUsuario { get; set; }

        public User()
        {
        }

        public User(string rut, string nombre, string apellidos, int telefono, string correo, string password, DateTime fechaNacimiento, string direccion, int aniosExperiencia, int idGenero, int idComuna, string nombreComuna, int idTipoUsuario)
        {
            Rut = rut;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Correo = correo;
            Password = password;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            AniosExperiencia = aniosExperiencia;
            IdGenero = idGenero;
            IdComuna = idComuna;
            NombreComuna = nombreComuna;
            IdTipoUsuario = idTipoUsuario;
        }
    }
}
