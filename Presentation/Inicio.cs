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
        ProductModelWS productModelWS = new ProductModelWS();
        ServiceModel serviceModel = new ServiceModel();
        ProductoModel productModel = new ProductoModel();
        VentaModel ventaModel = new VentaModel();
        bool barraLateralExpand = true;
        bool serviceCollapsed = true;
        bool gestionUserCollapsed = true;
        bool gestionLibroCollapsed = true;
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
                        modalGestion.IdGenero = usuario.IdGenero;
                        modalGestion.IdComuna = usuario.IdComuna;
                        modalGestion.IdTipoUsuario = usuario.IdTipoUsuario;

                        modalGestion.FormClosed += GestionUsuario_FormClosed;
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

                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            bool eliminarUsuario = userModel.EliminarUsuario(usuario.Rut);
                            if (eliminarUsuario)
                            {
                                MessageBox.Show("Usuario Eliminado");
                                listarUsuarios();
                            }
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

        private void listarProductosWS()
        {
            pnlInicio.Controls.Clear();

            var productos = productModelWS.ObtenerProductos();
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            foreach (Producto producto in productos)
            {
                Panel pnlProductos = new Panel();
                pnlProductos.BorderStyle = BorderStyle.FixedSingle;
                pnlProductos.BackColor = System.Drawing.Color.White;
                pnlProductos.Location = new System.Drawing.Point(3, 3);
                pnlProductos.Name = "pnlProductos";
                pnlProductos.Size = new System.Drawing.Size(285, 405);
                pnlProductos.TabIndex = 0;
                pnlProductos.ResumeLayout(false);
                pnlProductos.PerformLayout();
                pnlProductos.Padding = new Padding(10);
                pnlProductos.Margin = new Padding(13);

                if (producto.IdTipoProducto == 1)
                {
                    Label lblGenero = new Label();
                    lblGenero.AutoSize = true;
                    lblGenero.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblGenero.Location = new System.Drawing.Point(14, 323);
                    lblGenero.Name = "lblGenero";
                    lblGenero.Size = new System.Drawing.Size(122, 19);
                    lblGenero.TabIndex = 4;
                    lblGenero.Text = "Genero: " + producto.NombreGenero;
                    pnlProductos.Controls.Add(lblGenero);
                }
                else
                {
                    Label lblTipo = new Label();
                    lblTipo.AutoSize = true;
                    lblTipo.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTipo.Location = new System.Drawing.Point(14, 323);
                    lblTipo.Name = "lblGenero";
                    lblTipo.Size = new System.Drawing.Size(122, 19);
                    lblTipo.TabIndex = 4;
                    lblTipo.Text = "Tipo Producto: " + producto.NombreTipo;
                    pnlProductos.Controls.Add(lblTipo);
                }

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
                var Imagen = ConvertirImagenWS(producto.Imagen);
                imgProductos.Image = Imagen;
                imgProductos.Location = new System.Drawing.Point(65, 9);
                imgProductos.Name = "imgProductos";
                imgProductos.Size = new System.Drawing.Size(150, 207);
                imgProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                imgProductos.TabIndex = 0;
                imgProductos.TabStop = false;

                if (producto.Stock > 0)
                {
                    Button btnAgregar = new Button();
                    btnAgregar.BackColor = System.Drawing.Color.Black;
                    btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnAgregar.FlatAppearance.BorderSize = 0;
                    btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                    btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                    btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnAgregar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnAgregar.ForeColor = System.Drawing.Color.White;
                    btnAgregar.Location = new System.Drawing.Point(60, 355);
                    btnAgregar.Name = "btnAgregar";
                    btnAgregar.Size = new System.Drawing.Size(160, 35);
                    btnAgregar.TabIndex = 4;
                    btnAgregar.Text = "Agregar a Bodega";
                    btnAgregar.UseVisualStyleBackColor = false;
                    btnAgregar.Click += (sender, e) =>
                    {
                        GestionProductoWS gestionProducto = new GestionProductoWS();
                        gestionProducto.IdProducto = producto.IdProducto;
                        gestionProducto.Nombre = producto.Nombre;
                        gestionProducto.Autor = producto.Autor;
                        gestionProducto.Descripcion = producto.Descripcion;
                        gestionProducto.Imagen = Imagen;
                        gestionProducto.Precio = producto.Precio;
                        gestionProducto.Stock = producto.Stock;
                        gestionProducto.IdGeneroLiterario = producto.IdGeneroLiterario;
                        gestionProducto.IdTipoProducto = producto.IdTipoProducto;

                        gestionProducto.FormClosed += GestionProducto_FormClosed;
                        gestionProducto.ShowDialog();
                    };
                    pnlProductos.Controls.Add(btnAgregar);
                }
                else
                {
                    Label lblNoStock = new Label();
                    lblNoStock.Text = "Sin Stock Disponible";
                    lblNoStock.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblNoStock.ForeColor = System.Drawing.Color.Red;
                    lblNoStock.Size = new System.Drawing.Size(160, 35);
                    lblNoStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblNoStock.Location = new System.Drawing.Point(60, 355);
                    pnlProductos.Controls.Add(lblNoStock);
                }

                pnlInicio.Controls.Add(pnlProductos);
                pnlProductos.Controls.Add(lblStock);
                pnlProductos.Controls.Add(lblPrecio);
                pnlProductos.Controls.Add(lblNombre);
                pnlProductos.Controls.Add(imgProductos);
            }
        }

        private void listarProductos()
        {
            pnlInicio.Controls.Clear();

            var productos = productModel.ListarProductos();
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            foreach (Producto producto in productos)
            {
                Panel pnlProductos = new Panel();
                pnlProductos.BorderStyle = BorderStyle.FixedSingle;
                pnlProductos.BackColor = System.Drawing.Color.White;
                pnlProductos.Location = new System.Drawing.Point(3, 3);
                pnlProductos.Name = "pnlProductos";
                pnlProductos.TabIndex = 0;
                pnlProductos.ResumeLayout(false);
                pnlProductos.PerformLayout();
                pnlProductos.Padding = new Padding(10);
                pnlProductos.Margin = new Padding(13);
                pnlProductos.Size = new System.Drawing.Size(285, 450);

                PictureBox imgProductos = new PictureBox();
                var Imagen = ConvertirImagenBD(producto.Imagen);
                imgProductos.Image = Imagen;
                imgProductos.Location = new System.Drawing.Point(65, 9);
                imgProductos.Name = "imgProductos";
                imgProductos.Size = new System.Drawing.Size(150, 207);
                imgProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                imgProductos.TabIndex = 0;
                imgProductos.TabStop = false;

                if (producto.Stock > 0 || UserLoginCache.IdTipoUsuario ==1)
                {
                    if (UserLoginCache.IdTipoUsuario == 1)
                    {
                        Button btnGestionar = new Button();
                        btnGestionar.BackColor = System.Drawing.Color.Black;
                        btnGestionar.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnGestionar.FlatAppearance.BorderSize = 0;
                        btnGestionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                        btnGestionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                        btnGestionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnGestionar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnGestionar.ForeColor = System.Drawing.Color.White;
                        btnGestionar.Location = new System.Drawing.Point(60, 355);
                        btnGestionar.Name = "btnGestionar";
                        btnGestionar.Size = new System.Drawing.Size(160, 35);
                        btnGestionar.TabIndex = 4;
                        btnGestionar.Text = "Gestionar Producto";
                        btnGestionar.UseVisualStyleBackColor = false;
                        btnGestionar.Click += (sender, e) =>
                        {
                            GestionProductoBD gestionProductoBD = new GestionProductoBD();
                            gestionProductoBD.IdProducto = producto.IdProducto;
                            gestionProductoBD.Nombre = producto.Nombre;
                            gestionProductoBD.Autor = producto.Autor;
                            gestionProductoBD.Descripcion = producto.Descripcion;
                            gestionProductoBD.Precio = producto.Precio;
                            gestionProductoBD.Stock = producto.Stock;
                            gestionProductoBD.Imagen = Imagen;
                            gestionProductoBD.IdGeneroLiterario = producto.IdGeneroLiterario;
                            gestionProductoBD.IdTipoProducto = producto.IdTipoProducto;

                            gestionProductoBD.FormClosed += GestionProductoBD_FormClosed;
                            gestionProductoBD.ShowDialog();
                        };
                        pnlProductos.Controls.Add(btnGestionar);

                        Button btnEliminar = new Button();
                        btnEliminar.BackColor = System.Drawing.Color.Red;
                        btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnEliminar.FlatAppearance.BorderSize = 0;
                        btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                        btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                        btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnEliminar.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnEliminar.ForeColor = System.Drawing.Color.White;
                        btnEliminar.Location = new System.Drawing.Point(60, 400);
                        btnEliminar.Name = "btnEliminar";
                        btnEliminar.Size = new System.Drawing.Size(160, 35);
                        btnEliminar.TabIndex = 4;
                        btnEliminar.Text = "Eliminar Producto";
                        btnEliminar.UseVisualStyleBackColor = false;
                        btnEliminar.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas eliminar el {producto.NombreTipo}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                bool eliminarProducto = productModel.EliminarProducto(producto.IdProducto);
                                if (eliminarProducto)
                                {
                                    MessageBox.Show(producto.NombreTipo+" Eliminado");
                                    listarProductos();
                                }
                            }
                        };
                        pnlProductos.Controls.Add(btnEliminar);
                    }
                    else
                    {
                        Button btnVenta = new Button();
                        btnVenta.BackColor = System.Drawing.Color.Black;
                        btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnVenta.FlatAppearance.BorderSize = 0;
                        btnVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
                        btnVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
                        btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnVenta.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnVenta.ForeColor = System.Drawing.Color.White;
                        btnVenta.Location = new System.Drawing.Point(60, 375);
                        btnVenta.Name = "btnVenta";
                        btnVenta.Size = new System.Drawing.Size(160, 35);
                        btnVenta.TabIndex = 4;
                        btnVenta.Text = "Agregar a la Venta";
                        btnVenta.UseVisualStyleBackColor = false;
                        btnVenta.Click += (sender, e) =>
                        {
                            var carritos = ventaModel.ObtenerCarritos();
                            bool productoExistente = false;
                            foreach (Carrito carrito in carritos)
                            {
                                if (carrito.Codigo == producto.IdProducto && carrito.Rut == UserLoginCache.Rut)
                                {
                                    productoExistente = true;
                                }
                            }

                            if (productoExistente)
                            {
                                MessageBox.Show("El producto ya se encuentra en el carrito");
                            }
                            else
                            {
                                bool agregar = ventaModel.RegistrarCarrito(producto.IdProducto, UserLoginCache.Rut, producto.Nombre, producto.Precio, 1);
                                MessageBox.Show(producto.NombreTipo + " Agregado al carrito");
                            }
                        };
                        pnlProductos.Controls.Add(btnVenta);
                    }
                }
                else
                {
                    Label lblNoStock = new Label();
                    lblNoStock.Text = "Sin Stock Disponible";
                    lblNoStock.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblNoStock.ForeColor = System.Drawing.Color.Red;
                    lblNoStock.Size = new System.Drawing.Size(160, 35);
                    lblNoStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblNoStock.Location = new System.Drawing.Point(60, 380);
                    pnlProductos.Controls.Add(lblNoStock);
                }

                if (producto.IdTipoProducto == 1)
                {
                    Label lblGenero = new Label();
                    lblGenero.AutoSize = true;
                    lblGenero.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblGenero.Location = new System.Drawing.Point(14, 323);
                    lblGenero.Name = "lblGenero";
                    lblGenero.Size = new System.Drawing.Size(122, 19);
                    lblGenero.TabIndex = 4;
                    lblGenero.Text = "Genero: " + producto.NombreGenero;
                    pnlProductos.Controls.Add(lblGenero);
                }
                else
                {
                    Label lblTipo = new Label();
                    lblTipo.AutoSize = true;
                    lblTipo.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTipo.Location = new System.Drawing.Point(14, 323);
                    lblTipo.Name = "lblGenero";
                    lblTipo.Size = new System.Drawing.Size(122, 19);
                    lblTipo.TabIndex = 4;
                    lblTipo.Text = "Tipo Producto: " + producto.NombreTipo;
                    pnlProductos.Controls.Add(lblTipo);
                }

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
                lblPrecio.Text = "Precio: " + producto.Precio;

                Label lblNombre = new Label();
                lblNombre.AutoSize = true;
                lblNombre.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblNombre.Location = new System.Drawing.Point(14, 240);
                lblNombre.Name = "lblNombre";
                lblNombre.Size = new System.Drawing.Size(67, 19);
                lblNombre.TabIndex = 1;
                lblNombre.Text = "Nombre: " + producto.Nombre;

                pnlInicio.Controls.Add(pnlProductos);
                
                pnlProductos.Controls.Add(lblStock);
                pnlProductos.Controls.Add(lblPrecio);
                pnlProductos.Controls.Add(lblNombre);
                pnlProductos.Controls.Add(imgProductos);
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

        private void listarCarrito()
        {
            pnlInicio.Controls.Clear();
            pnlInicio.FlowDirection = FlowDirection.LeftToRight;
            pnlInicio.WrapContents = true;

            var carritos = ventaModel.ObtenerCarritos();
            int totalVenta = 0;

            FlowLayoutPanel containerVenta = new FlowLayoutPanel();
            containerVenta.AutoScroll = true;
            containerVenta.Location = new System.Drawing.Point(3, 3);
            containerVenta.Name = "containerVenta";
            containerVenta.Size = new System.Drawing.Size(648, 617);
            containerVenta.TabIndex = 0;

            Label lblNoHayProductos = new Label();
            lblNoHayProductos.AutoSize = true;
            lblNoHayProductos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNoHayProductos.Location = new System.Drawing.Point(166, 15);
            lblNoHayProductos.Name = "lblNoHayProductos";
            lblNoHayProductos.Size = new System.Drawing.Size(200, 23);
            lblNoHayProductos.TabIndex = 1;
            lblNoHayProductos.Text = "No hay productos en el carrito";
            
            Label lblTotalPrecio = new Label();

            Dictionary<int, int> cantidadesSeleccionadas = new Dictionary<int, int>();
            if (carritos.Count > 0)
            {
                foreach (Carrito carrito in carritos)
                {
                    if (carrito.Rut == UserLoginCache.Rut)
                    {
                        Producto producto = productModel.ObtenerProducto(carrito.Codigo);

                        if (producto != null)
                        {
                            Panel pnlProducto = new Panel();
                            pnlProducto.BackColor = System.Drawing.Color.LightBlue;
                            pnlProducto.Cursor = System.Windows.Forms.Cursors.Arrow;
                            pnlProducto.Location = new System.Drawing.Point(3, 3);
                            pnlProducto.Margin = new Padding(0, 0, 0, 10);
                            pnlProducto.Name = "pnlProducto";
                            pnlProducto.Size = new System.Drawing.Size(624, 237);
                            pnlProducto.TabIndex = 0;

                            int precioUnitarioInicial = carrito.Precio;
                            totalVenta += precioUnitarioInicial;

                            ComboBox cboCantidad = new ComboBox();
                            cboCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                            cboCantidad.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            cboCantidad.FormattingEnabled = true;
                            cboCantidad.Location = new System.Drawing.Point(244, 194);
                            cboCantidad.Name = "cboCantidad";
                            cboCantidad.Size = new System.Drawing.Size(95, 23);
                            cboCantidad.TabIndex = 15;
                            for (int i = 1; i <= producto.Stock; i++)
                            {
                                cboCantidad.Items.Add(i);
                            }
                            cboCantidad.SelectedIndex = 0;


                            Label lblCantidad = new Label();
                            lblCantidad.AutoSize = true;
                            lblCantidad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblCantidad.Location = new System.Drawing.Point(166, 195);
                            lblCantidad.Name = "lblCantidad";
                            lblCantidad.Size = new System.Drawing.Size(77, 19);
                            lblCantidad.TabIndex = 9;
                            lblCantidad.Text = "Cantidad: ";

                            PictureBox imgBasurero = new PictureBox();
                            imgBasurero.Cursor = System.Windows.Forms.Cursors.Hand;
                            imgBasurero.Image = global::Imagina.Properties.Resources.Basurero;
                            imgBasurero.Location = new System.Drawing.Point(572, 193);
                            imgBasurero.Name = "imgBasurero";
                            imgBasurero.Size = new System.Drawing.Size(48, 39);
                            imgBasurero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                            imgBasurero.TabIndex = 8;
                            imgBasurero.TabStop = false;
                            imgBasurero.Click += (sender, e) =>
                            {
                                DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas eliminar el {producto.NombreTipo} del carrito?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    ventaModel.EliminarCarrito(carrito.Id);
                                    listarCarrito();
                                }
                            };

                            Label lblTipoProducto = new Label();
                            lblTipoProducto.AutoSize = true;
                            lblTipoProducto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblTipoProducto.Location = new System.Drawing.Point(167, 169);
                            lblTipoProducto.Name = "lblTipoProducto";
                            lblTipoProducto.Size = new System.Drawing.Size(81, 19);
                            lblTipoProducto.TabIndex = 6;
                            lblTipoProducto.Text = "Producto: " + producto.NombreTipo;

                            Label lblStock = new Label();
                            lblStock.AutoSize = true;
                            lblStock.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblStock.Location = new System.Drawing.Point(167, 144);
                            lblStock.Name = "lblStock";
                            lblStock.Size = new System.Drawing.Size(55, 19);
                            lblStock.TabIndex = 5;
                            lblStock.Text = "Stock: " + producto.Stock;

                            Label lblPrecio = new Label();
                            lblPrecio.AutoSize = true;
                            lblPrecio.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblPrecio.Location = new System.Drawing.Point(166, 95);
                            lblPrecio.Name = "lblPrecio";
                            lblPrecio.Size = new System.Drawing.Size(89, 26);
                            lblPrecio.TabIndex = 4;
                            lblPrecio.Text = precioUnitarioInicial.ToString("C");

                            int precioTotalAnterior = precioUnitarioInicial;

                            cboCantidad.SelectedIndexChanged += (sender, e) =>
                            {
                                int cantidadSeleccionada = Convert.ToInt32(cboCantidad.SelectedItem);
                                cantidadesSeleccionadas[carrito.Id] = cantidadSeleccionada;

                                int precioUnitario = carrito.Precio;
                                int precioTotal = cantidadSeleccionada * precioUnitario;

                                totalVenta -= precioTotalAnterior;
                                totalVenta += precioTotal;

                                lblPrecio.Text = precioTotal.ToString("C");
                                lblTotalPrecio.Text = totalVenta.ToString("C");
                                precioTotalAnterior = precioTotal;
                            };

                            Label lblAutor = new Label();
                            lblAutor.AutoSize = true;
                            lblAutor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblAutor.Location = new System.Drawing.Point(168, 48);
                            lblAutor.Name = "lblAutor";
                            lblAutor.Size = new System.Drawing.Size(109, 15);
                            lblAutor.TabIndex = 3;

                            if (producto.IdTipoProducto == 1)
                            {
                                lblAutor.Text = $"{producto.Autor} (Autor)";
                            }

                            Label lblNombre = new Label();
                            lblNombre.AutoSize = true;
                            lblNombre.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            lblNombre.Location = new System.Drawing.Point(166, 15);
                            lblNombre.Name = "lblNombre";
                            lblNombre.Size = new System.Drawing.Size(214, 23);
                            lblNombre.TabIndex = 1;
                            lblNombre.Text = carrito.Nombre;

                            PictureBox imgProducto = new PictureBox();
                            var Imagen = ConvertirImagenBD(producto.Imagen);
                            imgProducto.Image = Imagen;
                            imgProducto.Location = new System.Drawing.Point(4, 3);
                            imgProducto.Name = "imgProducto";
                            imgProducto.Size = new System.Drawing.Size(146, 229);
                            imgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                            imgProducto.TabIndex = 0;
                            imgProducto.TabStop = false;

                            pnlInicio.Controls.Add(containerVenta);

                            containerVenta.Controls.Add(pnlProducto);

                            pnlProducto.Controls.Add(cboCantidad);
                            pnlProducto.Controls.Add(lblCantidad);
                            pnlProducto.Controls.Add(imgBasurero);
                            pnlProducto.Controls.Add(lblTipoProducto);
                            pnlProducto.Controls.Add(lblStock);
                            pnlProducto.Controls.Add(lblPrecio);
                            pnlProducto.Controls.Add(lblAutor);
                            pnlProducto.Controls.Add(lblNombre);
                            pnlProducto.Controls.Add(imgProducto);
                        }
                    }
                }
            }
            else
            {
                Panel pnlProducto = new Panel();
                pnlProducto.Cursor = System.Windows.Forms.Cursors.Arrow;
                pnlProducto.Location = new System.Drawing.Point(3, 3);
                pnlProducto.Margin = new Padding(0, 0, 0, 10);
                pnlProducto.Name = "pnlProducto";
                pnlProducto.Size = new System.Drawing.Size(624, 237);
                pnlProducto.TabIndex = 0;

                pnlProducto.Controls.Add(lblNoHayProductos);
                pnlInicio.Controls.Add(containerVenta);
                containerVenta.Controls.Add(pnlProducto);
            }

            Panel pnlVenta = new Panel();
            pnlVenta.BackColor = System.Drawing.Color.Beige;
            pnlVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlVenta.Location = new System.Drawing.Point(657, 3);
            pnlVenta.Name = "pnlVenta";
            pnlVenta.Size = new System.Drawing.Size(300, 617);
            pnlVenta.TabIndex = 1;

            Label lblTotalVenta = new Label();
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTotalVenta.Location = new System.Drawing.Point(92, 146);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new System.Drawing.Size(86, 19);
            lblTotalVenta.TabIndex = 16;
            lblTotalVenta.Text = "Total Venta";

            Panel pnlSubtotal = new Panel();
            pnlSubtotal.BackColor = System.Drawing.Color.LightBlue;
            pnlSubtotal.Location = new System.Drawing.Point(0, 0);
            pnlSubtotal.Name = "pnlSubtotal";
            pnlSubtotal.Size = new System.Drawing.Size(300, 108);
            pnlSubtotal.TabIndex = 17;

            Label lblDetalle = new Label();
            lblDetalle.AutoSize = true;
            lblDetalle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDetalle.Location = new System.Drawing.Point(79, 37);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new System.Drawing.Size(129, 26);
            lblDetalle.TabIndex = 16;
            lblDetalle.Text = "Detalle Venta";
            
            lblTotalPrecio.AutoSize = true;
            lblTotalPrecio.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTotalPrecio.Location = new System.Drawing.Point(91, 179);
            lblTotalPrecio.Name = "lblTotalPrecio";
            lblTotalPrecio.Size = new System.Drawing.Size(89, 26);
            lblTotalPrecio.TabIndex = 16;
            lblTotalPrecio.Text = totalVenta.ToString("C");

            Button btnVenta = new Button();
            btnVenta.BackColor = System.Drawing.Color.LightBlue;
            btnVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVenta.FlatAppearance.BorderSize = 0;
            btnVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            btnVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVenta.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnVenta.ForeColor = System.Drawing.Color.Black;
            btnVenta.Location = new System.Drawing.Point(55, 214);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new System.Drawing.Size(173, 35);
            btnVenta.TabIndex = 16;
            btnVenta.Text = "Realizar Venta";
            btnVenta.UseVisualStyleBackColor = false;
            btnVenta.Enabled = totalVenta > 0;
            DateTime fechaActual = DateTime.Now.Date;
            btnVenta.Click += (sender, e) =>
            {
                List<Venta> ventasUsuario = ventaModel.ObtenerVentas().Where(v => v.Rut == UserLoginCache.Rut).ToList();
                int ultimoNumeroOrden = 0;
                if (ventasUsuario.Count > 0)
                {
                    ultimoNumeroOrden = ventasUsuario.Max(v => v.Orden);
                }
                int nuevaOrden = ultimoNumeroOrden + 1;
                ventaModel.RegistrarVenta(nuevaOrden, UserLoginCache.Rut, totalVenta, fechaActual);
                foreach (Carrito carrito in carritos)
                {
                    int idProducto = carrito.Codigo;
                    int cantidadSeleccionada = 1;
                    if (cantidadesSeleccionadas.ContainsKey(carrito.Id))
                    {
                        cantidadSeleccionada = cantidadesSeleccionadas[carrito.Id];
                    }

                    int stockOriginal = productModel.ObtenerProducto(idProducto).Stock;
                    int nuevoStock = stockOriginal - cantidadSeleccionada;

                    productModel.DescontarStock(idProducto, nuevoStock);
                    ventaModel.EliminarCarrito(carrito.Id);
                }
                listarCarrito();
            };

            pnlInicio.Controls.Add(pnlVenta);

            pnlSubtotal.Controls.Add(lblDetalle);

            pnlVenta.Controls.Add(btnVenta);
            pnlVenta.Controls.Add(lblTotalPrecio);
            pnlVenta.Controls.Add(lblTotalVenta);
            pnlVenta.Controls.Add(pnlSubtotal);

            int x1 = 58;
            int x2 = 227;
            int y = 170;

            Control lineShape = new Control();
            lineShape.BackColor = Color.Black;
            lineShape.Bounds = new Rectangle(x1, y, x2 - x1, 1);
            pnlVenta.Controls.Add(lineShape);
        }

        private void GestionUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlInicio.Controls.Clear();
            listarUsuarios();
        }

        private void GestionProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlInicio.Controls.Clear();
            listarProductosWS();
        }
        private void GestionProductoBD_FormClosed(object sender, FormClosedEventArgs e)
        {
            pnlInicio.Controls.Clear();
            listarProductos();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {

                e.Handled = true;
            }
        }

        private Image ConvertirImagenWS(string imagen)
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
                    return Properties.Resources.portadaDefault;
                }
            }
        }
        private Image ConvertirImagenBD(string imagenBase64)
        {
            if (string.IsNullOrEmpty(imagenBase64))
            {
                return Properties.Resources.portadaDefault;
            }

            byte[] imagenBytes = Convert.FromBase64String(imagenBase64);
            using (MemoryStream ms = new MemoryStream(imagenBytes))
            {
                return Image.FromStream(ms);
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
            UserLoginCache.IdTipoUsuario = 0;
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
            GestionUserTimer.Start();
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
            if (gestionUserCollapsed)
            {
                gestionContainer.Height += 10;
                if (gestionContainer.Height == gestionContainer.MaximumSize.Height)
                {
                    gestionUserCollapsed = false;
                    GestionUserTimer.Stop();
                }
            }
            else
            {
                gestionContainer.Height -= 10;
                if (gestionContainer.Height == gestionContainer.MinimumSize.Height)
                {
                    gestionUserCollapsed = true;
                    GestionUserTimer.Stop();
                }
            }
        }
        private void GestionLibroTimer_Tick(object sender, EventArgs e)
        {
            if (gestionLibroCollapsed)
            {
                librosContainer.Height += 10;
                if (librosContainer.Height == librosContainer.MaximumSize.Height)
                {
                    gestionLibroCollapsed = false;
                    GestionLibroTimer.Stop();
                }
            }
            else
            {
                librosContainer.Height -= 10;
                if (librosContainer.Height == librosContainer.MinimumSize.Height)
                {
                    gestionLibroCollapsed = true;
                    GestionLibroTimer.Stop();
                }
            }
        }

        private void DiferenciarInterfaz(int tipoUsuario)
        {
            if (tipoUsuario == 1)
            {
                servicesContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 195);
                pnlProductos.Visible = false;
                pnlCarrito.Visible = false;
            }
            else if (tipoUsuario == 2)
            {
                gestionContainer.Visible = false;
                librosContainer.Visible = false;
                pnlProductos.Visible = false;
                pnlCarrito.Visible = false;
                pnlRelleno.Size = new Size(210, 260);
            }
            else if (tipoUsuario == 3)
            {
                servicesContainer.Visible = false;
                gestionContainer.Visible = false;
                librosContainer.Visible = false;
                pnlRelleno.Size = new Size(210, 210);
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

        private void btnAgregarUser_Click(object sender, EventArgs e)
        {
            Registro registroUsuario = new Registro();

            registroUsuario.ShowDialog();
        }

        private void btnAlphilia_Click(object sender, EventArgs e)
        {
            listarProductosWS();
        }

        private void btnGestionLibros_Click(object sender, EventArgs e)
        {
            GestionLibroTimer.Start();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void btnAgregarlibro_Click(object sender, EventArgs e)
        {
            RegistroProducto registroProducto = new RegistroProducto();
            registroProducto.FormClosed += RegistroProducto_FormClosed;
            registroProducto.ShowDialog();
        }

        private void RegistroProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            listarProductos();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void containerVenta_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void pnlVenta_MouseDown(object sender, MouseEventArgs e)
        {
            MoverVentanas();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            listarCarrito();
        }
    }
}
