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
            this.Btn_Usuarios = new System.Windows.Forms.Button();
            this.Btn_Grupo = new System.Windows.Forms.Button();
            this.DTGV_PermisosActuales = new System.Windows.Forms.DataGridView();
            this.DTGV_PermisosRestantes = new System.Windows.Forms.DataGridView();
            this.Btn_Funcion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_FamiliaUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosRestantes)).BeginInit();
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
            this.Btn_Guardar.Location = new System.Drawing.Point(345, 332);
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
            this.DTGV_FamiliaUsuario.Location = new System.Drawing.Point(18, 144);
            this.DTGV_FamiliaUsuario.Name = "DTGV_FamiliaUsuario";
            this.DTGV_FamiliaUsuario.RowHeadersWidth = 51;
            this.DTGV_FamiliaUsuario.RowTemplate.Height = 24;
            this.DTGV_FamiliaUsuario.Size = new System.Drawing.Size(226, 152);
            this.DTGV_FamiliaUsuario.TabIndex = 17;
            this.DTGV_FamiliaUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_FamiliaUsuario_CellClick);
            // 
            // Btn_Usuarios
            // 
            this.Btn_Usuarios.Location = new System.Drawing.Point(41, 115);
            this.Btn_Usuarios.Name = "Btn_Usuarios";
            this.Btn_Usuarios.Size = new System.Drawing.Size(75, 23);
            this.Btn_Usuarios.TabIndex = 20;
            this.Btn_Usuarios.Text = "Usuarios";
            this.Btn_Usuarios.UseVisualStyleBackColor = true;
            this.Btn_Usuarios.Click += new System.EventHandler(this.Btn_Usuarios_Click);
            // 
            // Btn_Grupo
            // 
            this.Btn_Grupo.Location = new System.Drawing.Point(141, 115);
            this.Btn_Grupo.Name = "Btn_Grupo";
            this.Btn_Grupo.Size = new System.Drawing.Size(75, 23);
            this.Btn_Grupo.TabIndex = 21;
            this.Btn_Grupo.Text = "Grupo";
            this.Btn_Grupo.UseVisualStyleBackColor = true;
            this.Btn_Grupo.Click += new System.EventHandler(this.Btn_Grupo_Click);
            // 
            // DTGV_PermisosActuales
            // 
            this.DTGV_PermisosActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_PermisosActuales.Location = new System.Drawing.Point(324, 144);
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
            this.DTGV_PermisosRestantes.Location = new System.Drawing.Point(782, 144);
            this.DTGV_PermisosRestantes.Name = "DTGV_PermisosRestantes";
            this.DTGV_PermisosRestantes.RowHeadersWidth = 51;
            this.DTGV_PermisosRestantes.RowTemplate.Height = 24;
            this.DTGV_PermisosRestantes.Size = new System.Drawing.Size(338, 152);
            this.DTGV_PermisosRestantes.TabIndex = 23;
            this.DTGV_PermisosRestantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_PermisosRestantes_CellClick);
            // 
            // Btn_Funcion
            // 
            this.Btn_Funcion.Location = new System.Drawing.Point(682, 213);
            this.Btn_Funcion.Name = "Btn_Funcion";
            this.Btn_Funcion.Size = new System.Drawing.Size(75, 26);
            this.Btn_Funcion.TabIndex = 24;
            this.Btn_Funcion.Text = "funcion";
            this.Btn_Funcion.UseVisualStyleBackColor = true;
            this.Btn_Funcion.Click += new System.EventHandler(this.Btn_Funcion_Click);
            // 
            // CV_ConfiguracionSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 450);
            this.Controls.Add(this.Btn_Funcion);
            this.Controls.Add(this.DTGV_PermisosRestantes);
            this.Controls.Add(this.DTGV_PermisosActuales);
            this.Controls.Add(this.Btn_Grupo);
            this.Controls.Add(this.Btn_Usuarios);
            this.Controls.Add(this.DTGV_FamiliaUsuario);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Lbl_CantMinStock);
            this.Controls.Add(this.Nud_CantMinStock);
            this.Controls.Add(this.Lbl_DiasVtoProd);
            this.Controls.Add(this.Nud_VtoProd);
            this.Name = "CV_ConfiguracionSistema";
            this.Text = "Configuracion Sistema";
            this.Load += new System.EventHandler(this.CV_ConfiguracionSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_VtoProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_FamiliaUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosRestantes)).EndInit();
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
        private System.Windows.Forms.Button Btn_Usuarios;
        private System.Windows.Forms.Button Btn_Grupo;
        private System.Windows.Forms.DataGridView DTGV_PermisosActuales;
        private System.Windows.Forms.DataGridView DTGV_PermisosRestantes;
        private System.Windows.Forms.Button Btn_Funcion;
    }
}