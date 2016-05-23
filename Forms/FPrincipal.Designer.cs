namespace Examinator
{
    partial class FPrincipal
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aulasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarAulasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarAsignaturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 77);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Añadir Preguntas";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aulasToolStripMenuItem,
            this.asignaturasToolStripMenuItem,
            this.alumnosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aulasToolStripMenuItem
            // 
            this.aulasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarAulasToolStripMenuItem});
            this.aulasToolStripMenuItem.Name = "aulasToolStripMenuItem";
            this.aulasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aulasToolStripMenuItem.Text = "Aulas";
            // 
            // gestionarAulasToolStripMenuItem
            // 
            this.gestionarAulasToolStripMenuItem.Name = "gestionarAulasToolStripMenuItem";
            this.gestionarAulasToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.gestionarAulasToolStripMenuItem.Text = "Gestionar Aulas";
            // 
            // asignaturasToolStripMenuItem
            // 
            this.asignaturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarAsignaturasToolStripMenuItem});
            this.asignaturasToolStripMenuItem.Name = "asignaturasToolStripMenuItem";
            this.asignaturasToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.asignaturasToolStripMenuItem.Text = "Asignaturas";
            // 
            // gestionarAsignaturasToolStripMenuItem
            // 
            this.gestionarAsignaturasToolStripMenuItem.Name = "gestionarAsignaturasToolStripMenuItem";
            this.gestionarAsignaturasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gestionarAsignaturasToolStripMenuItem.Text = "Gestionar Asignaturas";
            this.gestionarAsignaturasToolStripMenuItem.Click += new System.EventHandler(this.gestionarAsignaturasToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarAlumnosToolStripMenuItem});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // gestionarAlumnosToolStripMenuItem
            // 
            this.gestionarAlumnosToolStripMenuItem.Name = "gestionarAlumnosToolStripMenuItem";
            this.gestionarAlumnosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestionarAlumnosToolStripMenuItem.Text = "Gestionar Alumnos";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(464, 52);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(124, 77);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar Examen";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 294);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FPrincipal";
            this.Text = "Examinator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarAulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarAsignaturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarAlumnosToolStripMenuItem;
        private System.Windows.Forms.Button btnGenerar;
    }
}

