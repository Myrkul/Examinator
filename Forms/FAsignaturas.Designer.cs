namespace Examinator.Forms
{
    partial class FAsignaturas
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
            this.tablaAsignaturas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAsig = new System.Windows.Forms.Button();
            this.tNombreAsig = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminarAsig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tablaTemas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tNombreTema = new System.Windows.Forms.TextBox();
            this.btnAddTema = new System.Windows.Forms.Button();
            this.btnEliminarTema = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboClase = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAsignaturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTemas)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaAsignaturas
            // 
            this.tablaAsignaturas.AllowUserToAddRows = false;
            this.tablaAsignaturas.AllowUserToDeleteRows = false;
            this.tablaAsignaturas.AllowUserToOrderColumns = true;
            this.tablaAsignaturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaAsignaturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAsignaturas.Location = new System.Drawing.Point(12, 48);
            this.tablaAsignaturas.Name = "tablaAsignaturas";
            this.tablaAsignaturas.ReadOnly = true;
            this.tablaAsignaturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaAsignaturas.Size = new System.Drawing.Size(300, 163);
            this.tablaAsignaturas.TabIndex = 0;
            this.tablaAsignaturas.SelectionChanged += new System.EventHandler(this.tablaAsignaturas_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // btnAddAsig
            // 
            this.btnAddAsig.Location = new System.Drawing.Point(233, 281);
            this.btnAddAsig.Name = "btnAddAsig";
            this.btnAddAsig.Size = new System.Drawing.Size(79, 23);
            this.btnAddAsig.TabIndex = 2;
            this.btnAddAsig.Text = "Añadir Asignatura";
            this.btnAddAsig.UseVisualStyleBackColor = true;
            this.btnAddAsig.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tNombreAsig
            // 
            this.tNombreAsig.Location = new System.Drawing.Point(74, 249);
            this.tNombreAsig.Name = "tNombreAsig";
            this.tNombreAsig.Size = new System.Drawing.Size(238, 20);
            this.tNombreAsig.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(568, 308);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminarAsig
            // 
            this.btnEliminarAsig.Location = new System.Drawing.Point(153, 281);
            this.btnEliminarAsig.Name = "btnEliminarAsig";
            this.btnEliminarAsig.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarAsig.TabIndex = 5;
            this.btnEliminarAsig.Text = "Eliminar";
            this.btnEliminarAsig.UseVisualStyleBackColor = true;
            this.btnEliminarAsig.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Asignaturas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(449, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Temas";
            // 
            // tablaTemas
            // 
            this.tablaTemas.AllowUserToAddRows = false;
            this.tablaTemas.AllowUserToDeleteRows = false;
            this.tablaTemas.AllowUserToOrderColumns = true;
            this.tablaTemas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tablaTemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTemas.Location = new System.Drawing.Point(343, 48);
            this.tablaTemas.Name = "tablaTemas";
            this.tablaTemas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTemas.Size = new System.Drawing.Size(300, 163);
            this.tablaTemas.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nombre:";
            // 
            // tNombreTema
            // 
            this.tNombreTema.Location = new System.Drawing.Point(413, 217);
            this.tNombreTema.Name = "tNombreTema";
            this.tNombreTema.Size = new System.Drawing.Size(230, 20);
            this.tNombreTema.TabIndex = 10;
            // 
            // btnAddTema
            // 
            this.btnAddTema.Location = new System.Drawing.Point(568, 249);
            this.btnAddTema.Name = "btnAddTema";
            this.btnAddTema.Size = new System.Drawing.Size(75, 23);
            this.btnAddTema.TabIndex = 11;
            this.btnAddTema.Text = "Añadir";
            this.btnAddTema.UseVisualStyleBackColor = true;
            this.btnAddTema.Click += new System.EventHandler(this.btnAddTema_Click);
            // 
            // btnEliminarTema
            // 
            this.btnEliminarTema.Location = new System.Drawing.Point(487, 249);
            this.btnEliminarTema.Name = "btnEliminarTema";
            this.btnEliminarTema.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTema.TabIndex = 12;
            this.btnEliminarTema.Text = "Eliminar";
            this.btnEliminarTema.UseVisualStyleBackColor = true;
            this.btnEliminarTema.Click += new System.EventHandler(this.btnEliminarTema_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Clase:";
            // 
            // comboClase
            // 
            this.comboClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClase.FormattingEnabled = true;
            this.comboClase.Location = new System.Drawing.Point(74, 216);
            this.comboClase.Name = "comboClase";
            this.comboClase.Size = new System.Drawing.Size(238, 21);
            this.comboClase.TabIndex = 14;
            // 
            // FAsignaturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 357);
            this.Controls.Add(this.comboClase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEliminarTema);
            this.Controls.Add(this.btnAddTema);
            this.Controls.Add(this.tNombreTema);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tablaTemas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarAsig);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tNombreAsig);
            this.Controls.Add(this.btnAddAsig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaAsignaturas);
            this.Name = "FAsignaturas";
            this.Text = "Gestionar Asignaturas";
            ((System.ComponentModel.ISupportInitialize)(this.tablaAsignaturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTemas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaAsignaturas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAsig;
        private System.Windows.Forms.TextBox tNombreAsig;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminarAsig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tablaTemas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tNombreTema;
        private System.Windows.Forms.Button btnAddTema;
        private System.Windows.Forms.Button btnEliminarTema;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboClase;
    }
}