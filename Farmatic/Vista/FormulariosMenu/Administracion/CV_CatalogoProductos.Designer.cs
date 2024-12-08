namespace Vista.FormulariosMenu
{
    partial class CV_CatalogoProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_CatalogoProductos));
            this.Lbl_NombreComercial = new System.Windows.Forms.Label();
            this.Txb_NombreComercial = new System.Windows.Forms.TextBox();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_GuardarCambios = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Lbl_PrecioPorLote = new System.Windows.Forms.Label();
            this.Lbl_CompraMinima = new System.Windows.Forms.Label();
            this.Lbl_UnidadesporLote = new System.Windows.Forms.Label();
            this.Lbl_Marca = new System.Windows.Forms.Label();
            this.Lbl_Monodroga = new System.Windows.Forms.Label();
            this.Txb_PrecioporLote = new System.Windows.Forms.TextBox();
            this.Txb_Marca = new System.Windows.Forms.TextBox();
            this.Txb_Monodroga = new System.Windows.Forms.TextBox();
            this.DTGV_Catalogo = new System.Windows.Forms.DataGridView();
            this.Nud_UnidadporLote = new System.Windows.Forms.NumericUpDown();
            this.Nud_CompraMinima = new System.Windows.Forms.NumericUpDown();
            this.Txb_Proveedor = new System.Windows.Forms.TextBox();
            this.Lbl_Proveedor = new System.Windows.Forms.Label();
            this.Btn_SeleccionarProveedor = new System.Windows.Forms.Button();
            this.Pnl_Busqueda = new System.Windows.Forms.Panel();
            this.Lbl_CompraMinHasta = new System.Windows.Forms.Label();
            this.Txb_CompraMinHasta = new System.Windows.Forms.TextBox();
            this.Txb_CompraMinDesde = new System.Windows.Forms.TextBox();
            this.Lbl_CompraMinDesde = new System.Windows.Forms.Label();
            this.Lbl_PrecHasta = new System.Windows.Forms.Label();
            this.Lbl_CantHasta = new System.Windows.Forms.Label();
            this.Txb_PrecHasta = new System.Windows.Forms.TextBox();
            this.Txb_CantHasta = new System.Windows.Forms.TextBox();
            this.Lbl_CantDesde = new System.Windows.Forms.Label();
            this.Txb_CantDesde = new System.Windows.Forms.TextBox();
            this.Txb_PrecDesde = new System.Windows.Forms.TextBox();
            this.Lbl_PrecDesde = new System.Windows.Forms.Label();
            this.Chb_Busqueda = new System.Windows.Forms.CheckBox();
            this.Btn_Refrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Catalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_UnidadporLote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CompraMinima)).BeginInit();
            this.Pnl_Busqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_NombreComercial
            // 
            this.Lbl_NombreComercial.AutoSize = true;
            this.Lbl_NombreComercial.Location = new System.Drawing.Point(49, 102);
            this.Lbl_NombreComercial.Name = "Lbl_NombreComercial";
            this.Lbl_NombreComercial.Size = new System.Drawing.Size(118, 16);
            this.Lbl_NombreComercial.TabIndex = 57;
            this.Lbl_NombreComercial.Text = "Nombre comercial";
            // 
            // Txb_NombreComercial
            // 
            this.Txb_NombreComercial.Location = new System.Drawing.Point(176, 102);
            this.Txb_NombreComercial.Name = "Txb_NombreComercial";
            this.Txb_NombreComercial.Size = new System.Drawing.Size(210, 22);
            this.Txb_NombreComercial.TabIndex = 0;
            this.Txb_NombreComercial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(874, 227);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(75, 31);
            this.Btn_Eliminar.TabIndex = 11;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_GuardarCambios
            // 
            this.Btn_GuardarCambios.Location = new System.Drawing.Point(874, 191);
            this.Btn_GuardarCambios.Name = "Btn_GuardarCambios";
            this.Btn_GuardarCambios.Size = new System.Drawing.Size(75, 30);
            this.Btn_GuardarCambios.TabIndex = 10;
            this.Btn_GuardarCambios.Text = "Guardar";
            this.Btn_GuardarCambios.UseVisualStyleBackColor = true;
            this.Btn_GuardarCambios.Click += new System.EventHandler(this.Btn_GuardarCambios_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Location = new System.Drawing.Point(874, 156);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(75, 29);
            this.Btn_Modificar.TabIndex = 9;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(874, 121);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 29);
            this.Btn_Buscar.TabIndex = 8;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(874, 80);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(75, 30);
            this.Btn_Agregar.TabIndex = 7;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Lbl_PrecioPorLote
            // 
            this.Lbl_PrecioPorLote.AutoSize = true;
            this.Lbl_PrecioPorLote.Location = new System.Drawing.Point(541, 169);
            this.Lbl_PrecioPorLote.Name = "Lbl_PrecioPorLote";
            this.Lbl_PrecioPorLote.Size = new System.Drawing.Size(98, 16);
            this.Lbl_PrecioPorLote.TabIndex = 45;
            this.Lbl_PrecioPorLote.Text = "Precio por Lote";
            // 
            // Lbl_CompraMinima
            // 
            this.Lbl_CompraMinima.AutoSize = true;
            this.Lbl_CompraMinima.Location = new System.Drawing.Point(541, 133);
            this.Lbl_CompraMinima.Name = "Lbl_CompraMinima";
            this.Lbl_CompraMinima.Size = new System.Drawing.Size(101, 16);
            this.Lbl_CompraMinima.TabIndex = 43;
            this.Lbl_CompraMinima.Text = "Compra Minima";
            // 
            // Lbl_UnidadesporLote
            // 
            this.Lbl_UnidadesporLote.AutoSize = true;
            this.Lbl_UnidadesporLote.Location = new System.Drawing.Point(542, 94);
            this.Lbl_UnidadesporLote.Name = "Lbl_UnidadesporLote";
            this.Lbl_UnidadesporLote.Size = new System.Drawing.Size(118, 16);
            this.Lbl_UnidadesporLote.TabIndex = 41;
            this.Lbl_UnidadesporLote.Text = "Unidades por Lote";
            // 
            // Lbl_Marca
            // 
            this.Lbl_Marca.AutoSize = true;
            this.Lbl_Marca.Location = new System.Drawing.Point(49, 172);
            this.Lbl_Marca.Name = "Lbl_Marca";
            this.Lbl_Marca.Size = new System.Drawing.Size(45, 16);
            this.Lbl_Marca.TabIndex = 40;
            this.Lbl_Marca.Text = "Marca";
            // 
            // Lbl_Monodroga
            // 
            this.Lbl_Monodroga.AutoSize = true;
            this.Lbl_Monodroga.Location = new System.Drawing.Point(50, 138);
            this.Lbl_Monodroga.Name = "Lbl_Monodroga";
            this.Lbl_Monodroga.Size = new System.Drawing.Size(77, 16);
            this.Lbl_Monodroga.TabIndex = 38;
            this.Lbl_Monodroga.Text = "Monodroga";
            // 
            // Txb_PrecioporLote
            // 
            this.Txb_PrecioporLote.Location = new System.Drawing.Point(669, 172);
            this.Txb_PrecioporLote.Name = "Txb_PrecioporLote";
            this.Txb_PrecioporLote.Size = new System.Drawing.Size(121, 22);
            this.Txb_PrecioporLote.TabIndex = 6;
            this.Txb_PrecioporLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_Marca
            // 
            this.Txb_Marca.Location = new System.Drawing.Point(176, 172);
            this.Txb_Marca.Name = "Txb_Marca";
            this.Txb_Marca.Size = new System.Drawing.Size(210, 22);
            this.Txb_Marca.TabIndex = 2;
            this.Txb_Marca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_Monodroga
            // 
            this.Txb_Monodroga.Location = new System.Drawing.Point(177, 138);
            this.Txb_Monodroga.Name = "Txb_Monodroga";
            this.Txb_Monodroga.Size = new System.Drawing.Size(210, 22);
            this.Txb_Monodroga.TabIndex = 1;
            this.Txb_Monodroga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DTGV_Catalogo
            // 
            this.DTGV_Catalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Catalogo.Location = new System.Drawing.Point(21, 310);
            this.DTGV_Catalogo.Name = "DTGV_Catalogo";
            this.DTGV_Catalogo.RowHeadersWidth = 51;
            this.DTGV_Catalogo.RowTemplate.Height = 24;
            this.DTGV_Catalogo.Size = new System.Drawing.Size(1287, 350);
            this.DTGV_Catalogo.TabIndex = 53;
            this.DTGV_Catalogo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_Catalogo_CellClick);
            // 
            // Nud_UnidadporLote
            // 
            this.Nud_UnidadporLote.Location = new System.Drawing.Point(670, 92);
            this.Nud_UnidadporLote.Name = "Nud_UnidadporLote";
            this.Nud_UnidadporLote.Size = new System.Drawing.Size(120, 22);
            this.Nud_UnidadporLote.TabIndex = 4;
            this.Nud_UnidadporLote.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Nud_CompraMinima
            // 
            this.Nud_CompraMinima.Location = new System.Drawing.Point(670, 136);
            this.Nud_CompraMinima.Name = "Nud_CompraMinima";
            this.Nud_CompraMinima.Size = new System.Drawing.Size(120, 22);
            this.Nud_CompraMinima.TabIndex = 5;
            this.Nud_CompraMinima.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Txb_Proveedor
            // 
            this.Txb_Proveedor.Location = new System.Drawing.Point(176, 205);
            this.Txb_Proveedor.Name = "Txb_Proveedor";
            this.Txb_Proveedor.Size = new System.Drawing.Size(210, 22);
            this.Txb_Proveedor.TabIndex = 3;
            this.Txb_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lbl_Proveedor
            // 
            this.Lbl_Proveedor.AutoSize = true;
            this.Lbl_Proveedor.Location = new System.Drawing.Point(50, 205);
            this.Lbl_Proveedor.Name = "Lbl_Proveedor";
            this.Lbl_Proveedor.Size = new System.Drawing.Size(71, 16);
            this.Lbl_Proveedor.TabIndex = 54;
            this.Lbl_Proveedor.Text = "Proveedor";
            // 
            // Btn_SeleccionarProveedor
            // 
            this.Btn_SeleccionarProveedor.Location = new System.Drawing.Point(393, 203);
            this.Btn_SeleccionarProveedor.Name = "Btn_SeleccionarProveedor";
            this.Btn_SeleccionarProveedor.Size = new System.Drawing.Size(81, 24);
            this.Btn_SeleccionarProveedor.TabIndex = 58;
            this.Btn_SeleccionarProveedor.Text = "Seleccion";
            this.Btn_SeleccionarProveedor.UseVisualStyleBackColor = true;
            this.Btn_SeleccionarProveedor.Click += new System.EventHandler(this.Btn_SeleccionarProveedor_Click);
            // 
            // Pnl_Busqueda
            // 
            this.Pnl_Busqueda.Controls.Add(this.Lbl_CompraMinHasta);
            this.Pnl_Busqueda.Controls.Add(this.Txb_CompraMinHasta);
            this.Pnl_Busqueda.Controls.Add(this.Txb_CompraMinDesde);
            this.Pnl_Busqueda.Controls.Add(this.Lbl_CompraMinDesde);
            this.Pnl_Busqueda.Controls.Add(this.Lbl_PrecHasta);
            this.Pnl_Busqueda.Controls.Add(this.Lbl_CantHasta);
            this.Pnl_Busqueda.Controls.Add(this.Txb_PrecHasta);
            this.Pnl_Busqueda.Controls.Add(this.Txb_CantHasta);
            this.Pnl_Busqueda.Controls.Add(this.Lbl_CantDesde);
            this.Pnl_Busqueda.Controls.Add(this.Txb_CantDesde);
            this.Pnl_Busqueda.Controls.Add(this.Txb_PrecDesde);
            this.Pnl_Busqueda.Controls.Add(this.Lbl_PrecDesde);
            this.Pnl_Busqueda.Location = new System.Drawing.Point(985, 80);
            this.Pnl_Busqueda.Name = "Pnl_Busqueda";
            this.Pnl_Busqueda.Size = new System.Drawing.Size(385, 114);
            this.Pnl_Busqueda.TabIndex = 59;
            // 
            // Lbl_CompraMinHasta
            // 
            this.Lbl_CompraMinHasta.AutoSize = true;
            this.Lbl_CompraMinHasta.Location = new System.Drawing.Point(247, 52);
            this.Lbl_CompraMinHasta.Name = "Lbl_CompraMinHasta";
            this.Lbl_CompraMinHasta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_CompraMinHasta.TabIndex = 37;
            this.Lbl_CompraMinHasta.Text = "Hasta";
            // 
            // Txb_CompraMinHasta
            // 
            this.Txb_CompraMinHasta.Location = new System.Drawing.Point(296, 45);
            this.Txb_CompraMinHasta.Name = "Txb_CompraMinHasta";
            this.Txb_CompraMinHasta.Size = new System.Drawing.Size(72, 22);
            this.Txb_CompraMinHasta.TabIndex = 36;
            this.Txb_CompraMinHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_CompraMinDesde
            // 
            this.Txb_CompraMinDesde.Location = new System.Drawing.Point(154, 47);
            this.Txb_CompraMinDesde.Name = "Txb_CompraMinDesde";
            this.Txb_CompraMinDesde.Size = new System.Drawing.Size(76, 22);
            this.Txb_CompraMinDesde.TabIndex = 34;
            this.Txb_CompraMinDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lbl_CompraMinDesde
            // 
            this.Lbl_CompraMinDesde.AutoSize = true;
            this.Lbl_CompraMinDesde.Location = new System.Drawing.Point(7, 48);
            this.Lbl_CompraMinDesde.Name = "Lbl_CompraMinDesde";
            this.Lbl_CompraMinDesde.Size = new System.Drawing.Size(143, 16);
            this.Lbl_CompraMinDesde.TabIndex = 35;
            this.Lbl_CompraMinDesde.Text = "Compra minima desde";
            // 
            // Lbl_PrecHasta
            // 
            this.Lbl_PrecHasta.AutoSize = true;
            this.Lbl_PrecHasta.Location = new System.Drawing.Point(247, 88);
            this.Lbl_PrecHasta.Name = "Lbl_PrecHasta";
            this.Lbl_PrecHasta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_PrecHasta.TabIndex = 33;
            this.Lbl_PrecHasta.Text = "Hasta";
            // 
            // Lbl_CantHasta
            // 
            this.Lbl_CantHasta.AutoSize = true;
            this.Lbl_CantHasta.Location = new System.Drawing.Point(247, 11);
            this.Lbl_CantHasta.Name = "Lbl_CantHasta";
            this.Lbl_CantHasta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_CantHasta.TabIndex = 32;
            this.Lbl_CantHasta.Text = "Hasta";
            // 
            // Txb_PrecHasta
            // 
            this.Txb_PrecHasta.Location = new System.Drawing.Point(296, 81);
            this.Txb_PrecHasta.Name = "Txb_PrecHasta";
            this.Txb_PrecHasta.Size = new System.Drawing.Size(72, 22);
            this.Txb_PrecHasta.TabIndex = 30;
            this.Txb_PrecHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_CantHasta
            // 
            this.Txb_CantHasta.Location = new System.Drawing.Point(296, 8);
            this.Txb_CantHasta.Multiline = true;
            this.Txb_CantHasta.Name = "Txb_CantHasta";
            this.Txb_CantHasta.Size = new System.Drawing.Size(73, 22);
            this.Txb_CantHasta.TabIndex = 29;
            this.Txb_CantHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lbl_CantDesde
            // 
            this.Lbl_CantDesde.AutoSize = true;
            this.Lbl_CantDesde.Location = new System.Drawing.Point(7, 11);
            this.Lbl_CantDesde.Name = "Lbl_CantDesde";
            this.Lbl_CantDesde.Size = new System.Drawing.Size(141, 16);
            this.Lbl_CantDesde.TabIndex = 24;
            this.Lbl_CantDesde.Text = "Unidad por lote desde";
            // 
            // Txb_CantDesde
            // 
            this.Txb_CantDesde.Location = new System.Drawing.Point(154, 10);
            this.Txb_CantDesde.Multiline = true;
            this.Txb_CantDesde.Name = "Txb_CantDesde";
            this.Txb_CantDesde.Size = new System.Drawing.Size(77, 22);
            this.Txb_CantDesde.TabIndex = 23;
            this.Txb_CantDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txb_PrecDesde
            // 
            this.Txb_PrecDesde.Location = new System.Drawing.Point(154, 83);
            this.Txb_PrecDesde.Name = "Txb_PrecDesde";
            this.Txb_PrecDesde.Size = new System.Drawing.Size(76, 22);
            this.Txb_PrecDesde.TabIndex = 23;
            this.Txb_PrecDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lbl_PrecDesde
            // 
            this.Lbl_PrecDesde.AutoSize = true;
            this.Lbl_PrecDesde.Location = new System.Drawing.Point(7, 84);
            this.Lbl_PrecDesde.Name = "Lbl_PrecDesde";
            this.Lbl_PrecDesde.Size = new System.Drawing.Size(88, 16);
            this.Lbl_PrecDesde.TabIndex = 26;
            this.Lbl_PrecDesde.Text = "Precio desde";
            // 
            // Chb_Busqueda
            // 
            this.Chb_Busqueda.AutoSize = true;
            this.Chb_Busqueda.Location = new System.Drawing.Point(545, 206);
            this.Chb_Busqueda.Name = "Chb_Busqueda";
            this.Chb_Busqueda.Size = new System.Drawing.Size(220, 20);
            this.Chb_Busqueda.TabIndex = 60;
            this.Chb_Busqueda.Text = "¿Desea realizar una búsqueda?";
            this.Chb_Busqueda.UseVisualStyleBackColor = true;
            this.Chb_Busqueda.CheckedChanged += new System.EventHandler(this.Chb_Busqueda_CheckedChanged);
            // 
            // Btn_Refrescar
            // 
            this.Btn_Refrescar.Location = new System.Drawing.Point(874, 44);
            this.Btn_Refrescar.Name = "Btn_Refrescar";
            this.Btn_Refrescar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Refrescar.TabIndex = 61;
            this.Btn_Refrescar.Text = "Refrescar";
            this.Btn_Refrescar.UseVisualStyleBackColor = true;
            this.Btn_Refrescar.Click += new System.EventHandler(this.Btn_Refrescar_Click);
            // 
            // CV_CatalogoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1331, 701);
            this.Controls.Add(this.Btn_Refrescar);
            this.Controls.Add(this.Chb_Busqueda);
            this.Controls.Add(this.Pnl_Busqueda);
            this.Controls.Add(this.Btn_SeleccionarProveedor);
            this.Controls.Add(this.Txb_Proveedor);
            this.Controls.Add(this.Nud_CompraMinima);
            this.Controls.Add(this.Nud_UnidadporLote);
            this.Controls.Add(this.Lbl_NombreComercial);
            this.Controls.Add(this.Txb_NombreComercial);
            this.Controls.Add(this.Lbl_Proveedor);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_GuardarCambios);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.Lbl_PrecioPorLote);
            this.Controls.Add(this.Lbl_CompraMinima);
            this.Controls.Add(this.Lbl_UnidadesporLote);
            this.Controls.Add(this.Lbl_Marca);
            this.Controls.Add(this.Lbl_Monodroga);
            this.Controls.Add(this.Txb_PrecioporLote);
            this.Controls.Add(this.Txb_Marca);
            this.Controls.Add(this.Txb_Monodroga);
            this.Controls.Add(this.DTGV_Catalogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_CatalogoProductos";
            this.Text = "Catalogo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_CatalogoProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Catalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_UnidadporLote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CompraMinima)).EndInit();
            this.Pnl_Busqueda.ResumeLayout(false);
            this.Pnl_Busqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_NombreComercial;
        private System.Windows.Forms.TextBox Txb_NombreComercial;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_GuardarCambios;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Label Lbl_PrecioPorLote;
        private System.Windows.Forms.Label Lbl_CompraMinima;
        private System.Windows.Forms.Label Lbl_UnidadesporLote;
        private System.Windows.Forms.Label Lbl_Marca;
        private System.Windows.Forms.Label Lbl_Monodroga;
        private System.Windows.Forms.TextBox Txb_PrecioporLote;
        private System.Windows.Forms.TextBox Txb_Marca;
        private System.Windows.Forms.TextBox Txb_Monodroga;
        private System.Windows.Forms.DataGridView DTGV_Catalogo;
        private System.Windows.Forms.NumericUpDown Nud_UnidadporLote;
        private System.Windows.Forms.NumericUpDown Nud_CompraMinima;
        private System.Windows.Forms.TextBox Txb_Proveedor;
        private System.Windows.Forms.Label Lbl_Proveedor;
        private System.Windows.Forms.Button Btn_SeleccionarProveedor;
        private System.Windows.Forms.Panel Pnl_Busqueda;
        private System.Windows.Forms.Label Lbl_CompraMinHasta;
        private System.Windows.Forms.TextBox Txb_CompraMinHasta;
        private System.Windows.Forms.TextBox Txb_CompraMinDesde;
        private System.Windows.Forms.Label Lbl_CompraMinDesde;
        private System.Windows.Forms.Label Lbl_PrecHasta;
        private System.Windows.Forms.Label Lbl_CantHasta;
        private System.Windows.Forms.TextBox Txb_PrecHasta;
        private System.Windows.Forms.TextBox Txb_CantHasta;
        private System.Windows.Forms.Label Lbl_CantDesde;
        private System.Windows.Forms.TextBox Txb_CantDesde;
        private System.Windows.Forms.TextBox Txb_PrecDesde;
        private System.Windows.Forms.Label Lbl_PrecDesde;
        private System.Windows.Forms.CheckBox Chb_Busqueda;
        private System.Windows.Forms.Button Btn_Refrescar;
    }
}