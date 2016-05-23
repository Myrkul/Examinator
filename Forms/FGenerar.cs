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
    public partial class FGenerar : Form
    {
        private DAO.DAORepo repo;

        public FGenerar()
        {
            InitializeComponent();
            repo = new DAO.DAORepo();
            List<String> listaAsig = repo.getAsignaturas();

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
   /*         if (comboTema.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar el tema.");
                return;
            }*/
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
                valorPreguntaVacia = 1 / Convert.ToInt32(tVacias.Text);
            }
            catch (DivideByZeroException a) 
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
            catch (DivideByZeroException a) 
            {
                valorPreguntaFallada = 0;
            }
            catch
            {
                MessageBox.Show("Introduzca un valor válido.");
                return;
            }
			
            String asignatura = comboAsignatura.SelectedItem.ToString();
			String tema = comboTema.SelectedItem.ToString();
			
			listaPreguntasTotales = repo.getPreguntas(asignatura, tema);

            if (numPreguntas > listaPreguntasTotales.Count)
            {
                MessageBox.Show("No hay tantas preguntas guardadas.");
                return;
            }
            Random rnd = new Random();
            for (int i = 0; i < listaPreguntasTotales.Count; i++)
            {
                int indice = rnd.Next(1, listaPreguntasTotales.Count);
                listaPreguntasEscogidas.Add(listaPreguntasTotales[indice - 1]);
            }
			Clases.Examen examen = new Clases.Examen(repo.findTemaByName(tema);
			examen = repo.insertExamen(examen);
			MessageBox.Show("Generado.");
        }

        private void comboAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboTema.Items.Clear();
            List<String> listaTemas = new List<String>();
            listaTemas = repo.cargarTemas(comboAsignatura.GetItemText(this.comboAsignatura.SelectedItem);

            for (int k = 0; k < listaTemas.Count; k++)
			{
				comboTema.Items.Add(listaTemas[k]);
			}
        }
    }
}