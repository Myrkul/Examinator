namespace Examinator.Forms
{
    partial class FGenerar
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboAsignatura = new System.Windows.Forms.ComboBox();
            this.comboTema = new System.Windows.Forms.ComboBox();
            this.checkFinal = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tNumero = new System.Windows.Forms.TextBox();
            this.tIncorrectas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tVacias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tNumRespuestas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asignatura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tema:";
            // 
            // comboAsignatura
            // 
            this.comboAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAsignatura.FormattingEnabled = true;
            this.comboAsignatura.Location = new System.Drawing.Point(79, 10);
            this.comboAsignatura.Name = "comboAsignatura";
            this.comboAsignatura.Size = new System.Drawing.Size(215, 21);
            this.comboAsignatura.TabIndex = 2;
            this.comboAsignatura.SelectedIndexChanged += new System.EventHandler(this.comboAsignatura_SelectedIndexChanged);
            // 
            // comboTema
            // 
            this.comboTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTema.FormattingEnabled = true;
            this.comboTema.Location = new System.Drawing.Point(79, 44);
            this.comboTema.Name = "comboTema";
            this.comboTema.Size = new System.Drawing.Size(215, 21);
            this.comboTema.TabIndex = 3;
            // 
            // checkFinal
            // 
            this.checkFinal.AutoSize = true;
            this.checkFinal.Location = new System.Drawing.Point(339, 47);
            this.checkFinal.Name = "checkFinal";
            this.checkFinal.Size = new System.Drawing.Size(15, 14);
            this.checkFinal.TabIndex = 31;
            this.checkFinal.UseVisualStyleBackColor = true;
            this.checkFinal.CheckedChanged += new System.EventHandler(this.checkFinal_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Final:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Número de Preguntas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Se baja un punto cada...";
            // 
            // tNumero
            // 
            this.tNumero.Location = new System.Drawing.Point(143, 97);
            this.tNumero.Name = "tNumero";
            this.tNumero.Size = new System.Drawing.Size(95, 20);
            this.tNumero.TabIndex = 34;
            this.tNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tIncorrectas
            // 
            this.tIncorrectas.Location = new System.Drawing.Point(143, 173);
            this.tIncorrectas.Name = "tIncorrectas";
            this.tIncorrectas.Size = new System.Drawing.Size(95, 20);
            this.tIncorrectas.TabIndex = 35;
            this.tIncorrectas.Text = "0";
            this.tIncorrectas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "preguntas INCORRECTAS.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Se baja un punto cada...";
            // 
            // tVacias
            // 
            this.tVacias.Location = new System.Drawing.Point(143, 207);
            this.tVacias.Name = "tVacias";
            this.tVacias.Size = new System.Drawing.Size(95, 20);
            this.tVacias.TabIndex = 38;
            this.tVacias.Text = "0";
            this.tVacias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "preguntas SIN CONTESTAR.";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(160, 267);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(111, 81);
            this.btnGenerar.TabIndex = 40;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Número de Respuestas:";
            // 
            // tNumRespuestas
            // 
            this.tNumRespuestas.Location = new System.Drawing.Point(143, 136);
            this.tNumRespuestas.Name = "tNumRespuestas";
            this.tNumRespuestas.Size = new System.Drawing.Size(95, 20);
            this.tNumRespuestas.TabIndex = 42;
            this.tNumRespuestas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FGenerar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 360);
            this.Controls.Add(this.tNumRespuestas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tVacias);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tIncorrectas);
            this.Controls.Add(this.tNumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkFinal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboTema);
            this.Controls.Add(this.comboAsignatura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FGenerar";
            this.Text = "Generar Examen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAsignatura;
        private System.Windows.Forms.ComboBox comboTema;
        private System.Windows.Forms.CheckBox checkFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tNumero;
        private System.Windows.Forms.TextBox tIncorrectas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tVacias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tNumRespuestas;
    }
}