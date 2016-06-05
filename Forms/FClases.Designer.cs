namespace Examinator.Forms
{
    partial class FClases
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
            this.tablaClases = new System.Windows.Forms.DataGridView();
            this.tablaAlumnos = new System.Windows.Forms.DataGridView();
            this.btnAddAlumno = new System.Windows.Forms.Button();
            this.btnEliminarAlumno = new System.Windows.Forms.Button();
            this.btnAddClase = new System.Windows.Forms.Button();
            this.btnEliminarClase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tNombreClase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tNombreAlumno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tApellidosAlumno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaClases
            // 
            this.tablaClases.AllowUserToAddRows = false;
            this.tablaClases.AllowUserToDeleteRows = false;
            this.tablaClases.AllowUserToOrderColumns = true;
            this.tablaClases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClases.Location = new System.Drawing.Point(12, 48);
            this.tablaClases.Name = "tablaClases";
            this.tablaClases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClases.Size = new System.Drawing.Size(300, 163);
            this.tablaClases.TabIndex = 0;
            this.tablaClases.SelectionChanged += new System.EventHandler(this.tablaClases_SelectionChanged);
            // 
            // tablaAlumnos
            // 
            this.tablaAlumnos.AllowUserToAddRows = false;
            this.tablaAlumnos.AllowUserToDeleteRows = false;
            this.tablaAlumnos.AllowUserToOrderColumns = true;
            this.tablaAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAlumnos.Location = new System.Drawing.Point(343, 48);
            this.tablaAlumnos.Name = "tablaAlumnos";
            this.tablaAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaAlumnos.Size = new System.Drawing.Size(300, 163);
            this.tablaAlumnos.TabIndex = 1;
            // 
            // btnAddAlumno
            // 
            this.btnAddAlumno.Location = new System.Drawing.Point(568, 274);
            this.btnAddAlumno.Name = "btnAddAlumno";
            this.btnAddAlumno.Size = new System.Drawing.Size(75, 23);
            this.btnAddAlumno.TabIndex = 2;
            this.btnAddAlumno.Text = "Añadir";
            this.btnAddAlumno.UseVisualStyleBackColor = true;
            this.btnAddAlumno.Click += new System.EventHandler(this.btnAddAlumno_Click);
            // 
            // btnEliminarAlumno
            // 
            this.btnEliminarAlumno.Location = new System.Drawing.Point(487, 274);
            this.btnEliminarAlumno.Name = "btnEliminarAlumno";
            this.btnEliminarAlumno.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarAlumno.TabIndex = 3;
            this.btnEliminarAlumno.Text = "Eliminar";
            this.btnEliminarAlumno.UseVisualStyleBackColor = true;
            this.btnEliminarAlumno.Click += new System.EventHandler(this.btnEliminarAlumno_Click);
            // 
            // btnAddClase
            // 
            this.btnAddClase.Location = new System.Drawing.Point(233, 249);
            this.btnAddClase.Name = "btnAddClase";
            this.btnAddClase.Size = new System.Drawing.Size(79, 23);
            this.btnAddClase.TabIndex = 4;
            this.btnAddClase.Text = "Añadir";
            this.btnAddClase.UseVisualStyleBackColor = true;
            this.btnAddClase.Click += new System.EventHandler(this.btnAddClase_Click);
            // 
            // btnEliminarClase
            // 
            this.btnEliminarClase.Location = new System.Drawing.Point(153, 249);
            this.btnEliminarClase.Name = "btnEliminarClase";
            this.btnEliminarClase.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarClase.TabIndex = 5;
            this.btnEliminarClase.Text = "Eliminar";
            this.btnEliminarClase.UseVisualStyleBackColor = true;
            this.btnEliminarClase.Click += new System.EventHandler(this.btnEliminarClase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Clases";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(433, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alumnos";
            // 
            // tNombreClase
            // 
            this.tNombreClase.Location = new System.Drawing.Point(74, 217);
            this.tNombreClase.Name = "tNombreClase";
            this.tNombreClase.Size = new System.Drawing.Size(238, 20);
            this.tNombreClase.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre:";
            // 
            // tNombreAlumno
            // 
            this.tNombreAlumno.Location = new System.Drawing.Point(405, 217);
            this.tNombreAlumno.Name = "tNombreAlumno";
            this.tNombreAlumno.Size = new System.Drawing.Size(238, 20);
            this.tNombreAlumno.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(568, 322);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tApellidosAlumno
            // 
            this.tApellidosAlumno.Location = new System.Drawing.Point(405, 244);
            this.tApellidosAlumno.Name = "tApellidosAlumno";
            this.tApellidosAlumno.Size = new System.Drawing.Size(238, 20);
            this.tApellidosAlumno.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Apellidos:";
            // 
            // FClases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 357);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tApellidosAlumno);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.tNombreAlumno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tNombreClase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarClase);
            this.Controls.Add(this.btnAddClase);
            this.Controls.Add(this.btnEliminarAlumno);
            this.Controls.Add(this.btnAddAlumno);
            this.Controls.Add(this.tablaAlumnos);
            this.Controls.Add(this.tablaClases);
            this.Name = "FClases";
            this.Text = "FClases";
            ((System.ComponentModel.ISupportInitialize)(this.tablaClases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaClases;
        private System.Windows.Forms.DataGridView tablaAlumnos;
        private System.Windows.Forms.Button btnAddAlumno;
        private System.Windows.Forms.Button btnEliminarAlumno;
        private System.Windows.Forms.Button btnAddClase;
        private System.Windows.Forms.Button btnEliminarClase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tNombreClase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tNombreAlumno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox tApellidosAlumno;
        private System.Windows.Forms.Label label5;
    }
}