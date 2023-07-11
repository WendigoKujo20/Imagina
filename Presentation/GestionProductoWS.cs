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
    public partial class GestionProductoWS : Form
    {
        ProductModelWS productModel = new ProductModelWS();
        public GestionProductoWS()
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int cantidad = (int)numericStock.Value;
            string mensaje = $"¿Estás seguro que deseas seleccionar {cantidad} libro(s)? Stock disponible: {Stock}";

            DialogResult resultado = MessageBox.Show(mensaje, "Confirmar selección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                productModel.descontarStock(IdProducto, cantidad);
                MessageBox.Show("La cantidad se ha agregado exitosamente", "Solicitud de stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
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
