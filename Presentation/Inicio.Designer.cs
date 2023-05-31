
namespace Imagina
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BarraLateral = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.servicesContainer = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnMantenciones = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnReparaciones = new System.Windows.Forms.Button();
            this.pnlServicios = new System.Windows.Forms.Panel();
            this.btnServicios = new System.Windows.Forms.Button();
            this.gestionContainer = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlGestionar = new System.Windows.Forms.Panel();
            this.btnGestionar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pnlRelleno = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.TimerBarra = new System.Windows.Forms.Timer(this.components);
            this.ServicesTimer = new System.Windows.Forms.Timer(this.components);
            this.GestionTimer = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BarraLateral.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.panel2.SuspendLayout();
            this.servicesContainer.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlServicios.SuspendLayout();
            this.gestionContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlGestionar.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraLateral
            // 
            this.BarraLateral.BackColor = System.Drawing.Color.Black;
            this.BarraLateral.Controls.Add(this.panel1);
            this.BarraLateral.Controls.Add(this.panel2);
            this.BarraLateral.Controls.Add(this.servicesContainer);
            this.BarraLateral.Controls.Add(this.gestionContainer);
            this.BarraLateral.Controls.Add(this.panel6);
            this.BarraLateral.Controls.Add(this.pnlRelleno);
            this.BarraLateral.Controls.Add(this.panel8);
            this.BarraLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.BarraLateral.Location = new System.Drawing.Point(0, 0);
            this.BarraLateral.MaximumSize = new System.Drawing.Size(212, 743);
            this.BarraLateral.MinimumSize = new System.Drawing.Size(74, 743);
            this.BarraLateral.Name = "BarraLateral";
            this.BarraLateral.Size = new System.Drawing.Size(212, 743);
            this.BarraLateral.TabIndex = 0;
            this.BarraLateral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraLateral_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 124);
            this.panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Image = global::Imagina.Properties.Resources.menu;
            this.btnMenu.Location = new System.Drawing.Point(9, 38);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(51, 46);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 0;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPerfil);
            this.panel2.Location = new System.Drawing.Point(3, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 50);
            this.panel2.TabIndex = 1;
            // 
            // btnPerfil
            // 
            this.btnPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfil.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfil.ForeColor = System.Drawing.Color.White;
            this.btnPerfil.Image = global::Imagina.Properties.Resources.user;
            this.btnPerfil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerfil.Location = new System.Drawing.Point(-26, -8);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.btnPerfil.Size = new System.Drawing.Size(245, 69);
            this.btnPerfil.TabIndex = 1;
            this.btnPerfil.Text = "               Perfil";
            this.btnPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerfil.UseVisualStyleBackColor = true;
            // 
            // servicesContainer
            // 
            this.servicesContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.servicesContainer.Controls.Add(this.panel10);
            this.servicesContainer.Controls.Add(this.panel9);
            this.servicesContainer.Controls.Add(this.pnlServicios);
            this.servicesContainer.Location = new System.Drawing.Point(3, 189);
            this.servicesContainer.MaximumSize = new System.Drawing.Size(209, 137);
            this.servicesContainer.MinimumSize = new System.Drawing.Size(209, 54);
            this.servicesContainer.Name = "servicesContainer";
            this.servicesContainer.Size = new System.Drawing.Size(209, 54);
            this.servicesContainer.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnMantenciones);
            this.panel10.Location = new System.Drawing.Point(-6, 97);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(217, 40);
            this.panel10.TabIndex = 4;
            // 
            // btnMantenciones
            // 
            this.btnMantenciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnMantenciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenciones.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenciones.ForeColor = System.Drawing.Color.White;
            this.btnMantenciones.Image = global::Imagina.Properties.Resources.mantencion;
            this.btnMantenciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenciones.Location = new System.Drawing.Point(0, -13);
            this.btnMantenciones.Name = "btnMantenciones";
            this.btnMantenciones.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnMantenciones.Size = new System.Drawing.Size(225, 66);
            this.btnMantenciones.TabIndex = 1;
            this.btnMantenciones.Text = "             Mantenciones";
            this.btnMantenciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMantenciones.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnReparaciones);
            this.panel9.Location = new System.Drawing.Point(-6, 56);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(217, 40);
            this.panel9.TabIndex = 3;
            // 
            // btnReparaciones
            // 
            this.btnReparaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnReparaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReparaciones.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReparaciones.ForeColor = System.Drawing.Color.White;
            this.btnReparaciones.Image = global::Imagina.Properties.Resources.reparacion;
            this.btnReparaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReparaciones.Location = new System.Drawing.Point(0, -5);
            this.btnReparaciones.Name = "btnReparaciones";
            this.btnReparaciones.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnReparaciones.Size = new System.Drawing.Size(225, 53);
            this.btnReparaciones.TabIndex = 1;
            this.btnReparaciones.Text = "             Reparaciones";
            this.btnReparaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReparaciones.UseVisualStyleBackColor = false;
            // 
            // pnlServicios
            // 
            this.pnlServicios.Controls.Add(this.btnServicios);
            this.pnlServicios.Location = new System.Drawing.Point(-9, 0);
            this.pnlServicios.Name = "pnlServicios";
            this.pnlServicios.Size = new System.Drawing.Size(218, 64);
            this.pnlServicios.TabIndex = 2;
            // 
            // btnServicios
            // 
            this.btnServicios.BackColor = System.Drawing.Color.Black;
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicios.ForeColor = System.Drawing.Color.White;
            this.btnServicios.Image = global::Imagina.Properties.Resources.services;
            this.btnServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.Location = new System.Drawing.Point(-26, -8);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnServicios.Size = new System.Drawing.Size(254, 70);
            this.btnServicios.TabIndex = 1;
            this.btnServicios.Text = "              Servicios";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // gestionContainer
            // 
            this.gestionContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.gestionContainer.Controls.Add(this.panel4);
            this.gestionContainer.Controls.Add(this.panel5);
            this.gestionContainer.Controls.Add(this.pnlGestionar);
            this.gestionContainer.Location = new System.Drawing.Point(3, 249);
            this.gestionContainer.MaximumSize = new System.Drawing.Size(209, 137);
            this.gestionContainer.MinimumSize = new System.Drawing.Size(209, 54);
            this.gestionContainer.Name = "gestionContainer";
            this.gestionContainer.Size = new System.Drawing.Size(209, 137);
            this.gestionContainer.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(-6, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 40);
            this.panel4.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Imagina.Properties.Resources.libro;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, -13);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(225, 66);
            this.button1.TabIndex = 1;
            this.button1.Text = "             Libros";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button2);
            this.panel5.Location = new System.Drawing.Point(-6, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 40);
            this.panel5.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Imagina.Properties.Resources.users;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, -5);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(225, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "             Usuarios";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pnlGestionar
            // 
            this.pnlGestionar.Controls.Add(this.btnGestionar);
            this.pnlGestionar.Location = new System.Drawing.Point(-9, 0);
            this.pnlGestionar.Name = "pnlGestionar";
            this.pnlGestionar.Size = new System.Drawing.Size(218, 64);
            this.pnlGestionar.TabIndex = 2;
            // 
            // btnGestionar
            // 
            this.btnGestionar.BackColor = System.Drawing.Color.Black;
            this.btnGestionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionar.ForeColor = System.Drawing.Color.White;
            this.btnGestionar.Image = global::Imagina.Properties.Resources.gestion;
            this.btnGestionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionar.Location = new System.Drawing.Point(-26, -6);
            this.btnGestionar.Name = "btnGestionar";
            this.btnGestionar.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnGestionar.Size = new System.Drawing.Size(254, 70);
            this.btnGestionar.TabIndex = 1;
            this.btnGestionar.Text = "              Gestionar";
            this.btnGestionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionar.UseVisualStyleBackColor = false;
            this.btnGestionar.Click += new System.EventHandler(this.btnGestionar_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnConfig);
            this.panel6.Location = new System.Drawing.Point(3, 392);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(219, 50);
            this.panel6.TabIndex = 5;
            // 
            // btnConfig
            // 
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Image = global::Imagina.Properties.Resources.ajuste;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.Location = new System.Drawing.Point(-28, -5);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(249, 65);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "             Configuración";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // pnlRelleno
            // 
            this.pnlRelleno.Location = new System.Drawing.Point(3, 448);
            this.pnlRelleno.Name = "pnlRelleno";
            this.pnlRelleno.Size = new System.Drawing.Size(210, 201);
            this.pnlRelleno.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnLogout);
            this.panel8.Location = new System.Drawing.Point(3, 655);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(212, 53);
            this.panel8.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::Imagina.Properties.Resources.log_out;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(-25, -12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(238, 69);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "            Cerrar Sesión";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // TimerBarra
            // 
            this.TimerBarra.Interval = 10;
            this.TimerBarra.Tick += new System.EventHandler(this.TimerBarra_Tick);
            // 
            // ServicesTimer
            // 
            this.ServicesTimer.Interval = 10;
            this.ServicesTimer.Tick += new System.EventHandler(this.ServicesTimer_Tick);
            // 
            // GestionTimer
            // 
            this.GestionTimer.Interval = 10;
            this.GestionTimer.Tick += new System.EventHandler(this.GestionTimer_Tick);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackgroundImage = global::Imagina.Properties.Resources.Libros;
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(212, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(955, 624);
            this.panel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gray;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(131, 51);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(239, 221);
            this.panel7.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 624);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.BarraLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Inicio_MouseDown);
            this.BarraLateral.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.servicesContainer.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.pnlServicios.ResumeLayout(false);
            this.gestionContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlGestionar.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel BarraLateral;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Panel pnlServicios;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Timer TimerBarra;
        private System.Windows.Forms.Panel pnlRelleno;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel servicesContainer;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnMantenciones;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnReparaciones;
        private System.Windows.Forms.Timer ServicesTimer;
        private System.Windows.Forms.Panel gestionContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlGestionar;
        private System.Windows.Forms.Button btnGestionar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Timer GestionTimer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
    }
}