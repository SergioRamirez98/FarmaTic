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
            this.Btn_GestionUsuarios = new System.Windows.Forms.Button();
            this.Btn_GestionInventario = new System.Windows.Forms.Button();
            this.Btn_GestionVentas = new System.Windows.Forms.Button();
            this.Btn_CerraSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_GestionUsuarios
            // 
            this.Btn_GestionUsuarios.Location = new System.Drawing.Point(30, 12);
            this.Btn_GestionUsuarios.Name = "Btn_GestionUsuarios";
            this.Btn_GestionUsuarios.Size = new System.Drawing.Size(184, 109);
            this.Btn_GestionUsuarios.TabIndex = 0;
            this.Btn_GestionUsuarios.Text = "Gestion de Usuarios";
            this.Btn_GestionUsuarios.UseVisualStyleBackColor = true;
            this.Btn_GestionUsuarios.Click += new System.EventHandler(this.Btn_GestionUsuarios_Click);
            // 
            // Btn_GestionInventario
            // 
            this.Btn_GestionInventario.Location = new System.Drawing.Point(230, 12);
            this.Btn_GestionInventario.Name = "Btn_GestionInventario";
            this.Btn_GestionInventario.Size = new System.Drawing.Size(184, 109);
            this.Btn_GestionInventario.TabIndex = 1;
            this.Btn_GestionInventario.Text = "Modulo de Stock";
            this.Btn_GestionInventario.UseVisualStyleBackColor = true;
            // 
            // Btn_GestionVentas
            // 
            this.Btn_GestionVentas.Location = new System.Drawing.Point(430, 12);
            this.Btn_GestionVentas.Name = "Btn_GestionVentas";
            this.Btn_GestionVentas.Size = new System.Drawing.Size(184, 109);
            this.Btn_GestionVentas.TabIndex = 2;
            this.Btn_GestionVentas.Text = "Modulo de ventas";
            this.Btn_GestionVentas.UseVisualStyleBackColor = true;
            // 
            // Btn_CerraSesion
            // 
            this.Btn_CerraSesion.Location = new System.Drawing.Point(687, 46);
            this.Btn_CerraSesion.Name = "Btn_CerraSesion";
            this.Btn_CerraSesion.Size = new System.Drawing.Size(75, 40);
            this.Btn_CerraSesion.TabIndex = 3;
            this.Btn_CerraSesion.Text = "Cerrar sesión";
            this.Btn_CerraSesion.UseVisualStyleBackColor = true;
            this.Btn_CerraSesion.Click += new System.EventHandler(this.Btn_CerraSesion_Click);
            // 
            // CV_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_CerraSesion);
            this.Controls.Add(this.Btn_GestionVentas);
            this.Controls.Add(this.Btn_GestionInventario);
            this.Controls.Add(this.Btn_GestionUsuarios);
            this.Name = "CV_Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.CV_Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_GestionUsuarios;
        private System.Windows.Forms.Button Btn_GestionInventario;
        private System.Windows.Forms.Button Btn_GestionVentas;
        private System.Windows.Forms.Button Btn_CerraSesion;
    }
}