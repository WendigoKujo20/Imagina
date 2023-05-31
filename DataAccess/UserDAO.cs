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
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default);
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

        public List<> ObtenerUsuarios()
        {
            List<UsersCache> usuarios = new List<UsersCache>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_USUARIOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_USUARIOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                    while (reader.Read())
                    {
                        String Rut = reader.GetString(reader.GetOrdinal("RUT"));
                        String Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                        String Apellidos = reader.GetString(reader.GetOrdinal("APELLIDOS"));
                        int Telefono = reader.GetInt32(reader.GetOrdinal("TELEFONO"));
                        String Correo = reader.GetString(reader.GetOrdinal("CORREO"));
                        String Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                        DateTime FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FECHA_NACIMIENTO"));
                        String Direccion = reader.GetString(reader.GetOrdinal("DIRECCION"));
                        int AniosExperiencia = reader.GetInt32(reader.GetOrdinal("ANIOS_EXPERIENCIA"));
                        int IdGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO"));
                        int IdComuna = reader.GetInt32(reader.GetOrdinal("ID_COMUNA"));
                        int IdTipoUsuario = reader.GetInt32(reader.GetOrdinal("ID_TIPO_USUARIO"));

                        UsersCache usuario = new UsersCache(Rut, Nombre, Apellidos, Telefono, Correo, Password, FechaNacimiento, Direccion, AniosExperiencia, IdGenero, IdComuna, IdTipoUsuario);
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

    }
}
