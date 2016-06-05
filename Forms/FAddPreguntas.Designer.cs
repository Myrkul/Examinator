namespace Examinator.Forms
{
    partial class FAddPreguntas
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
            this.label1 = new System.Windows.Forms.Label();
            this.tPregunta = new System.Windows.Forms.TextBox();
            this.comboRespuestas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelRadio = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboAsignatura = new System.Windows.Forms.ComboBox();
            this.comboTema = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pregunta:";
            // 
            // tPregunta
            // 
            this.tPregunta.Location = new System.Drawing.Point(71, 10);
            this.tPregunta.Multiline = true;
            this.tPregunta.Name = "tPregunta";
            this.tPregunta.Size = new System.Drawing.Size(375, 77);
            this.tPregunta.TabIndex = 1;
            // 
            // comboRespuestas
            // 
            this.comboRespuestas.FormattingEnabled = true;
            this.comboRespuestas.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.comboRespuestas.Location = new System.Drawing.Point(137, 93);
            this.comboRespuestas.Name = "comboRespuestas";
            this.comboRespuestas.Size = new System.Drawing.Size(79, 21);
            this.comboRespuestas.TabIndex = 2;
            this.comboRespuestas.SelectedIndexChanged += new System.EventHandler(this.comboRespuestas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número de Respuestas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "¿Correcta?";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(373, 407);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Añadir";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(292, 407);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelRadio
            // 
            this.panelRadio.Location = new System.Drawing.Point(392, 207);
            this.panelRadio.Name = "panelRadio";
            this.panelRadio.Size = new System.Drawing.Size(54, 184);
            this.panelRadio.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Asignatura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Tema:";
            // 
            // comboAsignatura
            // 
            this.comboAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAsignatura.FormattingEnabled = true;
            this.comboAsignatura.Location = new System.Drawing.Point(137, 122);
            this.comboAsignatura.Name = "comboAsignatura";
            this.comboAsignatura.Size = new System.Drawing.Size(163, 21);
            this.comboAsignatura.TabIndex = 26;
            this.comboAsignatura.SelectedIndexChanged += new System.EventHandler(this.comboAsignatura_SelectedIndexChanged);
            // 
            // comboTema
            // 
            this.comboTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTema.FormattingEnabled = true;
            this.comboTema.Location = new System.Drawing.Point(137, 153);
            this.comboTema.Name = "comboTema";
            this.comboTema.Size = new System.Drawing.Size(163, 21);
            this.comboTema.TabIndex = 27;
            // 
            // FAddPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 442);
            this.Controls.Add(this.comboTema);
            this.Controls.Add(this.comboAsignatura);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelRadio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboRespuestas);
            this.Controls.Add(this.tPregunta);
            this.Controls.Add(this.label1);
            this.Name = "FAddPreguntas";
            this.Text = "Añadir Pregunta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tPregunta;
        private System.Windows.Forms.ComboBox comboRespuestas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboAsignatura;
        private System.Windows.Forms.ComboBox comboTema;
    }
}