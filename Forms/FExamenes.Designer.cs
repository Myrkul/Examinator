namespace Examinator.Forms
{
    partial class FExamenes
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
            this.label2 = new System.Windows.Forms.Label();
            this.tablaExamenes = new System.Windows.Forms.DataGridView();
            this.tablaPreguntas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAddPregunta = new System.Windows.Forms.Button();
            this.btnEliminarExamen = new System.Windows.Forms.Button();
            this.btnEliminarPregunta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaExamenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Exámenes";
            // 
            // tablaExamenes
            // 
            this.tablaExamenes.AllowUserToAddRows = false;
            this.tablaExamenes.AllowUserToDeleteRows = false;
            this.tablaExamenes.AllowUserToOrderColumns = true;
            this.tablaExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaExamenes.Location = new System.Drawing.Point(12, 47);
            this.tablaExamenes.Name = "tablaExamenes";
            this.tablaExamenes.ReadOnly = true;
            this.tablaExamenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaExamenes.Size = new System.Drawing.Size(300, 163);
            this.tablaExamenes.TabIndex = 7;
            this.tablaExamenes.SelectionChanged += new System.EventHandler(this.tablaExamenes_SelectionChanged);
            // 
            // tablaPreguntas
            // 
            this.tablaPreguntas.AllowUserToAddRows = false;
            this.tablaPreguntas.AllowUserToDeleteRows = false;
            this.tablaPreguntas.AllowUserToOrderColumns = true;
            this.tablaPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPreguntas.Location = new System.Drawing.Point(330, 47);
            this.tablaPreguntas.Name = "tablaPreguntas";
            this.tablaPreguntas.ReadOnly = true;
            this.tablaPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaPreguntas.Size = new System.Drawing.Size(364, 163);
            this.tablaPreguntas.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Preguntas";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(237, 216);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAddPregunta
            // 
            this.btnAddPregunta.Location = new System.Drawing.Point(619, 216);
            this.btnAddPregunta.Name = "btnAddPregunta";
            this.btnAddPregunta.Size = new System.Drawing.Size(75, 23);
            this.btnAddPregunta.TabIndex = 12;
            this.btnAddPregunta.Text = "Añadir";
            this.btnAddPregunta.UseVisualStyleBackColor = true;
            // 
            // btnEliminarExamen
            // 
            this.btnEliminarExamen.Location = new System.Drawing.Point(156, 216);
            this.btnEliminarExamen.Name = "btnEliminarExamen";
            this.btnEliminarExamen.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarExamen.TabIndex = 13;
            this.btnEliminarExamen.Text = "Eliminar";
            this.btnEliminarExamen.UseVisualStyleBackColor = true;
            this.btnEliminarExamen.Click += new System.EventHandler(this.btnEliminarExamen_Click);
            // 
            // btnEliminarPregunta
            // 
            this.btnEliminarPregunta.Location = new System.Drawing.Point(538, 216);
            this.btnEliminarPregunta.Name = "btnEliminarPregunta";
            this.btnEliminarPregunta.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPregunta.TabIndex = 14;
            this.btnEliminarPregunta.Text = "Eliminar";
            this.btnEliminarPregunta.UseVisualStyleBackColor = true;
            this.btnEliminarPregunta.Click += new System.EventHandler(this.btnEliminarPregunta_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(619, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FExamenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 308);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminarPregunta);
            this.Controls.Add(this.btnEliminarExamen);
            this.Controls.Add(this.btnAddPregunta);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaPreguntas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablaExamenes);
            this.Name = "FExamenes";
            this.Text = "FExamenes";
            ((System.ComponentModel.ISupportInitialize)(this.tablaExamenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPreguntas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tablaExamenes;
        private System.Windows.Forms.DataGridView tablaPreguntas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAddPregunta;
        private System.Windows.Forms.Button btnEliminarExamen;
        private System.Windows.Forms.Button btnEliminarPregunta;
        private System.Windows.Forms.Button btnCancelar;
    }
}