namespace UtileriasControlProg.UI.Implementacion.ProgramadorEnvios
{
    partial class EnviosComponentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnviosComponentes));
            this.btnExaminar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProgramarEnvio = new System.Windows.Forms.Button();
            this.lblProgramarEnvio = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotalArchivos = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtRutaDestino = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdUbicacionServidorPrincipal = new System.Windows.Forms.RadioButton();
            this.rdUbicacionLocal = new System.Windows.Forms.RadioButton();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSoporte = new System.Windows.Forms.CheckBox();
            this.chkProduccion = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdDestinoPorIp = new System.Windows.Forms.RadioButton();
            this.rdDestinoTodas = new System.Windows.Forms.RadioButton();
            this.rdDestinoUna = new System.Windows.Forms.RadioButton();
            this.rdDestinoVarias = new System.Windows.Forms.RadioButton();
            this.rdDestinoRango = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdTipoBM = new System.Windows.Forms.RadioButton();
            this.rdTipoBR = new System.Windows.Forms.RadioButton();
            this.rdTipoTienda = new System.Windows.Forms.RadioButton();
            this.txtPorIp = new System.Windows.Forms.TextBox();
            this.txtExcepciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTiendas = new System.Windows.Forms.Label();
            this.txtDestinos = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExaminar
            // 
            this.btnExaminar.Image = ((System.Drawing.Image)(resources.GetObject("btnExaminar.Image")));
            this.btnExaminar.Location = new System.Drawing.Point(268, 41);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(48, 46);
            this.btnExaminar.TabIndex = 0;
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProgramarEnvio);
            this.groupBox1.Controls.Add(this.lblProgramarEnvio);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.chkSoporte);
            this.groupBox1.Controls.Add(this.chkProduccion);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtPorIp);
            this.groupBox1.Controls.Add(this.txtExcepciones);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTiendas);
            this.groupBox1.Controls.Add(this.txtDestinos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1252, 335);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnProgramarEnvio
            // 
            this.btnProgramarEnvio.Image = ((System.Drawing.Image)(resources.GetObject("btnProgramarEnvio.Image")));
            this.btnProgramarEnvio.Location = new System.Drawing.Point(14, 264);
            this.btnProgramarEnvio.Name = "btnProgramarEnvio";
            this.btnProgramarEnvio.Size = new System.Drawing.Size(53, 46);
            this.btnProgramarEnvio.TabIndex = 5;
            this.btnProgramarEnvio.UseVisualStyleBackColor = true;
            this.btnProgramarEnvio.Click += new System.EventHandler(this.btnProgramarEnvio_Click);
            // 
            // lblProgramarEnvio
            // 
            this.lblProgramarEnvio.AutoSize = true;
            this.lblProgramarEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramarEnvio.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblProgramarEnvio.Location = new System.Drawing.Point(94, 273);
            this.lblProgramarEnvio.Name = "lblProgramarEnvio";
            this.lblProgramarEnvio.Size = new System.Drawing.Size(264, 24);
            this.lblProgramarEnvio.TabIndex = 11;
            this.lblProgramarEnvio.Text = "Programar Envio a Tiendas";
            this.lblProgramarEnvio.Click += new System.EventHandler(this.lblProgramarEnvio_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotalArchivos);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.btnAddFile);
            this.groupBox4.Controls.Add(this.txtRutaDestino);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.rdUbicacionServidorPrincipal);
            this.groupBox4.Controls.Add(this.rdUbicacionLocal);
            this.groupBox4.Controls.Add(this.txtArchivo);
            this.groupBox4.Controls.Add(this.btnExaminar);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(591, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(655, 309);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ingrese los archivos que se van a transmitir";
            // 
            // lblTotalArchivos
            // 
            this.lblTotalArchivos.AutoSize = true;
            this.lblTotalArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchivos.ForeColor = System.Drawing.Color.Black;
            this.lblTotalArchivos.Location = new System.Drawing.Point(224, 95);
            this.lblTotalArchivos.Name = "lblTotalArchivos";
            this.lblTotalArchivos.Size = new System.Drawing.Size(190, 16);
            this.lblTotalArchivos.TabIndex = 16;
            this.lblTotalArchivos.Text = "Total de Archivos Agregados: ";
            this.lblTotalArchivos.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(639, 189);
            this.dataGridView1.TabIndex = 18;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.Location = new System.Drawing.Point(580, 42);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(48, 46);
            this.btnAddFile.TabIndex = 17;
            this.btnAddFile.UseVisualStyleBackColor = true;
            // 
            // txtRutaDestino
            // 
            this.txtRutaDestino.Location = new System.Drawing.Point(322, 58);
            this.txtRutaDestino.Name = "txtRutaDestino";
            this.txtRutaDestino.Size = new System.Drawing.Size(252, 20);
            this.txtRutaDestino.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ruta Destino";
            // 
            // rdUbicacionServidorPrincipal
            // 
            this.rdUbicacionServidorPrincipal.AutoSize = true;
            this.rdUbicacionServidorPrincipal.Location = new System.Drawing.Point(147, 20);
            this.rdUbicacionServidorPrincipal.Name = "rdUbicacionServidorPrincipal";
            this.rdUbicacionServidorPrincipal.Size = new System.Drawing.Size(138, 17);
            this.rdUbicacionServidorPrincipal.TabIndex = 3;
            this.rdUbicacionServidorPrincipal.Text = "Desde servidor principal";
            this.rdUbicacionServidorPrincipal.UseVisualStyleBackColor = true;
            // 
            // rdUbicacionLocal
            // 
            this.rdUbicacionLocal.AutoSize = true;
            this.rdUbicacionLocal.Checked = true;
            this.rdUbicacionLocal.Location = new System.Drawing.Point(10, 20);
            this.rdUbicacionLocal.Name = "rdUbicacionLocal";
            this.rdUbicacionLocal.Size = new System.Drawing.Size(130, 17);
            this.rdUbicacionLocal.TabIndex = 2;
            this.rdUbicacionLocal.TabStop = true;
            this.rdUbicacionLocal.Text = "Desde ubicacion local";
            this.rdUbicacionLocal.UseVisualStyleBackColor = true;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(10, 58);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(252, 20);
            this.txtArchivo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Archivo";
            // 
            // chkSoporte
            // 
            this.chkSoporte.AutoSize = true;
            this.chkSoporte.Location = new System.Drawing.Point(399, 40);
            this.chkSoporte.Name = "chkSoporte";
            this.chkSoporte.Size = new System.Drawing.Size(63, 17);
            this.chkSoporte.TabIndex = 14;
            this.chkSoporte.Text = "Soporte";
            this.chkSoporte.UseVisualStyleBackColor = true;
            // 
            // chkProduccion
            // 
            this.chkProduccion.AutoSize = true;
            this.chkProduccion.Checked = true;
            this.chkProduccion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProduccion.Location = new System.Drawing.Point(312, 40);
            this.chkProduccion.Name = "chkProduccion";
            this.chkProduccion.Size = new System.Drawing.Size(80, 17);
            this.chkProduccion.TabIndex = 13;
            this.chkProduccion.Text = "Produccion";
            this.chkProduccion.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdDestinoPorIp);
            this.groupBox3.Controls.Add(this.rdDestinoTodas);
            this.groupBox3.Controls.Add(this.rdDestinoUna);
            this.groupBox3.Controls.Add(this.rdDestinoVarias);
            this.groupBox3.Controls.Add(this.rdDestinoRango);
            this.groupBox3.Location = new System.Drawing.Point(7, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 142);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Destino";
            // 
            // rdDestinoPorIp
            // 
            this.rdDestinoPorIp.AutoSize = true;
            this.rdDestinoPorIp.Location = new System.Drawing.Point(6, 113);
            this.rdDestinoPorIp.Name = "rdDestinoPorIp";
            this.rdDestinoPorIp.Size = new System.Drawing.Size(52, 17);
            this.rdDestinoPorIp.TabIndex = 3;
            this.rdDestinoPorIp.Text = "Por ip";
            this.rdDestinoPorIp.UseVisualStyleBackColor = true;
            this.rdDestinoPorIp.CheckedChanged += new System.EventHandler(this.rdDestinoPorIp_CheckedChanged);
            // 
            // rdDestinoTodas
            // 
            this.rdDestinoTodas.AutoSize = true;
            this.rdDestinoTodas.Location = new System.Drawing.Point(6, 90);
            this.rdDestinoTodas.Name = "rdDestinoTodas";
            this.rdDestinoTodas.Size = new System.Drawing.Size(112, 17);
            this.rdDestinoTodas.TabIndex = 4;
            this.rdDestinoTodas.TabStop = true;
            this.rdDestinoTodas.Text = "Todas las Tiendas";
            this.rdDestinoTodas.UseVisualStyleBackColor = true;
            this.rdDestinoTodas.CheckedChanged += new System.EventHandler(this.rdDestinoTodas_CheckedChanged);
            // 
            // rdDestinoUna
            // 
            this.rdDestinoUna.AutoSize = true;
            this.rdDestinoUna.Checked = true;
            this.rdDestinoUna.Location = new System.Drawing.Point(6, 20);
            this.rdDestinoUna.Name = "rdDestinoUna";
            this.rdDestinoUna.Size = new System.Drawing.Size(77, 17);
            this.rdDestinoUna.TabIndex = 0;
            this.rdDestinoUna.TabStop = true;
            this.rdDestinoUna.Text = "Por Tienda";
            this.rdDestinoUna.UseVisualStyleBackColor = true;
            this.rdDestinoUna.CheckedChanged += new System.EventHandler(this.rdDestinoUna_CheckedChanged);
            // 
            // rdDestinoVarias
            // 
            this.rdDestinoVarias.AutoSize = true;
            this.rdDestinoVarias.Location = new System.Drawing.Point(6, 43);
            this.rdDestinoVarias.Name = "rdDestinoVarias";
            this.rdDestinoVarias.Size = new System.Drawing.Size(82, 17);
            this.rdDestinoVarias.TabIndex = 1;
            this.rdDestinoVarias.Text = "Por Tiendas";
            this.rdDestinoVarias.UseVisualStyleBackColor = true;
            this.rdDestinoVarias.CheckedChanged += new System.EventHandler(this.rdDestinoVarias_CheckedChanged);
            // 
            // rdDestinoRango
            // 
            this.rdDestinoRango.AutoSize = true;
            this.rdDestinoRango.Location = new System.Drawing.Point(6, 67);
            this.rdDestinoRango.Name = "rdDestinoRango";
            this.rdDestinoRango.Size = new System.Drawing.Size(103, 17);
            this.rdDestinoRango.TabIndex = 2;
            this.rdDestinoRango.Text = "Por Rango [300]";
            this.rdDestinoRango.UseVisualStyleBackColor = true;
            this.rdDestinoRango.CheckedChanged += new System.EventHandler(this.rdDestinoRango_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdTipoBM);
            this.groupBox2.Controls.Add(this.rdTipoBR);
            this.groupBox2.Controls.Add(this.rdTipoTienda);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 41);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de envio";
            // 
            // rdTipoBM
            // 
            this.rdTipoBM.AutoSize = true;
            this.rdTipoBM.Location = new System.Drawing.Point(173, 21);
            this.rdTipoBM.Name = "rdTipoBM";
            this.rdTipoBM.Size = new System.Drawing.Size(105, 17);
            this.rdTipoBM.TabIndex = 2;
            this.rdTipoBM.Text = "Bodega Muebles";
            this.rdTipoBM.UseVisualStyleBackColor = true;
            this.rdTipoBM.CheckedChanged += new System.EventHandler(this.rdTipoBM_CheckedChanged);
            // 
            // rdTipoBR
            // 
            this.rdTipoBR.AutoSize = true;
            this.rdTipoBR.Location = new System.Drawing.Point(76, 21);
            this.rdTipoBR.Name = "rdTipoBR";
            this.rdTipoBR.Size = new System.Drawing.Size(91, 17);
            this.rdTipoBR.TabIndex = 1;
            this.rdTipoBR.Text = "Bodega Ropa";
            this.rdTipoBR.UseVisualStyleBackColor = true;
            this.rdTipoBR.CheckedChanged += new System.EventHandler(this.rdTipoBR_CheckedChanged);
            // 
            // rdTipoTienda
            // 
            this.rdTipoTienda.AutoSize = true;
            this.rdTipoTienda.Checked = true;
            this.rdTipoTienda.Location = new System.Drawing.Point(7, 20);
            this.rdTipoTienda.Name = "rdTipoTienda";
            this.rdTipoTienda.Size = new System.Drawing.Size(63, 17);
            this.rdTipoTienda.TabIndex = 0;
            this.rdTipoTienda.TabStop = true;
            this.rdTipoTienda.Text = "Tiendas";
            this.rdTipoTienda.UseVisualStyleBackColor = true;
            this.rdTipoTienda.CheckedChanged += new System.EventHandler(this.rdTipoTienda_CheckedChanged);
            // 
            // txtPorIp
            // 
            this.txtPorIp.Location = new System.Drawing.Point(137, 87);
            this.txtPorIp.Name = "txtPorIp";
            this.txtPorIp.Size = new System.Drawing.Size(221, 20);
            this.txtPorIp.TabIndex = 10;
            this.txtPorIp.Visible = false;
            // 
            // txtExcepciones
            // 
            this.txtExcepciones.Location = new System.Drawing.Point(364, 86);
            this.txtExcepciones.Multiline = true;
            this.txtExcepciones.Name = "txtExcepciones";
            this.txtExcepciones.Size = new System.Drawing.Size(221, 123);
            this.txtExcepciones.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agregar Excepciones separado por (,)";
            // 
            // lblTiendas
            // 
            this.lblTiendas.AutoSize = true;
            this.lblTiendas.Location = new System.Drawing.Point(134, 67);
            this.lblTiendas.Name = "lblTiendas";
            this.lblTiendas.Size = new System.Drawing.Size(91, 13);
            this.lblTiendas.TabIndex = 1;
            this.lblTiendas.Text = "Ingresa el numero";
            // 
            // txtDestinos
            // 
            this.txtDestinos.Location = new System.Drawing.Point(137, 86);
            this.txtDestinos.Multiline = true;
            this.txtDestinos.Name = "txtDestinos";
            this.txtDestinos.Size = new System.Drawing.Size(221, 123);
            this.txtDestinos.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView2);
            this.groupBox5.Location = new System.Drawing.Point(12, 371);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1252, 409);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle de envios programados";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(14, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1232, 384);
            this.dataGridView2.TabIndex = 0;
            // 
            // EnviosComponentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 890);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "EnviosComponentes";
            this.Text = "Envio de componentes";
            this.Load += new System.EventHandler(this.EnviosComponentes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPorIp;
        private System.Windows.Forms.TextBox txtExcepciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTiendas;
        private System.Windows.Forms.TextBox txtDestinos;
        private System.Windows.Forms.RadioButton rdDestinoTodas;
        private System.Windows.Forms.RadioButton rdDestinoPorIp;
        private System.Windows.Forms.RadioButton rdDestinoRango;
        private System.Windows.Forms.RadioButton rdDestinoVarias;
        private System.Windows.Forms.RadioButton rdDestinoUna;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdTipoBM;
        private System.Windows.Forms.RadioButton rdTipoBR;
        private System.Windows.Forms.RadioButton rdTipoTienda;
        private System.Windows.Forms.CheckBox chkProduccion;
        private System.Windows.Forms.CheckBox chkSoporte;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdUbicacionLocal;
        private System.Windows.Forms.TextBox txtRutaDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdUbicacionServidorPrincipal;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalArchivos;
        private System.Windows.Forms.Label lblProgramarEnvio;
        private System.Windows.Forms.Button btnProgramarEnvio;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}