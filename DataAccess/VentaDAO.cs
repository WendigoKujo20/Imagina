using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using Common.Cache;

namespace DataAccess
{
    public class VentaDAO : Connection
    {
        public List<Carrito> ObtenerCarritos()
        {
            List<Carrito> carritos = new List<Carrito>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_CARRITOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_CARRITOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            Carrito carrito = new Carrito();

                            carrito.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                            carrito.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                            carrito.Rut = reader.GetString(reader.GetOrdinal("RUT"));
                            carrito.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                            carrito.Precio = reader.GetInt32(reader.GetOrdinal("PRECIO"));
                            carrito.Cantidad = reader.GetInt32(reader.GetOrdinal("CANTIDAD"));
                            carritos.Add(carrito);
                        }
                    }
                }
            }
            return carritos;
        }

        public bool EliminarCarrito(int idCarrito)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_ELIMINAR_CARRITO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID", OracleDbType.Varchar2).Value = idCarrito;

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

        public bool RegistrarCarrito(int codigo, string rut, string nombre, int precio, int cantidad)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_REGISTRAR_CARRITO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_CODIGO", OracleDbType.Int32).Value = codigo;
                    command.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = rut;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add("P_PRECIO", OracleDbType.Int32).Value = precio;
                    command.Parameters.Add("P_CANTIDAD", OracleDbType.Int32).Value = cantidad;


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

        public bool RegistrarVenta(int orden, string rut, int total, DateTime fecha)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_REGISTRAR_VENTA", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ORDEN", OracleDbType.Int32).Value = orden;
                    command.Parameters.Add("P_RUT", OracleDbType.Varchar2).Value = rut;
                    command.Parameters.Add("P_PRECIO", OracleDbType.Int32).Value = total;
                    command.Parameters.Add("P_FECHA", OracleDbType.Date).Value = fecha;

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

        public List<Venta> ObtenerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_VENTAS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_VENTAS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta();

                            venta.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                            venta.Orden = reader.GetInt32(reader.GetOrdinal("ORDEN"));
                            venta.Rut = reader.GetString(reader.GetOrdinal("RUT"));
                            venta.PrecioTotal = reader.GetInt32(reader.GetOrdinal("PRECIOTOTAL"));
                            venta.Fecha = reader.GetDateTime(reader.GetOrdinal("FECHA"));

                            ventas.Add(venta);
                        }
                    }
                }
            }
            return ventas;
        }

        public Carrito ObtenerCarrito(int idCarrito)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_CARRITO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID", OracleDbType.Varchar2).Value = idCarrito;
                    OracleParameter datosProductoParameter = new OracleParameter("DATOS_CARRITO", OracleDbType.RefCursor);
                    datosProductoParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(datosProductoParameter);
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        if (reader.Read())
                        {
                            Carrito carrito = new Carrito();

                            carrito.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                            carrito.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                            carrito.Rut = reader.GetString(reader.GetOrdinal("RUT"));
                            carrito.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                            carrito.Precio = reader.GetInt32(reader.GetOrdinal("PRECIO"));
                            carrito.Cantidad = reader.GetInt32(reader.GetOrdinal("CANTIDAD"));

                            return carrito;
                        }
                        else return null;
                    }
                }
            }
        }
    }
}
