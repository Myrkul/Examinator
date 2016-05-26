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
    public partial class FAsignaturas : Form
    {
		private DAO.Asignatura_DAO asignaturaDAO;
		private DAO.Tema_DAO temaDAO;

        public FAsignaturas()
        {
            InitializeComponent();
			asignaturaDAO = new DAO.Asignatura_DAO();
			temaDAO = new DAO.Tema_DAO();

			tablaAsignaturas.DataSource = asignaturaDAO.actualizarTablaAsig();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tNombreAsig.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
            Clases.Asignatura asignatura = new Clases.Asignatura(tNombreAsig.Text);
			asignatura = asignaturaDAO.insertAsignatura(asignatura);
			tablaAsignaturas.DataSource = asignaturaDAO.actualizarTablaAsig();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
			try{
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
				asignaturaDAO.deleteAsignatura (idAsignatura);
				tablaAsignaturas.DataSource = asignaturaDAO.actualizarTablaAsig ();
			}
			catch(ArgumentOutOfRangeException){}
        }

        private void btnEliminarTema_Click(object sender, EventArgs e)
        {
			try{
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
				int idTema = Convert.ToInt32(tablaTemas.SelectedRows[0].Cells[0].Value);

				temaDAO.deleteTema (idTema);
				tablaTemas.DataSource = temaDAO.actualizarTablaTemas (idAsignatura);
			}
			catch(ArgumentOutOfRangeException){}

        }

        private void btnAddTema_Click(object sender, EventArgs e)
        {
            if (tNombreTema.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
			Clases.Tema tema = new Clases.Tema(tNombreTema.Text, Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value));
			tema = temaDAO.insertTema(tema);
			tablaTemas.DataSource = temaDAO.actualizarTablaTemas(tema.getIdAsig());
        }

        private void tablaAsignaturas_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaAsignaturas.SelectedRows.Count > 0)
            {
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
				tablaTemas.DataSource = temaDAO.actualizarTablaTemas(idAsignatura);
            }
        }
    }
}