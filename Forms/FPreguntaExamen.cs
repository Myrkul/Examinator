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
    public partial class FPreguntaExamen : Form
    {
		private int idExamen;
		private int idTema;
		private DAO.ExamenNota_DAO examenNotaDAO;
		private DAO.PreguntaRespuesta_DAO preguntaRespuestaDAO;
		private DAO.Tema_DAO temaDAO;
		private DataGridView tablaPreguntasExamen;

		public FPreguntaExamen(int idExamen, DataGridView tablaPreguntasExamen)
        {
			examenNotaDAO = new DAO.ExamenNota_DAO ();
			preguntaRespuestaDAO = new DAO.PreguntaRespuesta_DAO ();
			temaDAO = new DAO.Tema_DAO ();

            //Guarda el DataGridView que se le pasa por parámetro
            //Para poder actualizar la tabla de preguntas del form anterior
            //Cuando se añada una nueva
			this.tablaPreguntasExamen = tablaPreguntasExamen;

			InitializeComponent();

            //Inicializa la tabla de preguntas de ese tema
			this.idExamen = idExamen;
			idTema = temaDAO.findTemaByExamen(this.idExamen);
			tablaPreguntas.DataSource = preguntaRespuestaDAO.getPreguntasByTemaDataTable (this.idTema);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
			try {
				int idPregunta = Convert.ToInt32(tablaPreguntas.SelectedRows [0].Cells [0].Value);
				examenNotaDAO.insertPreguntaEnExamen (idExamen, idPregunta);
				this.tablaPreguntasExamen.DataSource = preguntaRespuestaDAO.actualizarTablaPreguntas(idExamen);
			} catch(ArgumentOutOfRangeException) {
				MessageBox.Show ("Debe seleccionar una pregunta.");
			}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
			this.Dispose ();
        }
    }
}
