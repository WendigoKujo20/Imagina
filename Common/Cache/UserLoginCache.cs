﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class UserLoginCache
    {
        public static string Rut { get; set; }
        public static string Nombre { get; set; }
        public static string Apellidos { get; set; }
        public static int Telefono { get; set; }
        public static string Correo { get; set; }
        public static string Password { get; set; }
        public static DateTime FechaNacimiento { get; set; }
        public static string Direccion { get; set; }
        public static int AniosExperiencia { get; set; }
        public static int IdGenero { get; set; }
        public static int IdComuna { get; set; }
        public static int IdTipoUsuario { get; set; }
    }
}
