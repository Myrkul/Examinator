using System;
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

        public FExamenes()
        {
            InitializeComponent();

            examenNotaDAO = new DAO.ExamenNota_DAO();
            preguntaRespuestaDAO = new DAO.PreguntaRespuesta_DAO();

            tablaExamenes.DataSource = examenNotaDAO.actualizarTablaExamenes();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tablaExamenes_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaExamenes.SelectedRows.Count > 0)
            {
                int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);
                tablaPreguntas.DataSource = preguntaRespuestaDAO.actualizarTablaPreguntas(idExamen);
            }
        }

        private void btnEliminarExamen_Click(object sender, EventArgs e)
        {
            try
            {
                int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);
                examenNotaDAO.deleteExamen(idExamen);
                tablaExamenes.DataSource = examenNotaDAO.actualizarTablaExamenes();
            }
            catch (ArgumentOutOfRangeException) { }
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
            catch (ArgumentOutOfRangeException) { }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idExamen = Convert.ToInt32(tablaExamenes.SelectedRows[0].Cells[0].Value);

            Clases.Examen examen = examenNotaDAO.getExamen(idExamen);
            Utils.Generar.generarPDF(examen);
        }

        private void comboClase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPregunta_Click(object sender, EventArgs e)
        {

        }
    }
}
