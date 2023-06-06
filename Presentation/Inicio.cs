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
using System.Net;
using System.IO;

namespace Imagina
{
    public partial class Inicio : Form
    {
        UserModel userModel = new UserModel();
        ProductModel productModel = new ProductModel();
        ServiceModel serviceModel = new ServiceModel();
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
            
            var usuarios = userModel.ObtenerUsuarios();
            string TipoUsuario = "Desconocido";
            string Genero = "Desconocido";
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            foreach (User usuario in usuarios)
            {
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

                if (usuario.IdGenero == 1)
                {
                    Genero = "Masculino";
                }
                else if (usuario.IdGenero == 2)
                {
                    Genero = "Femenino";
                }
                else if (usuario.IdGenero == 3)
                {
                    Genero = "Personalizado";
                }

                if (usuario.IdTipoUsuario != 1)
                {
                    Panel panel = new Panel();
                    panel.Name = "pnl" + usuario.Rut;
                    panel.BackColor = System.Drawing.Color.White;
                    panel.Location = new System.Drawing.Point(3, 3);
                    panel.Size = new System.Drawing.Size(295, 290);
                    panel.TabIndex = 0;
                    panel.ResumeLayout(false);
                    panel.PerformLayout();
                    panel.Padding = new Padding(10);
                    panel.Margin = new Padding(10);

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
                    btnModificar.Text = "Gestionar";
                    btnModificar.UseVisualStyleBackColor = false;
                    btnModificar.Click += (sender, e) =>
                    {
                        GestionUsuario modalGestion = new GestionUsuario();
                        modalGestion.Rut = usuario.Rut;
                        modalGestion.Nombre = usuario.Nombre;
                        modalGestion.Apellidos = usuario.Apellidos;
                        modalGestion.Telefono = usuario.Telefono;
                        modalGestion.Correo = usuario.Correo;
                        modalGestion.Password = usuario.Password;
                        modalGestion.FechaNacimiento = usuario.FechaNacimiento;
                        modalGestion.Direccion = usuario.Direccion;
                        modalGestion.AniosExperiencia = usuario.AniosExperiencia;
                        modalGestion.Genero = Genero;
                        modalGestion.IdComuna = usuario.IdComuna;
                        modalGestion.TipoUsuario = TipoUsuario;

                        modalGestion.FormClosed += GestionarUsuario_FormClosed;
                        this.Hide();

                        modalGestion.ShowDialog();
                    };

                    Button btnEliminar = new Button();
                    btnEliminar.BackColor = System.Drawing.Color.Red;
                    btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnEliminar.FlatAppearance.BorderSize = 0;
                    btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                    btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                    btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnEliminar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnEliminar.ForeColor = System.Drawing.Color.White;
                    btnEliminar.Location = new System.Drawing.Point(95, 250);
                    btnEliminar.Name = "btnEliminar";
                    btnEliminar.Size = new System.Drawing.Size(89, 31);
                    btnEliminar.TabIndex = 13;
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseVisualStyleBackColor = false;
                    btnEliminar.Click += (sender, e) =>
                    {
                        bool eliminarUsuario = userModel.EliminarUsuario(usuario.Rut);
                        if (eliminarUsuario)
                        {
                            MessageBox.Show("Usuario Eliminado");
                            listarUsuarios();
                        }
                    };

                    Label lblRut = new Label();
                    lblRut.AutoSize = true;
                    lblRut.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblRut.Location = new System.Drawing.Point(13, 187);
                    lblRut.Name = "lblRut";
                    lblRut.Size = new System.Drawing.Size(40, 17);
                    lblRut.TabIndex = 5;
                    lblRut.Text = "Rut:" + usuario.Rut;

                    Label lblCorreo = new Label();
                    lblCorreo.AutoSize = true;
                    lblCorreo.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblCorreo.Location = new System.Drawing.Point(13, 166);
                    lblCorreo.Name = "lblCorreo";
                    lblCorreo.Size = new System.Drawing.Size(64, 17);
                    lblCorreo.TabIndex = 4;
                    lblCorreo.Text = "Correo:" + usuario.Correo;

                    Label lblApellidos = new Label();
                    lblApellidos.AutoSize = true;
                    lblApellidos.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblApellidos.Location = new System.Drawing.Point(13, 143);
                    lblApellidos.Name = "lblApellidos";
                    lblApellidos.Size = new System.Drawing.Size(88, 17);
                    lblApellidos.TabIndex = 3;
                    lblApellidos.Text = "Apellidos:" + usuario.Apellidos;

                    Label lblNombre = new Label();
                    lblNombre.AutoSize = true;
                    lblNombre.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblNombre.Location = new System.Drawing.Point(13, 121);
                    lblNombre.Name = "lblNombre";
                    lblNombre.Size = new System.Drawing.Size(64, 17);
                    lblNombre.TabIndex = 2;
                    lblNombre.Text = "Nombre:" + usuario.Nombre;

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
                    panel.Controls.Add(btnEliminar);
                }    
            }
        }

        private void listarProductos()
        {
            pnlInicio.Controls.Clear();

            var productos = productModel.ObtenerProductos();
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            foreach (Producto producto in productos)
            {
                Panel pnlProductos = new Panel();
                pnlProductos.BackColor = System.Drawing.Color.White;
                pnlProductos.Location = new System.Drawing.Point(3, 3);
                pnlProductos.Name = "pnlProductos";
                pnlProductos.Size = new System.Drawing.Size(285, 400);
                pnlProductos.TabIndex = 0;
                pnlProductos.ResumeLayout(false);
                pnlProductos.PerformLayout();
                pnlProductos.Padding = new Padding(10);
                pnlProductos.Margin = new Padding(13);

                Label lblGenero = new Label();
                lblGenero.AutoSize = true;
                lblGenero.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblGenero.Location = new System.Drawing.Point(14, 323);
                lblGenero.Name = "lblGenero";
                lblGenero.Size = new System.Drawing.Size(122, 19);
                lblGenero.TabIndex = 4;
                lblGenero.Text = "Genero: " + producto.NombreGenero;

                Label lblStock = new Label();
                lblStock.AutoSize = true;
                lblStock.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblStock.Location = new System.Drawing.Point(14, 297);
                lblStock.Name = "lblStock";
                lblStock.Size = new System.Drawing.Size(49, 19);
                lblStock.TabIndex = 3;
                lblStock.Text = "Stock: " + producto.Stock;

                Label lblPrecio = new Label();
                lblPrecio.AutoSize = true;
                lblPrecio.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblPrecio.Location = new System.Drawing.Point(14, 269);
                lblPrecio.Name = "lblPrecio";
                lblPrecio.Size = new System.Drawing.Size(55, 19);
                lblPrecio.TabIndex = 2;
                lblPrecio.Text = "Precio: " +  producto.Precio;

                Label lblNombre = new Label();
                lblNombre.AutoSize = true;
                lblNombre.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblNombre.Location = new System.Drawing.Point(14, 240);
                lblNombre.Name = "lblNombre";
                lblNombre.Size = new System.Drawing.Size(67, 19);
                lblNombre.TabIndex = 1;
                lblNombre.Text = "Nombre: " + producto.Nombre;

                PictureBox imgProductos = new PictureBox();
                var Imagen = ConvertirImagen(producto.Imagen);
                imgProductos.Image = Imagen;
                imgProductos.Location = new System.Drawing.Point(65, 9);
                imgProductos.Name = "imgProductos";
                imgProductos.Size = new System.Drawing.Size(150, 207);
                imgProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                imgProductos.TabIndex = 0;
                imgProductos.TabStop = false;

                Button btnModificar = new Button();
                btnModificar.BackColor = System.Drawing.Color.Black;
                btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
                btnModificar.FlatAppearance.BorderSize = 0;
                btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnModificar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnModificar.ForeColor = System.Drawing.Color.White;
                btnModificar.Location = new System.Drawing.Point(87, 353);
                btnModificar.Name = "btnModificar";
                btnModificar.Size = new System.Drawing.Size(105, 35);
                btnModificar.TabIndex = 4;
                btnModificar.Text = "Gestionar";
                btnModificar.UseVisualStyleBackColor = false;
                btnModificar.Click += (sender, e) =>
                {
                    GestionProducto gestionProducto = new GestionProducto();
                    gestionProducto.IdProducto = producto.IdProducto;
                    gestionProducto.Nombre = producto.Nombre;
                    gestionProducto.Imagen = Imagen;
                    gestionProducto.Precio = producto.Precio;
                    gestionProducto.Stock = producto.Stock;

                    gestionProducto.ShowDialog();
                };

                pnlInicio.Controls.Add(pnlProductos);
                pnlProductos.Controls.Add(lblGenero);
                pnlProductos.Controls.Add(lblStock);
                pnlProductos.Controls.Add(lblPrecio);
                pnlProductos.Controls.Add(lblNombre);
                pnlProductos.Controls.Add(imgProductos);
                pnlProductos.Controls.Add(btnModificar);
            }
        }

        private void listarServicios()
        {
            pnlInicio.Controls.Clear();
            string TipoServicio = "Desconocido";

            var servicios = serviceModel.ObtenerServicios();
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            foreach (Servicio servicio in servicios)
            {
                if (servicio.IdTipoServicio == 1)
                {
                    TipoServicio = "Mantencion";
                } 
                else if (servicio.IdTipoServicio == 2)
                {
                    TipoServicio = "Reparacion";
                }

                if (servicio.RutCliente == null && servicio.RutTecnico == UserLoginCache.Rut)
                {
                    Panel pnlServicios = new Panel();
                    pnlServicios.BackColor = System.Drawing.Color.White;
                    pnlServicios.Location = new System.Drawing.Point(3, 3);
                    pnlServicios.Name = "pnlServicios";
                    pnlServicios.Size = new System.Drawing.Size(226, 280);
                    pnlServicios.TabIndex = 0;
                    pnlServicios.Padding = new Padding(10);
                    pnlServicios.Margin = new Padding(5);

                    Label lblTipo = new Label();
                    lblTipo.AutoSize = true;
                    lblTipo.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTipo.Location = new System.Drawing.Point(3, 178);
                    lblTipo.Name = "lblTipo";
                    lblTipo.Size = new System.Drawing.Size(121, 19);
                    lblTipo.TabIndex = 2;
                    lblTipo.Text = "Tipo de Servicio: " + TipoServicio;

                    Label lblFecha = new Label();
                    lblFecha.AutoSize = true;
                    lblFecha.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblFecha.Location = new System.Drawing.Point(3, 147);
                    lblFecha.Name = "lblFecha";
                    lblFecha.Size = new System.Drawing.Size(111, 19);
                    lblFecha.TabIndex = 1;
                    string FechaSinHora = servicio.FechaServicio.ToString("dd/MM/yyyy");
                    lblFecha.Text = "Fecha Servicio: " + FechaSinHora;

                    PictureBox imgServicio = new PictureBox();
                    imgServicio.Image = global::Imagina.Properties.Resources.ListServices;
                    imgServicio.Location = new System.Drawing.Point(57, 38);
                    imgServicio.Name = "pictureBox1";
                    imgServicio.Size = new System.Drawing.Size(100, 86);
                    imgServicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    imgServicio.TabIndex = 0;
                    imgServicio.TabStop = false;

                    Button btnModificar = new Button();
                    btnModificar.BackColor = System.Drawing.Color.Black;
                    btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnModificar.FlatAppearance.BorderSize = 0;
                    btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                    btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                    btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnModificar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnModificar.ForeColor = System.Drawing.Color.White;
                    btnModificar.Location = new System.Drawing.Point(45, 215);
                    btnModificar.Name = "btnModificar";
                    btnModificar.Size = new System.Drawing.Size(129, 27);
                    btnModificar.TabIndex = 12;
                    btnModificar.Text = "Gestionar";
                    btnModificar.UseVisualStyleBackColor = false;
                    btnModificar.Click += (sender, e) =>
                    {
                        AgregarServicio agregarServicio = new AgregarServicio(true);
                        agregarServicio.IdServicio = servicio.Id;
                        agregarServicio.FormClosed += AgregarServicio_FormClosed;
                        this.Hide();
                        agregarServicio.ShowDialog();
                    };

                    Button btnEliminar = new Button();
                    btnEliminar.BackColor = System.Drawing.Color.Red;
                    btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnEliminar.FlatAppearance.BorderSize = 0;
                    btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                    btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                    btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnEliminar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnEliminar.ForeColor = System.Drawing.Color.White;
                    btnEliminar.Location = new System.Drawing.Point(45, 248);
                    btnEliminar.Name = "btnEliminar";
                    btnEliminar.Size = new System.Drawing.Size(129, 27);
                    btnEliminar.TabIndex = 13;
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseVisualStyleBackColor = false;
                    btnEliminar.Click += (sender, e) =>
                    {
                        bool eliminarSevicio = serviceModel.EliminarServicio(servicio.Id);
                        if (eliminarSevicio)
                        {
                            MessageBox.Show("Servicio Eliminado");
                            listarServicios();
                        }
                    };

                    pnlInicio.Controls.Add(pnlServicios);
                    pnlServicios.Controls.Add(lblTipo);
                    pnlServicios.Controls.Add(lblFecha);
                    pnlServicios.Controls.Add(imgServicio);
                    pnlServicios.Controls.Add(btnModificar);
                    pnlServicios.Controls.Add(btnEliminar);
                }
            }
        }

        private void listarSolicitudes()
        {
            pnlInicio.Controls.Clear();
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;
            var servicios = serviceModel.ObtenerServicios();
            string TipoServicio = "Desconocido";

            foreach (Servicio servicio in servicios)
            {
                if (servicio.IdTipoServicio == 1)
                {
                    TipoServicio = "Mantencion";
                }
                else if (servicio.IdTipoServicio == 2)
                {
                    TipoServicio = "Reparacion";
                }

                if (servicio.RutCliente != null && servicio.RutTecnico == UserLoginCache.Rut && servicio.Costo == null)
                {
                    Panel pnlSolicitud = new Panel();
                    pnlServicios.Padding = new Padding(10);
                    pnlServicios.Margin = new Padding(5);
                    pnlSolicitud.BackColor = System.Drawing.Color.White;
                    pnlSolicitud.Location = new System.Drawing.Point(3, 3);
                    pnlSolicitud.Name = "pnlSolicitud";
                    pnlSolicitud.Size = new System.Drawing.Size(333, 400);
                    pnlSolicitud.TabIndex = 0;

                    Button btnRechazar = new Button();
                    btnRechazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    btnRechazar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnRechazar.FlatAppearance.BorderSize = 0;
                    btnRechazar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                    btnRechazar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                    btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnRechazar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnRechazar.ForeColor = System.Drawing.Color.White;
                    btnRechazar.Location = new System.Drawing.Point(180, 330);
                    btnRechazar.Name = "btnRechazar";
                    btnRechazar.Size = new System.Drawing.Size(107, 44);
                    btnRechazar.TabIndex = 6;
                    btnRechazar.Text = "Rechazar";
                    btnRechazar.UseVisualStyleBackColor = false;
                    btnRechazar.Click += (sender, e) =>
                    {
                        serviceModel.Rechazar(servicio.Id);
                        listarSolicitudes();
                    };

                    PictureBox pbConfirmar = new PictureBox();
                    pbConfirmar.Image = Properties.Resources.Aceptar;
                    pbConfirmar.Cursor = Cursors.Hand;
                    pbConfirmar.Location = new Point(45, 330);
                    pbConfirmar.Size = new Size(107, 44);
                    pbConfirmar.SizeMode = PictureBoxSizeMode.Zoom;
                    pbConfirmar.Visible = false;
                    

                    PictureBox pbCancelar = new PictureBox();
                    pbCancelar.Image = Properties.Resources.Cancelar;
                    pbCancelar.Cursor = Cursors.Hand;
                    pbCancelar.Location = new Point(180, 330);
                    pbCancelar.Size = new Size(107, 44);
                    pbCancelar.SizeMode = PictureBoxSizeMode.Zoom;
                    pbCancelar.Visible = false;

                    Label lblIngreseMonto = new Label();
                    lblIngreseMonto.AutoSize = true;
                    lblIngreseMonto.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblIngreseMonto.Location = new System.Drawing.Point(19, 290);
                    lblIngreseMonto.Name = "lblIngreseMonto";
                    lblIngreseMonto.Size = new System.Drawing.Size(119, 19);
                    lblIngreseMonto.TabIndex = 8;
                    lblIngreseMonto.Text = "Ingrese Monto: ";
                    lblIngreseMonto.Visible = false;

                    TextBox txtMonto = new TextBox();
                    txtMonto.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    txtMonto.Location = new System.Drawing.Point(144, 290);
                    txtMonto.Name = "txtMonto";
                    txtMonto.Size = new System.Drawing.Size(164, 20);
                    txtMonto.TabIndex = 9;
                    txtMonto.Visible = false;
                    txtMonto.KeyPress += new KeyPressEventHandler(txtMonto_KeyPress);

                    pbConfirmar.Click += (sender, e) =>
                    {
                        int costo = int.Parse(txtMonto.Text);
                        serviceModel.AgregarCosto(servicio.Id, costo);
                        pnlSolicitud.Visible = false;
                    };

                    Button btnAceptar = new Button();
                    btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                    btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnAceptar.FlatAppearance.BorderSize = 0;
                    btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                    btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                    btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnAceptar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnAceptar.ForeColor = System.Drawing.Color.White;
                    btnAceptar.Location = new System.Drawing.Point(45, 330);
                    btnAceptar.Name = "btnAceptar";
                    btnAceptar.Size = new System.Drawing.Size(107, 44);
                    btnAceptar.TabIndex = 5;
                    btnAceptar.Text = "Aceptar";
                    btnAceptar.UseVisualStyleBackColor = false;
                    btnAceptar.Click += (sender, e) =>
                    {
                        txtMonto.Visible = true;
                        lblIngreseMonto.Visible = true;
                        btnAceptar.Visible = false;
                        btnRechazar.Visible = false;
                        pbConfirmar.Visible = true;
                        pbCancelar.Visible = true;
                    };

                    pbCancelar.Click += (sender, e) =>
                    {
                        txtMonto.Visible = false;
                        lblIngreseMonto.Visible = false;
                        btnAceptar.Visible = true;
                        btnRechazar.Visible = true;
                        pbConfirmar.Visible = false;
                        pbCancelar.Visible = false;
                    };

                    Label lblDetalles = new Label();
                    lblDetalles.AutoSize = true;
                    lblDetalles.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblDetalles.Location = new System.Drawing.Point(103, 156);
                    lblDetalles.Name = "lblDetalles";
                    lblDetalles.Size = new System.Drawing.Size(106, 19);
                    lblDetalles.TabIndex = 4;
                    lblDetalles.Text = "Detalles Libros";

                    Label lblTipo = new Label();
                    lblTipo.AutoSize = true;
                    lblTipo.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTipo.Location = new System.Drawing.Point(19, 105);
                    lblTipo.Name = "lblTipo";
                    lblTipo.Size = new System.Drawing.Size(101, 19);
                    lblTipo.TabIndex = 3;
                    lblTipo.Text = "Tipo Servicio: "  + TipoServicio;

                    Label lblCliente = new Label();
                    lblCliente.AutoSize = true;
                    lblCliente.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblCliente.Location = new System.Drawing.Point(19, 62);
                    lblCliente.Name = "lblCliente";
                    lblCliente.Size = new System.Drawing.Size(63, 19);
                    lblCliente.TabIndex = 2;
                    lblCliente.Text = "Cliente: " + servicio.RutCliente;

                    RichTextBox richTxtDetalle = new RichTextBox();
                    richTxtDetalle.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    richTxtDetalle.Location = new System.Drawing.Point(23, 178);
                    richTxtDetalle.Name = "richTxtDetalle";
                    richTxtDetalle.Size = new System.Drawing.Size(285, 96);
                    richTxtDetalle.TabIndex = 1;
                    richTxtDetalle.ReadOnly = true;
                    richTxtDetalle.Text = servicio.EstadoLibro;

                    Label lblFecha = new Label();
                    lblFecha.AutoSize = true;
                    lblFecha.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblFecha.Location = new System.Drawing.Point(19, 21);
                    lblFecha.Name = "lblFecha";
                    lblFecha.Size = new System.Drawing.Size(55, 19);
                    lblFecha.TabIndex = 0;
                    lblFecha.Text = "Fecha: " + servicio.FechaServicio;

                    pnlInicio.Controls.Add(pnlSolicitud);
                    pnlSolicitud.Controls.Add(btnAceptar);
                    pnlSolicitud.Controls.Add(btnRechazar);
                    pnlSolicitud.Controls.Add(lblDetalles);
                    pnlSolicitud.Controls.Add(lblTipo);
                    pnlSolicitud.Controls.Add(lblCliente);
                    pnlSolicitud.Controls.Add(lblFecha);
                    pnlSolicitud.Controls.Add(richTxtDetalle);
                    pnlSolicitud.Controls.Add(txtMonto);
                    pnlSolicitud.Controls.Add(lblIngreseMonto);
                    pnlSolicitud.Controls.Add(pbConfirmar);
                    pnlSolicitud.Controls.Add(pbCancelar);
                }
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {

                e.Handled = true;
            }
        }

        private Image ConvertirImagen(string imagen)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    byte[] imagenBytes = webClient.DownloadData(imagen);

                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
                catch (Exception)
                {   
                    return Properties.Resources.UsersList;
                }
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

        private void btnLibros_Click(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarServicio agregarServicio = new AgregarServicio(false);
            agregarServicio.FormClosed += AgregarServicio_FormClosed;
            this.Hide();
            agregarServicio.ShowDialog();
        }
        private void AgregarServicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            pnlInicio.Controls.Clear();
        }

        private void GestionarUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            listarUsuarios();
        }

        private void btnGestServ_Click(object sender, EventArgs e)
        {
            listarServicios();
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            listarSolicitudes();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}
