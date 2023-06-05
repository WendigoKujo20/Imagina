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

namespace Imagina
{
    public partial class Registro : Form
    {
        UserModel userModel = new UserModel();

        public Registro()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            int idGenero = 0;
            int idTipo = 0;

            if (cboGenero.SelectedItem == "Masculino")
            {
                idGenero = 1;
            }else if(cboGenero.SelectedItem == "Femenino")
            {
                idGenero = 2;
            }else if(cboGenero.SelectedItem == "Personalizado")
            {
                idGenero = 3;
            }

            if (cboTipo.SelectedItem == "Tecnico")
            {
                idTipo = 2;
            }else if(cboTipo.SelectedItem == "Vendedor")
            {
                idTipo = 3;
            }

            string rut = txtRut.Text;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string telefonoText = txtTelefono.Text;
            int telefono;
            bool exito = int.TryParse(telefonoText, out telefono);
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;
            DateTime fechaNacimiento = FechaNacimiento.Value;
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
                                if (txtConfirmar.Text == password)
                                {
                                    if (direccion.Length > 1 && direccion != "Dirección")
                                    {
                                        if (rut.Length > 1 && rut != "Rut")
                                        {
                                            if (cboComuna.SelectedItem != null)
                                            {
                                                if (cboGenero.SelectedItem != null)
                                                {
                                                    if (cboTipo.SelectedItem != null)
                                                    {
                                                        bool registrar = userModel.RegistrarUsuarios(rut, nombre, apellidos, telefono, correo, password, fechaNacimiento, direccion, aniosExperiencia, idGenero, idComuna, idTipo);

                                                        if (registrar)
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
                                        else error("El rut no puede estar vacio");
                                    }
                                    else error("La direccion no puede estar vacia");
                                }
                                else error("Las contraseñas no coinciden");
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
    }
}
