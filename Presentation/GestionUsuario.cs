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
using Region = Common.Cache.Region;
using System.Text.RegularExpressions;

namespace Imagina
{
    public partial class GestionUsuario : Form
    {
        public GestionUsuario()
        {
            InitializeComponent();
            RellenarRegiones();
            RellenarGeneros();
            RellenarTipos();
        }

        UserModel userModel = new UserModel();

        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int AniosExperiencia { get; set; }
        public int IdGenero { get; set; }
        public int IdComuna { get; set; }
        public int IdTipoUsuario { get; set; }

        private void RellenarComunas(int idRegion)
        {
            cboComuna.Items.Clear();

            List<Comuna> comunas = userModel.ObtenerComunas();
            foreach (Comuna comuna in comunas)
            {
                if (comuna.IdRegion == idRegion)
                {
                    cboComuna.Items.Add(comuna.Nombre);
                }
            }
        }

        private void RellenarRegiones()
        {
            List<Region> regiones = userModel.ObtenerRegiones();
            foreach (Region region in regiones)
            {
                cboRegion.Items.Add(region.Nombre);
            }
        }

        private void RellenarGeneros()
        {
            List<Genero> generos = userModel.ObtenerGeneros();
            foreach (Genero genero in generos)
            {
                cboGenero.Items.Add(genero.Nombre);
            }
        }

        private void RellenarTipos()
        {
            List<TipoUsuario> tipos = userModel.ObtenerTipos();
            foreach (TipoUsuario tipo in tipos)
            {
                cboTipo.Items.Add(tipo.Nombre);
            }
        }

        private void CargarRegion(int idComuna)
        {
            List<Comuna> comunas = userModel.ObtenerComunas();
            List<Region> regiones = userModel.ObtenerRegiones();
            Comuna comuna = comunas.FirstOrDefault(c => c.IdComuna == IdComuna);
            Region region = regiones.FirstOrDefault(r => r.IdRegion == comuna.IdRegion);
            cboRegion.SelectedItem = region.Nombre;
        }

        private void CargarComuna(int idComuna)
        {
            List<Comuna> comunas = userModel.ObtenerComunas();
            Comuna comuna = comunas.FirstOrDefault(c => c.IdComuna == IdComuna);
            cboComuna.SelectedItem = comuna.Nombre;
        }

        private void CargarGenero(int idGenero)
        {
            List<Genero> generos = userModel.ObtenerGeneros();
            Genero genero = generos.FirstOrDefault(g => g.IdGenero == IdGenero);
            cboGenero.SelectedItem = genero.Nombre;
        }

        private void CargarTipo(int idTipo)
        {
            List<TipoUsuario> tipos = userModel.ObtenerTipos();
            TipoUsuario tipo = tipos.FirstOrDefault(t => t.IdTipoUsuario== idTipo);
            cboTipo.SelectedItem = tipo.Nombre;
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Region> regiones = userModel.ObtenerRegiones();
            foreach (Region region in regiones)
            {
                if (cboRegion.SelectedItem.ToString() == region.Nombre)
                {
                    RellenarComunas(region.IdRegion);
                }
            }
        }

        private int ObtenerIdComuna()
        {
            List<Comuna> comunas = userModel.ObtenerComunas();

            foreach (Comuna comuna in comunas)
            {
                if (cboComuna.SelectedItem.ToString() == comuna.Nombre)
                {
                    return comuna.IdComuna;
                }
            }
            return 0;
        }
        private int ObtenerIdGenero()
        {
            List<Genero> generos = userModel.ObtenerGeneros();

            foreach (Genero genero in generos)
            {
                if (cboGenero.SelectedItem.ToString() == genero.Nombre)
                {
                    return genero.IdGenero;
                }
            }
            return 0;
        }

        private int ObtenerIdTipo()
        {
            List<TipoUsuario> tipos = userModel.ObtenerTipos();

            foreach (TipoUsuario tipo in tipos)
            {
                if (cboTipo.SelectedItem.ToString() == tipo.Nombre)
                {
                    return tipo.IdTipoUsuario;
                }
            }
            return 0;
        }
        private void GestionUsuario_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = Nombre + " " + Apellidos;
            lblCorreoUsuarios.Text = Correo;
            txtNombre.Text = Nombre;
            txtApellidos.Text = Apellidos;
            txtCorreo.Text = Correo;
            txtTelefono.Text = Telefono.ToString();
            txtDireccion.Text = Direccion;
            PickerFecha.Value = FechaNacimiento;
            numericAnios.Value = AniosExperiencia;
            CargarRegion(IdComuna);
            CargarComuna(IdComuna);
            CargarGenero(IdGenero);
            CargarTipo(IdTipoUsuario);
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == Nombre)
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = Nombre;
            }
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            if (txtApellidos.Text == Apellidos)
            {
                txtApellidos.Text = "";
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "")
            {
                txtApellidos.Text = Apellidos;
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == Correo)
            {
                txtCorreo.Text = "";
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = Correo;
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == Telefono.ToString())
            {
                txtTelefono.Text = "";
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = Telefono.ToString();
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == Direccion)
            {
                txtDireccion.Text = "";
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = Direccion;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idGenero;
            int idTipo;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            int telefono;
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;
            DateTime fechaNacimiento = PickerFecha.Value;
            string direccion = txtDireccion.Text;
            int aniosExperiencia = (int)numericAnios.Value;

            if (nombre == "Nombre" || nombre.Length < 1 || nombre.Length > 60)
            {
                error("Nombre no valido");
                return;
            }

            if (apellidos == "Apellidos" || apellidos.Length < 1 || apellidos.Length > 80)
            {
                error("Apellidos no validos");
                return;
            }

            if (correo == "Correo" || !EmailValido(correo))
            {
                error("El Correo debe tener un formato valido");
                return;
            }

            if (txtTelefono.Text == "Telefono" || txtTelefono.Text.Length != 9)
            {
                error("El Telefono debe tener 9 caracteres");
                return;
            }
            else
            {
                telefono = int.Parse(txtTelefono.Text);
            }

            if (direccion == "Dirección" || direccion.Length < 1 || direccion.Length > 80)
            {
                error("Direccion no valida");
                return;
            }

            if (password.Length < 1 || password == "Contraseña")
            {
                error("Contraseña no valida");
                return;
            }

            if (!EdadValida(fechaNacimiento))
            {
                error("Debe ser mayor de edad");
                return;
            }

            if (cboRegion.SelectedItem == null)
            {
                error("Debe seleccionar una Región");
                return;
            }

            if (cboComuna.SelectedItem == null)
            {
                error("Debe seleccionar una Comuna");
                return;
            }

            if (cboGenero.SelectedItem == null)
            {
                error("Debe seleccionar un Genero");
                return;
            }
            else
            {
                idGenero = ObtenerIdGenero();
            }

            if (cboTipo.SelectedItem == null)
            {
                error("Debe seleccionar un Tipo de usuario");
                return;
            }
            else
            {
                idTipo = ObtenerIdTipo();
            }

            if (txtPassword.Text != Password)
            {
                error("Contraseña incorrecta");
                return;
            }

            int idComuna = ObtenerIdComuna();
            bool modificado = userModel.ModificarUsuario(Rut, nombre, apellidos, telefono, correo, password, fechaNacimiento, direccion, aniosExperiencia, idGenero, idComuna, idTipo);
            if (modificado)
            {
                MessageBox.Show("Usuario Modificado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        static bool EmailValido(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        static bool EdadValida(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad >= 18;
        }

        private void error(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}