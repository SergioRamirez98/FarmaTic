namespace Vista.FormulariosMenu
{
    partial class CV_ConfiguracionSistema
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
            this.Lbl_CantMinStock = new System.Windows.Forms.Label();
            this.Nud_CantMinStock = new System.Windows.Forms.NumericUpDown();
            this.Lbl_DiasVtoProd = new System.Windows.Forms.Label();
            this.Nud_VtoProd = new System.Windows.Forms.NumericUpDown();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.DTGV_FamiliaUsuario = new System.Windows.Forms.DataGridView();
            this.DTGV_PermisosActuales = new System.Windows.Forms.DataGridView();
            this.DTGV_PermisosRestantes = new System.Windows.Forms.DataGridView();
            this.Btn_Funcion = new System.Windows.Forms.Button();
            this.Gpb_Permisos = new System.Windows.Forms.GroupBox();
            this.Txb_BuscarPermisoRestante = new System.Windows.Forms.TextBox();
            this.Txb_BuscarPermisoActual = new System.Windows.Forms.TextBox();
            this.Rbt_Grupo = new System.Windows.Forms.RadioButton();
            this.Rbt_Usuario = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_FamiliaUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosRestantes)).BeginInit();
            this.Gpb_Permisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_CantMinStock
            // 
            this.Lbl_CantMinStock.AutoSize = true;
            this.Lbl_CantMinStock.Location = new System.Drawing.Point(451, 35);
            this.Lbl_CantMinStock.Name = "Lbl_CantMinStock";
            this.Lbl_CantMinStock.Size = new System.Drawing.Size(161, 16);
            this.Lbl_CantMinStock.TabIndex = 12;
            this.Lbl_CantMinStock.Text = "Cantidad minima de stock";
            // 
            // Nud_CantMinStock
            // 
            this.Nud_CantMinStock.Location = new System.Drawing.Point(388, 35);
            this.Nud_CantMinStock.Name = "Nud_CantMinStock";
            this.Nud_CantMinStock.Size = new System.Drawing.Size(54, 22);
            this.Nud_CantMinStock.TabIndex = 13;
            this.Nud_CantMinStock.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Lbl_DiasVtoProd
            // 
            this.Lbl_DiasVtoProd.AutoSize = true;
            this.Lbl_DiasVtoProd.Location = new System.Drawing.Point(125, 35);
            this.Lbl_DiasVtoProd.Name = "Lbl_DiasVtoProd";
            this.Lbl_DiasVtoProd.Size = new System.Drawing.Size(179, 16);
            this.Lbl_DiasVtoProd.TabIndex = 10;
            this.Lbl_DiasVtoProd.Text = "Aviso de dias Vto. Productos";
            // 
            // Nud_VtoProd
            // 
            this.Nud_VtoProd.Location = new System.Drawing.Point(62, 35);
            this.Nud_VtoProd.Name = "Nud_VtoProd";
            this.Nud_VtoProd.Size = new System.Drawing.Size(54, 22);
            this.Nud_VtoProd.TabIndex = 11;
            this.Nud_VtoProd.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(343, 351);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Guardar.TabIndex = 16;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // DTGV_FamiliaUsuario
            // 
            this.DTGV_FamiliaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_FamiliaUsuario.Location = new System.Drawing.Point(14, 71);
            this.DTGV_FamiliaUsuario.Name = "DTGV_FamiliaUsuario";
            this.DTGV_FamiliaUsuario.RowHeadersWidth = 51;
            this.DTGV_FamiliaUsuario.RowTemplate.Height = 24;
            this.DTGV_FamiliaUsuario.Size = new System.Drawing.Size(226, 152);
            this.DTGV_FamiliaUsuario.TabIndex = 17;
            this.DTGV_FamiliaUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_FamiliaUsuario_CellClick);
            // 
            // DTGV_PermisosActuales
            // 
            this.DTGV_PermisosActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_PermisosActuales.Location = new System.Drawing.Point(320, 71);
            this.DTGV_PermisosActuales.Name = "DTGV_PermisosActuales";
            this.DTGV_PermisosActuales.RowHeadersWidth = 51;
            this.DTGV_PermisosActuales.RowTemplate.Height = 24;
            this.DTGV_PermisosActuales.Size = new System.Drawing.Size(338, 152);
            this.DTGV_PermisosActuales.TabIndex = 22;
            this.DTGV_PermisosActuales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_PermisosActuales_CellClick);
            // 
            // DTGV_PermisosRestantes
            // 
            this.DTGV_PermisosRestantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_PermisosRestantes.Location = new System.Drawing.Point(778, 71);
            this.DTGV_PermisosRestantes.Name = "DTGV_PermisosRestantes";
            this.DTGV_PermisosRestantes.RowHeadersWidth = 51;
            this.DTGV_PermisosRestantes.RowTemplate.Height = 24;
            this.DTGV_PermisosRestantes.Size = new System.Drawing.Size(338, 152);
            this.DTGV_PermisosRestantes.TabIndex = 23;
            this.DTGV_PermisosRestantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_PermisosRestantes_CellClick);
            // 
            // Btn_Funcion
            // 
            this.Btn_Funcion.Location = new System.Drawing.Point(678, 140);
            this.Btn_Funcion.Name = "Btn_Funcion";
            this.Btn_Funcion.Size = new System.Drawing.Size(75, 26);
            this.Btn_Funcion.TabIndex = 24;
            this.Btn_Funcion.Text = "funcion";
            this.Btn_Funcion.UseVisualStyleBackColor = true;
            this.Btn_Funcion.Click += new System.EventHandler(this.Btn_Funcion_Click);
            // 
            // Gpb_Permisos
            // 
            this.Gpb_Permisos.Controls.Add(this.Txb_BuscarPermisoRestante);
            this.Gpb_Permisos.Controls.Add(this.Txb_BuscarPermisoActual);
            this.Gpb_Permisos.Controls.Add(this.Rbt_Grupo);
            this.Gpb_Permisos.Controls.Add(this.Rbt_Usuario);
            this.Gpb_Permisos.Controls.Add(this.Btn_Funcion);
            this.Gpb_Permisos.Controls.Add(this.DTGV_FamiliaUsuario);
            this.Gpb_Permisos.Controls.Add(this.DTGV_PermisosRestantes);
            this.Gpb_Permisos.Controls.Add(this.DTGV_PermisosActuales);
            this.Gpb_Permisos.Location = new System.Drawing.Point(12, 79);
            this.Gpb_Permisos.Name = "Gpb_Permisos";
            this.Gpb_Permisos.Size = new System.Drawing.Size(1127, 266);
            this.Gpb_Permisos.TabIndex = 25;
            this.Gpb_Permisos.TabStop = false;
            this.Gpb_Permisos.Text = "Permisos para los usuarios";
            // 
            // Txb_BuscarPermisoRestante
            // 
            this.Txb_BuscarPermisoRestante.Location = new System.Drawing.Point(882, 32);
            this.Txb_BuscarPermisoRestante.Name = "Txb_BuscarPermisoRestante";
            this.Txb_BuscarPermisoRestante.Size = new System.Drawing.Size(100, 22);
            this.Txb_BuscarPermisoRestante.TabIndex = 28;
            this.Txb_BuscarPermisoRestante.TextChanged += new System.EventHandler(this.Txb_BuscarPermisoRestante_TextChanged);
            // 
            // Txb_BuscarPermisoActual
            // 
            this.Txb_BuscarPermisoActual.Location = new System.Drawing.Point(423, 42);
            this.Txb_BuscarPermisoActual.Name = "Txb_BuscarPermisoActual";
            this.Txb_BuscarPermisoActual.Size = new System.Drawing.Size(100, 22);
            this.Txb_BuscarPermisoActual.TabIndex = 27;
            this.Txb_BuscarPermisoActual.TextChanged += new System.EventHandler(this.Txb_BuscarPermisoActual_TextChanged);
            // 
            // Rbt_Grupo
            // 
            this.Rbt_Grupo.AutoSize = true;
            this.Rbt_Grupo.Location = new System.Drawing.Point(156, 45);
            this.Rbt_Grupo.Name = "Rbt_Grupo";
            this.Rbt_Grupo.Size = new System.Drawing.Size(65, 20);
            this.Rbt_Grupo.TabIndex = 26;
            this.Rbt_Grupo.TabStop = true;
            this.Rbt_Grupo.Text = "Grupo";
            this.Rbt_Grupo.UseVisualStyleBackColor = true;
            this.Rbt_Grupo.CheckedChanged += new System.EventHandler(this.Rbt_Grupo_CheckedChanged);
            // 
            // Rbt_Usuario
            // 
            this.Rbt_Usuario.AutoSize = true;
            this.Rbt_Usuario.Location = new System.Drawing.Point(34, 45);
            this.Rbt_Usuario.Name = "Rbt_Usuario";
            this.Rbt_Usuario.Size = new System.Drawing.Size(75, 20);
            this.Rbt_Usuario.TabIndex = 25;
            this.Rbt_Usuario.TabStop = true;
            this.Rbt_Usuario.Text = "Usuario";
            this.Rbt_Usuario.UseVisualStyleBackColor = true;
            this.Rbt_Usuario.CheckedChanged += new System.EventHandler(this.Rbt_Usuario_CheckedChanged);
            // 
            // CV_ConfiguracionSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1222, 450);
            this.Controls.Add(this.Gpb_Permisos);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Lbl_CantMinStock);
            this.Controls.Add(this.Nud_CantMinStock);
            this.Controls.Add(this.Lbl_DiasVtoProd);
            this.Controls.Add(this.Nud_VtoProd);
            this.Name = "CV_ConfiguracionSistema";
            this.Text = "Configuracion Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_ConfiguracionSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_FamiliaUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosRestantes)).EndInit();
            this.Gpb_Permisos.ResumeLayout(false);
            this.Gpb_Permisos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_CantMinStock;
        private System.Windows.Forms.NumericUpDown Nud_CantMinStock;
        private System.Windows.Forms.Label Lbl_DiasVtoProd;
        private System.Windows.Forms.NumericUpDown Nud_VtoProd;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.DataGridView DTGV_FamiliaUsuario;
        private System.Windows.Forms.DataGridView DTGV_PermisosActuales;
        private System.Windows.Forms.DataGridView DTGV_PermisosRestantes;
        private System.Windows.Forms.Button Btn_Funcion;
        private System.Windows.Forms.GroupBox Gpb_Permisos;
        private System.Windows.Forms.RadioButton Rbt_Grupo;
        private System.Windows.Forms.RadioButton Rbt_Usuario;
        private System.Windows.Forms.TextBox Txb_BuscarPermisoRestante;
        private System.Windows.Forms.TextBox Txb_BuscarPermisoActual;
    }
}