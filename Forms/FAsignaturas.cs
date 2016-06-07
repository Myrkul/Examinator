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
        private DAO.Clase_DAO claseDAO;

        public FAsignaturas()
        {
            InitializeComponent();
			asignaturaDAO = new DAO.Asignatura_DAO();
			temaDAO = new DAO.Tema_DAO();
            claseDAO = new DAO.Clase_DAO();

            //Se carga la tabla de asignaturas
			tablaAsignaturas.DataSource = asignaturaDAO.actualizarTablaAsig();

            //Se carga el combo de clases
            List<String> listaClases = claseDAO.getClases();

            for (int k = 0; k < listaClases.Count; k++)
            {
                comboClase.Items.Add(listaClases[k]);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboClase.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una clase.");
                return;
            }
            if(tNombreAsig.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
            String nombreClase = comboClase.SelectedItem.ToString();
            int idClase = claseDAO.findClaseByName(nombreClase);

            //Se inserta una asignatura
            Clases.Asignatura asignatura = new Clases.Asignatura(tNombreAsig.Text, idClase);
			asignatura = asignaturaDAO.insertAsignatura(asignatura);
			tablaAsignaturas.DataSource = asignaturaDAO.actualizarTablaAsig();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
			try{
                //Se elimina una asignatura
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
				asignaturaDAO.deleteAsignatura (idAsignatura);
				tablaAsignaturas.DataSource = asignaturaDAO.actualizarTablaAsig ();
			}
			catch(ArgumentOutOfRangeException){} //Captura la excepción en caso de que no se haya seleccionado ninguna asignatura
        }

        private void btnEliminarTema_Click(object sender, EventArgs e)
        {
			try{
                //Se elimina un tema
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
				int idTema = Convert.ToInt32(tablaTemas.SelectedRows[0].Cells[0].Value);
				temaDAO.deleteTema (idTema);
				tablaTemas.DataSource = temaDAO.actualizarTablaTemas (idAsignatura);
			}
            catch (ArgumentOutOfRangeException) { }//Captura la excepción en caso de que no se haya seleccionado ningun tema

        }

        private void btnAddTema_Click(object sender, EventArgs e)
        {
            if (tNombreTema.Text.Equals(""))
            {
                MessageBox.Show("El nombre no puede ir en blanco.");
                return;
            }
            //Se añade un tema
			Clases.Tema tema = new Clases.Tema(tNombreTema.Text, Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value));
			tema = temaDAO.insertTema(tema);
			tablaTemas.DataSource = temaDAO.actualizarTablaTemas(tema.getIdAsig());
        }

        private void tablaAsignaturas_SelectionChanged(object sender, EventArgs e)
        {
            if (tablaAsignaturas.SelectedRows.Count > 0)
            {
                //Se actualiza la tabla de temas al cambiar la selección de la tabla de asignaturas
				int idAsignatura = Convert.ToInt32(tablaAsignaturas.SelectedRows[0].Cells[0].Value);
				tablaTemas.DataSource = temaDAO.actualizarTablaTemas(idAsignatura);
            }
        }
    }
}