namespace UtileriasControlProg.UI.Implementacion
{
    partial class frmDetalleTiendasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleTiendasPendientes));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInterrumpir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(505, 488);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnInterrumpir
            // 
            this.btnInterrumpir.Image = ((System.Drawing.Image)(resources.GetObject("btnInterrumpir.Image")));
            this.btnInterrumpir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInterrumpir.Location = new System.Drawing.Point(12, 506);
            this.btnInterrumpir.Name = "btnInterrumpir";
            this.btnInterrumpir.Size = new System.Drawing.Size(136, 63);
            this.btnInterrumpir.TabIndex = 1;
            this.btnInterrumpir.Text = "INTERRUMPIR EJECUCION";
            this.btnInterrumpir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInterrumpir.UseVisualStyleBackColor = true;
            this.btnInterrumpir.Click += new System.EventHandler(this.btnInterrumpir_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(406, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "CERRAR VENTANA";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDetalleTiendasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 581);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInterrumpir);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmDetalleTiendasPendientes";
            this.Text = "Detalle de tiendas por terminar";
            this.Load += new System.EventHandler(this.frmDetalleTiendasPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInterrumpir;
        private System.Windows.Forms.Button button1;
    }
}