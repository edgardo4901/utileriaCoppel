
namespace UtileriasControlProg.UI.Personal
{
    partial class frmReporteDinamico
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
            this.chklstboxBloque1 = new System.Windows.Forms.CheckedListBox();
            this.chklstboxBloque2 = new System.Windows.Forms.CheckedListBox();
            this.chklstboxBloque3 = new System.Windows.Forms.CheckedListBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCiudad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSeccion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbZona = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDelCentro = new System.Windows.Forms.TextBox();
            this.txtAlCentro = new System.Windows.Forms.TextBox();
            this.txtDescripcionDel = new System.Windows.Forms.TextBox();
            this.txtDescripcionAl = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.chkSueldo = new System.Windows.Forms.CheckBox();
            this.chkAntiguedad = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.btnMenos = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.btnMas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // chklstboxBloque1
            // 
            this.chklstboxBloque1.FormattingEnabled = true;
            this.chklstboxBloque1.Location = new System.Drawing.Point(677, 12);
            this.chklstboxBloque1.Name = "chklstboxBloque1";
            this.chklstboxBloque1.Size = new System.Drawing.Size(367, 372);
            this.chklstboxBloque1.TabIndex = 0;
            this.chklstboxBloque1.SelectedIndexChanged += new System.EventHandler(this.chklstboxBloque1_SelectedIndexChanged);
            // 
            // chklstboxBloque2
            // 
            this.chklstboxBloque2.FormattingEnabled = true;
            this.chklstboxBloque2.Location = new System.Drawing.Point(1391, 12);
            this.chklstboxBloque2.Name = "chklstboxBloque2";
            this.chklstboxBloque2.Size = new System.Drawing.Size(296, 165);
            this.chklstboxBloque2.TabIndex = 1;
            // 
            // chklstboxBloque3
            // 
            this.chklstboxBloque3.FormattingEnabled = true;
            this.chklstboxBloque3.Location = new System.Drawing.Point(1050, 12);
            this.chklstboxBloque3.Name = "chklstboxBloque3";
            this.chklstboxBloque3.Size = new System.Drawing.Size(335, 372);
            this.chklstboxBloque3.TabIndex = 2;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(126, 43);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(409, 28);
            this.cbEmpresa.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Region:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(127, 88);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(408, 28);
            this.cbRegion.TabIndex = 5;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cbRegion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ciudad:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCiudad
            // 
            this.cbCiudad.FormattingEnabled = true;
            this.cbCiudad.Location = new System.Drawing.Point(127, 137);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(408, 28);
            this.cbCiudad.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Seccion:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSeccion
            // 
            this.cbSeccion.FormattingEnabled = true;
            this.cbSeccion.Location = new System.Drawing.Point(126, 186);
            this.cbSeccion.Name = "cbSeccion";
            this.cbSeccion.Size = new System.Drawing.Size(409, 28);
            this.cbSeccion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Zona:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbZona
            // 
            this.cbZona.FormattingEnabled = true;
            this.cbZona.Location = new System.Drawing.Point(127, 239);
            this.cbZona.Name = "cbZona";
            this.cbZona.Size = new System.Drawing.Size(408, 28);
            this.cbZona.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Del centro:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Al centro:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDelCentro
            // 
            this.txtDelCentro.Location = new System.Drawing.Point(125, 302);
            this.txtDelCentro.Name = "txtDelCentro";
            this.txtDelCentro.Size = new System.Drawing.Size(93, 26);
            this.txtDelCentro.TabIndex = 15;
            this.txtDelCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDelCentro_KeyPress);
            this.txtDelCentro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDelCentro_KeyUp);
            this.txtDelCentro.Leave += new System.EventHandler(this.txtDelCentro_Leave);
            // 
            // txtAlCentro
            // 
            this.txtAlCentro.Location = new System.Drawing.Point(127, 348);
            this.txtAlCentro.Name = "txtAlCentro";
            this.txtAlCentro.Size = new System.Drawing.Size(93, 26);
            this.txtAlCentro.TabIndex = 16;
            this.txtAlCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlCentro_KeyPress);
            this.txtAlCentro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAlCentro_KeyUp);
            this.txtAlCentro.Leave += new System.EventHandler(this.txtAlCentro_Leave);
            // 
            // txtDescripcionDel
            // 
            this.txtDescripcionDel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDescripcionDel.Enabled = false;
            this.txtDescripcionDel.Location = new System.Drawing.Point(238, 302);
            this.txtDescripcionDel.Name = "txtDescripcionDel";
            this.txtDescripcionDel.Size = new System.Drawing.Size(297, 26);
            this.txtDescripcionDel.TabIndex = 17;
            // 
            // txtDescripcionAl
            // 
            this.txtDescripcionAl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDescripcionAl.Enabled = false;
            this.txtDescripcionAl.Location = new System.Drawing.Point(238, 345);
            this.txtDescripcionAl.Name = "txtDescripcionAl";
            this.txtDescripcionAl.Size = new System.Drawing.Size(297, 26);
            this.txtDescripcionAl.TabIndex = 18;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1401, 400);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(142, 50);
            this.btnExcel.TabIndex = 19;
            this.btnExcel.Text = "F5 Exportar";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(1558, 400);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(139, 50);
            this.btnConsultar.TabIndex = 20;
            this.btnConsultar.Text = "F9 Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // chkSueldo
            // 
            this.chkSueldo.AutoSize = true;
            this.chkSueldo.Location = new System.Drawing.Point(6, 35);
            this.chkSueldo.Name = "chkSueldo";
            this.chkSueldo.Size = new System.Drawing.Size(85, 24);
            this.chkSueldo.TabIndex = 23;
            this.chkSueldo.Text = "Sueldo";
            this.chkSueldo.UseVisualStyleBackColor = true;
            // 
            // chkAntiguedad
            // 
            this.chkAntiguedad.AutoSize = true;
            this.chkAntiguedad.Location = new System.Drawing.Point(6, 65);
            this.chkAntiguedad.Name = "chkAntiguedad";
            this.chkAntiguedad.Size = new System.Drawing.Size(117, 24);
            this.chkAntiguedad.TabIndex = 24;
            this.chkAntiguedad.Text = "Antiguedad";
            this.chkAntiguedad.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSueldo);
            this.groupBox1.Controls.Add(this.chkAntiguedad);
            this.groupBox1.Location = new System.Drawing.Point(1410, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 107);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar Por:";
            this.groupBox1.Visible = false;
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            this.dgvConsulta.AllowUserToDeleteRows = false;
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsulta.Location = new System.Drawing.Point(46, 456);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.RowHeadersWidth = 62;
            this.dgvConsulta.RowTemplate.Height = 28;
            this.dgvConsulta.Size = new System.Drawing.Size(1656, 563);
            this.dgvConsulta.TabIndex = 23;
            // 
            // btnMenos
            // 
            this.btnMenos.Location = new System.Drawing.Point(713, 413);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(83, 35);
            this.btnMenos.TabIndex = 24;
            this.btnMenos.Text = "<";
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // lblPagina
            // 
            this.lblPagina.Location = new System.Drawing.Point(802, 413);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(100, 37);
            this.lblPagina.TabIndex = 25;
            this.lblPagina.Text = "0/0";
            this.lblPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMas
            // 
            this.btnMas.Location = new System.Drawing.Point(900, 413);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(83, 35);
            this.btnMas.TabIndex = 26;
            this.btnMas.Text = ">";
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // frmReporteDinamico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1750, 1072);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.lblPagina);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.txtDescripcionAl);
            this.Controls.Add(this.txtDescripcionDel);
            this.Controls.Add(this.txtAlCentro);
            this.Controls.Add(this.txtDelCentro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbZona);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSeccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.chklstboxBloque3);
            this.Controls.Add(this.chklstboxBloque2);
            this.Controls.Add(this.chklstboxBloque1);
            this.Name = "frmReporteDinamico";
            this.Text = "frmReporteDinamico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklstboxBloque1;
        private System.Windows.Forms.CheckedListBox chklstboxBloque2;
        private System.Windows.Forms.CheckedListBox chklstboxBloque3;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCiudad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSeccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbZona;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDelCentro;
        private System.Windows.Forms.TextBox txtAlCentro;
        private System.Windows.Forms.TextBox txtDescripcionDel;
        private System.Windows.Forms.TextBox txtDescripcionAl;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.CheckBox chkAntiguedad;
        private System.Windows.Forms.CheckBox chkSueldo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Button btnMas;
    }
}