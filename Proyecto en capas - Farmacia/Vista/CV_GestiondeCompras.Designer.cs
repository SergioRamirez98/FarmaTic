﻿namespace Vista
{
    partial class CV_GestiondeCompras
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
            this.Btn_Catalogo = new System.Windows.Forms.Button();
            this.Btn_PedidodeCompra = new System.Windows.Forms.Button();
            this.Btn_OrdendeCompra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Catalogo
            // 
            this.Btn_Catalogo.Location = new System.Drawing.Point(67, 98);
            this.Btn_Catalogo.Name = "Btn_Catalogo";
            this.Btn_Catalogo.Size = new System.Drawing.Size(103, 51);
            this.Btn_Catalogo.TabIndex = 0;
            this.Btn_Catalogo.Text = "Catalogo";
            this.Btn_Catalogo.UseVisualStyleBackColor = true;
            this.Btn_Catalogo.Click += new System.EventHandler(this.Btn_Catalogo_Click);
            // 
            // Btn_PedidodeCompra
            // 
            this.Btn_PedidodeCompra.Location = new System.Drawing.Point(213, 98);
            this.Btn_PedidodeCompra.Name = "Btn_PedidodeCompra";
            this.Btn_PedidodeCompra.Size = new System.Drawing.Size(103, 51);
            this.Btn_PedidodeCompra.TabIndex = 1;
            this.Btn_PedidodeCompra.Text = "Pedido de compra";
            this.Btn_PedidodeCompra.UseVisualStyleBackColor = true;
            this.Btn_PedidodeCompra.Click += new System.EventHandler(this.Btn_PedidodeCompra_Click);
            // 
            // Btn_OrdendeCompra
            // 
            this.Btn_OrdendeCompra.Location = new System.Drawing.Point(361, 98);
            this.Btn_OrdendeCompra.Name = "Btn_OrdendeCompra";
            this.Btn_OrdendeCompra.Size = new System.Drawing.Size(103, 51);
            this.Btn_OrdendeCompra.TabIndex = 2;
            this.Btn_OrdendeCompra.Text = "Orden de Compra";
            this.Btn_OrdendeCompra.UseVisualStyleBackColor = true;
            this.Btn_OrdendeCompra.Click += new System.EventHandler(this.Btn_OrdendeCompra_Click);
            // 
            // CV_GestiondeCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_OrdendeCompra);
            this.Controls.Add(this.Btn_PedidodeCompra);
            this.Controls.Add(this.Btn_Catalogo);
            this.Name = "CV_GestiondeCompras";
            this.Text = "Gestion de compras";
            this.Load += new System.EventHandler(this.CV_GestiondeCompras_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Catalogo;
        private System.Windows.Forms.Button Btn_PedidodeCompra;
        private System.Windows.Forms.Button Btn_OrdendeCompra;
    }
}