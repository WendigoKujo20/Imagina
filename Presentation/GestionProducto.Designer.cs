
namespace Imagina
{
    partial class GestionProducto
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
            this.imgProducto = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.containerPrecio = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.editPrecio = new System.Windows.Forms.PictureBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.linePrecio = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.containerStock = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStock = new System.Windows.Forms.Label();
            this.editStock = new System.Windows.Forms.PictureBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lineStock = new Microsoft.VisualBasic.PowerPacks.LineShape();
            ((System.ComponentModel.ISupportInitialize)(this.imgProducto)).BeginInit();
            this.panel1.SuspendLayout();
            this.containerPrecio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPrecio)).BeginInit();
            this.containerStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editStock)).BeginInit();
            this.SuspendLayout();
            // 
            // imgProducto
            // 
            this.imgProducto.Location = new System.Drawing.Point(57, 8);
            this.imgProducto.Name = "imgProducto";
            this.imgProducto.Size = new System.Drawing.Size(150, 207);
            this.imgProducto.TabIndex = 0;
            this.imgProducto.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.imgProducto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 259);
            this.panel1.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(62, 228);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 19);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Libro";
            // 
            // containerPrecio
            // 
            this.containerPrecio.Controls.Add(this.lblPrecio);
            this.containerPrecio.Controls.Add(this.editPrecio);
            this.containerPrecio.Location = new System.Drawing.Point(12, 289);
            this.containerPrecio.Name = "containerPrecio";
            this.containerPrecio.Size = new System.Drawing.Size(207, 32);
            this.containerPrecio.TabIndex = 7;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecio.Location = new System.Drawing.Point(3, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(59, 19);
            this.lblPrecio.TabIndex = 0;
            this.lblPrecio.Text = "Precio: ";
            // 
            // editPrecio
            // 
            this.editPrecio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editPrecio.Image = global::Imagina.Properties.Resources.edit;
            this.editPrecio.Location = new System.Drawing.Point(68, 3);
            this.editPrecio.Name = "editPrecio";
            this.editPrecio.Size = new System.Drawing.Size(27, 28);
            this.editPrecio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editPrecio.TabIndex = 0;
            this.editPrecio.TabStop = false;
            this.editPrecio.Click += new System.EventHandler(this.editPrecio_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.Black;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.Color.White;
            this.txtPrecio.Location = new System.Drawing.Point(73, 299);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(146, 20);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // linePrecio
            // 
            this.linePrecio.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linePrecio.Enabled = false;
            this.linePrecio.Name = "linePrecio";
            this.linePrecio.X1 = 67;
            this.linePrecio.X2 = 220;
            this.linePrecio.Y1 = 321;
            this.linePrecio.Y2 = 321;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineStock,
            this.linePrecio});
            this.shapeContainer1.Size = new System.Drawing.Size(270, 466);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // containerStock
            // 
            this.containerStock.Controls.Add(this.lblStock);
            this.containerStock.Controls.Add(this.editStock);
            this.containerStock.Location = new System.Drawing.Point(12, 346);
            this.containerStock.Name = "containerStock";
            this.containerStock.Size = new System.Drawing.Size(207, 32);
            this.containerStock.TabIndex = 10;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.White;
            this.lblStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStock.Location = new System.Drawing.Point(3, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(53, 19);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "Stock: ";
            // 
            // editStock
            // 
            this.editStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editStock.Image = global::Imagina.Properties.Resources.edit;
            this.editStock.Location = new System.Drawing.Point(62, 3);
            this.editStock.Name = "editStock";
            this.editStock.Size = new System.Drawing.Size(27, 28);
            this.editStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editStock.TabIndex = 0;
            this.editStock.TabStop = false;
            this.editStock.Click += new System.EventHandler(this.editStock_Click);
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.Black;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStock.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.ForeColor = System.Drawing.Color.White;
            this.txtStock.Location = new System.Drawing.Point(73, 356);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(148, 20);
            this.txtStock.TabIndex = 9;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // lineStock
            // 
            this.lineStock.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lineStock.Enabled = false;
            this.lineStock.Name = "lineStock";
            this.lineStock.X1 = 67;
            this.lineStock.X2 = 220;
            this.lineStock.Y1 = 378;
            this.lineStock.Y2 = 378;
            // 
            // GestionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(270, 466);
            this.Controls.Add(this.containerStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.containerPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionProducto";
            this.Load += new System.EventHandler(this.GestionProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgProducto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.containerPrecio.ResumeLayout(false);
            this.containerPrecio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editPrecio)).EndInit();
            this.containerStock.ResumeLayout(false);
            this.containerStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgProducto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.FlowLayoutPanel containerPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.PictureBox editPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private Microsoft.VisualBasic.PowerPacks.LineShape linePrecio;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.FlowLayoutPanel containerStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.PictureBox editStock;
        private System.Windows.Forms.TextBox txtStock;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineStock;
    }
}