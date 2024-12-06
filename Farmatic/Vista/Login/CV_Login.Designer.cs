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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_Login));
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Llb_Contrasena = new System.Windows.Forms.Label();
            this.Txb_Usuario = new System.Windows.Forms.TextBox();
            this.Txb_Contrasena = new System.Windows.Forms.TextBox();
            this.Btn_Ingresar = new System.Windows.Forms.Button();
            this.LnkLbl_OlvideContrasena = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMostrarContrasenia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Usuario.Location = new System.Drawing.Point(316, 88);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(67, 20);
            this.Lbl_Usuario.TabIndex = 5;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Llb_Contrasena
            // 
            this.Llb_Contrasena.AutoSize = true;
            this.Llb_Contrasena.BackColor = System.Drawing.Color.Transparent;
            this.Llb_Contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Llb_Contrasena.Location = new System.Drawing.Point(316, 113);
            this.Llb_Contrasena.Name = "Llb_Contrasena";
            this.Llb_Contrasena.Size = new System.Drawing.Size(95, 20);
            this.Llb_Contrasena.TabIndex = 6;
            this.Llb_Contrasena.Text = "Contraseña";
            // 
            // Txb_Usuario
            // 
            this.Txb_Usuario.Location = new System.Drawing.Point(424, 87);
            this.Txb_Usuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txb_Usuario.Name = "Txb_Usuario";
            this.Txb_Usuario.Size = new System.Drawing.Size(131, 22);
            this.Txb_Usuario.TabIndex = 0;
            // 
            // Txb_Contrasena
            // 
            this.Txb_Contrasena.Location = new System.Drawing.Point(424, 112);
            this.Txb_Contrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txb_Contrasena.Name = "Txb_Contrasena";
            this.Txb_Contrasena.Size = new System.Drawing.Size(131, 22);
            this.Txb_Contrasena.TabIndex = 1;
            // 
            // Btn_Ingresar
            // 
            this.Btn_Ingresar.BackColor = System.Drawing.Color.CadetBlue;
            this.Btn_Ingresar.FlatAppearance.BorderSize = 0;
            this.Btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ingresar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Ingresar.Location = new System.Drawing.Point(424, 148);
            this.Btn_Ingresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Ingresar.Name = "Btn_Ingresar";
            this.Btn_Ingresar.Size = new System.Drawing.Size(131, 31);
            this.Btn_Ingresar.TabIndex = 3;
            this.Btn_Ingresar.Text = "Ingresar";
            this.Btn_Ingresar.UseVisualStyleBackColor = false;
            this.Btn_Ingresar.Click += new System.EventHandler(this.Btn_Ingresar_Click);
            // 
            // LnkLbl_OlvideContrasena
            // 
            this.LnkLbl_OlvideContrasena.AutoSize = true;
            this.LnkLbl_OlvideContrasena.BackColor = System.Drawing.Color.Transparent;
            this.LnkLbl_OlvideContrasena.Location = new System.Drawing.Point(423, 190);
            this.LnkLbl_OlvideContrasena.Name = "LnkLbl_OlvideContrasena";
            this.LnkLbl_OlvideContrasena.Size = new System.Drawing.Size(133, 16);
            this.LnkLbl_OlvideContrasena.TabIndex = 4;
            this.LnkLbl_OlvideContrasena.TabStop = true;
            this.LnkLbl_OlvideContrasena.Text = "Olvide mi contraseña";
            this.LnkLbl_OlvideContrasena.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLbl_OlvideContrasena_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Vista.Properties.Resources.farmaTic_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 231);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnMostrarContrasenia
            // 
            this.btnMostrarContrasenia.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarContrasenia.BackgroundImage = global::Vista.Properties.Resources.ojo;
            this.btnMostrarContrasenia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMostrarContrasenia.FlatAppearance.BorderSize = 0;
            this.btnMostrarContrasenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarContrasenia.Location = new System.Drawing.Point(563, 114);
            this.btnMostrarContrasenia.Name = "btnMostrarContrasenia";
            this.btnMostrarContrasenia.Size = new System.Drawing.Size(30, 19);
            this.btnMostrarContrasenia.TabIndex = 8;
            this.btnMostrarContrasenia.UseVisualStyleBackColor = false;
            this.btnMostrarContrasenia.Click += new System.EventHandler(this.btnMostrarContrasenia_Click);
            this.btnMostrarContrasenia.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMostrarContrasenia_MouseDown);
            this.btnMostrarContrasenia.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMostrarContrasenia_MouseUp);
            // 
            // CV_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(645, 277);
            this.Controls.Add(this.btnMostrarContrasenia);
            this.Controls.Add(this.Lbl_Usuario);
            this.Controls.Add(this.Llb_Contrasena);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LnkLbl_OlvideContrasena);
            this.Controls.Add(this.Btn_Ingresar);
            this.Controls.Add(this.Txb_Contrasena);
            this.Controls.Add(this.Txb_Usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CV_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.CV_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Label Llb_Contrasena;
        private System.Windows.Forms.TextBox Txb_Usuario;
        private System.Windows.Forms.TextBox Txb_Contrasena;
        private System.Windows.Forms.Button Btn_Ingresar;
        private System.Windows.Forms.LinkLabel LnkLbl_OlvideContrasena;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMostrarContrasenia;
    }
}

