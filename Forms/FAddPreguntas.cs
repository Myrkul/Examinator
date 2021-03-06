﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examinator.Forms
{
    public partial class FAddPreguntas : Form
    {
        //Estas tres listas se usan para almacenar las etiquetas y campos de las respuestas que se generan en el código.
        List<Label> listaLabels = new List<Label>();
        List<TextBox> listaRespuestas = new List<TextBox>();
        List<RadioButton> listaRadioResp = new List<RadioButton>();

		private DAO.Asignatura_DAO asignaturaDAO;
		private DAO.PreguntaRespuesta_DAO preguntaDAO;
		private DAO.Tema_DAO temaDAO;

        public FAddPreguntas()
        {
            InitializeComponent();
			asignaturaDAO = new DAO.Asignatura_DAO();
			preguntaDAO = new DAO.PreguntaRespuesta_DAO();
			temaDAO = new DAO.Tema_DAO();

            //Se carga el combo de asignaturas
			List<String> listaAsig = asignaturaDAO.getAsignaturas();

            for (int k = 0; k < listaAsig.Count; k++)
            {
                comboAsignatura.Items.Add(listaAsig[k]);
            }
        }

        private void comboRespuestas_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int k=0; k<listaLabels.Count; k++) //Se eliminan los anteriores campos (Si los hubiera)
            {
                this.Controls.Remove(listaLabels[k]);
                this.Controls.Remove(listaRespuestas[k]);
                panelRadio.Controls.Remove(listaRadioResp[k]);
            }
            listaLabels.Clear();
            listaRespuestas.Clear();
            listaRadioResp.Clear();
            int numRespuestas = Convert.ToInt32(comboRespuestas.SelectedItem.ToString());
            for(int k=0; k<numRespuestas; k++) //Se generan y almacenan los campos.
            {
                Label Ltemporal = new Label();
                TextBox Ttemporal = new TextBox();
                RadioButton Rtemporal = new RadioButton();
                Ltemporal.Text = "Respuesta " + (k + 1);
                Ltemporal.Location = new Point(12, 210 + 40 * k);
                Ltemporal.Size = new Size(70, 13);

                Ttemporal.Location = new Point(88, 207 + 40 * k);
                Ttemporal.Size = new Size(297, 20);

                Rtemporal.Location = new Point(20, 1 + 40 * k);

                listaLabels.Add(Ltemporal);
                listaRespuestas.Add(Ttemporal);
                listaRadioResp.Add(Rtemporal);
            }
            for (int k = 0; k < listaLabels.Count; k++) //Se añaden los campos al formulario.
            {
                this.Controls.Add(listaLabels[k]);
                this.Controls.Add(listaRespuestas[k]);
                panelRadio.Controls.Add(listaRadioResp[k]);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Típico control de entrada.

            if(tPregunta.Text.Equals(""))
            {
                MessageBox.Show("El campo de la pregunta no puede estar vacío.");
                return;
            }
            if(comboRespuestas.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar el número de respuestas.");
                return;
            }
            if (comboAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar la asignatura.");
                return;
            }
            if (comboTema.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar el tema.");
                return;
            }

            bool errorVacio = false;
            bool errorRespuesta = true;
            for(int k=0; k<listaLabels.Count; k++)
            {
                if(listaRespuestas[k].Text.Equals(""))
                {
                    errorVacio = true;
                    break;
                }
                if(listaRadioResp[k].Checked == true)
                {
                    errorRespuesta = false;
                }
            }

            if(errorVacio)
            {
                MessageBox.Show("Las respuestas no pueden estar en blanco.");
                return;
            }
            if(errorRespuesta)
            {
                MessageBox.Show("Tiene que haber una respuesta correcta.");
                return;
            }
			int correcta = 0;
			for (int k = 0; k < listaLabels.Count; k++)
            {
                if (listaRadioResp[k].Checked)
                {
					correcta = k+1;
                }
            }
            //Se inserta una pregunta y sus respuestas
			Clases.Pregunta pregunta = new Clases.Pregunta(tPregunta.Text, correcta, temaDAO.findTemaByName(comboTema.SelectedItem.ToString()));
            List<Clases.Respuesta> respuestas = new List<Clases.Respuesta>();

            for (int k = 0; k < listaRespuestas.Count; k++)
            {
                Clases.Respuesta respuestaTemporal = new Clases.Respuesta(listaRespuestas[k].Text);
                respuestas.Add(respuestaTemporal);
            }
			preguntaDAO.insertPregunta(pregunta, respuestas);
			MessageBox.Show ("Añadida");
        }

        private void comboAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Actualiza el combo de los temas al cambiar la asignatura
            comboTema.Items.Clear();
			List<String> listaTemas = new List<String>();
			int idAsignatura = asignaturaDAO.findAsignaturaByName (this.comboAsignatura.SelectedItem.ToString());
			listaTemas = asignaturaDAO.getTemas(idAsignatura);
			
			for(int k=0; k< listaTemas.Count;k++)
			{
				comboTema.Items.Add(listaTemas[k]);
			}
        }
    }
}