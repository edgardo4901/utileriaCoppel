namespace UtileriasControlProg.UI.Implementacion
{
    partial class frmDetalleArchivoComparacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleArchivoComparacion));
            this.lblTotalTiendasRevisadas = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rdTodos = new System.Windows.Forms.RadioButton();
            this.rdOk = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnEnviarTodo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalTiendasRevisadas
            // 
            this.lblTotalTiendasRevisadas.AutoSize = true;
            this.lblTotalTiendasRevisadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTiendasRevisadas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotalTiendasRevisadas.Location = new System.Drawing.Point(227, 9);
            this.lblTotalTiendasRevisadas.Name = "lblTotalTiendasRevisadas";
            this.lblTotalTiendasRevisadas.Size = new System.Drawing.Size(359, 24);
            this.lblTotalTiendasRevisadas.TabIndex = 14;
            this.lblTotalTiendasRevisadas.Text = "Detalle de archivos de la tienda: 1155";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(930, 564);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rdTodos
            // 
            this.rdTodos.AutoSize = true;
            this.rdTodos.Location = new System.Drawing.Point(600, 53);
            this.rdTodos.Name = "rdTodos";
            this.rdTodos.Size = new System.Drawing.Size(55, 17);
            this.rdTodos.TabIndex = 16;
            this.rdTodos.Text = "Todos";
            this.rdTodos.UseVisualStyleBackColor = true;
            this.rdTodos.Click += new System.EventHandler(this.rdTodos_Click);
            // 
            // rdOk
            // 
            this.rdOk.AutoSize = true;
            this.rdOk.Location = new System.Drawing.Point(436, 53);
            this.rdOk.Name = "rdOk";
            this.rdOk.Size = new System.Drawing.Size(89, 17);
            this.rdOk.TabIndex = 17;
            this.rdOk.Text = "Sin diferencia";
            this.rdOk.UseVisualStyleBackColor = true;
            this.rdOk.Click += new System.EventHandler(this.rdOk_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(300, 53);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 17);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Con diferencia";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // btnEnviarTodo
            // 
            this.btnEnviarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarTodo.Image")));
            this.btnEnviarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarTodo.Location = new System.Drawing.Point(384, 667);
            this.btnEnviarTodo.Name = "btnEnviarTodo";
            this.btnEnviarTodo.Size = new System.Drawing.Size(214, 58);
            this.btnEnviarTodo.TabIndex = 19;
            this.btnEnviarTodo.Text = "ENVIAR TODO";
            this.btnEnviarTodo.UseVisualStyleBackColor = true;
            this.btnEnviarTodo.Click += new System.EventHandler(this.btnEnviarTodo_Click);
            // 
            // frmDetalleArchivoComparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 737);
            this.Controls.Add(this.btnEnviarTodo);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdOk);
            this.Controls.Add(this.rdTodos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTotalTiendasRevisadas);
            this.Name = "frmDetalleArchivoComparacion";
            this.Text = "Detalle de archivos comparados";
            this.Load += new System.EventHandler(this.frmDetalleArchivoComparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalTiendasRevisadas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rdTodos;
        private System.Windows.Forms.RadioButton rdOk;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnEnviarTodo;
    }
}