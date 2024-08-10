namespace Vista
{
    partial class CV_GestionStock
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
            this.DTGV_Productos = new System.Windows.Forms.DataGridView();
            this.Txb_Nombre = new System.Windows.Forms.TextBox();
            this.Txb_Marca = new System.Windows.Forms.TextBox();
            this.Txb_Descripcion = new System.Windows.Forms.TextBox();
            this.Txb_Cantidad = new System.Windows.Forms.TextBox();
            this.Txb_Precio = new System.Windows.Forms.TextBox();
            this.Txb_NumLote = new System.Windows.Forms.TextBox();
            this.Dtp_FeVto = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Marca = new System.Windows.Forms.Label();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Lbl_Vto = new System.Windows.Forms.Label();
            this.Lbl_NroLote = new System.Windows.Forms.Label();
            this.Lbl_Precio = new System.Windows.Forms.Label();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_GuardarCambios = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // DTGV_Productos
            // 
            this.DTGV_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Productos.Location = new System.Drawing.Point(11, 250);
            this.DTGV_Productos.Name = "DTGV_Productos";
            this.DTGV_Productos.RowHeadersWidth = 51;
            this.DTGV_Productos.RowTemplate.Height = 24;
            this.DTGV_Productos.Size = new System.Drawing.Size(1340, 350);
            this.DTGV_Productos.TabIndex = 19;
            this.DTGV_Productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_Productos_CellClick);
            // 
            // Txb_Nombre
            // 
            this.Txb_Nombre.Location = new System.Drawing.Point(120, 50);
            this.Txb_Nombre.Name = "Txb_Nombre";
            this.Txb_Nombre.Size = new System.Drawing.Size(210, 22);
            this.Txb_Nombre.TabIndex = 1;
            this.Txb_Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_Marca
            // 
            this.Txb_Marca.Location = new System.Drawing.Point(120, 100);
            this.Txb_Marca.Name = "Txb_Marca";
            this.Txb_Marca.Size = new System.Drawing.Size(210, 22);
            this.Txb_Marca.TabIndex = 2;
            this.Txb_Marca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_Descripcion
            // 
            this.Txb_Descripcion.Location = new System.Drawing.Point(120, 150);
            this.Txb_Descripcion.Name = "Txb_Descripcion";
            this.Txb_Descripcion.Size = new System.Drawing.Size(210, 22);
            this.Txb_Descripcion.TabIndex = 3;
            this.Txb_Descripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_Cantidad
            // 
            this.Txb_Cantidad.Location = new System.Drawing.Point(121, 200);
            this.Txb_Cantidad.Multiline = true;
            this.Txb_Cantidad.Name = "Txb_Cantidad";
            this.Txb_Cantidad.Size = new System.Drawing.Size(210, 22);
            this.Txb_Cantidad.TabIndex = 4;
            this.Txb_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_Precio
            // 
            this.Txb_Precio.Location = new System.Drawing.Point(629, 50);
            this.Txb_Precio.Name = "Txb_Precio";
            this.Txb_Precio.Size = new System.Drawing.Size(107, 22);
            this.Txb_Precio.TabIndex = 5;
            this.Txb_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_NumLote
            // 
            this.Txb_NumLote.Location = new System.Drawing.Point(629, 100);
            this.Txb_NumLote.Name = "Txb_NumLote";
            this.Txb_NumLote.Size = new System.Drawing.Size(107, 22);
            this.Txb_NumLote.TabIndex = 6;
            this.Txb_NumLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Dtp_FeVto
            // 
            this.Dtp_FeVto.CustomFormat = "dd/MM/yyyy";
            this.Dtp_FeVto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_FeVto.Location = new System.Drawing.Point(630, 150);
            this.Dtp_FeVto.Name = "Dtp_FeVto";
            this.Dtp_FeVto.Size = new System.Drawing.Size(107, 22);
            this.Dtp_FeVto.TabIndex = 7;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Location = new System.Drawing.Point(40, 50);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(56, 16);
            this.Lbl_Nombre.TabIndex = 8;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Lbl_Marca
            // 
            this.Lbl_Marca.AutoSize = true;
            this.Lbl_Marca.Location = new System.Drawing.Point(40, 100);
            this.Lbl_Marca.Name = "Lbl_Marca";
            this.Lbl_Marca.Size = new System.Drawing.Size(45, 16);
            this.Lbl_Marca.TabIndex = 9;
            this.Lbl_Marca.Text = "Marca";
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Location = new System.Drawing.Point(40, 150);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(79, 16);
            this.Lbl_Descripcion.TabIndex = 10;
            this.Lbl_Descripcion.Text = "Descripcion";
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Location = new System.Drawing.Point(40, 200);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Cantidad.TabIndex = 11;
            this.Lbl_Cantidad.Text = "Cantidad";
            // 
            // Lbl_Vto
            // 
            this.Lbl_Vto.AutoSize = true;
            this.Lbl_Vto.Location = new System.Drawing.Point(528, 150);
            this.Lbl_Vto.Name = "Lbl_Vto";
            this.Lbl_Vto.Size = new System.Drawing.Size(81, 16);
            this.Lbl_Vto.TabIndex = 14;
            this.Lbl_Vto.Text = "Vencimiento";
            // 
            // Lbl_NroLote
            // 
            this.Lbl_NroLote.AutoSize = true;
            this.Lbl_NroLote.Location = new System.Drawing.Point(528, 100);
            this.Lbl_NroLote.Name = "Lbl_NroLote";
            this.Lbl_NroLote.Size = new System.Drawing.Size(50, 16);
            this.Lbl_NroLote.TabIndex = 13;
            this.Lbl_NroLote.Text = "Lote N°";
            // 
            // Lbl_Precio
            // 
            this.Lbl_Precio.AutoSize = true;
            this.Lbl_Precio.Location = new System.Drawing.Point(528, 50);
            this.Lbl_Precio.Name = "Lbl_Precio";
            this.Lbl_Precio.Size = new System.Drawing.Size(46, 16);
            this.Lbl_Precio.TabIndex = 12;
            this.Lbl_Precio.Text = "Precio";
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(865, 50);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(75, 25);
            this.Btn_Agregar.TabIndex = 15;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(865, 97);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 25);
            this.Btn_Buscar.TabIndex = 16;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(865, 143);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(75, 25);
            this.Btn_Modificar.TabIndex = 17;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_GuardarCambios
            // 
            this.Btn_GuardarCambios.Location = new System.Drawing.Point(865, 174);
            this.Btn_GuardarCambios.Name = "Btn_GuardarCambios";
            this.Btn_GuardarCambios.Size = new System.Drawing.Size(75, 25);
            this.Btn_GuardarCambios.TabIndex = 18;
            this.Btn_GuardarCambios.Text = "Guardar Cambios";
            this.Btn_GuardarCambios.UseVisualStyleBackColor = true;
            this.Btn_GuardarCambios.Click += new System.EventHandler(this.Btn_GuardarCambios_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(865, 205);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(75, 25);
            this.Btn_Eliminar.TabIndex = 20;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // CV_GestionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 697);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_GuardarCambios);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.Lbl_Vto);
            this.Controls.Add(this.Lbl_NroLote);
            this.Controls.Add(this.Lbl_Precio);
            this.Controls.Add(this.Lbl_Cantidad);
            this.Controls.Add(this.Lbl_Descripcion);
            this.Controls.Add(this.Lbl_Marca);
            this.Controls.Add(this.Lbl_Nombre);
            this.Controls.Add(this.Dtp_FeVto);
            this.Controls.Add(this.Txb_NumLote);
            this.Controls.Add(this.Txb_Precio);
            this.Controls.Add(this.Txb_Cantidad);
            this.Controls.Add(this.Txb_Descripcion);
            this.Controls.Add(this.Txb_Marca);
            this.Controls.Add(this.Txb_Nombre);
            this.Controls.Add(this.DTGV_Productos);
            this.Name = "CV_GestionStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de inventario";
            this.Load += new System.EventHandler(this.CV_GestionStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DTGV_Productos;
        private System.Windows.Forms.TextBox Txb_Nombre;
        private System.Windows.Forms.TextBox Txb_Marca;
        private System.Windows.Forms.TextBox Txb_Descripcion;
        private System.Windows.Forms.TextBox Txb_Cantidad;
        private System.Windows.Forms.TextBox Txb_Precio;
        private System.Windows.Forms.TextBox Txb_NumLote;
        private System.Windows.Forms.DateTimePicker Dtp_FeVto;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Marca;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.Label Lbl_Vto;
        private System.Windows.Forms.Label Lbl_NroLote;
        private System.Windows.Forms.Label Lbl_Precio;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_GuardarCambios;
        private System.Windows.Forms.Button Btn_Eliminar;
    }
}