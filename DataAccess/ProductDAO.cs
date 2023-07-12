using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Cache;
using System.Data;
using Oracle.DataAccess.Types;

namespace DataAccess
{
    public class ProductDAO : Connection
    {
        public List<Producto> listarProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_PRODUCTOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_USUARIOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.IdProducto = reader.GetInt32(reader.GetOrdinal("ID_PRODUCTO"));
                            producto.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                            int autorOrdinal = reader.GetOrdinal("AUTOR");
                            if (!reader.IsDBNull(autorOrdinal))
                            {
                                producto.Autor = reader.GetString(autorOrdinal);
                            }
                            else
                            {
                                producto.Autor = null;
                            }
                            producto.Descripcion = reader.GetString(reader.GetOrdinal("DESCRIPCION"));
                            producto.Precio = reader.GetInt32(reader.GetOrdinal("PRECIO"));
                            producto.Stock = reader.GetInt32(reader.GetOrdinal("STOCK"));
                            OracleBlob blob = reader.GetOracleBlob(reader.GetOrdinal("IMAGEN"));
                            byte[] blobBytes = new byte[blob.Length];
                            blob.Read(blobBytes, 0, (int)blob.Length);
                            string base64Image = Convert.ToBase64String(blobBytes);
                            producto.Imagen = base64Image;
                            if (!reader.IsDBNull(reader.GetOrdinal("ID_GENERO_LITERARIO")))
                            {
                                int idGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO_LITERARIO"));
                                producto.IdGeneroLiterario = idGenero;
                                producto.NombreGenero = ObtenerNombreGeneroLiterario(idGenero);
                            }
                            int idTipoProducto = reader.GetInt32(reader.GetOrdinal("ID_TIPO_PRODUCTO"));
                            producto.IdTipoProducto = idTipoProducto;
                            producto.NombreTipo = ObtenerNombreTipoProducto(idTipoProducto);

                            productos.Add(producto);
                        }
                    }
                }
                return productos;
            }
        }

        public bool RegistrarProducto(string nombre, string autor, string descripcion, int precio, int stock, Byte[] imagen, int idGenero, int idTipo)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_REGISTRAR_PRODUCTO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add("P_AUTOR", OracleDbType.Varchar2).Value = autor;
                    command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                    command.Parameters.Add("P_PRECIO", OracleDbType.Int32).Value = precio;
                    command.Parameters.Add("P_STOCK", OracleDbType.Int32).Value = stock;
                    command.Parameters.Add("P_IMAGEN", OracleDbType.Blob).Value = new OracleBinary(imagen);
                    if (idGenero == -1)
                    {
                        command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idGenero;
                    }
                    command.Parameters.Add("P_ID_TIPO", OracleDbType.Int32).Value = idTipo;


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

        public List<GeneroLiterario> ObtenerGenerosLiterarios()
        {
            List<GeneroLiterario> generos = new List<GeneroLiterario>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_GENERO_LITERARIOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_GENERO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            GeneroLiterario generoLiterario = new GeneroLiterario();
                            generoLiterario.IdGeneroLiterario = reader.GetInt32(reader.GetOrdinal("ID_GENERO_LITERARIO"));
                            generoLiterario.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));

                            generos.Add(generoLiterario);
                        }
                    }
                }
            }
            return generos;
        }

        public List<TipoProducto> ObtenerTiposProductos()
        {
            List<TipoProducto> tipoProductos = new List<TipoProducto>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_TIPO_PRODUCTOS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("DATOS_TIPO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            TipoProducto tipoProducto = new TipoProducto();
                            tipoProducto.idTipoProducto = reader.GetInt32(reader.GetOrdinal("ID_TIPO_PRODUCTO"));
                            tipoProducto.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));

                            tipoProductos.Add(tipoProducto);
                        }
                    }
                }
            }
            return tipoProductos;
        }

        public string ObtenerNombreGeneroLiterario(int idGenero)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_NOMBRE_GENERO_LITETARIO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idGenero;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    return command.Parameters["P_NOMBRE"].Value.ToString();
                }
            }
        }

        public string ObtenerNombreTipoProducto(int idTipo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_NOMBRE_TIPO_PRODUCTO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idTipo;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    return command.Parameters["P_NOMBRE"].Value.ToString();
                }
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_ELIMINAR_PRODUCTO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_PRODUCTO", OracleDbType.Varchar2).Value = idProducto;

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

        public bool ModificarProducto(int idProducto, string nombre, string autor, string descripcion, int precio, int stock, byte[] imagen, int idGeneroLiterario, int idTipoProducto)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_MODIFICAR_PRODUCTO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_PRODUCTO", OracleDbType.Int32).Value = idProducto;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add("P_AUTOR", OracleDbType.Varchar2).Value = autor;
                    command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                    command.Parameters.Add("P_PRECIO", OracleDbType.Int32).Value = precio;
                    command.Parameters.Add("P_STOCK", OracleDbType.Int32).Value = stock;
                    command.Parameters.Add("P_IMAGEN", OracleDbType.Blob).Value = imagen;
                    if (idGeneroLiterario == -1)
                    {
                        command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idGeneroLiterario;
                    }
                    command.Parameters.Add("P_ID_TIPO_PRODUCTO", OracleDbType.Int32).Value = idTipoProducto;

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

        public Producto ObtenerProducto(int idProducto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_OBTENER_PRODUCTO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_PRODUCTO", OracleDbType.Varchar2).Value = idProducto;
                    OracleParameter datosProductoParameter = new OracleParameter("DATOS_PRODUCTO", OracleDbType.RefCursor);
                    datosProductoParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(datosProductoParameter);
                    using (OracleDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                        if (reader.Read())
                        {
                            Producto producto = new Producto();

                            producto.IdProducto = reader.GetInt32(reader.GetOrdinal("ID_PRODUCTO"));
                            producto.Nombre = reader.GetString(reader.GetOrdinal("NOMBRE"));
                            int autorOrdinal = reader.GetOrdinal("AUTOR");
                            if (!reader.IsDBNull(autorOrdinal))
                            {
                                producto.Autor = reader.GetString(autorOrdinal);
                            }
                            else
                            {
                                producto.Autor = null;
                            }
                            producto.Descripcion = reader.GetString(reader.GetOrdinal("DESCRIPCION"));
                            producto.Precio = reader.GetInt32(reader.GetOrdinal("PRECIO"));
                            producto.Stock = reader.GetInt32(reader.GetOrdinal("STOCK"));
                            OracleBlob blob = reader.GetOracleBlob(reader.GetOrdinal("IMAGEN"));
                            byte[] blobBytes = new byte[blob.Length];
                            blob.Read(blobBytes, 0, (int)blob.Length);
                            string base64Image = Convert.ToBase64String(blobBytes);
                            producto.Imagen = base64Image;
                            if (!reader.IsDBNull(reader.GetOrdinal("ID_GENERO_LITERARIO")))
                            {
                                int idGenero = reader.GetInt32(reader.GetOrdinal("ID_GENERO_LITERARIO"));
                                producto.IdGeneroLiterario = idGenero;
                                producto.NombreGenero = ObtenerNombreGeneroLiterario(idGenero);
                            }
                            int idTipoProducto = reader.GetInt32(reader.GetOrdinal("ID_TIPO_PRODUCTO"));
                            producto.IdTipoProducto = idTipoProducto;
                            producto.NombreTipo = ObtenerNombreTipoProducto(idTipoProducto);

                            return producto;
                        }
                        else return null;
                    }
                }
            }
        }

        public bool DescontarStock(int idProducto, int nuevoStock)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_DESCONTAR_STOCK", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_PRODUCTO", OracleDbType.Int32).Value = idProducto;
                    command.Parameters.Add("P_NUEVO_STOCK", OracleDbType.Int32).Value = nuevoStock;

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

        public bool RegistrarProductoWS(int id, string nombre, string autor, string descripcion, int precio, int stock, Byte[] imagen, int? idGenero, int idTipo)
        {
            bool exito = false;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand("SP_REGISTRAR_PRODUCTO_WS", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("P_ID_PRODUCTO", OracleDbType.Int32).Value = id;
                    command.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add("P_AUTOR", OracleDbType.Varchar2).Value = autor;
                    command.Parameters.Add("P_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                    command.Parameters.Add("P_PRECIO", OracleDbType.Int32).Value = precio;
                    command.Parameters.Add("P_STOCK", OracleDbType.Int32).Value = stock;
                    command.Parameters.Add("P_IMAGEN", OracleDbType.Blob).Value = new OracleBinary(imagen);
                    if (idGenero == -1)
                    {
                        command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("P_ID_GENERO", OracleDbType.Int32).Value = idGenero;
                    }
                    command.Parameters.Add("P_ID_TIPO", OracleDbType.Int32).Value = idTipo;


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
