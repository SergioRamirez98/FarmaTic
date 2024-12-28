namespace Vista
{
    partial class CV_ModulodeSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CV_ModulodeSeguridad));
            this.Chb_MinCaracteres = new System.Windows.Forms.CheckBox();
            this.Chb_MayMin = new System.Windows.Forms.CheckBox();
            this.Chb_CaracEspec = new System.Windows.Forms.CheckBox();
            this.Chb_DatosPersonales = new System.Windows.Forms.CheckBox();
            this.Chb_NumYLetras = new System.Windows.Forms.CheckBox();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Chb_RepetirPass = new System.Windows.Forms.CheckBox();
            this.Lbl_CantIntentosFallidos = new System.Windows.Forms.Label();
            this.Nud_CantidadIntentosFallidos = new System.Windows.Forms.NumericUpDown();
            this.Pnl_Bitacora = new System.Windows.Forms.Panel();
            this.Lbl_Bitacora = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Txb_UserName = new System.Windows.Forms.TextBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Lbl_Hasta = new System.Windows.Forms.Label();
            this.Lbl_Desde = new System.Windows.Forms.Label();
            this.Btn_VerTodo = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.Dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this.DTGV_Bitacora = new System.Windows.Forms.DataGridView();
            this.Pnl_ConfPass = new System.Windows.Forms.Panel();
            this.Lbl_ConfigPass = new System.Windows.Forms.Label();
            this.Pnl_Permisos = new System.Windows.Forms.Panel();
            this.Lbl_PermisosUsuarios = new System.Windows.Forms.Label();
            this.Txb_BuscarPermisoRestante = new System.Windows.Forms.TextBox();
            this.Txb_BuscarPermisoActual = new System.Windows.Forms.TextBox();
            this.Rbt_Grupo = new System.Windows.Forms.RadioButton();
            this.Rbt_Usuario = new System.Windows.Forms.RadioButton();
            this.Btn_Funcion = new System.Windows.Forms.Button();
            this.DTGV_FamiliaUsuario = new System.Windows.Forms.DataGridView();
            this.DTGV_PermisosRestantes = new System.Windows.Forms.DataGridView();
            this.DTGV_PermisosActuales = new System.Windows.Forms.DataGridView();
            this.Pnl_Backup = new System.Windows.Forms.Panel();
            this.Btn_RestaurarBDD = new System.Windows.Forms.Button();
            this.DTGV_BackUp = new System.Windows.Forms.DataGridView();
            this.Lbl_BackUp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantidadIntentosFallidos)).BeginInit();
            this.Pnl_Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Bitacora)).BeginInit();
            this.Pnl_ConfPass.SuspendLayout();
            this.Pnl_Permisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_FamiliaUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosRestantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosActuales)).BeginInit();
            this.Pnl_Backup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_BackUp)).BeginInit();
            this.SuspendLayout();
            // 
            // Chb_MinCaracteres
            // 
            this.Chb_MinCaracteres.AutoSize = true;
            this.Chb_MinCaracteres.Location = new System.Drawing.Point(9, 33);
            this.Chb_MinCaracteres.Name = "Chb_MinCaracteres";
            this.Chb_MinCaracteres.Size = new System.Drawing.Size(168, 20);
            this.Chb_MinCaracteres.TabIndex = 0;
            this.Chb_MinCaracteres.Text = "Minimo de 8 caracteres";
            this.Chb_MinCaracteres.UseVisualStyleBackColor = true;
            this.Chb_MinCaracteres.CheckedChanged += new System.EventHandler(this.Chb_MinCaracteres_CheckedChanged);
            // 
            // Chb_MayMin
            // 
            this.Chb_MayMin.AutoSize = true;
            this.Chb_MayMin.Location = new System.Drawing.Point(9, 63);
            this.Chb_MayMin.Name = "Chb_MayMin";
            this.Chb_MayMin.Size = new System.Drawing.Size(242, 20);
            this.Chb_MayMin.TabIndex = 1;
            this.Chb_MayMin.Text = "Combinar mayusculas y minúsculas";
            this.Chb_MayMin.UseVisualStyleBackColor = true;
            // 
            // Chb_CaracEspec
            // 
            this.Chb_CaracEspec.AutoSize = true;
            this.Chb_CaracEspec.Location = new System.Drawing.Point(9, 93);
            this.Chb_CaracEspec.Name = "Chb_CaracEspec";
            this.Chb_CaracEspec.Size = new System.Drawing.Size(165, 20);
            this.Chb_CaracEspec.TabIndex = 2;
            this.Chb_CaracEspec.Text = "Caracteres especiales";
            this.Chb_CaracEspec.UseVisualStyleBackColor = true;
            // 
            // Chb_DatosPersonales
            // 
            this.Chb_DatosPersonales.AutoSize = true;
            this.Chb_DatosPersonales.Location = new System.Drawing.Point(9, 123);
            this.Chb_DatosPersonales.Name = "Chb_DatosPersonales";
            this.Chb_DatosPersonales.Size = new System.Drawing.Size(202, 20);
            this.Chb_DatosPersonales.TabIndex = 3;
            this.Chb_DatosPersonales.Text = "No permitir datos personales";
            this.Chb_DatosPersonales.UseVisualStyleBackColor = true;
            // 
            // Chb_NumYLetras
            // 
            this.Chb_NumYLetras.AutoSize = true;
            this.Chb_NumYLetras.Location = new System.Drawing.Point(319, 33);
            this.Chb_NumYLetras.Name = "Chb_NumYLetras";
            this.Chb_NumYLetras.Size = new System.Drawing.Size(184, 20);
            this.Chb_NumYLetras.TabIndex = 4;
            this.Chb_NumYLetras.Text = "Contener numeros y letras";
            this.Chb_NumYLetras.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(618, 647);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(84, 23);
            this.Btn_Guardar.TabIndex = 10;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Chb_RepetirPass
            // 
            this.Chb_RepetirPass.AutoSize = true;
            this.Chb_RepetirPass.Location = new System.Drawing.Point(319, 63);
            this.Chb_RepetirPass.Name = "Chb_RepetirPass";
            this.Chb_RepetirPass.Size = new System.Drawing.Size(165, 20);
            this.Chb_RepetirPass.TabIndex = 5;
            this.Chb_RepetirPass.Text = "No repetir contraseñas";
            this.Chb_RepetirPass.UseVisualStyleBackColor = true;
            // 
            // Lbl_CantIntentosFallidos
            // 
            this.Lbl_CantIntentosFallidos.AutoSize = true;
            this.Lbl_CantIntentosFallidos.Location = new System.Drawing.Point(382, 93);
            this.Lbl_CantIntentosFallidos.Name = "Lbl_CantIntentosFallidos";
            this.Lbl_CantIntentosFallidos.Size = new System.Drawing.Size(175, 16);
            this.Lbl_CantIntentosFallidos.TabIndex = 9;
            this.Lbl_CantIntentosFallidos.Text = "Cantidad de intentos fallidos";
            // 
            // Nud_CantidadIntentosFallidos
            // 
            this.Nud_CantidadIntentosFallidos.Location = new System.Drawing.Point(319, 93);
            this.Nud_CantidadIntentosFallidos.Name = "Nud_CantidadIntentosFallidos";
            this.Nud_CantidadIntentosFallidos.Size = new System.Drawing.Size(54, 22);
            this.Nud_CantidadIntentosFallidos.TabIndex = 9;
            this.Nud_CantidadIntentosFallidos.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Pnl_Bitacora
            // 
            this.Pnl_Bitacora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Bitacora);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Usuario);
            this.Pnl_Bitacora.Controls.Add(this.Txb_UserName);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Tipo);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Hasta);
            this.Pnl_Bitacora.Controls.Add(this.Lbl_Desde);
            this.Pnl_Bitacora.Controls.Add(this.Btn_VerTodo);
            this.Pnl_Bitacora.Controls.Add(this.Btn_Buscar);
            this.Pnl_Bitacora.Controls.Add(this.Cmb_Tipo);
            this.Pnl_Bitacora.Controls.Add(this.Dtp_Hasta);
            this.Pnl_Bitacora.Controls.Add(this.Dtp_Desde);
            this.Pnl_Bitacora.Controls.Add(this.DTGV_Bitacora);
            this.Pnl_Bitacora.Location = new System.Drawing.Point(21, 219);
            this.Pnl_Bitacora.Name = "Pnl_Bitacora";
            this.Pnl_Bitacora.Size = new System.Drawing.Size(628, 413);
            this.Pnl_Bitacora.TabIndex = 12;
            // 
            // Lbl_Bitacora
            // 
            this.Lbl_Bitacora.AutoSize = true;
            this.Lbl_Bitacora.Location = new System.Drawing.Point(9, 4);
            this.Lbl_Bitacora.Name = "Lbl_Bitacora";
            this.Lbl_Bitacora.Size = new System.Drawing.Size(57, 16);
            this.Lbl_Bitacora.TabIndex = 15;
            this.Lbl_Bitacora.Text = "Bitácora";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Location = new System.Drawing.Point(30, 35);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(54, 16);
            this.Lbl_Usuario.TabIndex = 63;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Txb_UserName
            // 
            this.Txb_UserName.Location = new System.Drawing.Point(33, 54);
            this.Txb_UserName.Name = "Txb_UserName";
            this.Txb_UserName.Size = new System.Drawing.Size(119, 22);
            this.Txb_UserName.TabIndex = 53;
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Location = new System.Drawing.Point(484, 35);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(118, 16);
            this.Lbl_Tipo.TabIndex = 61;
            this.Lbl_Tipo.Text = "Tipo de operacion";
            // 
            // Lbl_Hasta
            // 
            this.Lbl_Hasta.AutoSize = true;
            this.Lbl_Hasta.Location = new System.Drawing.Point(331, 35);
            this.Lbl_Hasta.Name = "Lbl_Hasta";
            this.Lbl_Hasta.Size = new System.Drawing.Size(43, 16);
            this.Lbl_Hasta.TabIndex = 60;
            this.Lbl_Hasta.Text = "Hasta";
            // 
            // Lbl_Desde
            // 
            this.Lbl_Desde.AutoSize = true;
            this.Lbl_Desde.Location = new System.Drawing.Point(176, 35);
            this.Lbl_Desde.Name = "Lbl_Desde";
            this.Lbl_Desde.Size = new System.Drawing.Size(48, 16);
            this.Lbl_Desde.TabIndex = 59;
            this.Lbl_Desde.Text = "Desde";
            // 
            // Btn_VerTodo
            // 
            this.Btn_VerTodo.Location = new System.Drawing.Point(320, 101);
            this.Btn_VerTodo.Name = "Btn_VerTodo";
            this.Btn_VerTodo.Size = new System.Drawing.Size(115, 25);
            this.Btn_VerTodo.TabIndex = 58;
            this.Btn_VerTodo.Text = "Ver todo";
            this.Btn_VerTodo.UseVisualStyleBackColor = true;
            this.Btn_VerTodo.Click += new System.EventHandler(this.Btn_VerTodo_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(179, 101);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(115, 25);
            this.Btn_Buscar.TabIndex = 56;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Cmb_Tipo
            // 
            this.Cmb_Tipo.FormattingEnabled = true;
            this.Cmb_Tipo.Location = new System.Drawing.Point(487, 52);
            this.Cmb_Tipo.Name = "Cmb_Tipo";
            this.Cmb_Tipo.Size = new System.Drawing.Size(121, 24);
            this.Cmb_Tipo.TabIndex = 57;
            // 
            // Dtp_Hasta
            // 
            this.Dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Hasta.Location = new System.Drawing.Point(334, 54);
            this.Dtp_Hasta.Name = "Dtp_Hasta";
            this.Dtp_Hasta.Size = new System.Drawing.Size(130, 22);
            this.Dtp_Hasta.TabIndex = 55;
            // 
            // Dtp_Desde
            // 
            this.Dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Desde.Location = new System.Drawing.Point(179, 54);
            this.Dtp_Desde.Name = "Dtp_Desde";
            this.Dtp_Desde.Size = new System.Drawing.Size(130, 22);
            this.Dtp_Desde.TabIndex = 54;
            // 
            // DTGV_Bitacora
            // 
            this.DTGV_Bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_Bitacora.Location = new System.Drawing.Point(12, 130);
            this.DTGV_Bitacora.Name = "DTGV_Bitacora";
            this.DTGV_Bitacora.RowHeadersWidth = 51;
            this.DTGV_Bitacora.RowTemplate.Height = 24;
            this.DTGV_Bitacora.Size = new System.Drawing.Size(603, 262);
            this.DTGV_Bitacora.TabIndex = 62;
            // 
            // Pnl_ConfPass
            // 
            this.Pnl_ConfPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_ConfPass.Controls.Add(this.Lbl_ConfigPass);
            this.Pnl_ConfPass.Controls.Add(this.Chb_MinCaracteres);
            this.Pnl_ConfPass.Controls.Add(this.Chb_MayMin);
            this.Pnl_ConfPass.Controls.Add(this.Chb_CaracEspec);
            this.Pnl_ConfPass.Controls.Add(this.Lbl_CantIntentosFallidos);
            this.Pnl_ConfPass.Controls.Add(this.Chb_DatosPersonales);
            this.Pnl_ConfPass.Controls.Add(this.Nud_CantidadIntentosFallidos);
            this.Pnl_ConfPass.Controls.Add(this.Chb_NumYLetras);
            this.Pnl_ConfPass.Controls.Add(this.Chb_RepetirPass);
            this.Pnl_ConfPass.Location = new System.Drawing.Point(23, 17);
            this.Pnl_ConfPass.Name = "Pnl_ConfPass";
            this.Pnl_ConfPass.Size = new System.Drawing.Size(628, 181);
            this.Pnl_ConfPass.TabIndex = 13;
            // 
            // Lbl_ConfigPass
            // 
            this.Lbl_ConfigPass.AutoSize = true;
            this.Lbl_ConfigPass.Location = new System.Drawing.Point(6, 4);
            this.Lbl_ConfigPass.Name = "Lbl_ConfigPass";
            this.Lbl_ConfigPass.Size = new System.Drawing.Size(185, 16);
            this.Lbl_ConfigPass.TabIndex = 14;
            this.Lbl_ConfigPass.Text = "Configuración de contraseñas";
            // 
            // Pnl_Permisos
            // 
            this.Pnl_Permisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Permisos.Controls.Add(this.Lbl_PermisosUsuarios);
            this.Pnl_Permisos.Controls.Add(this.Txb_BuscarPermisoRestante);
            this.Pnl_Permisos.Controls.Add(this.Txb_BuscarPermisoActual);
            this.Pnl_Permisos.Controls.Add(this.Rbt_Grupo);
            this.Pnl_Permisos.Controls.Add(this.Rbt_Usuario);
            this.Pnl_Permisos.Controls.Add(this.Btn_Funcion);
            this.Pnl_Permisos.Controls.Add(this.DTGV_FamiliaUsuario);
            this.Pnl_Permisos.Controls.Add(this.DTGV_PermisosRestantes);
            this.Pnl_Permisos.Controls.Add(this.DTGV_PermisosActuales);
            this.Pnl_Permisos.Location = new System.Drawing.Point(679, 219);
            this.Pnl_Permisos.Name = "Pnl_Permisos";
            this.Pnl_Permisos.Size = new System.Drawing.Size(710, 413);
            this.Pnl_Permisos.TabIndex = 64;
            // 
            // Lbl_PermisosUsuarios
            // 
            this.Lbl_PermisosUsuarios.AutoSize = true;
            this.Lbl_PermisosUsuarios.Location = new System.Drawing.Point(9, 4);
            this.Lbl_PermisosUsuarios.Name = "Lbl_PermisosUsuarios";
            this.Lbl_PermisosUsuarios.Size = new System.Drawing.Size(51, 16);
            this.Lbl_PermisosUsuarios.TabIndex = 16;
            this.Lbl_PermisosUsuarios.Text = "Label 2";
            // 
            // Txb_BuscarPermisoRestante
            // 
            this.Txb_BuscarPermisoRestante.Location = new System.Drawing.Point(516, 216);
            this.Txb_BuscarPermisoRestante.Name = "Txb_BuscarPermisoRestante";
            this.Txb_BuscarPermisoRestante.Size = new System.Drawing.Size(100, 22);
            this.Txb_BuscarPermisoRestante.TabIndex = 36;
            this.Txb_BuscarPermisoRestante.TextChanged += new System.EventHandler(this.Txb_BuscarPermisoRestante_TextChanged);
            // 
            // Txb_BuscarPermisoActual
            // 
            this.Txb_BuscarPermisoActual.Location = new System.Drawing.Point(94, 215);
            this.Txb_BuscarPermisoActual.Name = "Txb_BuscarPermisoActual";
            this.Txb_BuscarPermisoActual.Size = new System.Drawing.Size(100, 22);
            this.Txb_BuscarPermisoActual.TabIndex = 35;
            this.Txb_BuscarPermisoActual.TextChanged += new System.EventHandler(this.Txb_BuscarPermisoActual_TextChanged);
            // 
            // Rbt_Grupo
            // 
            this.Rbt_Grupo.AutoSize = true;
            this.Rbt_Grupo.Location = new System.Drawing.Point(398, 9);
            this.Rbt_Grupo.Name = "Rbt_Grupo";
            this.Rbt_Grupo.Size = new System.Drawing.Size(65, 20);
            this.Rbt_Grupo.TabIndex = 34;
            this.Rbt_Grupo.TabStop = true;
            this.Rbt_Grupo.Text = "Grupo";
            this.Rbt_Grupo.UseVisualStyleBackColor = true;
            this.Rbt_Grupo.CheckedChanged += new System.EventHandler(this.Rbt_Grupo_CheckedChanged);
            // 
            // Rbt_Usuario
            // 
            this.Rbt_Usuario.AutoSize = true;
            this.Rbt_Usuario.Location = new System.Drawing.Point(276, 9);
            this.Rbt_Usuario.Name = "Rbt_Usuario";
            this.Rbt_Usuario.Size = new System.Drawing.Size(75, 20);
            this.Rbt_Usuario.TabIndex = 33;
            this.Rbt_Usuario.TabStop = true;
            this.Rbt_Usuario.Text = "Usuario";
            this.Rbt_Usuario.UseVisualStyleBackColor = true;
            this.Rbt_Usuario.CheckedChanged += new System.EventHandler(this.Rbt_Usuario_CheckedChanged);
            // 
            // Btn_Funcion
            // 
            this.Btn_Funcion.Location = new System.Drawing.Point(329, 315);
            this.Btn_Funcion.Name = "Btn_Funcion";
            this.Btn_Funcion.Size = new System.Drawing.Size(75, 26);
            this.Btn_Funcion.TabIndex = 32;
            this.Btn_Funcion.Text = "funcion";
            this.Btn_Funcion.UseVisualStyleBackColor = true;
            this.Btn_Funcion.Click += new System.EventHandler(this.Btn_Funcion_Click);
            // 
            // DTGV_FamiliaUsuario
            // 
            this.DTGV_FamiliaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_FamiliaUsuario.Location = new System.Drawing.Point(256, 35);
            this.DTGV_FamiliaUsuario.Name = "DTGV_FamiliaUsuario";
            this.DTGV_FamiliaUsuario.RowHeadersWidth = 51;
            this.DTGV_FamiliaUsuario.RowTemplate.Height = 24;
            this.DTGV_FamiliaUsuario.Size = new System.Drawing.Size(226, 152);
            this.DTGV_FamiliaUsuario.TabIndex = 29;
            this.DTGV_FamiliaUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_FamiliaUsuario_CellClick);
            // 
            // DTGV_PermisosRestantes
            // 
            this.DTGV_PermisosRestantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_PermisosRestantes.Location = new System.Drawing.Point(449, 244);
            this.DTGV_PermisosRestantes.Name = "DTGV_PermisosRestantes";
            this.DTGV_PermisosRestantes.RowHeadersWidth = 51;
            this.DTGV_PermisosRestantes.RowTemplate.Height = 24;
            this.DTGV_PermisosRestantes.Size = new System.Drawing.Size(245, 152);
            this.DTGV_PermisosRestantes.TabIndex = 31;
            this.DTGV_PermisosRestantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_PermisosRestantes_CellClick);
            // 
            // DTGV_PermisosActuales
            // 
            this.DTGV_PermisosActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_PermisosActuales.Location = new System.Drawing.Point(24, 244);
            this.DTGV_PermisosActuales.Name = "DTGV_PermisosActuales";
            this.DTGV_PermisosActuales.RowHeadersWidth = 51;
            this.DTGV_PermisosActuales.RowTemplate.Height = 24;
            this.DTGV_PermisosActuales.Size = new System.Drawing.Size(245, 152);
            this.DTGV_PermisosActuales.TabIndex = 30;
            this.DTGV_PermisosActuales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_PermisosActuales_CellClick);
            // 
            // Pnl_Backup
            // 
            this.Pnl_Backup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Backup.Controls.Add(this.Btn_RestaurarBDD);
            this.Pnl_Backup.Controls.Add(this.DTGV_BackUp);
            this.Pnl_Backup.Controls.Add(this.Lbl_BackUp);
            this.Pnl_Backup.Location = new System.Drawing.Point(678, 17);
            this.Pnl_Backup.Name = "Pnl_Backup";
            this.Pnl_Backup.Size = new System.Drawing.Size(710, 181);
            this.Pnl_Backup.TabIndex = 65;
            // 
            // Btn_RestaurarBDD
            // 
            this.Btn_RestaurarBDD.Location = new System.Drawing.Point(562, 55);
            this.Btn_RestaurarBDD.Name = "Btn_RestaurarBDD";
            this.Btn_RestaurarBDD.Size = new System.Drawing.Size(133, 58);
            this.Btn_RestaurarBDD.TabIndex = 17;
            this.Btn_RestaurarBDD.Text = "button1";
            this.Btn_RestaurarBDD.UseVisualStyleBackColor = true;
            this.Btn_RestaurarBDD.Click += new System.EventHandler(this.Btn_RestaurarBDD_Click);
            // 
            // DTGV_BackUp
            // 
            this.DTGV_BackUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV_BackUp.Location = new System.Drawing.Point(170, 22);
            this.DTGV_BackUp.Name = "DTGV_BackUp";
            this.DTGV_BackUp.RowHeadersWidth = 51;
            this.DTGV_BackUp.RowTemplate.Height = 24;
            this.DTGV_BackUp.Size = new System.Drawing.Size(376, 139);
            this.DTGV_BackUp.TabIndex = 16;
            // 
            // Lbl_BackUp
            // 
            this.Lbl_BackUp.AutoSize = true;
            this.Lbl_BackUp.Location = new System.Drawing.Point(10, 5);
            this.Lbl_BackUp.Name = "Lbl_BackUp";
            this.Lbl_BackUp.Size = new System.Drawing.Size(44, 16);
            this.Lbl_BackUp.TabIndex = 15;
            this.Lbl_BackUp.Text = "label1";
            // 
            // CV_ModulodeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1429, 719);
            this.Controls.Add(this.Pnl_Backup);
            this.Controls.Add(this.Pnl_Permisos);
            this.Controls.Add(this.Pnl_ConfPass);
            this.Controls.Add(this.Pnl_Bitacora);
            this.Controls.Add(this.Btn_Guardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CV_ModulodeSeguridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de seguridad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CV_Configuracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_CantidadIntentosFallidos)).EndInit();
            this.Pnl_Bitacora.ResumeLayout(false);
            this.Pnl_Bitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_Bitacora)).EndInit();
            this.Pnl_ConfPass.ResumeLayout(false);
            this.Pnl_ConfPass.PerformLayout();
            this.Pnl_Permisos.ResumeLayout(false);
            this.Pnl_Permisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_FamiliaUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosRestantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_PermisosActuales)).EndInit();
            this.Pnl_Backup.ResumeLayout(false);
            this.Pnl_Backup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV_BackUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox Chb_MinCaracteres;
        private System.Windows.Forms.CheckBox Chb_MayMin;
        private System.Windows.Forms.CheckBox Chb_CaracEspec;
        private System.Windows.Forms.CheckBox Chb_DatosPersonales;
        private System.Windows.Forms.CheckBox Chb_NumYLetras;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.CheckBox Chb_RepetirPass;
        private System.Windows.Forms.Label Lbl_CantIntentosFallidos;
        private System.Windows.Forms.NumericUpDown Nud_CantidadIntentosFallidos;
        private System.Windows.Forms.Panel Pnl_Bitacora;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.TextBox Txb_UserName;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.Label Lbl_Hasta;
        private System.Windows.Forms.Label Lbl_Desde;
        private System.Windows.Forms.Button Btn_VerTodo;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.ComboBox Cmb_Tipo;
        private System.Windows.Forms.DateTimePicker Dtp_Hasta;
        private System.Windows.Forms.DateTimePicker Dtp_Desde;
        private System.Windows.Forms.DataGridView DTGV_Bitacora;
        private System.Windows.Forms.Panel Pnl_ConfPass;
        private System.Windows.Forms.Label Lbl_Bitacora;
        private System.Windows.Forms.Label Lbl_ConfigPass;
        private System.Windows.Forms.Panel Pnl_Permisos;
        private System.Windows.Forms.TextBox Txb_BuscarPermisoRestante;
        private System.Windows.Forms.TextBox Txb_BuscarPermisoActual;
        private System.Windows.Forms.RadioButton Rbt_Grupo;
        private System.Windows.Forms.RadioButton Rbt_Usuario;
        private System.Windows.Forms.Button Btn_Funcion;
        private System.Windows.Forms.DataGridView DTGV_FamiliaUsuario;
        private System.Windows.Forms.DataGridView DTGV_PermisosRestantes;
        private System.Windows.Forms.DataGridView DTGV_PermisosActuales;
        private System.Windows.Forms.Label Lbl_PermisosUsuarios;
        private System.Windows.Forms.Panel Pnl_Backup;
        private System.Windows.Forms.Label Lbl_BackUp;
        private System.Windows.Forms.DataGridView DTGV_BackUp;
        private System.Windows.Forms.Button Btn_RestaurarBDD;
    }
}