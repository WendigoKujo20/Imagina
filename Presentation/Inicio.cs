using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common.Cache;
using Domain;

namespace Imagina
{
    public partial class Inicio : Form
    {
        bool barraLateralExpand = true;
        bool serviceCollapsed = true;
        bool gestionCollapsed = true;
        int tipoUsuario = UserLoginCache.IdTipoUsuario;
        public Inicio()
        {
            InitializeComponent();
            DiferenciarInterfaz(tipoUsuario);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void listarUsuarios()
        {
            pnlInicio.Controls.Clear();
            UserModel userModel = new UserModel();
            var usuarios = userModel.ObtenerUsuarios();

            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            foreach (var usuario in usuarios)
            {
                string TipoUsuario = "Desconocido";
                if (usuario.IdTipoUsuario == 1)
                {
                    TipoUsuario = "Administrador";
                }
                else if (usuario.IdTipoUsuario == 2)
                {
                    TipoUsuario = "  Tecnico";
                }
                else if (usuario.IdTipoUsuario == 3)
                {
                    TipoUsuario = "  Vendedor";
                }
                else if (usuario.IdTipoUsuario == 4)
                {
                    TipoUsuario = "  Cliente";
                }

                Panel panel = new Panel();
                panel.Name = "pnl" + usuario.Rut;
                panel.BackColor = System.Drawing.Color.White;
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Size = new System.Drawing.Size(295, 248);
                panel.TabIndex = 0;
                panel.ResumeLayout(false);
                panel.PerformLayout();
                panel.Padding = new Padding(10);
                panel.Margin = new Padding(5); // Establecer el espacio de separación entre paneles

                Button btnModificar = new Button();
                btnModificar.BackColor = System.Drawing.Color.Black;
                btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnModificar.FlatAppearance.BorderSize = 0;
                btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnModificar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnModificar.ForeColor = System.Drawing.Color.White;
                btnModificar.Location = new System.Drawing.Point(95, 211);
                btnModificar.Name = "btnModificar";
                btnModificar.Size = new System.Drawing.Size(89, 31);
                btnModificar.TabIndex = 4;
                btnModificar.Text = "Modificar";
                btnModificar.UseVisualStyleBackColor = false;

                Label lblRut = new Label();
                lblRut.AutoSize = true;
                lblRut.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblRut.Location = new System.Drawing.Point(13, 187);
                lblRut.Name = "lblRut";
                lblRut.Size = new System.Drawing.Size(40, 17);
                lblRut.TabIndex = 5;
                lblRut.Text = "Rut:"+usuario.Rut;

                Label lblCorreo = new Label();
                lblCorreo.AutoSize = true;
                lblCorreo.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblCorreo.Location = new System.Drawing.Point(13, 166);
                lblCorreo.Name = "lblCorreo";
                lblCorreo.Size = new System.Drawing.Size(64, 17);
                lblCorreo.TabIndex = 4;
                lblCorreo.Text = "Correo:"+usuario.Correo;

                Label lblApellidos = new Label();
                lblApellidos.AutoSize = true;
                lblApellidos.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblApellidos.Location = new System.Drawing.Point(13, 143);
                lblApellidos.Name = "lblApellidos";
                lblApellidos.Size = new System.Drawing.Size(88, 17);
                lblApellidos.TabIndex = 3;
                lblApellidos.Text = "Apellidos:"+usuario.Apellidos;

                Label lblNombre = new Label();
                lblNombre.AutoSize = true;
                lblNombre.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblNombre.Location = new System.Drawing.Point(13, 121);
                lblNombre.Name = "lblNombre";
                lblNombre.Size = new System.Drawing.Size(64, 17);
                lblNombre.TabIndex = 2;
                lblNombre.Text = "Nombre:"+usuario.Nombre;

                Label lblTipoUsuario = new Label();
                lblTipoUsuario.AutoSize = true;
                lblTipoUsuario.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblTipoUsuario.Location = new System.Drawing.Point(90, 20);
                lblTipoUsuario.Name = "lblTipoUser";
                lblTipoUsuario.Size = new System.Drawing.Size(64, 17);
                lblTipoUsuario.TabIndex = 1;
                lblTipoUsuario.Text = TipoUsuario;

                PictureBox pictureBox = new PictureBox();
                pictureBox.BackgroundImage = global::Imagina.Properties.Resources.UsersList;
                pictureBox.Image = global::Imagina.Properties.Resources.UsersList;
                pictureBox.Location = new System.Drawing.Point(50, -10);
                pictureBox.Name = "pictureBox1";
                pictureBox.Size = new System.Drawing.Size(182, 184);
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;

                pnlInicio.Controls.Add(panel);
                panel.Controls.Add(btnModificar);
                panel.Controls.Add(lblRut);
                panel.Controls.Add(lblCorreo);
                panel.Controls.Add(lblApellidos);
                panel.Controls.Add(lblNombre);
                panel.Controls.Add(lblTipoUsuario);
                panel.Controls.Add(pictureBox);
            }
        }

        private void TimerBarra_Tick(object sender, EventArgs e)
        {
            if (barraLateralExpand)
            {
                BarraLateral.Width -= 10;
                if (BarraLateral.Width == BarraLateral.MinimumSize.Width)
                {
                    barraLateralExpand = false;
                    TimerBarra.Stop();
                }
            }
            else
            {
                BarraLateral.Width += 10;
                if (BarraLateral.Width == BarraLateral.MaximumSize.Width)
                {
                    barraLateralExpand = true;
                    TimerBarra.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            TimerBarra.Start();
        }

        private void Inicio_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void BarraLateral_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MoverVentanas()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            ServicesTimer.Start();
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            GestionTimer.Start();
        }

        private void ServicesTimer_Tick(object sender, EventArgs e)
        {
            if (serviceCollapsed)
            {
                servicesContainer.Height += 10;
                if (servicesContainer.Height == servicesContainer.MaximumSize.Height)
                {
                    serviceCollapsed = false;
                    ServicesTimer.Stop();
                }
            }
            else
            {
                servicesContainer.Height -= 10;
                if (servicesContainer.Height == servicesContainer.MinimumSize.Height)
                {
                    serviceCollapsed = true;
                    ServicesTimer.Stop();
                }
            }
        }

        private void GestionTimer_Tick(object sender, EventArgs e)
        {
            if (gestionCollapsed)
            {
                gestionContainer.Height += 10;
                if (gestionContainer.Height == gestionContainer.MaximumSize.Height)
                {
                    gestionCollapsed = false;
                    GestionTimer.Stop();
                }
            }
            else
            {
                gestionContainer.Height -= 10;
                if (gestionContainer.Height == gestionContainer.MinimumSize.Height)
                {
                    gestionCollapsed = true;
                    GestionTimer.Stop();
                }
            }
        }

        private void DiferenciarInterfaz(int tipoUsuario)
        {
            if (tipoUsuario == 1)
            {
                servicesContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 265);
            }
            else if (tipoUsuario == 2)
            {
                gestionContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 265);
            }
            else if (tipoUsuario == 3)
            {
                servicesContainer.Visible = false;
                gestionContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 324);
            }

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            listarUsuarios();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void pnlInicio_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void pnlRelleno_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }
    }
}
