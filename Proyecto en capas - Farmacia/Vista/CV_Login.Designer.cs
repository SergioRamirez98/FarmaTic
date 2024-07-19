namespace Vista
{
    partial class CV_Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Llb_Contraseña = new System.Windows.Forms.Label();
            this.Txb_Usuario = new System.Windows.Forms.TextBox();
            this.Txb_Contrasena = new System.Windows.Forms.TextBox();
            this.Cbx_MostrarContrasena = new System.Windows.Forms.CheckBox();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.LnkLbl_OlvideContrasena = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Location = new System.Drawing.Point(179, 129);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(54, 16);
            this.Lbl_Usuario.TabIndex = 5;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Llb_Contraseña
            // 
            this.Llb_Contraseña.AutoSize = true;
            this.Llb_Contraseña.Location = new System.Drawing.Point(179, 194);
            this.Llb_Contraseña.Name = "Llb_Contraseña";
            this.Llb_Contraseña.Size = new System.Drawing.Size(76, 16);
            this.Llb_Contraseña.TabIndex = 6;
            this.Llb_Contraseña.Text = "Contraseña";
            // 
            // Txb_Usuario
            // 
            this.Txb_Usuario.Location = new System.Drawing.Point(308, 129);
            this.Txb_Usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txb_Usuario.Name = "Txb_Usuario";
            this.Txb_Usuario.Size = new System.Drawing.Size(100, 22);
            this.Txb_Usuario.TabIndex = 0;
            // 
            // Txb_Contrasena
            // 
            this.Txb_Contrasena.Location = new System.Drawing.Point(308, 194);
            this.Txb_Contrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txb_Contrasena.Name = "Txb_Contrasena";
            this.Txb_Contrasena.Size = new System.Drawing.Size(100, 22);
            this.Txb_Contrasena.TabIndex = 1;
            // 
            // Cbx_MostrarContrasena
            // 
            this.Cbx_MostrarContrasena.AutoSize = true;
            this.Cbx_MostrarContrasena.Location = new System.Drawing.Point(447, 166);
            this.Cbx_MostrarContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cbx_MostrarContrasena.Name = "Cbx_MostrarContrasena";
            this.Cbx_MostrarContrasena.Size = new System.Drawing.Size(144, 20);
            this.Cbx_MostrarContrasena.TabIndex = 2;
            this.Cbx_MostrarContrasena.Text = "Mostrar contraseña";
            this.Cbx_MostrarContrasena.UseVisualStyleBackColor = true;
            this.Cbx_MostrarContrasena.CheckedChanged += new System.EventHandler(this.Cbx_MostrarContrasena_CheckedChanged);
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.Location = new System.Drawing.Point(308, 263);
            this.Btn_Ingresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(100, 42);
            this.Btn_Ingresar.TabIndex = 3;
            this.Btn_Ingresar.Text = "Ingresar";
            this.Btn_Ingresar.UseVisualStyleBackColor = true;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // LnkLbl_OlvideContrasena
            // 
            this.LnkLbl_OlvideContrasena.AutoSize = true;
            this.LnkLbl_OlvideContrasena.Location = new System.Drawing.Point(287, 319);
            this.LnkLbl_OlvideContrasena.Name = "LnkLbl_OlvideContrasena";
            this.LnkLbl_OlvideContrasena.Size = new System.Drawing.Size(133, 16);
            this.LnkLbl_OlvideContrasena.TabIndex = 4;
            this.LnkLbl_OlvideContrasena.TabStop = true;
            this.LnkLbl_OlvideContrasena.Text = "Olvide mi contraseña";
            this.LnkLbl_OlvideContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLbl_OlvideContrasena_LinkClicked);
            // 
            // CV_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LnkLbl_OlvideContrasena);
            this.Controls.Add(this.Btn_Ingresar);
            this.Controls.Add(this.Cbx_MostrarContrasena);
            this.Controls.Add(this.Txb_Contrasena);
            this.Controls.Add(this.Txb_Usuario);
            this.Controls.Add(this.Llb_Contraseña);
            this.Controls.Add(this.Lbl_Usuario);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CV_Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.CV_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Label Llb_Contraseña;
        private System.Windows.Forms.TextBox Txb_Usuario;
        private System.Windows.Forms.TextBox Txb_Contrasena;
        private System.Windows.Forms.CheckBox Cbx_MostrarContrasena;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.LinkLabel LnkLbl_OlvideContrasena;
    }
}

