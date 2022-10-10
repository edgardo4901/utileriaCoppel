namespace UtileriasControlProg
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utileriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revisorVersionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programacionDeEnviosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utileriasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1137, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utileriasToolStripMenuItem
            // 
            this.utileriasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revisorVersionesToolStripMenuItem,
            this.programacionDeEnviosToolStripMenuItem});
            this.utileriasToolStripMenuItem.Name = "utileriasToolStripMenuItem";
            this.utileriasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.utileriasToolStripMenuItem.Text = "Utilerias";
            // 
            // revisorVersionesToolStripMenuItem
            // 
            this.revisorVersionesToolStripMenuItem.Name = "revisorVersionesToolStripMenuItem";
            this.revisorVersionesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.revisorVersionesToolStripMenuItem.Text = "Revisor Versiones";
            this.revisorVersionesToolStripMenuItem.Click += new System.EventHandler(this.revisorVersionesToolStripMenuItem_Click);
            // 
            // programacionDeEnviosToolStripMenuItem
            // 
            this.programacionDeEnviosToolStripMenuItem.Name = "programacionDeEnviosToolStripMenuItem";
            this.programacionDeEnviosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.programacionDeEnviosToolStripMenuItem.Text = "Programacion de Envios";
            this.programacionDeEnviosToolStripMenuItem.Click += new System.EventHandler(this.programacionDeEnviosToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 668);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilerias de Control Programación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem utileriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revisorVersionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programacionDeEnviosToolStripMenuItem;
    }
}

