using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Imagina
{
    public partial class GestionProducto : Form
    {
        ProductModel productModel = new ProductModel();
        public GestionProducto()
        {
            InitializeComponent();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public Image Imagen { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }

        private void GestionProducto_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Nombre;
            CargarImagen();
        }

        private void CargarImagen()
        {
            imgProducto.Image = Imagen;
            imgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            imgProducto.TabStop = false;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string costoText = txtPrecio.Text;
            int costo;
            bool exitoCosto = int.TryParse(costoText, out costo);

            string stockText = txtStock.Text;
            int stock;
            bool exitoStock = int.TryParse(costoText, out stock);

            if (exitoCosto)
            {
                if (exitoStock)
                {
                    bool modificar = productModel.ModificarProducto(IdProducto, costo, stock);
                    if (modificar)
                    {
                        Close();
                    }
                    else error("No se pudo modificar");
                }
                else error("Debe introducir un stock para el servicio");
            }
            else error("Debe introducir un costo para el servicio");
        }

        private void error(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
