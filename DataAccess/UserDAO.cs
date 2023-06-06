using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using Common.Cache;
using System.Collections;

namespace DataAccess
{
    public class UserDAO : Connection
    {
        public bool Login(string correo, string password)
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_USUARIO_LOGIN", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_CORREO", OracleDbType.Varchar2).Value = correo;
                    command.Parameters.Add("P_PASSWORD", OracleDbType.Varchar2).Value = password;
                    command.Parameters.Add("DATOS_USUARIO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserLoginCache.Rut = reader.GetString(reader.GetOrdinal("RUT"));
                                UserLoginCache.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                                UserLoginCache.Apellidos = reader.GetString(reader.GetOrdinal("APELLIDOS"));
                                UserLoginCache.Telefono = reader.GetInt32(reader.GetOrdinal("TELEFONO"));
                                UserLoginCache.Correo = reader.GetString(reader.GetOrdinal("CORREO"));
                                UserLoginCache.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                                UserLoginCache.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FECHA_NACIMIENTO"));
                                UserLoginCache.Direccion = reader.GetString(reader.GetOrdinal("DIRECCION"));
                                UserLoginCache.AniosExperiencia = reader.GetInt32(reader.GetOrdinal("ANIOS_EXPERIENCIA"));
                                UserLoginCache.IdGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO"));
                                UserLoginCache.IdComuna = reader.GetInt32(reader.GetOrdinal("ID_COMUNA"));
                                UserLoginCache.IdTipoUsuario = reader.GetInt32(reader.GetOrdinal("ID_TIPO_USUARIO"));
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

        }

        public List<User> ObtenerUsuarios()
        {
            List<User> usuarios = new List<User>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_USUARIOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_USUARIOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            User usuario = new User();

                            usuario.Rut = reader.GetString(reader.GetOrdinal("RUT"));
                            usuario.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                            usuario.Apellidos = reader.GetString(reader.GetOrdinal("APELLIDOS"));
                            usuario.Telefono = reader.GetInt32(reader.GetOrdinal("TELEFONO"));
                            usuario.Correo = reader.GetString(reader.GetOrdinal("CORREO"));
                            usuario.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                            usuario.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FECHA_NACIMIENTO"));
                            usuario.Direccion = reader.GetString(reader.GetOrdinal("DIRECCION"));
                            usuario.AniosExperiencia = reader.GetInt32(reader.GetOrdinal("ANIOS_EXPERIENCIA"));
                            usuario.IdGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO"));
                            usuario.IdComuna = reader.GetInt32(reader.GetOrdinal("ID_COMUNA"));
                            usuario.IdTipoUsuario = reader.GetInt32(reader.GetOrdinal("ID_TIPO_USUARIO"));

                            usuarios.Add(usuario);
                        }
                    }      
                }
            }
            return usuarios;
        }

        //Probablemente lo usare despues para la navbar
        public User ObtenerUsuario(string rut)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using(var command = new OracleCommand("SP_OBTENER_USUARIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = rut;
                    command.Parameters.Add("DATOS_USUARIO", OracleDbType.RefCursor).Value = ParameterDirection.Output;
                    using(OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        if (reader.Read())
                        {
                            User usuario = new User();

                            usuario.Rut = reader.GetString(reader.GetOrdinal("RUT"));
                            usuario.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                            usuario.Apellidos = reader.GetString(reader.GetOrdinal("APELLIDOS"));
                            usuario.Telefono = reader.GetInt32(reader.GetOrdinal("TELEFONO"));
                            usuario.Correo = reader.GetString(reader.GetOrdinal("CORREO"));
                            usuario.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                            usuario.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FECHA_NACIMIENTO"));
                            usuario.Direccion = reader.GetString(reader.GetOrdinal("DIRECCION"));
                            usuario.AniosExperiencia = reader.GetInt32(reader.GetOrdinal("ANIOS_EXPERIENCIA"));
                            usuario.IdGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO"));
                            usuario.IdComuna = reader.GetInt32(reader.GetOrdinal("ID_COMUNA"));
                            usuario.IdTipoUsuario = reader.GetInt32(reader.GetOrdinal("ID_TIPO_USUARIO"));

                            return usuario;
                        }
                        else return null;
                    }
                }
            }
        }

        public bool RegistrarUsuario(string rut, string nombre, string apellidos, int telefono, string correo, string password, DateTime fechaNacimiento, string direccion, int aniosExperiencia, int idGenero, int idComuna, int idTipoUsuario)
        {
            bool exito = false;

            using(var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_REGISTRO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = rut;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add("P_APELLIDOS", OracleDbType.Varchar2).Value = apellidos;
                    command.Parameters.Add("P_TELEFONO", OracleDbType.Int32).Value = telefono;
                    command.Parameters.Add("P_CORREO", OracleDbType.Varchar2).Value = correo;
                    command.Parameters.Add("P_PASSWORD", OracleDbType.Varchar2).Value = password;
                    command.Parameters.Add("P_FECHA_NACIMIENTO", OracleDbType.Date).Value = fechaNacimiento;
                    command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2).Value = direccion;
                    command.Parameters.Add("P_ANIOS_EXPERIENCIA", OracleDbType.Int32).Value = aniosExperiencia;
                    command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idGenero;
                    command.Parameters.Add("P_ID_COMUNA", OracleDbType.Int32).Value = idComuna;
                    command.Parameters.Add("P_TIPO_USUARIO", OracleDbType.Int32).Value = idTipoUsuario;

                    try
                    {
                        command.ExecuteNonQuery();
                        exito = true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return exito;
        }

        public bool ModificarUsuario(string rut, string nombre, string apellidos, int telefono, string correo, string password, DateTime fechaNacimiento, string direccion, int aniosExperiencia, int idGenero, int idComuna, int idTipoUsuario)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_MODIFICAR_USUARIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = rut;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add("P_APELLIDOS", OracleDbType.Varchar2).Value = apellidos;
                    command.Parameters.Add("P_TELEFONO", OracleDbType.Int32).Value = telefono;
                    command.Parameters.Add("P_CORREO", OracleDbType.Varchar2).Value = correo;
                    command.Parameters.Add("P_PASSWORD", OracleDbType.Varchar2).Value = password;
                    command.Parameters.Add("P_FECHA_NACIMIENTO", OracleDbType.Date).Value = fechaNacimiento;
                    command.Parameters.Add("P_DIRECCION", OracleDbType.Varchar2).Value = direccion;
                    command.Parameters.Add("P_ANIOS_EXPERIENCIA", OracleDbType.Int32).Value = aniosExperiencia;
                    command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idGenero;
                    command.Parameters.Add("P_ID_COMUNA", OracleDbType.Int32).Value = idComuna;
                    command.Parameters.Add("P_TIPO_USUARIO", OracleDbType.Int32).Value = idTipoUsuario;

                    try
                    {
                        command.ExecuteNonQuery();
                        exito = true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return exito;
        }

        public bool EliminarUsuario(string rut)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_ELIMINAR_USUARIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = rut;

                    try
                    {
                        command.ExecuteNonQuery();
                        exito = true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return exito;
        }
    }
}
