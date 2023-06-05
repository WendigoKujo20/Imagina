
namespace Imagina
{
    partial class AgregarServicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.FechaDisponible = new System.Windows.Forms.DateTimePicker();
            this.lblTipoServicio = new System.Windows.Forms.Label();
            this.cboTipoServicio = new System.Windows.Forms.ComboBox();
            this.linkCancelar = new System.Windows.Forms.LinkLabel();
            this.btnPrincipal = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 162);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Imagina.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(88, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(75, 185);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(165, 23);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Agregar Servicio";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(97, 242);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(127, 19);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Fecha Disponible  ";
            // 
            // FechaDisponible
            // 
            this.FechaDisponible.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDisponible.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDisponible.Location = new System.Drawing.Point(106, 269);
            this.FechaDisponible.Name = "FechaDisponible";
            this.FechaDisponible.Size = new System.Drawing.Size(96, 27);
            this.FechaDisponible.TabIndex = 8;
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.AutoSize = true;
            this.lblTipoServicio.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServicio.ForeColor = System.Drawing.Color.White;
            this.lblTipoServicio.Location = new System.Drawing.Point(109, 315);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(93, 19);
            this.lblTipoServicio.TabIndex = 9;
            this.lblTipoServicio.Text = "Tipo Servicio";
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Items.AddRange(new object[] {
            "Reparacion",
            "Mantencion"});
            this.cboTipoServicio.Location = new System.Drawing.Point(101, 346);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(111, 27);
            this.cboTipoServicio.TabIndex = 10;
            // 
            // linkCancelar
            // 
            this.linkCancelar.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.linkCancelar.AutoSize = true;
            this.linkCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkCancelar.Font = new System.Drawing.Font("Calibri", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCancelar.LinkColor = System.Drawing.Color.White;
            this.linkCancelar.Location = new System.Drawing.Point(128, 461);
            this.linkCancelar.Name = "linkCancelar";
            this.linkCancelar.Size = new System.Drawing.Size(48, 13);
            this.linkCancelar.TabIndex = 1;
            this.linkCancelar.TabStop = true;
            this.linkCancelar.Text = "Cancelar";
            this.linkCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCancelar_LinkClicked);
            // 
            // btnPrincipal
            // 
            this.btnPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.btnPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrincipal.FlatAppearance.BorderSize = 0;
            this.btnPrincipal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPrincipal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.btnPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrincipal.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrincipal.ForeColor = System.Drawing.Color.White;
            this.btnPrincipal.Location = new System.Drawing.Point(88, 422);
            this.btnPrincipal.Name = "btnPrincipal";
            this.btnPrincipal.Size = new System.Drawing.Size(129, 27);
            this.btnPrincipal.TabIndex = 12;
            this.btnPrincipal.Text = "Registrar";
            this.btnPrincipal.UseVisualStyleBackColor = false;
            this.btnPrincipal.Click += new System.EventHandler(this.btnPrincipal_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Image = global::Imagina.Properties.Resources.error;
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(66, 397);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(13, 13);
            this.lblError.TabIndex = 28;
            this.lblError.Text = "   ";
            this.lblError.Visible = false;
            // 
            // AgregarServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(309, 490);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnPrincipal);
            this.Controls.Add(this.linkCancelar);
            this.Controls.Add(this.cboTipoServicio);
            this.Controls.Add(this.lblTipoServicio);
            this.Controls.Add(this.FechaDisponible);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AgregarServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarServicio";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker FechaDisponible;
        private System.Windows.Forms.Label lblTipoServicio;
        private System.Windows.Forms.ComboBox cboTipoServicio;
        private System.Windows.Forms.LinkLabel linkCancelar;
        private System.Windows.Forms.Button btnPrincipal;
        private System.Windows.Forms.Label lblError;
    }
}