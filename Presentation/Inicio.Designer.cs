
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.BarraLateral = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.gestionContainer = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAgregarUser = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.pnlGestionar = new System.Windows.Forms.Panel();
            this.btnGestionar = new System.Windows.Forms.Button();
            this.librosContainer = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnAgregarlibro = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnLibros = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnAlphilia = new System.Windows.Forms.Button();
            this.pnlLibros = new System.Windows.Forms.Panel();
            this.btnGestionLibros = new System.Windows.Forms.Button();
            this.servicesContainer = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRevisar = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnGestServ = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pnlServicios = new System.Windows.Forms.Panel();
            this.btnServicios = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pnlRelleno = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.TimerBarra = new System.Windows.Forms.Timer(this.components);
            this.ServicesTimer = new System.Windows.Forms.Timer(this.components);
            this.GestionUserTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlInicio = new System.Windows.Forms.FlowLayoutPanel();
            this.GestionLibroTimer = new System.Windows.Forms.Timer(this.components);
            this.BarraLateral.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.panel2.SuspendLayout();
            this.gestionContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlGestionar.SuspendLayout();
            this.librosContainer.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel14.SuspendLayout();
            this.pnlLibros.SuspendLayout();
            this.servicesContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlServicios.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraLateral
            // 
            this.BarraLateral.BackColor = System.Drawing.Color.Black;
            this.BarraLateral.Controls.Add(this.panel1);
            this.BarraLateral.Controls.Add(this.panel2);
            this.BarraLateral.Controls.Add(this.gestionContainer);
            this.BarraLateral.Controls.Add(this.librosContainer);
            this.BarraLateral.Controls.Add(this.servicesContainer);
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
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
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
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // gestionContainer
            // 
            this.gestionContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.gestionContainer.Controls.Add(this.panel4);
            this.gestionContainer.Controls.Add(this.panel5);
            this.gestionContainer.Controls.Add(this.pnlGestionar);
            this.gestionContainer.Location = new System.Drawing.Point(3, 189);
            this.gestionContainer.MaximumSize = new System.Drawing.Size(209, 137);
            this.gestionContainer.MinimumSize = new System.Drawing.Size(209, 54);
            this.gestionContainer.Name = "gestionContainer";
            this.gestionContainer.Size = new System.Drawing.Size(209, 54);
            this.gestionContainer.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAgregarUser);
            this.panel4.Location = new System.Drawing.Point(-6, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 40);
            this.panel4.TabIndex = 4;
            // 
            // btnAgregarUser
            // 
            this.btnAgregarUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnAgregarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUser.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarUser.ForeColor = System.Drawing.Color.White;
            this.btnAgregarUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarUser.Image")));
            this.btnAgregarUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarUser.Location = new System.Drawing.Point(0, -13);
            this.btnAgregarUser.Name = "btnAgregarUser";
            this.btnAgregarUser.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnAgregarUser.Size = new System.Drawing.Size(225, 66);
            this.btnAgregarUser.TabIndex = 1;
            this.btnAgregarUser.Text = "           Agregar Usuario";
            this.btnAgregarUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarUser.UseVisualStyleBackColor = false;
            this.btnAgregarUser.Click += new System.EventHandler(this.btnAgregarUser_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnUsuarios);
            this.panel5.Location = new System.Drawing.Point(-6, 56);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 40);
            this.panel5.TabIndex = 3;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Image = global::Imagina.Properties.Resources.users;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, -5);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(225, 53);
            this.btnUsuarios.TabIndex = 1;
            this.btnUsuarios.Text = "           Ver Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
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
            this.btnGestionar.Text = "             Gestionar Usuarios";
            this.btnGestionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionar.UseVisualStyleBackColor = false;
            this.btnGestionar.Click += new System.EventHandler(this.btnGestionar_Click);
            // 
            // librosContainer
            // 
            this.librosContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.librosContainer.Controls.Add(this.panel11);
            this.librosContainer.Controls.Add(this.panel12);
            this.librosContainer.Controls.Add(this.panel14);
            this.librosContainer.Controls.Add(this.pnlLibros);
            this.librosContainer.Location = new System.Drawing.Point(3, 249);
            this.librosContainer.MaximumSize = new System.Drawing.Size(209, 178);
            this.librosContainer.MinimumSize = new System.Drawing.Size(209, 54);
            this.librosContainer.Name = "librosContainer";
            this.librosContainer.Size = new System.Drawing.Size(209, 54);
            this.librosContainer.TabIndex = 9;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnAgregarlibro);
            this.panel11.Location = new System.Drawing.Point(-6, 97);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(217, 40);
            this.panel11.TabIndex = 4;
            // 
            // btnAgregarlibro
            // 
            this.btnAgregarlibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnAgregarlibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarlibro.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarlibro.ForeColor = System.Drawing.Color.White;
            this.btnAgregarlibro.Image = global::Imagina.Properties.Resources.Add;
            this.btnAgregarlibro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarlibro.Location = new System.Drawing.Point(0, -13);
            this.btnAgregarlibro.Name = "btnAgregarlibro";
            this.btnAgregarlibro.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnAgregarlibro.Size = new System.Drawing.Size(225, 66);
            this.btnAgregarlibro.TabIndex = 1;
            this.btnAgregarlibro.Text = "           Agregar Producto";
            this.btnAgregarlibro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarlibro.UseVisualStyleBackColor = false;
            this.btnAgregarlibro.Click += new System.EventHandler(this.btnAgregarlibro_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnLibros);
            this.panel12.Location = new System.Drawing.Point(-6, 56);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(217, 40);
            this.panel12.TabIndex = 3;
            // 
            // btnLibros
            // 
            this.btnLibros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnLibros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibros.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibros.ForeColor = System.Drawing.Color.White;
            this.btnLibros.Image = global::Imagina.Properties.Resources.users;
            this.btnLibros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLibros.Location = new System.Drawing.Point(0, -5);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnLibros.Size = new System.Drawing.Size(225, 53);
            this.btnLibros.TabIndex = 1;
            this.btnLibros.Text = "           Ver Productos";
            this.btnLibros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLibros.UseVisualStyleBackColor = false;
            this.btnLibros.Click += new System.EventHandler(this.btnLibros_Click);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btnAlphilia);
            this.panel14.Location = new System.Drawing.Point(-6, 138);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(217, 40);
            this.panel14.TabIndex = 5;
            // 
            // btnAlphilia
            // 
            this.btnAlphilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnAlphilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlphilia.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlphilia.ForeColor = System.Drawing.Color.White;
            this.btnAlphilia.Image = global::Imagina.Properties.Resources.libro;
            this.btnAlphilia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlphilia.Location = new System.Drawing.Point(0, -13);
            this.btnAlphilia.Name = "btnAlphilia";
            this.btnAlphilia.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnAlphilia.Size = new System.Drawing.Size(225, 66);
            this.btnAlphilia.TabIndex = 1;
            this.btnAlphilia.Text = "           Alphilia";
            this.btnAlphilia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlphilia.UseVisualStyleBackColor = false;
            this.btnAlphilia.Click += new System.EventHandler(this.btnAlphilia_Click);
            // 
            // pnlLibros
            // 
            this.pnlLibros.Controls.Add(this.btnGestionLibros);
            this.pnlLibros.Location = new System.Drawing.Point(-9, -3);
            this.pnlLibros.Name = "pnlLibros";
            this.pnlLibros.Size = new System.Drawing.Size(218, 64);
            this.pnlLibros.TabIndex = 2;
            // 
            // btnGestionLibros
            // 
            this.btnGestionLibros.BackColor = System.Drawing.Color.Black;
            this.btnGestionLibros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionLibros.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionLibros.ForeColor = System.Drawing.Color.White;
            this.btnGestionLibros.Image = global::Imagina.Properties.Resources.libro;
            this.btnGestionLibros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionLibros.Location = new System.Drawing.Point(-26, -6);
            this.btnGestionLibros.Name = "btnGestionLibros";
            this.btnGestionLibros.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.btnGestionLibros.Size = new System.Drawing.Size(254, 70);
            this.btnGestionLibros.TabIndex = 1;
            this.btnGestionLibros.Text = "             Gestionar Productos";
            this.btnGestionLibros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionLibros.UseVisualStyleBackColor = false;
            this.btnGestionLibros.Click += new System.EventHandler(this.btnGestionLibros_Click);
            // 
            // servicesContainer
            // 
            this.servicesContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.servicesContainer.Controls.Add(this.panel3);
            this.servicesContainer.Controls.Add(this.panel10);
            this.servicesContainer.Controls.Add(this.panel9);
            this.servicesContainer.Controls.Add(this.pnlServicios);
            this.servicesContainer.Location = new System.Drawing.Point(3, 309);
            this.servicesContainer.MaximumSize = new System.Drawing.Size(209, 180);
            this.servicesContainer.MinimumSize = new System.Drawing.Size(209, 52);
            this.servicesContainer.Name = "servicesContainer";
            this.servicesContainer.Size = new System.Drawing.Size(209, 52);
            this.servicesContainer.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRevisar);
            this.panel3.Location = new System.Drawing.Point(-11, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 43);
            this.panel3.TabIndex = 5;
            // 
            // btnRevisar
            // 
            this.btnRevisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnRevisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevisar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevisar.ForeColor = System.Drawing.Color.White;
            this.btnRevisar.Image = global::Imagina.Properties.Resources.Revisar;
            this.btnRevisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevisar.Location = new System.Drawing.Point(0, -13);
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnRevisar.Size = new System.Drawing.Size(225, 66);
            this.btnRevisar.TabIndex = 1;
            this.btnRevisar.Text = "           Revisar Servicios";
            this.btnRevisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevisar.UseVisualStyleBackColor = false;
            this.btnRevisar.Click += new System.EventHandler(this.btnRevisar_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnGestServ);
            this.panel10.Location = new System.Drawing.Point(-6, 138);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(217, 41);
            this.panel10.TabIndex = 4;
            // 
            // btnGestServ
            // 
            this.btnGestServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnGestServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestServ.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestServ.ForeColor = System.Drawing.Color.White;
            this.btnGestServ.Image = global::Imagina.Properties.Resources.mantencion;
            this.btnGestServ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestServ.Location = new System.Drawing.Point(-3, -7);
            this.btnGestServ.Name = "btnGestServ";
            this.btnGestServ.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnGestServ.Size = new System.Drawing.Size(228, 53);
            this.btnGestServ.TabIndex = 1;
            this.btnGestServ.Text = "          Gestionar Servicio";
            this.btnGestServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestServ.UseVisualStyleBackColor = false;
            this.btnGestServ.Click += new System.EventHandler(this.btnGestServ_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnAgregar);
            this.panel9.Location = new System.Drawing.Point(-5, 97);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(217, 40);
            this.panel9.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(-3, -5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnAgregar.Size = new System.Drawing.Size(228, 53);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "          Agregar Servicio";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pnlServicios
            // 
            this.pnlServicios.Controls.Add(this.btnServicios);
            this.pnlServicios.Location = new System.Drawing.Point(-9, 0);
            this.pnlServicios.Name = "pnlServicios";
            this.pnlServicios.Size = new System.Drawing.Size(218, 54);
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
            this.btnServicios.Size = new System.Drawing.Size(254, 63);
            this.btnServicios.TabIndex = 1;
            this.btnServicios.Text = "              Servicios";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnConfig);
            this.panel6.Location = new System.Drawing.Point(3, 367);
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
            this.btnConfig.Location = new System.Drawing.Point(-28, -8);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(241, 65);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "             Configuración";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // pnlRelleno
            // 
            this.pnlRelleno.Location = new System.Drawing.Point(3, 423);
            this.pnlRelleno.Name = "pnlRelleno";
            this.pnlRelleno.Size = new System.Drawing.Size(210, 120);
            this.pnlRelleno.TabIndex = 6;
            this.pnlRelleno.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlRelleno_MouseDown);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnLogout);
            this.panel8.Location = new System.Drawing.Point(3, 549);
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
            // GestionUserTimer
            // 
            this.GestionUserTimer.Interval = 10;
            this.GestionUserTimer.Tick += new System.EventHandler(this.GestionTimer_Tick);
            // 
            // pnlInicio
            // 
            this.pnlInicio.AutoScroll = true;
            this.pnlInicio.BackColor = System.Drawing.Color.Beige;
            this.pnlInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInicio.Location = new System.Drawing.Point(212, 0);
            this.pnlInicio.Name = "pnlInicio";
            this.pnlInicio.Size = new System.Drawing.Size(962, 624);
            this.pnlInicio.TabIndex = 1;
            this.pnlInicio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlInicio_MouseDown);
            // 
            // GestionLibroTimer
            // 
            this.GestionLibroTimer.Interval = 10;
            this.GestionLibroTimer.Tick += new System.EventHandler(this.GestionLibroTimer_Tick);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 624);
            this.Controls.Add(this.pnlInicio);
            this.Controls.Add(this.BarraLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "z";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Inicio_MouseDown);
            this.BarraLateral.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.gestionContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlGestionar.ResumeLayout(false);
            this.librosContainer.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.pnlLibros.ResumeLayout(false);
            this.servicesContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.pnlServicios.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel servicesContainer;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnGestServ;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Timer ServicesTimer;
        private System.Windows.Forms.Panel gestionContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAgregarUser;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Panel pnlGestionar;
        private System.Windows.Forms.Button btnGestionar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Timer GestionUserTimer;
        private System.Windows.Forms.FlowLayoutPanel pnlInicio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRevisar;
        private System.Windows.Forms.Panel pnlRelleno;
        private System.Windows.Forms.Panel librosContainer;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnAgregarlibro;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnLibros;
        private System.Windows.Forms.Panel pnlLibros;
        private System.Windows.Forms.Button btnGestionLibros;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btnAlphilia;
        private System.Windows.Forms.Timer GestionLibroTimer;
    }
}