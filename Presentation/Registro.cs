using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Common.Cache;
using Region = Common.Cache.Region;
using System.Text.RegularExpressions;

namespace Imagina
{
    public partial class Registro : Form
    {
        UserModel userModel = new UserModel();
        int tipoUsuario = UserLoginCache.IdTipoUsuario;

        public Registro()
        {
            InitializeComponent();
            RellenarRegiones();
            RellenarGeneros();
            RellenarTipos();
            if (tipoUsuario != 1)
            {
                numericAnios.Visible = false;
                lblAnios.Visible = false;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
            }
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "Apellidos")
            {
                txtApellidos.Text = "";
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "")
            {
                txtApellidos.Text = "Apellidos";
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo")
            {
                txtCorreo.Text = "";
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Correo";
            }
        }

        private void txtRut_Enter(object sender, EventArgs e)
        {
            if (txtRut.Text == "Rut")
            {
                txtRut.Text = "";
            }
        }

        private void txtRut_Leave(object sender, EventArgs e)
        {
            if (txtRut.Text == "")
            {
                txtRut.Text = "Rut";
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Telefono")
            {
                txtTelefono.Text = "";
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Telefono";
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Dirección")
            {
                txtDireccion.Text = "";
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Dirección";
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

        private void txtConfirmar_Enter(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "Confirmar Contraseña")
            {
                txtConfirmar.Text = "";
                txtConfirmar.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmar_Leave(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "")
            {
                txtConfirmar.Text = "Confirmar Contraseña";
                txtConfirmar.UseSystemPasswordChar = false;
            }
        }

        private void Registro_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }
                
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void MoverVentanas()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            int idGenero;
            int idTipo;
            string rut = txtRut.Text;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            int telefono;
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;
            DateTime fechaNacimiento = FechaNacimiento.Value;
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

            if (!RutValido(rut))
            {
                error("El rut debe tener un formato correcto");
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

            if (txtConfirmar.Text != password)
            {
                error("Las Contraseñas no coinciden");
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

            int idComuna = ObtenerIdComuna();
            bool registrado = userModel.RegistrarUsuarios(rut, nombre, apellidos, telefono, correo, password, fechaNacimiento, direccion, aniosExperiencia, idGenero, idComuna, idTipo);
            if (registrado)
            {
                MessageBox.Show("Usuario Registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
            cboTipo.Items.Clear();

            if (UserLoginCache.IdTipoUsuario == 1)
            {
                foreach (TipoUsuario tipo in tipos)
                {
                    cboTipo.Items.Add(tipo.Nombre);
                }
            }
            else
            {
                foreach (TipoUsuario tipo in tipos)
                {
                    if (tipo.IdTipoUsuario == 2 || tipo.IdTipoUsuario == 3)
                    {
                        cboTipo.Items.Add(tipo.Nombre);
                    }
                }
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

        static bool RutValido(string rut)
        {
            string pattern = @"^\d{1,2}\.\d{3}\.\d{3}-\d{1}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(rut);
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
    }
}
