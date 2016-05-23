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
        private DAO.DAORepo repo;

        public FAsignaturas()
        {
            InitializeComponent();
            repo = new DAO.DAORepo();
            tablaAsignaturas.DataSource = repo.actualizarTablaAsig();
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
            asignatura = repo.insertAsignatura(asignatura);
            tablaAsignaturas.DataSource = repo.actualizarTablaAsig();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
			int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
			
            repo.deleteAsignatura(idAsignatura);
            tablaAsignaturas.DataSource = repo.actualizarTablaAsig();
        }

        private void btnEliminarTema_Click(object sender, EventArgs e)
        {
			int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
			int idTema = Convert.ToInt32(tablaTemas.SelectedRows[0].Cells[0].Value));
			
            repo.deleteTema(idTema));
            tablaTemas.DataSource = repo.actualizarTablaTemas(idAsignatura);
        }

        private void btnAddTema_Click(object sender, EventArgs e)
        {
            if (tNombreTema.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
			Clases.Tema tema = new Clases.Tema(tNombreTema.Text, Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value));
            tema = repo.insertTema(tema);
            tablaTemas.DataSource = repo.actualizarTablaTemas(tema.getIdAsig());
        }

        private void tablaAsignaturas_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaAsignaturas.SelectedRows.Count > 0)
            {
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
                tablaTemas.DataSource = repo.actualizarTablaTemas(idAsignatura);
            }
        }
    }
}