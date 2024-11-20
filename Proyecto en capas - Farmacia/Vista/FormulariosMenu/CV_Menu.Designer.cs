namespace Vista
{
    partial class CV_Menu
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
            this.Btn_CerraSesion = new System.Windows.Forms.Button();
            this.Ms_Menu = new System.Windows.Forms.MenuStrip();
            this.Ms_ModuloAltas = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_Personas = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_ModuloStock = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_ModuloVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_ModuloAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_Proveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_Catalogo = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_PediodeCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_OrdendeCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_Informes = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_ModuloSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_ModuloConfiguracionSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.Ms_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_CerraSesion
            // 
            this.Btn_CerraSesion.Location = new System.Drawing.Point(67, 614);
            this.Btn_CerraSesion.Name = "Btn_CerraSesion";
            this.Btn_CerraSesion.Size = new System.Drawing.Size(108, 48);
            this.Btn_CerraSesion.TabIndex = 3;
            this.Btn_CerraSesion.Text = "Cerrar sesión";
            this.Btn_CerraSesion.UseVisualStyleBackColor = true;
            this.Btn_CerraSesion.Click += new System.EventHandler(this.Btn_CerraSesion_Click);
            // 
            // Ms_Menu
            // 
            this.Ms_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Ms_Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Ms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ms_ModuloAltas,
            this.Ms_ModuloStock,
            this.Ms_ModuloVentas,
            this.Ms_ModuloAdministracion,
            this.Ms_ModuloSeguridad,
            this.Ms_ModuloConfiguracionSistema});
            this.Ms_Menu.Location = new System.Drawing.Point(0, 0);
            this.Ms_Menu.Name = "Ms_Menu";
            this.Ms_Menu.Size = new System.Drawing.Size(181, 751);
            this.Ms_Menu.TabIndex = 22;
            this.Ms_Menu.Text = "menuStrip1";
            this.Ms_Menu.MouseEnter += new System.EventHandler(this.Ms_Menu_MouseEnter);
            this.Ms_Menu.MouseLeave += new System.EventHandler(this.Ms_Menu_MouseLeave);
            // 
            // Ms_ModuloAltas
            // 
            this.Ms_ModuloAltas.AutoSize = false;
            this.Ms_ModuloAltas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ms_Personas,
            this.Ms_Usuarios});
            this.Ms_ModuloAltas.Name = "Ms_ModuloAltas";
            this.Ms_ModuloAltas.Size = new System.Drawing.Size(175, 80);
            this.Ms_ModuloAltas.Text = "Gestión de altas";
            // 
            // Ms_Personas
            // 
            this.Ms_Personas.Name = "Ms_Personas";
            this.Ms_Personas.Size = new System.Drawing.Size(203, 26);
            this.Ms_Personas.Text = "Alta de personas";
            this.Ms_Personas.Click += new System.EventHandler(this.Ms_Personas_Click);
            // 
            // Ms_Usuarios
            // 
            this.Ms_Usuarios.Name = "Ms_Usuarios";
            this.Ms_Usuarios.Size = new System.Drawing.Size(203, 26);
            this.Ms_Usuarios.Text = "Usuarios";
            this.Ms_Usuarios.Click += new System.EventHandler(this.Ms_Usuarios_Click);
            // 
            // Ms_ModuloStock
            // 
            this.Ms_ModuloStock.AutoSize = false;
            this.Ms_ModuloStock.Name = "Ms_ModuloStock";
            this.Ms_ModuloStock.Size = new System.Drawing.Size(175, 80);
            this.Ms_ModuloStock.Text = "Gestión de stock";
            this.Ms_ModuloStock.Click += new System.EventHandler(this.Ms_ModuloStock_Click);
            // 
            // Ms_ModuloVentas
            // 
            this.Ms_ModuloVentas.AutoSize = false;
            this.Ms_ModuloVentas.Name = "Ms_ModuloVentas";
            this.Ms_ModuloVentas.Size = new System.Drawing.Size(175, 80);
            this.Ms_ModuloVentas.Text = "Ventas";
            this.Ms_ModuloVentas.Click += new System.EventHandler(this.Ms_ModuloVentas_Click);
            // 
            // Ms_ModuloAdministracion
            // 
            this.Ms_ModuloAdministracion.AutoSize = false;
            this.Ms_ModuloAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ms_Proveedores,
            this.Ms_Catalogo,
            this.Ms_PediodeCompra,
            this.Ms_OrdendeCompra,
            this.Ms_Informes});
            this.Ms_ModuloAdministracion.Name = "Ms_ModuloAdministracion";
            this.Ms_ModuloAdministracion.Size = new System.Drawing.Size(175, 80);
            this.Ms_ModuloAdministracion.Text = "Administración";
            // 
            // Ms_Proveedores
            // 
            this.Ms_Proveedores.Name = "Ms_Proveedores";
            this.Ms_Proveedores.Size = new System.Drawing.Size(237, 26);
            this.Ms_Proveedores.Text = "Proveedores";
            this.Ms_Proveedores.Click += new System.EventHandler(this.Ms_Proveedores_Click);
            // 
            // Ms_Catalogo
            // 
            this.Ms_Catalogo.Name = "Ms_Catalogo";
            this.Ms_Catalogo.Size = new System.Drawing.Size(237, 26);
            this.Ms_Catalogo.Text = "Catalogo de Compras";
            this.Ms_Catalogo.Click += new System.EventHandler(this.Ms_Catalogo_Click);
            // 
            // Ms_PediodeCompra
            // 
            this.Ms_PediodeCompra.Name = "Ms_PediodeCompra";
            this.Ms_PediodeCompra.Size = new System.Drawing.Size(237, 26);
            this.Ms_PediodeCompra.Text = "Pedido de compra";
            this.Ms_PediodeCompra.Click += new System.EventHandler(this.Ms_PediodeCompra_Click);
            // 
            // Ms_OrdendeCompra
            // 
            this.Ms_OrdendeCompra.Name = "Ms_OrdendeCompra";
            this.Ms_OrdendeCompra.Size = new System.Drawing.Size(237, 26);
            this.Ms_OrdendeCompra.Text = "Órdenes de compra";
            this.Ms_OrdendeCompra.Click += new System.EventHandler(this.Ms_OrdendeCompra_Click);
            // 
            // Ms_Informes
            // 
            this.Ms_Informes.Name = "Ms_Informes";
            this.Ms_Informes.Size = new System.Drawing.Size(237, 26);
            this.Ms_Informes.Text = "Informes";
            this.Ms_Informes.Click += new System.EventHandler(this.Ms_Informes_Click);
            // 
            // Ms_ModuloSeguridad
            // 
            this.Ms_ModuloSeguridad.AutoSize = false;
            this.Ms_ModuloSeguridad.Name = "Ms_ModuloSeguridad";
            this.Ms_ModuloSeguridad.Size = new System.Drawing.Size(175, 80);
            this.Ms_ModuloSeguridad.Text = "Seguridad";
            this.Ms_ModuloSeguridad.Click += new System.EventHandler(this.Ms_ModuloSeguridad_Click);
            // 
            // Ms_ModuloConfiguracionSistema
            // 
            this.Ms_ModuloConfiguracionSistema.AutoSize = false;
            this.Ms_ModuloConfiguracionSistema.Name = "Ms_ModuloConfiguracionSistema";
            this.Ms_ModuloConfiguracionSistema.Size = new System.Drawing.Size(175, 80);
            this.Ms_ModuloConfiguracionSistema.Text = "Configuración del sistema";
            this.Ms_ModuloConfiguracionSistema.Click += new System.EventHandler(this.Ms_ModuloConfiguracionSistema_Click);
            // 
            // CV_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 751);
            this.Controls.Add(this.Btn_CerraSesion);
            this.Controls.Add(this.Ms_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "CV_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmatic";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CV_Menu_FormClosed);
            this.Load += new System.EventHandler(this.CV_Menu_Load);
            //this.MouseEnter += new System.EventHandler(this.CV_Menu_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CV_Menu_MouseMove);
            this.Ms_Menu.ResumeLayout(false);
            this.Ms_Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_CerraSesion;
        private System.Windows.Forms.MenuStrip Ms_Menu;
        private System.Windows.Forms.ToolStripMenuItem Ms_ModuloAltas;
        private System.Windows.Forms.ToolStripMenuItem Ms_ModuloStock;
        private System.Windows.Forms.ToolStripMenuItem Ms_ModuloVentas;
        private System.Windows.Forms.ToolStripMenuItem Ms_ModuloAdministracion;
        private System.Windows.Forms.ToolStripMenuItem Ms_ModuloSeguridad;
        private System.Windows.Forms.ToolStripMenuItem Ms_ModuloConfiguracionSistema;
        private System.Windows.Forms.ToolStripMenuItem Ms_Personas;
        private System.Windows.Forms.ToolStripMenuItem Ms_Usuarios;
        private System.Windows.Forms.ToolStripMenuItem Ms_Proveedores;
        private System.Windows.Forms.ToolStripMenuItem Ms_Catalogo;
        private System.Windows.Forms.ToolStripMenuItem Ms_PediodeCompra;
        private System.Windows.Forms.ToolStripMenuItem Ms_OrdendeCompra;
        private System.Windows.Forms.ToolStripMenuItem Ms_Informes;
    }
}