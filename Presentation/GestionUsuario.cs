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
    public partial class GestionUsuario : Form
    {
        public GestionUsuario()
        {
            InitializeComponent();
        }

        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int AniosExperiencia { get; set; }
        public string Genero { get; set; }
        public int IdComuna { get; set; }
        public string TipoUsuario { get; set; }

        private void GestionUsuario_Load(object sender, EventArgs e)
        {
            cargarGestiones();
        }

        private void cargarGestiones()
        {
            GestionRut();
            GestionNombre();
            GestionApellidos();
            GestionTelefono();
            GestionCorreo();
            GestionDireccion();
            GestionFechaNac();
            GestionGenero();
            GestionComuna();
            GestionTipoUsuario();
            GestionAnios();
        }

        private void GestionRut()
        {
            lblRut.Text = "Rut: " + Rut;
            lblRut.Margin = new Padding(0, 12, 0, 0);
            txtRut.Visible = false;
            lineRut.Visible = false;
            editRut.Margin = new Padding(0, 0, 10, 0);
        }

        private void editRut_Click(object sender, EventArgs e)
        {
            lblRut.Text = "Rut: ";
            containerRut.Size = new Size(38, 29);
            txtRut.Visible = true;
            lineRut.Visible = true;
            editRut.Visible = false;
        }

        private void GestionNombre()
        {
            lblNombre.Text = "Nombre: " + Nombre;
            lblNombre.Margin = new Padding(0, 12, 0, 0);
            txtNombre.Visible = false;
            lineNombre.Visible = false;
            editNombre.Margin = new Padding(0, 0, 10, 0);
        }

        private void editNombre_Click(object sender, EventArgs e)
        {
            lblNombre.Text = "Nombre: ";
            containerNombre.Size = new Size(67, 29);
            txtNombre.Visible = true;
            lineNombre.Visible = true;
            editNombre.Visible = false;
        }

        private void GestionApellidos()
        {
            lblApellidos.Text = "Apellidos: " + Apellidos;
            lblApellidos.Margin = new Padding(0, 12, 0, 0);
            txtApellidos.Visible = false;
            lineApellidos.Visible = false;
            editApellidos.Margin = new Padding(0, 0, 10, 0);
        }

        private void editApellidos_Click(object sender, EventArgs e)
        {
            lblApellidos.Text = "Apellidos: ";
            containerApellidos.Size = new Size(75, 29);
            txtApellidos.Visible = true;
            lineApellidos.Visible = true;
            editApellidos.Visible = false;
        }
        private void GestionTelefono()
        {
            lblTelefono.Text = "Telefono: " + Telefono;
            lblTelefono.Margin = new Padding(0, 12, 0, 0);
            txtTelefono.Visible = false;
            lineTelefono.Visible = false;
            editTelefono.Margin = new Padding(0, 0, 10, 0);
        }

        private void editTelefono_Click(object sender, EventArgs e)
        {
            lblTelefono.Text = "Telefono: ";
            containerTelefono.Size = new Size(76, 29);
            txtTelefono.Visible = true;
            lineTelefono.Visible = true;
            editTelefono.Visible = false;
        }
        private void GestionCorreo()
        {
            lblCorreo.Text = "Correo: " + Correo;
            lblCorreo.Margin = new Padding(0, 12, 0, 0);
            txtCorreo.Visible = false;
            lineCorreo.Visible = false;
            editCorreo.Margin = new Padding(0, 0, 10, 0);
        }

        private void editCorreo_Click(object sender, EventArgs e)
        {
            lblCorreo.Text = "Correo: ";
            containerCorreo.Size = new Size(76, 29);
            txtCorreo.Visible = true;
            lineCorreo.Visible = true;
            editCorreo.Visible = false;
        }
        private void GestionDireccion()
        {
            lblDireccion.Text = "Direccion: " + Direccion;
            lblDireccion.Margin = new Padding(0, 12, 0, 0);
            txtDireccion.Visible = false;
            lineDireccion.Visible = false;
            editDireccion.Margin = new Padding(0, 0, 10, 0);
        }

        private void editDireccion_Click(object sender, EventArgs e)
        {
            lblDireccion.Text = "Direccion: ";
            containerDireccion.Size = new Size(76, 29);
            txtDireccion.Visible = true;
            lineDireccion.Visible = true;
            editDireccion.Visible = false;
        }

        private void GestionFechaNac()
        {
            string FechaSinHora = FechaNacimiento.ToString("dd/MM/yyyy");
            lblNacimiento.Text = "Fecha Nacimiento: " + FechaSinHora;
            lblNacimiento.Margin = new Padding(0, 12, 0, 0);
            editNacimiento.Margin = new Padding(0, 0, 10, 0);
            dtNacimiento.Visible = false;
        }

        private void editNacimiento_Click(object sender, EventArgs e)
        {
            lblNacimiento.Text = "Fecha Nacimiento: ";
            containerNacimiento.Size = new Size(140, 29);
            editNacimiento.Visible = false;
            dtNacimiento.Visible = true;
        }
        private void GestionGenero()
        {
            lblGenero.Text = "Genero: " + Genero;
            lblGenero.Margin = new Padding(0, 12, 0, 0);
            editGenero.Margin = new Padding(0, 0, 10, 0);
            cboGenero.Visible = false;
        }

        private void editGenero_Click(object sender, EventArgs e)
        {
            lblGenero.Text = "Genero: ";
            containerGenero.Size = new Size(76, 29);
            editGenero.Visible = false;
            cboGenero.Visible = true;
        }

        private void GestionComuna()
        {
            lblComuna.Text = "Comuna: " + IdComuna;
            lblComuna.Margin = new Padding(0, 12, 0, 0);
            editComuna.Margin = new Padding(0, 0, 10, 0);
            cboComuna.Visible = false;
        }

        private void editComuna_Click(object sender, EventArgs e)
        {
            lblComuna.Text = "Comuna: ";
            containerComuna.Size = new Size(76, 29);
            editComuna.Visible = false;
            cboComuna.Visible = true;
        }

        private void GestionTipoUsuario()
        {
            lblTipoUsuario.Text = "Tipo Usuario: " + TipoUsuario;
            lblTipoUsuario.Margin = new Padding(0, 12, 0, 0);
            editTipoUsuario.Margin = new Padding(0, 0, 10, 0);
            cboTipoUsuario.Visible = false;
        }

        private void editTipoUsuario_Click(object sender, EventArgs e)
        {
            lblTipoUsuario.Text = "Tipo Usuario: ";
            containerTipoUsuario.Size = new Size(101, 29);
            editTipoUsuario.Visible = false;
            cboTipoUsuario.Visible = true;
        }

        private void GestionAnios() {
            lblAniosXP.Text = "Años Experiencia: " + AniosExperiencia;
            lblAniosXP.Margin = new Padding(0, 12, 0, 0);
            editAnios.Margin = new Padding(0, 0, 10, 0);
            numericAnios.Visible = false;
        }

        private void editAnios_Click(object sender, EventArgs e)
        {
            lblAniosXP.Text = "Años Experiencia: ";
            containerAnios.Size = new Size(131, 29);
            editAnios.Visible = false;
            numericAnios.Visible = true;
        }
    }
}