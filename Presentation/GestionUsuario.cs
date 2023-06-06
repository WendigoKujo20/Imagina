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
    public partial class GestionUsuario : Form
    {
        public GestionUsuario()
        {
            InitializeComponent();
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
        public string Genero { get; set; }
        public int IdComuna { get; set; }
        public string TipoUsuario { get; set; }

        private void GestionUsuario_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = Nombre + " " + Apellidos;
            lblCorreoUsuarios.Text = Correo;
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
            if (txtDireccion.Text == "Direccion")
            {
                txtDireccion.Text = "";
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Direccion";
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
            int idGenero = 0;
            int idTipo = 0;

            if (cboGenero.SelectedItem == "Masculino")
            {
                idGenero = 1;
            }
            else if (cboGenero.SelectedItem == "Femenino")
            {
                idGenero = 2;
            }
            else if (cboGenero.SelectedItem == "Personalizado")
            {
                idGenero = 3;
            }

            if (cboTipo.SelectedItem == "Administrador")
            {
                idTipo = 1;
            }
            else if (cboTipo.SelectedItem == "Tecnico")
            {
                idTipo = 2;
            }
            else if (cboTipo.SelectedItem == "Vendedor")
            {
                idTipo = 3;
            }else if(cboTipo.SelectedItem == "Cliente")
            {
                idTipo = 4;
            }

            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string telefonoText = txtTelefono.Text;
            int telefono;
            bool exito = int.TryParse(telefonoText, out telefono);
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;
            DateTime fechaNacimiento = PickerFecha.Value;
            string direccion = txtDireccion.Text;
            int aniosExperiencia = (int)numericAnios.Value;
            int idComuna = 1;
            if (nombre.Length > 1 && nombre != "Nombre")
            {
                if (apellidos.Length > 1 && apellidos != "Apellidos")
                {
                    if (exito)
                    {
                        if (correo.Length > 1 && correo != "Correo")
                        {
                            if (password.Length > 1 && password != "Contraseña")
                            {
                                if (direccion.Length > 1 && direccion != "Dirección")
                                {
                                    if (cboComuna.SelectedItem != null)
                                    {
                                        if (cboGenero.SelectedItem != null)
                                        {
                                            if (cboTipo.SelectedItem != null)
                                            {
                                                bool modificar = userModel.ModificarUsuario(Rut, nombre, apellidos, telefono, correo, password, fechaNacimiento, direccion, aniosExperiencia, idGenero, idComuna, idTipo);

                                                if (modificar)
                                                {
                                                    this.Close();
                                                }
                                                else error("No se ha podido Registrar");
                                            }
                                            else error("Tiene que seleccionar un usuario");
                                        }
                                        else error("Tiene que seleccionar un genero");
                                    }
                                    else error("Tiene que seleccionar una comuna");
                                }
                                else error("La direccion no puede estar vacia");
                            }
                            else error("La contraseña no puede estar vacia");
                        }
                        else error("El correo no puede estar vacio");
                    }
                    else error("El telefono no puede estar vacio");
                }
                else error("Los Apellidos no pueden estar vacios");
            }
            else error("El nombre no puede estar vacio");
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