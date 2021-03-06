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
    public partial class FExamenes : Form
    {
        private DAO.ExamenNota_DAO examenNotaDAO;
        private DAO.PreguntaRespuesta_DAO preguntaRespuestaDAO;
		private DAO.Clase_DAO claseDAO;
		private DAO.Asignatura_DAO asignaturaDAO;
		private DAO.Tema_DAO temaDAO;

        public FExamenes()
        {
            InitializeComponent();

            examenNotaDAO = new DAO.ExamenNota_DAO();
            preguntaRespuestaDAO = new DAO.PreguntaRespuesta_DAO();
			claseDAO = new DAO.Clase_DAO ();
			asignaturaDAO = new DAO.Asignatura_DAO ();
			temaDAO = new DAO.Tema_DAO ();

			List<String> listaClases = claseDAO.getClases();

            //Se carga el combo de clases
			for (int k = 0; k < listaClases.Count; k++)
			{
				comboClase.Items.Add(listaClases[k]);
			}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tablaExamenes_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaExamenes.SelectedRows.Count > 0)
            {
                //Se actualiza la tabla de preguntas al cambiar la selección de la tabla de exámenes
                int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);
                tablaPreguntas.DataSource = preguntaRespuestaDAO.actualizarTablaPreguntas(idExamen);
            }
        }

        private void btnEliminarExamen_Click(object sender, EventArgs e)
        {
            try
            {
                //Se elimina el examen
                int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);
				String clase = comboClase.SelectedItem.ToString();
				int idClase = claseDAO.findClaseByName (clase);
                examenNotaDAO.deleteExamen(idExamen);
				tablaExamenes.DataSource = examenNotaDAO.actualizarTablaExamenes(idClase);
            }
            catch (ArgumentOutOfRangeException) { } //Captura la excepción en caso de que no se haya seleccionado ningun examen
        }

        private void btnEliminarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);
                int idPregunta = Convert.ToInt32(tablaPreguntas.SelectedRows[0].Cells[0].Value);

                preguntaRespuestaDAO.deletePregunta(idPregunta);
                tablaPreguntas.DataSource = preguntaRespuestaDAO.actualizarTablaPreguntas(idExamen);
            }
            catch (ArgumentOutOfRangeException) { } //Captura la excepción en caso de que no se haya seleccionado ninguna pregunta
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);

            Clases.Examen examen = examenNotaDAO.getExamen(idExamen);
            examen.setIdExamen(idExamen);
            Utils.Generar.generarPDF(examen);
        }

        private void comboClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Actualiza el combo de las asignaturas al cambiar la clase
			String clase = comboClase.SelectedItem.ToString();
			int idClase = claseDAO.findClaseByName (clase);
			List<String> listaAsignaturas = asignaturaDAO.getAsignaturasByClase(idClase);
			comboAsignatura.Items.Clear ();
			for (int k = 0; k < listaAsignaturas.Count; k++)
			{
				comboAsignatura.Items.Add(listaAsignaturas[k]);
			}
			comboTema.Items.Clear ();
        }
		private void comboAsignatura_SelectedIndexChanged(object sender, EventArgs e)
		{
            //Actualiza el combo de los temas al cambiar la asignatura
			String asignatura = comboAsignatura.SelectedItem.ToString();
			int idAsignatura = asignaturaDAO.findAsignaturaByName (asignatura);
			List<String> listaTemas = asignaturaDAO.getTemas(idAsignatura);
			comboTema.Items.Clear ();
			for (int k = 0; k < listaTemas.Count; k++)
			{
				comboTema.Items.Add(listaTemas[k]);
			}
		}
		private void comboTema_SelectedIndexChanged(object sender, EventArgs e)
		{
            //Actualiza la tabla de exámenes al cambiar de tema
			String tema = comboTema.SelectedItem.ToString();
			int idTema = temaDAO.findTemaByName (tema);
			tablaExamenes.DataSource = examenNotaDAO.actualizarTablaExamenes(idTema);
		}

        private void btnAddPregunta_Click(object sender, EventArgs e)
        {
			try {
				int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);
				Forms.FPreguntaExamen preguntaExamen = new Forms.FPreguntaExamen (idExamen, tablaPreguntas);
				preguntaExamen.Show ();
            }catch (ArgumentOutOfRangeException) { } //Captura la excepción en caso de que no se haya seleccionado ningun examen
        }
    }
}
