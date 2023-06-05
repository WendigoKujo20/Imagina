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
    public class ServiceDAO : Connection
    {
        public List<Servicio> ObtenerServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_SERVICIOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_SERVICIOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            Servicio servicio = new Servicio();

                            servicio.IdServicio = reader.GetString(reader.GetOrdinal("ID_SERVICIO"));
                            int estadoLibroOrdinal = reader.GetOrdinal("ESTADO_LIBRO");
                            if (!reader.IsDBNull(estadoLibroOrdinal))
                            {
                                servicio.EstadoLibro = reader.GetString(estadoLibroOrdinal);
                            }
                            else
                            {
                                servicio.EstadoLibro = null;
                            }

                            servicio.RutTecnico = reader.GetString(reader.GetOrdinal("RUT_TECNICO"));

                            int rutClienteOrdinal = reader.GetOrdinal("RUT_CLIENTE");
                            if (!reader.IsDBNull(rutClienteOrdinal))
                            {
                                servicio.RutCliente = reader.GetString(rutClienteOrdinal);
                            }
                            else
                            {
                                servicio.RutCliente = null;
                            }

                            int costoOrdinal = reader.GetOrdinal("COSTO");
                            if (!reader.IsDBNull(costoOrdinal))
                            {
                                servicio.Costo = reader.GetInt32(costoOrdinal);
                            }
                            else
                            {
                                servicio.Costo = null;
                            }

                            servicio.FechaServicio = reader.GetDateTime(reader.GetOrdinal("FECHA_SERVICIO"));
                            servicio.IdTipoServicio = reader.GetInt32(reader.GetOrdinal("ID_TIPO_SERVICIO"));

                            servicios.Add(servicio);
                        }
                    }
                }
            }
            return servicios;
        }

        public bool RegistrarServicio(string idServicio, string estadoLibro, string rutTecnico, string rutCliente, int? costo, DateTime fechaServicio, int idTipoServicio)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_REGISTRO_SERVICIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_SERVICIO", OracleDbType.Varchar2).Value = idServicio;
                    command.Parameters.Add("P_ESTADO_LIBRO", OracleDbType.Varchar2).Value = estadoLibro;
                    command.Parameters.Add("P_RUT_TECNICO", OracleDbType.Varchar2).Value = rutTecnico;
                    command.Parameters.Add("P_RUT_CLIENTE", OracleDbType.Varchar2).Value = rutCliente;
                    command.Parameters.Add("P_COSTO", OracleDbType.Int32).Value = costo;
                    command.Parameters.Add("P_FECHA_SERVICIO", OracleDbType.Date).Value = fechaServicio;
                    command.Parameters.Add("P_ID_TIPO_SERVICIO", OracleDbType.Int32).Value = idTipoServicio;

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

        public bool ModificarServicio(string idServicio, DateTime fechaServicio, int idTipoServicio)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_MODIFICAR_SERVICIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_SERVICIO", OracleDbType.Varchar2).Value = idServicio;
                    command.Parameters.Add("P_FECHA_SERVICIO", OracleDbType.Date).Value = fechaServicio;
                    command.Parameters.Add("P_ID_TIPO_SERVICIO", OracleDbType.Int32).Value = idTipoServicio;

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

        public bool AgregarCosto(string idServicio, int costo)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_AGREGAR_COSTO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_SERVICIO", OracleDbType.Varchar2).Value = idServicio;
                    command.Parameters.Add("P_COSTO", OracleDbType.Int32).Value = costo;

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

        public bool EliminarServicio(string idServicio)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_ELIMINAR_SERVICIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_SERVICIO", OracleDbType.Varchar2).Value = idServicio;

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

        public bool Rechazar(string idServicio)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_RECHAZAR", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_SERVICIO", OracleDbType.Varchar2).Value = idServicio;

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
