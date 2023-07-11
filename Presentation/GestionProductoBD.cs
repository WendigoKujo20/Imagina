using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Common.Cache;
using Domain;
using System.Drawing.Imaging;

namespace Imagina
{
    public partial class GestionProductoBD : Form
    {
        private string rutaImagenSeleccionada;
        ProductoModel productoModel = new ProductoModel();
        public GestionProductoBD()
        {
            InitializeComponent();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public Image Imagen { get; set; }
        public int? IdGeneroLiterario { get; set; }
        public int IdTipoProducto { get; set; }
        public string NombreImagen { get; set; }

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

        private byte[] ConvertirImgByte(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Obtener el formato de imagen original
                ImageFormat formatoImagen = image.RawFormat;

                image.Save(ms, formatoImagen);

                return ms.ToArray();
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

        private void GestionProductoBD_Load(object sender, EventArgs e)
        {
            cargarDatos();
            CargarImagen();
            RellenarTipos();
            RellenarGeneros();
            CargarTipoProducto(IdTipoProducto);
            if (IdTipoProducto == 1)
            {
                CargarGeneroLiterario(IdGeneroLiterario);
            }
        }

        private void cargarDatos()
        {
            txtNombre.Text = Nombre;
            txtPrecio.Text = Precio.ToString();
            txtStock.Text = Stock.ToString();
            richTxtDesc.Text = Descripcion;
            lblNombreArchivo.Text = NombreImagen;
        }

        private void CargarImagen()
        {
            imgProducto.Image = Imagen;
            imgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            imgProducto.TabStop = false;
        }
        private void RellenarTipos()
        {
            List<TipoProducto> tipos = productoModel.ObtenerTipos();
            foreach (TipoProducto tipoProducto in tipos)
            {
                cboTipoProducto.Items.Add(tipoProducto.Nombre);
            }
        }

        private void CargarTipoProducto(int idTipoProducto)
        {
            List<TipoProducto> tipos = productoModel.ObtenerTipos();
            TipoProducto tipoSeleccionado = tipos.FirstOrDefault(t => t.idTipoProducto == idTipoProducto);
            cboTipoProducto.SelectedItem = tipoSeleccionado?.Nombre;
        }

        private void CargarGeneroLiterario(int? idGeneroLiterario)
        {
            List<GeneroLiterario> generos = productoModel.ObtenerGeneros();
            GeneroLiterario generoSeleccionado = generos.FirstOrDefault(g => g.IdGeneroLiterario == idGeneroLiterario);
            cboGenero.SelectedItem = generoSeleccionado?.Nombre;
            txtAutor.Text = Autor;
        }

        private void RellenarGeneros()
        {
            List<GeneroLiterario> generos = productoModel.ObtenerGeneros();
            foreach (GeneroLiterario genero in generos)
            {
                cboGenero.Items.Add(genero.Nombre);
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
                imagen = ConvertirImgByte(Imagen);
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

            if (txtStock.Text == "Stock")
            {
                error("Debe registrar algo en Stock");
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

            bool modificado = productoModel.ModificarProducto(IdProducto, nombre, autor, descripcion, precio, stock, imagen, idGenero, idTipo);
            if (modificado)
            {
                MessageBox.Show("Producto Modificado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObtenerIdTipo() == 1)
            {
                lineAutor.Visible = true;
                txtAutor.Visible = true;
                cboGenero.Visible = true;
                txtAutor.Text = "Autor";
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
    }
}
