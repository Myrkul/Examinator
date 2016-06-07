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
    public partial class FGenerar : Form
    {
		private DAO.Tema_DAO temaDAO;
		private DAO.ExamenNota_DAO examenNotaDAO;
		private DAO.Asignatura_DAO asignaturaDAO;
		private DAO.PreguntaRespuesta_DAO preguntaRespuestaDAO;

        public FGenerar()
        {
            InitializeComponent();
			temaDAO = new DAO.Tema_DAO ();
			examenNotaDAO = new DAO.ExamenNota_DAO ();
			asignaturaDAO = new DAO.Asignatura_DAO ();
			preguntaRespuestaDAO = new DAO.PreguntaRespuesta_DAO ();

			List<String> listaAsig = asignaturaDAO.getAsignaturas();

            for (int k = 0; k < listaAsig.Count; k++)
			{
				comboAsignatura.Items.Add(listaAsig[k]);
			}
        }

        private void checkFinal_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox final = (CheckBox)sender;

            if (final.Checked)
            {
                comboTema.Enabled = false;
            }
            else
            {
                comboTema.Enabled = true;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int numPreguntas;
            int numRespuestas;
            int valorPreguntaAcertada;
            int valorPreguntaFallada;
            int valorPreguntaVacia;
            List<int> listaPreguntasTotales = new List<int>();
            List<int> listaPreguntasEscogidas = new List<int>();

            if (comboAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar la asignatura.");
                return;
            }
            if(tNumero.Text.Equals("") || tNumero.Text.Equals("0"))
            {
                MessageBox.Show("Introduzca el número de preguntas.");
                return;
            }
            try
            {
                numPreguntas = Convert.ToInt32(tNumero.Text);
                valorPreguntaAcertada = 10 / numPreguntas;
            }
            catch
            {
                MessageBox.Show("Introduzca un número válido de preguntas.");
                return;
            }
            try
            {
                numRespuestas = Convert.ToInt32(tNumRespuestas.Text);
            }
            catch
            {
                MessageBox.Show("Introduzca un número válido de respuestas.");
                return;
            }
            try
            {
                valorPreguntaVacia = 1 / Convert.ToInt32(tVacias.Text);
            }
            catch (DivideByZeroException) 
            {
                valorPreguntaVacia = 0;
            }
            catch
            {
                MessageBox.Show("Introduzca un valor válido.");
                return;
            }
            try
            {
                valorPreguntaFallada = 1 / Convert.ToInt32(tIncorrectas.Text);
            }
            catch (DivideByZeroException) 
            {
                valorPreguntaFallada = 0;
            }
            catch
            {
                MessageBox.Show("Introduzca un valor válido.");
                return;
            }

			String tema = comboTema.SelectedItem.ToString();

            listaPreguntasTotales = preguntaRespuestaDAO.getPreguntas(temaDAO.findTemaByName(tema), numRespuestas);

            if (numPreguntas > listaPreguntasTotales.Count)
            {
                MessageBox.Show("No hay tantas preguntas guardadas.");
                return;
            }
            Random rnd = new Random();
			int k = 0;
			do {
				int indice = rnd.Next (1, listaPreguntasTotales.Count);
				if(!listaPreguntasEscogidas.Contains(listaPreguntasTotales [indice - 1])) {
					listaPreguntasEscogidas.Add (listaPreguntasTotales [indice - 1]);
					k++;
				}
			} while(numPreguntas > k);
			Clases.Examen examen = new Clases.Examen(temaDAO.findTemaByName(tema), numPreguntas, numRespuestas);
			examen = examenNotaDAO.insertExamen(examen, listaPreguntasEscogidas);
            Utils.Generar.generarPDF(examen);
			MessageBox.Show("Generado.");
        }

        private void comboAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboTema.Items.Clear();
            List<String> listaTemas = new List<String>();
			int idAsignatura = asignaturaDAO.findAsignaturaByName (this.comboAsignatura.SelectedItem.ToString ());
			listaTemas = asignaturaDAO.getTemas(idAsignatura);

            for (int k = 0; k < listaTemas.Count; k++)
			{
				comboTema.Items.Add(listaTemas[k]);
			}
        }
    }
}