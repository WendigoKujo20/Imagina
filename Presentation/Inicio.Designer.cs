
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnServicios = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.TimerBarra = new System.Windows.Forms.Timer(this.components);
            this.ServicesTimer = new System.Windows.Forms.Timer(this.components);
            this.BarraLateral.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.panel2.SuspendLayout();
            this.servicesContainer.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraLateral
            // 
            this.BarraLateral.BackColor = System.Drawing.Color.Black;
            this.BarraLateral.Controls.Add(this.panel1);
            this.BarraLateral.Controls.Add(this.panel2);
            this.BarraLateral.Controls.Add(this.servicesContainer);
            this.BarraLateral.Controls.Add(this.panel4);
            this.BarraLateral.Controls.Add(this.panel6);
            this.BarraLateral.Controls.Add(this.panel7);
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
            this.servicesContainer.Controls.Add(this.panel3);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.btnServicios);
            this.panel3.Location = new System.Drawing.Point(-9, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 64);
            this.panel3.TabIndex = 2;
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
            this.btnServicios.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Location = new System.Drawing.Point(3, 249);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(219, 50);
            this.panel4.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-26, -5);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(238, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "             Nosequeponer";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnConfig);
            this.panel6.Location = new System.Drawing.Point(3, 305);
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
            this.btnConfig.Location = new System.Drawing.Point(-26, -5);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(238, 56);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "            Configuración";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(3, 361);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(210, 201);
            this.panel7.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnLogout);
            this.panel8.Controls.Add(this.button6);
            this.panel8.Location = new System.Drawing.Point(3, 568);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(254, 53);
            this.panel8.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::Imagina.Properties.Resources.log_out;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(-26, -8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(238, 69);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "            Cerrar Sesión";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::Imagina.Properties.Resources.ajuste;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-26, -16);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(306, 69);
            this.button6.TabIndex = 1;
            this.button6.Text = "            Configuración";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
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
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 624);
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
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel BarraLateral;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Timer TimerBarra;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel servicesContainer;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnMantenciones;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnReparaciones;
        private System.Windows.Forms.Timer ServicesTimer;
    }
}