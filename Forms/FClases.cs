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
    public partial class FClases : Form
    {
		private DAO.Alumno_DAO alumnoDAO;
		private DAO.Clase_DAO claseDAO;

        public FClases()
        {
            InitializeComponent();
			claseDAO = new DAO.Clase_DAO ();
			alumnoDAO = new DAO.Alumno_DAO ();

            this.actualizarTablaClases();
        }

        private void actualizarTablaClases()
        {
			tablaClases.DataSource = claseDAO.actualizarTablaClases();
        }

        private void actualizarTablaAlumnos()
        {
			tablaAlumnos.DataSource = alumnoDAO.actualizarTablaAlumnos(Convert.ToInt32(tablaClases.SelectedRows[0].Cells[0].Value));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddClase_Click(object sender, EventArgs e)
        {
            if (tNombreClase.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
            Clases.Clase clase = new Clases.Clase(tNombreClase.Text);
			claseDAO.insertClase(clase);
            this.actualizarTablaClases();
        }

        private void btnEliminarClase_Click(object sender, EventArgs e)
        {
			claseDAO.deleteClase(Convert.ToInt32(tablaClases.SelectedRows[0].Cells[0].Value));
            this.actualizarTablaClases();
        }

        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {
			alumnoDAO.deleteAlumno(Convert.ToInt32(tablaAlumnos.SelectedRows[0].Cells[0].Value));
            actualizarTablaAlumnos();
        }

        private void btnAddAlumno_Click(object sender, EventArgs e)
        {
            if (tNombreAlumno.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
            if (tApellidosAlumno.Text.Equals(""))
            {
                MessageBox.Show("Los apellidos no pueden ir en blanco.");
                return;
            }
            Clases.Alumno alumno = new Clases.Alumno(tNombreAlumno.Text, tApellidosAlumno.Text, Convert.ToInt32(tablaClases.SelectedRows[0].Cells[0].Value));
			alumnoDAO.insertAlumno(alumno);
			tablaAlumnos.DataSource = alumnoDAO.actualizarTablaAlumnos(alumno.getIdClase());
        }

        private void tablaClases_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaClases.SelectedRows.Count > 0)
            {
                actualizarTablaAlumnos();
            }
        }
    }
}
