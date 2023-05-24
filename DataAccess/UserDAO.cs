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
                            UserLoginCache.Rut = reader.GetString(reader.GetOrdinal("RUT_USUARIO"));
                            UserLoginCache.PrimerNombre = reader.GetString(reader.GetOrdinal("PRIMER_NOMBRE"));
                            UserLoginCache.SegundoNombre = reader.GetString(reader.GetOrdinal("SEGUNDO_NOMBRE"));
                            UserLoginCache.PrimerApellido = reader.GetString(reader.GetOrdinal("PRIMER_APELLIDO"));
                            UserLoginCache.SegundoApellido = reader.GetString(reader.GetOrdinal("SEGUNDO_APELLIDO"));
                            UserLoginCache.Edad = reader.GetInt32(reader.GetOrdinal("EDAD"));
                            UserLoginCache.Telefono = reader.GetInt32(reader.GetOrdinal("TELEFONO"));
                            UserLoginCache.Correo = reader.GetString(reader.GetOrdinal("CORREO"));
                            UserLoginCache.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                            UserLoginCache.FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FECHA_NACIMIENTO"));
                            UserLoginCache.Direccion = reader.GetString(reader.GetOrdinal("DIRECCION"));
                            UserLoginCache.AniosExperiencia = reader.GetInt32(reader.GetOrdinal("ANIOS_EXPERIENCIA"));
                            UserLoginCache.IdGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO"));
                            UserLoginCache.IdComuna = reader.GetInt32(reader.GetOrdinal("ID_COMUNA"));
                            UserLoginCache.IdEstado = reader.GetInt32(reader.GetOrdinal("ID_ESTADO"));
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
}
