using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;
using Common.Cache;

namespace Imagina
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text;

            UserModel user = new UserModel();
            var validarLogin = user.LoginUser(correo, password);
            if (validarLogin)
            {
                int tipoUsuario = UserLoginCache.IdTipoUsuario;
                if (tipoUsuario != 4)
                {
                    Inicio inicio = new Inicio();
                    inicio.Show();
                    inicio.FormClosed += logOut;
                    this.Hide();
                }
                else error("Usuario no autorizado");
                txtPassword.Text = "Contraseña";
                txtCorreo.Text = "Correo";
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                error("Correo o Contraseña incorrectos");
                txtPassword.Text = "Contraseña";
                txtPassword.UseSystemPasswordChar = false;
                txtCorreo.Focus();
            }
        }

        private void error(string mensaje)
        {
            lblError.Text = "      " + mensaje;
            lblError.Visible = true;
        }

        private void logOut(object sender, FormClosedEventArgs e)
        {
            txtCorreo.Text = "Correo";
            txtPassword.Text = "Contraseña";
            txtPassword.UseSystemPasswordChar = false;
            lblError.Visible = false;
            this.Show();
        }

        private void MoverVentanas()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            registro.FormClosed += logOut;
            this.Hide();
        }
    }
}
