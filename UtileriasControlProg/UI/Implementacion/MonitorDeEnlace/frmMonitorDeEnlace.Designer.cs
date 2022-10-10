namespace UtileriasControlProg.UI.Implementacion.MonitorDeEnlace
{
    partial class frmMonitorDeEnlace
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitorDeEnlace));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSoporte = new System.Windows.Forms.CheckBox();
            this.chkProduccion = new System.Windows.Forms.CheckBox();
            this.btnIniciarEjecucion = new System.Windows.Forms.Button();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.txtTiendasExcepcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTiendas = new System.Windows.Forms.Label();
            this.txtTiendas = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdFiltroPorIP = new System.Windows.Forms.RadioButton();
            this.rdPorRangoTiendas = new System.Windows.Forms.RadioButton();
            this.rdPorTiendas = new System.Windows.Forms.RadioButton();
            this.rdPorTienda = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DataGridViewTiendas = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTiendas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.chkSoporte);
            this.groupBox1.Controls.Add(this.chkProduccion);
            this.groupBox1.Controls.Add(this.btnIniciarEjecucion);
            this.groupBox1.Controls.Add(this.txtIPServer);
            this.groupBox1.Controls.Add(this.txtTiendasExcepcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTiendas);
            this.groupBox1.Controls.Add(this.txtTiendas);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1868, 266);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // chkSoporte
            // 
            this.chkSoporte.AutoSize = true;
            this.chkSoporte.Location = new System.Drawing.Point(358, 195);
            this.chkSoporte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSoporte.Name = "chkSoporte";
            this.chkSoporte.Size = new System.Drawing.Size(92, 24);
            this.chkSoporte.TabIndex = 26;
            this.chkSoporte.Text = "Soporte";
            this.chkSoporte.UseVisualStyleBackColor = true;
            // 
            // chkProduccion
            // 
            this.chkProduccion.AutoSize = true;
            this.chkProduccion.Checked = true;
            this.chkProduccion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProduccion.Location = new System.Drawing.Point(230, 195);
            this.chkProduccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProduccion.Name = "chkProduccion";
            this.chkProduccion.Size = new System.Drawing.Size(114, 24);
            this.chkProduccion.TabIndex = 25;
            this.chkProduccion.Text = "Produccion";
            this.chkProduccion.UseVisualStyleBackColor = true;
            // 
            // btnIniciarEjecucion
            // 
            this.btnIniciarEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarEjecucion.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarEjecucion.Image")));
            this.btnIniciarEjecucion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarEjecucion.Location = new System.Drawing.Point(922, 54);
            this.btnIniciarEjecucion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIniciarEjecucion.Name = "btnIniciarEjecucion";
            this.btnIniciarEjecucion.Size = new System.Drawing.Size(198, 57);
            this.btnIniciarEjecucion.TabIndex = 5;
            this.btnIniciarEjecucion.Text = "Verificar Enlace";
            this.btnIniciarEjecucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciarEjecucion.UseVisualStyleBackColor = true;
            this.btnIniciarEjecucion.Click += new System.EventHandler(this.BtnIniciarEjecucion_Click);
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(226, 51);
            this.txtIPServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(330, 26);
            this.txtIPServer.TabIndex = 10;
            this.txtIPServer.Visible = false;
            // 
            // txtTiendasExcepcion
            // 
            this.txtTiendasExcepcion.Location = new System.Drawing.Point(584, 54);
            this.txtTiendasExcepcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTiendasExcepcion.Multiline = true;
            this.txtTiendasExcepcion.Name = "txtTiendasExcepcion";
            this.txtTiendasExcepcion.Size = new System.Drawing.Size(330, 129);
            this.txtTiendasExcepcion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agregar Excepciones separado por (,)";
            // 
            // lblTiendas
            // 
            this.lblTiendas.AutoSize = true;
            this.lblTiendas.Location = new System.Drawing.Point(226, 25);
            this.lblTiendas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiendas.Name = "lblTiendas";
            this.lblTiendas.Size = new System.Drawing.Size(207, 20);
            this.lblTiendas.TabIndex = 1;
            this.lblTiendas.Text = "Ingresa el numero de tienda";
            // 
            // txtTiendas
            // 
            this.txtTiendas.Location = new System.Drawing.Point(226, 52);
            this.txtTiendas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTiendas.Multiline = true;
            this.txtTiendas.Name = "txtTiendas";
            this.txtTiendas.Size = new System.Drawing.Size(330, 130);
            this.txtTiendas.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdFiltroPorIP);
            this.panel1.Controls.Add(this.rdPorRangoTiendas);
            this.panel1.Controls.Add(this.rdPorTiendas);
            this.panel1.Controls.Add(this.rdPorTienda);
            this.panel1.Location = new System.Drawing.Point(9, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 214);
            this.panel1.TabIndex = 0;
            // 
            // rdFiltroPorIP
            // 
            this.rdFiltroPorIP.AutoSize = true;
            this.rdFiltroPorIP.Location = new System.Drawing.Point(4, 165);
            this.rdFiltroPorIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdFiltroPorIP.Name = "rdFiltroPorIP";
            this.rdFiltroPorIP.Size = new System.Drawing.Size(74, 24);
            this.rdFiltroPorIP.TabIndex = 3;
            this.rdFiltroPorIP.Text = "Por ip";
            this.rdFiltroPorIP.UseVisualStyleBackColor = true;
            this.rdFiltroPorIP.CheckedChanged += new System.EventHandler(this.RdFiltroPorIP_CheckedChanged);
            // 
            // rdPorRangoTiendas
            // 
            this.rdPorRangoTiendas.AutoSize = true;
            this.rdPorRangoTiendas.Location = new System.Drawing.Point(4, 94);
            this.rdPorRangoTiendas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdPorRangoTiendas.Name = "rdPorRangoTiendas";
            this.rdPorRangoTiendas.Size = new System.Drawing.Size(149, 24);
            this.rdPorRangoTiendas.TabIndex = 2;
            this.rdPorRangoTiendas.Text = "Por Rango [100]";
            this.rdPorRangoTiendas.UseVisualStyleBackColor = true;
            this.rdPorRangoTiendas.CheckedChanged += new System.EventHandler(this.RdPorRangoTiendas_CheckedChanged);
            // 
            // rdPorTiendas
            // 
            this.rdPorTiendas.AutoSize = true;
            this.rdPorTiendas.Location = new System.Drawing.Point(4, 58);
            this.rdPorTiendas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdPorTiendas.Name = "rdPorTiendas";
            this.rdPorTiendas.Size = new System.Drawing.Size(118, 24);
            this.rdPorTiendas.TabIndex = 1;
            this.rdPorTiendas.Text = "Por Tiendas";
            this.rdPorTiendas.UseVisualStyleBackColor = true;
            this.rdPorTiendas.CheckedChanged += new System.EventHandler(this.RdPorTiendas_CheckedChanged);
            // 
            // rdPorTienda
            // 
            this.rdPorTienda.AutoSize = true;
            this.rdPorTienda.Checked = true;
            this.rdPorTienda.Location = new System.Drawing.Point(4, 23);
            this.rdPorTienda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdPorTienda.Name = "rdPorTienda";
            this.rdPorTienda.Size = new System.Drawing.Size(110, 24);
            this.rdPorTienda.TabIndex = 0;
            this.rdPorTienda.TabStop = true;
            this.rdPorTienda.Text = "Por Tienda";
            this.rdPorTienda.UseVisualStyleBackColor = true;
            this.rdPorTienda.CheckedChanged += new System.EventHandler(this.RdPorTienda_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DataGridViewTiendas);
            this.groupBox2.Location = new System.Drawing.Point(13, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1868, 750);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiendas";
            // 
            // DataGridViewTiendas
            // 
            this.DataGridViewTiendas.AllowUserToAddRows = false;
            this.DataGridViewTiendas.AllowUserToDeleteRows = false;
            this.DataGridViewTiendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTiendas.Location = new System.Drawing.Point(6, 77);
            this.DataGridViewTiendas.Name = "DataGridViewTiendas";
            this.DataGridViewTiendas.ReadOnly = true;
            this.DataGridViewTiendas.RowHeadersWidth = 62;
            this.DataGridViewTiendas.RowTemplate.Height = 28;
            this.DataGridViewTiendas.Size = new System.Drawing.Size(1856, 599);
            this.DataGridViewTiendas.TabIndex = 0;
            this.DataGridViewTiendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewTiendas_CellDoubleClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(922, 120);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(198, 57);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // frmMonitorDeEnlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1050);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMonitorDeEnlace";
            this.Text = "Monitor de enlace";
            this.Load += new System.EventHandler(this.FrmMonitorDeEnlace_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTiendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.TextBox txtTiendasExcepcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTiendas;
        private System.Windows.Forms.TextBox txtTiendas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdFiltroPorIP;
        private System.Windows.Forms.RadioButton rdPorRangoTiendas;
        private System.Windows.Forms.RadioButton rdPorTiendas;
        private System.Windows.Forms.RadioButton rdPorTienda;
        private System.Windows.Forms.Button btnIniciarEjecucion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DataGridViewTiendas;
        private System.Windows.Forms.CheckBox chkSoporte;
        private System.Windows.Forms.CheckBox chkProduccion;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnLimpiar;
    }
}