using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Common.Cache;

namespace Imagina
{
    public partial class GestionProductoWS : Form
    {
        ProductModelWS productModelWS = new ProductModelWS();
        ProductoModel productModelBD = new ProductoModel();
        public GestionProductoWS()
        {
            InitializeComponent();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public Image Imagen { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int? IdGeneroLiterario { get; set; }
        public int IdTipoProducto { get; set; }

        private void GestionProducto_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Nombre;
            lblStock.Text = lblStock.Text+Stock;
            CargarImagen();
            cargarNumeric();
        }

        private void cargarNumeric()
        {
            numericStock.Minimum = 1;
            numericStock.Maximum = Stock;
        }

        private void CargarImagen()
        {
            imgProducto.Image = Imagen;
            imgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            imgProducto.TabStop = false;
        }

        public static byte[] ImagenByte(Image imagen)
        {
            byte[] bytesImagen;
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, imagen.RawFormat);
                bytesImagen = ms.ToArray();
            }
            return bytesImagen;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cantidad = (int)numericStock.Value;
            string mensaje = $"¿Estás seguro que deseas seleccionar {cantidad} libro(s)? Stock disponible: {Stock}";
            int? idGenero;
            string autor = string.IsNullOrEmpty(Autor) ? null : Autor;
            byte[] imagen = ImagenByte(Imagen);
            int idTipo;

            DialogResult resultado = MessageBox.Show(mensaje, "Confirmar selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Producto productoExiste = productModelBD.ObtenerProducto(IdProducto);
                productModelWS.descontarStock(IdProducto, cantidad);
                bool generoExiste = false;

                if (productoExiste != null) 
                {
                    var nuevostock = productoExiste.Stock + cantidad;
                    productModelBD.DescontarStock(IdProducto, nuevostock);
                    MessageBox.Show("La cantidad se ha agregado exitosamente", "Solicitudd de stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    if (IdGeneroLiterario == null)
                    {
                        idGenero = -1;
                        productModelBD.RegistrarProductosWS(IdProducto, Nombre, autor, Descripcion, Precio, cantidad, imagen, idGenero, IdTipoProducto);
                        MessageBox.Show("La cantidad se ha agregado exitosamente", "Solicitud de stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        var generos = productModelBD.ObtenerGeneros();
                        foreach (GeneroLiterario genero in generos)
                        {
                            if (genero.IdGeneroLiterario == IdGeneroLiterario)
                            {
                                generoExiste = true;
                                break;
                            }
                        }
                    }

                    idGenero = generoExiste ? IdGeneroLiterario : 0;

                    productModelBD.RegistrarProductosWS(IdProducto, Nombre, autor, Descripcion, Precio, cantidad, imagen, idGenero, IdTipoProducto);
                    MessageBox.Show("La cantidad se ha agregado exitosamente", "Solicitud de stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
