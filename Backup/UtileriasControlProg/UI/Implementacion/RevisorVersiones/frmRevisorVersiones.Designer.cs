namespace UtileriasControlProg.UI.Implementacion
{
    partial class frmRevisorVersiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRevisorVersiones));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMD5 = new System.Windows.Forms.TextBox();
            this.dgBusquedaPorArchivos = new System.Windows.Forms.DataGridView();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.lblTotalArchivosFiltros = new System.Windows.Forms.Label();
            this.rdTPorArchivo = new System.Windows.Forms.RadioButton();
            this.rdTPorDirectorio = new System.Windows.Forms.RadioButton();
            this.txtRutaPrincipal = new System.Windows.Forms.TextBox();
            this.txtTiendasExcepcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTiendas = new System.Windows.Forms.Label();
            this.txtTiendas = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rDTodasLasTiendas = new System.Windows.Forms.RadioButton();
            this.rdFiltroPorIP = new System.Windows.Forms.RadioButton();
            this.rdPorRangoTiendas = new System.Windows.Forms.RadioButton();
            this.rdPorTiendas = new System.Windows.Forms.RadioButton();
            this.rdPorTienda = new System.Windows.Forms.RadioButton();
            this.lblGenerandoArchivosAConsultar = new System.Windows.Forms.Label();
            this.pgbArchivosServidor = new System.Windows.Forms.ProgressBar();
            this.lblTotalTiendasRevisadas = new System.Windows.Forms.Label();
            this.btnDetalleArchivosBase = new System.Windows.Forms.Button();
            this.lblTotalTiendas = new System.Windows.Forms.Label();
            this.lblTotalArchivos = new System.Windows.Forms.Label();
            this.btnIniciarEjecucion = new System.Windows.Forms.Button();
            this.lblServidorPrincipal = new System.Windows.Forms.Label();
            this.btnConfigurarServer = new System.Windows.Forms.Button();
            this.pgArchivosPorTienda = new System.Windows.Forms.ProgressBar();
            this.dataGridResultadoTiendas = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdResModulosDesactualizados = new System.Windows.Forms.RadioButton();
            this.rdResTodasLasTiendas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKillHilo = new System.Windows.Forms.Button();
            this.btnEnviarTodo = new System.Windows.Forms.Button();
            this.pgEnviarTodo = new System.Windows.Forms.ProgressBar();
            this.lblEnvioTodasTiendas = new System.Windows.Forms.Label();
            this.chkProduccion = new System.Windows.Forms.CheckBox();
            this.chkSoporte = new System.Windows.Forms.CheckBox();
            this.lblTotalRev = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBusquedaPorArchivos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResultadoTiendas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIPServer);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtTiendasExcepcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTiendas);
            this.groupBox1.Controls.Add(this.txtTiendas);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1245, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(151, 33);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(221, 20);
            this.txtIPServer.TabIndex = 10;
            this.txtIPServer.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMD5);
            this.groupBox2.Controls.Add(this.dgBusquedaPorArchivos);
            this.groupBox2.Controls.Add(this.btnAddFile);
            this.groupBox2.Controls.Add(this.lblTotalArchivosFiltros);
            this.groupBox2.Controls.Add(this.rdTPorArchivo);
            this.groupBox2.Controls.Add(this.rdTPorDirectorio);
            this.groupBox2.Controls.Add(this.txtRutaPrincipal);
            this.groupBox2.Location = new System.Drawing.Point(616, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 151);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de busqueda";
            // 
            // txtMD5
            // 
            this.txtMD5.Enabled = false;
            this.txtMD5.Location = new System.Drawing.Point(6, 70);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.Size = new System.Drawing.Size(207, 20);
            this.txtMD5.TabIndex = 18;
            this.txtMD5.Text = "MD5 MANUAL";
            this.txtMD5.Visible = false;
            this.txtMD5.Click += new System.EventHandler(this.txtMD5_Click);
            // 
            // dgBusquedaPorArchivos
            // 
            this.dgBusquedaPorArchivos.AllowUserToAddRows = false;
            this.dgBusquedaPorArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBusquedaPorArchivos.Location = new System.Drawing.Point(219, 15);
            this.dgBusquedaPorArchivos.Name = "dgBusquedaPorArchivos";
            this.dgBusquedaPorArchivos.ReadOnly = true;
            this.dgBusquedaPorArchivos.Size = new System.Drawing.Size(377, 127);
            this.dgBusquedaPorArchivos.TabIndex = 17;
            this.dgBusquedaPorArchivos.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgBusquedaPorArchivos_UserDeletedRow);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Enabled = false;
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.Location = new System.Drawing.Point(6, 96);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(53, 46);
            this.btnAddFile.TabIndex = 16;
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Visible = false;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // lblTotalArchivosFiltros
            // 
            this.lblTotalArchivosFiltros.AutoSize = true;
            this.lblTotalArchivosFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchivosFiltros.ForeColor = System.Drawing.Color.Black;
            this.lblTotalArchivosFiltros.Location = new System.Drawing.Point(65, 111);
            this.lblTotalArchivosFiltros.Name = "lblTotalArchivosFiltros";
            this.lblTotalArchivosFiltros.Size = new System.Drawing.Size(100, 16);
            this.lblTotalArchivosFiltros.TabIndex = 15;
            this.lblTotalArchivosFiltros.Text = "Total Archivos: ";
            this.lblTotalArchivosFiltros.Visible = false;
            // 
            // rdTPorArchivo
            // 
            this.rdTPorArchivo.AutoSize = true;
            this.rdTPorArchivo.Location = new System.Drawing.Point(99, 20);
            this.rdTPorArchivo.Name = "rdTPorArchivo";
            this.rdTPorArchivo.Size = new System.Drawing.Size(79, 17);
            this.rdTPorArchivo.TabIndex = 9;
            this.rdTPorArchivo.Text = "Por archivo";
            this.rdTPorArchivo.UseVisualStyleBackColor = true;
            this.rdTPorArchivo.Click += new System.EventHandler(this.rdTPorArchivo_Click);
            // 
            // rdTPorDirectorio
            // 
            this.rdTPorDirectorio.AutoSize = true;
            this.rdTPorDirectorio.Checked = true;
            this.rdTPorDirectorio.Location = new System.Drawing.Point(6, 20);
            this.rdTPorDirectorio.Name = "rdTPorDirectorio";
            this.rdTPorDirectorio.Size = new System.Drawing.Size(87, 17);
            this.rdTPorDirectorio.TabIndex = 8;
            this.rdTPorDirectorio.TabStop = true;
            this.rdTPorDirectorio.Text = "Por directorio";
            this.rdTPorDirectorio.UseVisualStyleBackColor = true;
            this.rdTPorDirectorio.Click += new System.EventHandler(this.rdTPorDirectorio_Click);
            // 
            // txtRutaPrincipal
            // 
            this.txtRutaPrincipal.Location = new System.Drawing.Point(6, 43);
            this.txtRutaPrincipal.Name = "txtRutaPrincipal";
            this.txtRutaPrincipal.Size = new System.Drawing.Size(207, 20);
            this.txtRutaPrincipal.TabIndex = 7;
            this.txtRutaPrincipal.Text = "/sysx/progs/progx/";
            // 
            // txtTiendasExcepcion
            // 
            this.txtTiendasExcepcion.Location = new System.Drawing.Point(389, 35);
            this.txtTiendasExcepcion.Multiline = true;
            this.txtTiendasExcepcion.Name = "txtTiendasExcepcion";
            this.txtTiendasExcepcion.Size = new System.Drawing.Size(221, 85);
            this.txtTiendasExcepcion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agregar Excepciones separado por (,)";
            // 
            // lblTiendas
            // 
            this.lblTiendas.AutoSize = true;
            this.lblTiendas.Location = new System.Drawing.Point(151, 16);
            this.lblTiendas.Name = "lblTiendas";
            this.lblTiendas.Size = new System.Drawing.Size(138, 13);
            this.lblTiendas.TabIndex = 1;
            this.lblTiendas.Text = "Ingresa el numero de tienda";
            // 
            // txtTiendas
            // 
            this.txtTiendas.Location = new System.Drawing.Point(151, 34);
            this.txtTiendas.Multiline = true;
            this.txtTiendas.Name = "txtTiendas";
            this.txtTiendas.Size = new System.Drawing.Size(221, 86);
            this.txtTiendas.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rDTodasLasTiendas);
            this.panel1.Controls.Add(this.rdFiltroPorIP);
            this.panel1.Controls.Add(this.rdPorRangoTiendas);
            this.panel1.Controls.Add(this.rdPorTiendas);
            this.panel1.Controls.Add(this.rdPorTienda);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 139);
            this.panel1.TabIndex = 0;
            // 
            // rDTodasLasTiendas
            // 
            this.rDTodasLasTiendas.AutoSize = true;
            this.rDTodasLasTiendas.Location = new System.Drawing.Point(3, 84);
            this.rDTodasLasTiendas.Name = "rDTodasLasTiendas";
            this.rDTodasLasTiendas.Size = new System.Drawing.Size(108, 17);
            this.rDTodasLasTiendas.TabIndex = 4;
            this.rDTodasLasTiendas.TabStop = true;
            this.rDTodasLasTiendas.Text = "Todas las tiendas";
            this.rDTodasLasTiendas.UseVisualStyleBackColor = true;
            this.rDTodasLasTiendas.CheckedChanged += new System.EventHandler(this.rDTodasLasTiendas_CheckedChanged);
            // 
            // rdFiltroPorIP
            // 
            this.rdFiltroPorIP.AutoSize = true;
            this.rdFiltroPorIP.Location = new System.Drawing.Point(3, 107);
            this.rdFiltroPorIP.Name = "rdFiltroPorIP";
            this.rdFiltroPorIP.Size = new System.Drawing.Size(52, 17);
            this.rdFiltroPorIP.TabIndex = 3;
            this.rdFiltroPorIP.Text = "Por ip";
            this.rdFiltroPorIP.UseVisualStyleBackColor = true;
            this.rdFiltroPorIP.CheckedChanged += new System.EventHandler(this.rdFiltroPorIP_CheckedChanged);
            // 
            // rdPorRangoTiendas
            // 
            this.rdPorRangoTiendas.AutoSize = true;
            this.rdPorRangoTiendas.Location = new System.Drawing.Point(3, 61);
            this.rdPorRangoTiendas.Name = "rdPorRangoTiendas";
            this.rdPorRangoTiendas.Size = new System.Drawing.Size(103, 17);
            this.rdPorRangoTiendas.TabIndex = 2;
            this.rdPorRangoTiendas.Text = "Por Rango [300]";
            this.rdPorRangoTiendas.UseVisualStyleBackColor = true;
            this.rdPorRangoTiendas.CheckedChanged += new System.EventHandler(this.rdPorRangoTiendas_CheckedChanged);
            // 
            // rdPorTiendas
            // 
            this.rdPorTiendas.AutoSize = true;
            this.rdPorTiendas.Location = new System.Drawing.Point(3, 38);
            this.rdPorTiendas.Name = "rdPorTiendas";
            this.rdPorTiendas.Size = new System.Drawing.Size(82, 17);
            this.rdPorTiendas.TabIndex = 1;
            this.rdPorTiendas.Text = "Por Tiendas";
            this.rdPorTiendas.UseVisualStyleBackColor = true;
            this.rdPorTiendas.CheckedChanged += new System.EventHandler(this.rdPorTiendas_CheckedChanged);
            // 
            // rdPorTienda
            // 
            this.rdPorTienda.AutoSize = true;
            this.rdPorTienda.Checked = true;
            this.rdPorTienda.Location = new System.Drawing.Point(3, 15);
            this.rdPorTienda.Name = "rdPorTienda";
            this.rdPorTienda.Size = new System.Drawing.Size(77, 17);
            this.rdPorTienda.TabIndex = 0;
            this.rdPorTienda.TabStop = true;
            this.rdPorTienda.Text = "Por Tienda";
            this.rdPorTienda.UseVisualStyleBackColor = true;
            this.rdPorTienda.CheckedChanged += new System.EventHandler(this.rdPorTienda_CheckedChanged);
            // 
            // lblGenerandoArchivosAConsultar
            // 
            this.lblGenerandoArchivosAConsultar.AutoSize = true;
            this.lblGenerandoArchivosAConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerandoArchivosAConsultar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblGenerandoArchivosAConsultar.Location = new System.Drawing.Point(351, 239);
            this.lblGenerandoArchivosAConsultar.Name = "lblGenerandoArchivosAConsultar";
            this.lblGenerandoArchivosAConsultar.Size = new System.Drawing.Size(535, 24);
            this.lblGenerandoArchivosAConsultar.TabIndex = 14;
            this.lblGenerandoArchivosAConsultar.Text = "Obteniendo información del directorio espere porfavor...";
            this.lblGenerandoArchivosAConsultar.Visible = false;
            // 
            // pgbArchivosServidor
            // 
            this.pgbArchivosServidor.Location = new System.Drawing.Point(77, 266);
            this.pgbArchivosServidor.Name = "pgbArchivosServidor";
            this.pgbArchivosServidor.Size = new System.Drawing.Size(1174, 23);
            this.pgbArchivosServidor.TabIndex = 12;
            // 
            // lblTotalTiendasRevisadas
            // 
            this.lblTotalTiendasRevisadas.AutoSize = true;
            this.lblTotalTiendasRevisadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTiendasRevisadas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalTiendasRevisadas.Location = new System.Drawing.Point(723, 300);
            this.lblTotalTiendasRevisadas.Name = "lblTotalTiendasRevisadas";
            this.lblTotalTiendasRevisadas.Size = new System.Drawing.Size(191, 24);
            this.lblTotalTiendasRevisadas.TabIndex = 13;
            this.lblTotalTiendasRevisadas.Text = "Total Tiendas Rev: ";
            // 
            // btnDetalleArchivosBase
            // 
            this.btnDetalleArchivosBase.Enabled = false;
            this.btnDetalleArchivosBase.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleArchivosBase.Image")));
            this.btnDetalleArchivosBase.Location = new System.Drawing.Point(290, 294);
            this.btnDetalleArchivosBase.Name = "btnDetalleArchivosBase";
            this.btnDetalleArchivosBase.Size = new System.Drawing.Size(40, 37);
            this.btnDetalleArchivosBase.TabIndex = 12;
            this.btnDetalleArchivosBase.UseVisualStyleBackColor = true;
            this.btnDetalleArchivosBase.Click += new System.EventHandler(this.btnDetalleArchivosBase_Click);
            // 
            // lblTotalTiendas
            // 
            this.lblTotalTiendas.AutoSize = true;
            this.lblTotalTiendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTiendas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalTiendas.Location = new System.Drawing.Point(492, 300);
            this.lblTotalTiendas.Name = "lblTotalTiendas";
            this.lblTotalTiendas.Size = new System.Drawing.Size(149, 24);
            this.lblTotalTiendas.TabIndex = 11;
            this.lblTotalTiendas.Text = "Total Tiendas: ";
            // 
            // lblTotalArchivos
            // 
            this.lblTotalArchivos.AutoSize = true;
            this.lblTotalArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchivos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalArchivos.Location = new System.Drawing.Point(73, 300);
            this.lblTotalArchivos.Name = "lblTotalArchivos";
            this.lblTotalArchivos.Size = new System.Drawing.Size(155, 24);
            this.lblTotalArchivos.TabIndex = 10;
            this.lblTotalArchivos.Text = "Total Archivos: ";
            // 
            // btnIniciarEjecucion
            // 
            this.btnIniciarEjecucion.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarEjecucion.Image")));
            this.btnIniciarEjecucion.Location = new System.Drawing.Point(18, 265);
            this.btnIniciarEjecucion.Name = "btnIniciarEjecucion";
            this.btnIniciarEjecucion.Size = new System.Drawing.Size(53, 46);
            this.btnIniciarEjecucion.TabIndex = 4;
            this.btnIniciarEjecucion.UseVisualStyleBackColor = true;
            this.btnIniciarEjecucion.Click += new System.EventHandler(this.btnIniciarEjecucion_Click);
            // 
            // lblServidorPrincipal
            // 
            this.lblServidorPrincipal.AutoSize = true;
            this.lblServidorPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidorPrincipal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblServidorPrincipal.Location = new System.Drawing.Point(77, 20);
            this.lblServidorPrincipal.Name = "lblServidorPrincipal";
            this.lblServidorPrincipal.Size = new System.Drawing.Size(187, 24);
            this.lblServidorPrincipal.TabIndex = 8;
            this.lblServidorPrincipal.Text = "Servidor Principal: ";
            // 
            // btnConfigurarServer
            // 
            this.btnConfigurarServer.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigurarServer.Image")));
            this.btnConfigurarServer.Location = new System.Drawing.Point(18, 9);
            this.btnConfigurarServer.Name = "btnConfigurarServer";
            this.btnConfigurarServer.Size = new System.Drawing.Size(53, 50);
            this.btnConfigurarServer.TabIndex = 9;
            this.btnConfigurarServer.UseVisualStyleBackColor = true;
            this.btnConfigurarServer.Click += new System.EventHandler(this.btnConfigurarServer_Click);
            // 
            // pgArchivosPorTienda
            // 
            this.pgArchivosPorTienda.Location = new System.Drawing.Point(18, 339);
            this.pgArchivosPorTienda.Name = "pgArchivosPorTienda";
            this.pgArchivosPorTienda.Size = new System.Drawing.Size(1233, 23);
            this.pgArchivosPorTienda.TabIndex = 10;
            // 
            // dataGridResultadoTiendas
            // 
            this.dataGridResultadoTiendas.AllowUserToAddRows = false;
            this.dataGridResultadoTiendas.AllowUserToDeleteRows = false;
            this.dataGridResultadoTiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResultadoTiendas.Location = new System.Drawing.Point(18, 414);
            this.dataGridResultadoTiendas.Name = "dataGridResultadoTiendas";
            this.dataGridResultadoTiendas.ReadOnly = true;
            this.dataGridResultadoTiendas.Size = new System.Drawing.Size(1233, 405);
            this.dataGridResultadoTiendas.TabIndex = 11;
            this.dataGridResultadoTiendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResultadoTiendas_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdResModulosDesactualizados);
            this.groupBox3.Controls.Add(this.rdResTodasLasTiendas);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(18, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1231, 40);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar Resultados";
            // 
            // rdResModulosDesactualizados
            // 
            this.rdResModulosDesactualizados.AutoSize = true;
            this.rdResModulosDesactualizados.Location = new System.Drawing.Point(120, 17);
            this.rdResModulosDesactualizados.Name = "rdResModulosDesactualizados";
            this.rdResModulosDesactualizados.Size = new System.Drawing.Size(138, 17);
            this.rdResModulosDesactualizados.TabIndex = 2;
            this.rdResModulosDesactualizados.Text = "Tiendas con diferencias";
            this.rdResModulosDesactualizados.UseVisualStyleBackColor = true;
            this.rdResModulosDesactualizados.Click += new System.EventHandler(this.rdResModulosDesactualizados_Click);
            // 
            // rdResTodasLasTiendas
            // 
            this.rdResTodasLasTiendas.AutoSize = true;
            this.rdResTodasLasTiendas.Checked = true;
            this.rdResTodasLasTiendas.Location = new System.Drawing.Point(6, 17);
            this.rdResTodasLasTiendas.Name = "rdResTodasLasTiendas";
            this.rdResTodasLasTiendas.Size = new System.Drawing.Size(108, 17);
            this.rdResTodasLasTiendas.TabIndex = 0;
            this.rdResTodasLasTiendas.TabStop = true;
            this.rdResTodasLasTiendas.Text = "Todas las tiendas";
            this.rdResTodasLasTiendas.UseVisualStyleBackColor = true;
            this.rdResTodasLasTiendas.Click += new System.EventHandler(this.rdResTodasLasTiendas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(986, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Detalle Avance";
            // 
            // btnKillHilo
            // 
            this.btnKillHilo.Enabled = false;
            this.btnKillHilo.Image = ((System.Drawing.Image)(resources.GetObject("btnKillHilo.Image")));
            this.btnKillHilo.Location = new System.Drawing.Point(1142, 296);
            this.btnKillHilo.Name = "btnKillHilo";
            this.btnKillHilo.Size = new System.Drawing.Size(40, 37);
            this.btnKillHilo.TabIndex = 17;
            this.btnKillHilo.UseVisualStyleBackColor = true;
            this.btnKillHilo.Click += new System.EventHandler(this.btnKillHilo_Click);
            // 
            // btnEnviarTodo
            // 
            this.btnEnviarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarTodo.Image")));
            this.btnEnviarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarTodo.Location = new System.Drawing.Point(12, 837);
            this.btnEnviarTodo.Name = "btnEnviarTodo";
            this.btnEnviarTodo.Size = new System.Drawing.Size(145, 48);
            this.btnEnviarTodo.TabIndex = 20;
            this.btnEnviarTodo.Text = "ENVIAR TODO";
            this.btnEnviarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviarTodo.UseVisualStyleBackColor = true;
            this.btnEnviarTodo.Visible = false;
            this.btnEnviarTodo.Click += new System.EventHandler(this.btnEnviarTodo_Click);
            // 
            // pgEnviarTodo
            // 
            this.pgEnviarTodo.Location = new System.Drawing.Point(161, 851);
            this.pgEnviarTodo.Name = "pgEnviarTodo";
            this.pgEnviarTodo.Size = new System.Drawing.Size(1088, 23);
            this.pgEnviarTodo.TabIndex = 21;
            this.pgEnviarTodo.Visible = false;
            // 
            // lblEnvioTodasTiendas
            // 
            this.lblEnvioTodasTiendas.AutoSize = true;
            this.lblEnvioTodasTiendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvioTodasTiendas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblEnvioTodasTiendas.Location = new System.Drawing.Point(409, 822);
            this.lblEnvioTodasTiendas.Name = "lblEnvioTodasTiendas";
            this.lblEnvioTodasTiendas.Size = new System.Drawing.Size(450, 24);
            this.lblEnvioTodasTiendas.TabIndex = 22;
            this.lblEnvioTodasTiendas.Text = "Preparando archivos a transmitir a las tiendas...";
            this.lblEnvioTodasTiendas.Visible = false;
            // 
            // chkProduccion
            // 
            this.chkProduccion.AutoSize = true;
            this.chkProduccion.Checked = true;
            this.chkProduccion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProduccion.Location = new System.Drawing.Point(21, 242);
            this.chkProduccion.Name = "chkProduccion";
            this.chkProduccion.Size = new System.Drawing.Size(80, 17);
            this.chkProduccion.TabIndex = 23;
            this.chkProduccion.Text = "Produccion";
            this.chkProduccion.UseVisualStyleBackColor = true;
            // 
            // chkSoporte
            // 
            this.chkSoporte.AutoSize = true;
            this.chkSoporte.Location = new System.Drawing.Point(107, 242);
            this.chkSoporte.Name = "chkSoporte";
            this.chkSoporte.Size = new System.Drawing.Size(63, 17);
            this.chkSoporte.TabIndex = 24;
            this.chkSoporte.Text = "Soporte";
            this.chkSoporte.UseVisualStyleBackColor = true;
            // 
            // lblTotalRev
            // 
            this.lblTotalRev.AutoSize = true;
            this.lblTotalRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRev.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalRev.Location = new System.Drawing.Point(331, 300);
            this.lblTotalRev.Name = "lblTotalRev";
            this.lblTotalRev.Size = new System.Drawing.Size(58, 24);
            this.lblTotalRev.TabIndex = 25;
            this.lblTotalRev.Text = "Rev: ";
            // 
            // frmRevisorVersiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 890);
            this.Controls.Add(this.lblTotalRev);
            this.Controls.Add(this.chkSoporte);
            this.Controls.Add(this.chkProduccion);
            this.Controls.Add(this.lblEnvioTodasTiendas);
            this.Controls.Add(this.pgEnviarTodo);
            this.Controls.Add(this.btnEnviarTodo);
            this.Controls.Add(this.btnKillHilo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblGenerandoArchivosAConsultar);
            this.Controls.Add(this.pgbArchivosServidor);
            this.Controls.Add(this.dataGridResultadoTiendas);
            this.Controls.Add(this.lblTotalTiendasRevisadas);
            this.Controls.Add(this.pgArchivosPorTienda);
            this.Controls.Add(this.btnDetalleArchivosBase);
            this.Controls.Add(this.btnConfigurarServer);
            this.Controls.Add(this.lblTotalTiendas);
            this.Controls.Add(this.lblServidorPrincipal);
            this.Controls.Add(this.lblTotalArchivos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIniciarEjecucion);
            this.Name = "frmRevisorVersiones";
            this.Text = "Revision de Versiones";
            this.Load += new System.EventHandler(this.frmRevisorVersiones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBusquedaPorArchivos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResultadoTiendas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdFiltroPorIP;
        private System.Windows.Forms.RadioButton rdPorRangoTiendas;
        private System.Windows.Forms.RadioButton rdPorTiendas;
        private System.Windows.Forms.RadioButton rdPorTienda;
        private System.Windows.Forms.TextBox txtTiendas;
        private System.Windows.Forms.Label lblTiendas;
        private System.Windows.Forms.TextBox txtTiendasExcepcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciarEjecucion;
        private System.Windows.Forms.Label lblServidorPrincipal;
        private System.Windows.Forms.Button btnConfigurarServer;
        private System.Windows.Forms.TextBox txtRutaPrincipal;
        private System.Windows.Forms.Button btnDetalleArchivosBase;
        private System.Windows.Forms.Label lblTotalTiendas;
        private System.Windows.Forms.Label lblTotalArchivos;
        private System.Windows.Forms.Label lblTotalTiendasRevisadas;
        private System.Windows.Forms.ProgressBar pgArchivosPorTienda;
        private System.Windows.Forms.Label lblGenerandoArchivosAConsultar;
        private System.Windows.Forms.ProgressBar pgbArchivosServidor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdTPorArchivo;
        private System.Windows.Forms.RadioButton rdTPorDirectorio;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.DataGridView dgBusquedaPorArchivos;
        private System.Windows.Forms.Label lblTotalArchivosFiltros;
        private System.Windows.Forms.DataGridView dataGridResultadoTiendas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdResModulosDesactualizados;
        private System.Windows.Forms.RadioButton rdResTodasLasTiendas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKillHilo;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.Button btnEnviarTodo;
        private System.Windows.Forms.TextBox txtMD5;
        private System.Windows.Forms.ProgressBar pgEnviarTodo;
        private System.Windows.Forms.Label lblEnvioTodasTiendas;
        private System.Windows.Forms.RadioButton rDTodasLasTiendas;
        private System.Windows.Forms.CheckBox chkProduccion;
        private System.Windows.Forms.CheckBox chkSoporte;
        private System.Windows.Forms.Label lblTotalRev;
    }
}