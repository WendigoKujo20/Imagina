using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class UserModel  
    {
        UserDAO userDao = new UserDAO();

        public bool LoginUser(string correo, string password)
        {
            return userDao.Login(correo, password);
        }

        public List<User> ObtenerUsuarios()
        {
            return userDao.ObtenerUsuarios();
        }

        public User ObtenerUsuario(string Rut)
        {
            return userDao.ObtenerUsuario(Rut);
        }

        public bool RegistrarUsuarios(string rut, string nombre, string apellidos, int telefono, string correo, string password, DateTime fechaNacimiento, string direccion, int aniosExperiencia, int idGenero, int idComuna, int idTipoUsuario)
        {
            return userDao.RegistrarUsuario(rut, nombre, apellidos, telefono, correo, password, fechaNacimiento, direccion, aniosExperiencia, idGenero, idComuna, idTipoUsuario);
        }

        public bool ModificarUsuario(string rut, string nombre, string apellidos, int telefono, string correo, string password, DateTime fechaNacimiento, string direccion, int aniosExperiencia, int idGenero, int idComuna, int idTipoUsuario)
        {
            return userDao.ModificarUsuario(rut, nombre, apellidos, telefono, correo, password, fechaNacimiento, direccion, aniosExperiencia, idGenero, idComuna, idTipoUsuario);
        }

        public bool EliminarUsuario(string rut)
        {
            return userDao.EliminarUsuario(rut); 
        }

        public List<Comuna> ObtenerComunas()
        {
            return userDao.ObtenerComunas();
        }

        public List<Region> ObtenerRegiones()
        {
            return userDao.ObtenerRegiones();
        }

        public List<Genero> ObtenerGeneros()
        {
            return userDao.ObtenerGeneros();
        }

        public List<TipoUsuario> ObtenerTipos()
        {
            return userDao.ObtenerTipos();
        }
    }
}
