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
                            Console.WriteLine(usuario.Nombre);
                        }
                    }      
                }
            }
            return usuarios;
        }

    }
}
