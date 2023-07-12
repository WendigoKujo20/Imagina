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
using Common.Cache;
using System.IO;

namespace Imagina
{
    public partial class RegistroProducto : Form
    {
        private string rutaImagenSeleccionada;
        ProductoModel productoModel = new ProductoModel();
        public RegistroProducto()
        {
            InitializeComponent();
            RellenarGeneros();
            RellenarTipos();
        }

        private void RellenarGeneros()
        {
            List<GeneroLiterario> generos = productoModel.ObtenerGeneros();
            foreach (GeneroLiterario genero in generos)
            {
                cboGenero.Items.Add(genero.Nombre);
            }
        }

        private void RellenarTipos()
        {
            List<TipoProducto> tipos = productoModel.ObtenerTipos();
            foreach (TipoProducto tipoProducto in tipos)
            {
                cboTipoProducto.Items.Add(tipoProducto.Nombre);
            }
        }

        private int ObtenerIdTipo()
        {
            if (cboTipoProducto.SelectedItem != null)
            {
                List<TipoProducto> tipos = productoModel.ObtenerTipos();

                foreach (TipoProducto tipo in tipos)
                {
                    if (cboTipoProducto.SelectedItem.ToString() == tipo.Nombre)
                    {
                        return tipo.idTipoProducto;
                    }
                }
            }
            return -1;
        }

        private int ObtenerIdGenero()
        {
            if (cboGenero.SelectedItem != null)
            {
                List<GeneroLiterario> generos = productoModel.ObtenerGeneros();

                foreach (GeneroLiterario genero in generos)
                {
                    if (cboGenero.SelectedItem.ToString() == genero.Nombre)
                    {
                        return genero.IdGeneroLiterario;
                    }
                }
            }
            return -1;
        }

        private void cboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObtenerIdTipo() == 1)
            {
                lineAutor.Visible = true;
                txtAutor.Visible = true;
                cboGenero.Visible = true;
            }
            else
            {
                lineAutor.Visible = false;
                txtAutor.Visible = false;
                cboGenero.Visible = false;
                txtAutor.Text = string.Empty;
                cboGenero.SelectedItem = null;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre Producto")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre Producto";
            }
        }

        private void txtAutor_Enter(object sender, EventArgs e)
        {
            if (txtAutor.Text == "Autor")
            {
                txtAutor.Text = "";
            }
        }

        private void txtAutor_Leave(object sender, EventArgs e)
        {
            if (txtAutor.Text == "")
            {
                txtAutor.Text = "Autor";
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "Precio")
            {
                txtPrecio.Text = "";
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "Precio";
            }
        }

        private void txtStock_Enter(object sender, EventArgs e)
        {
            if (txtStock.Text == "Stock")
            {
                txtStock.Text = "";
            }
        }

        private void txtStock_Leave(object sender, EventArgs e)
        {
            if (txtStock.Text == "")
            {
                txtStock.Text = "Stock";
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            fileImagen.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (fileImagen.ShowDialog() == DialogResult.OK)
            {
                rutaImagenSeleccionada = fileImagen.FileName;
                lblNombreArchivo.Text = Path.GetFileName(rutaImagenSeleccionada);
            }
        }

        public byte[] ConvertirByte(string imagePath)
        {
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            int precio;
            int stock;
            string descripcion = richTxtDesc.Text;
            int idTipo;
            string autor = string.IsNullOrEmpty(txtAutor.Text) ? null : txtAutor.Text;
            int idGenero;
            byte[] imagen;

            if (!string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                imagen = ConvertirByte(rutaImagenSeleccionada);
            }
            else
            {
                imagen = null;
            }

            if (nombre == "Nombre Producto" || nombre.Length > 50)
            {
                error("El Nombre debe tener entre 1 y 50 caracteres.");
                return;
            }

            if (txtPrecio.Text == "Precio")
            {
                error("El Producto debe tener un Precio.");
                return;
            }
            else
            {
                precio = int.Parse(txtPrecio.Text);
            }

            if (txtStock.Text == "Stock" || txtStock.Text == "0")
            {
                error("El Producto debe tener al menos 1 de Stock.");
                return;
            }
            else
            {
                stock = int.Parse(txtStock.Text);
            }

            if (descripcion.Length < 1 || descripcion.Length > 200)
            {
                error("La Descripcion debe tener entre 1 y 200 caracteres.");
                return;
            }

            if (cboTipoProducto.SelectedItem == null)
            {
                error("Debe seleccionar un Tipo de Producto.");
                return;
            }
            else
            {
                idTipo = ObtenerIdTipo();
            }

            if (idTipo == 1 && autor == "Autor")
            {
                error("Debe escribir un Autor.");
                return;
            }

            if (idTipo == 1 && ObtenerIdGenero() == -1)
            {
                error("Debe seleccionar un Género Literario.");
                return;
            }
            else
            {
                idGenero = ObtenerIdGenero();
            }

            bool registrado = productoModel.RegistrarProductos(nombre, autor, descripcion, precio, stock, imagen, idGenero, idTipo);
            if (registrado)
            {
                MessageBox.Show("Producto Registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void error(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
