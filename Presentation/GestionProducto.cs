using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imagina
{
    public partial class GestionProducto : Form
    {
        public GestionProducto()
        {
            InitializeComponent();
        }

        public string Nombre { get; set; }
        public Image Imagen { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }

        private void GestionProducto_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Nombre;
            CargarImagen();
            CargarGestiones();
        }

        private void CargarGestiones()
        {
            GestionPrecio();
            GestionStock();
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

        private void GestionPrecio()
        {
            lblPrecio.Text = "Precio: " + Precio;
            lblPrecio.Margin = new Padding(0, 12, 0, 0);
            txtPrecio.Visible = false;
            linePrecio.Visible = false;
            editPrecio.Margin = new Padding(0, 0, 10, 0);
        }

        private void editPrecio_Click(object sender, EventArgs e)
        {
            lblPrecio.Text = "Precio: ";
            containerPrecio.Size = new Size(62, 32);
            txtPrecio.Visible = true;
            linePrecio.Visible = true;
            editPrecio.Visible = false;
        }

        private void GestionStock()
        {
            lblStock.Text = "Stock: " + Stock;
            lblStock.Margin = new Padding(0, 12, 0, 0);
            txtStock.Visible = false;
            lineStock.Visible = false;
            editStock.Margin = new Padding(0, 0, 10, 0);
        }

        private void editStock_Click(object sender, EventArgs e)
        {
            lblStock.Text = "Stock: ";
            containerStock.Size = new Size(62, 32);
            txtStock.Visible = true;
            lineStock.Visible = true;
            editStock.Visible = false;
        }
    }
}
