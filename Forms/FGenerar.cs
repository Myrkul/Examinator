using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

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
			Clases.Examen examen = new Clases.Examen(temaDAO.findTemaByName(tema));
			examen = examenNotaDAO.insertExamen(examen, listaPreguntasEscogidas);
            this.generarPDF(examen, comboAsignatura.SelectedItem.ToString(), comboTema.SelectedItem.ToString(), listaPreguntasEscogidas, numRespuestas);
			MessageBox.Show("Generado.");
        }

        private void comboAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboTema.Items.Clear();
            List<String> listaTemas = new List<String>();
			listaTemas = asignaturaDAO.cargarAsignaturas(comboAsignatura.GetItemText(this.comboAsignatura.SelectedItem));

            for (int k = 0; k < listaTemas.Count; k++)
			{
				comboTema.Items.Add(listaTemas[k]);
			}
        }

		private void generarPDF(Clases.Examen examen, String nombreAsignatura, String nombreTema, List<int> listaPreguntas, int numRespuestas)
		{
			Document doc = new Document(PageSize.LETTER);

			PdfWriter writer = PdfWriter.GetInstance(doc,
				new FileStream(@"C:\Examen - " + nombreAsignatura + " - " + nombreTema + ".pdf", FileMode.Create));
			
			doc.AddTitle("Examen tema: " + nombreTema);

			// Abrimos el archivo
			doc.Open();

			// Creamos el tipo de Font que vamos utilizar
			iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

			// Escribimos el encabezamiento en el documento
			doc.Add(new Paragraph(nombreAsignatura));
			doc.Add(Chunk.NEWLINE);
			doc.Add(new Paragraph("Examen tema: " + nombreTema));

			// Creamos una tabla que contendrá el nombre, apellido y país
			// de nuestros visitante.
			List<String> listaEnunciados = new List<String> ();

			for (int k = 0; k < listaPreguntas.Count; k++) {
				listaEnunciados.Add(preguntaRespuestaDAO.findPreguntaById(listaPreguntas[k]));
			}
			PdfPTable tblPrueba = new PdfPTable(2);
			tblPrueba.WidthPercentage = 100;

			// Configuramos el título de las columnas de la tabla
			PdfPCell clPreguntas = new PdfPCell();
			clPreguntas.BorderWidth = 1;
			clPreguntas.BorderWidthBottom = 0.75f;

			// Configuramos el título de las columnas de la tabla
			PdfPCell clRespuestas = new PdfPCell();
			clRespuestas.BorderWidth = 1;
			clRespuestas.BorderWidthBottom = 0.75f;

			// Añadimos las celdas a la tabla
			tblPrueba.AddCell(clPreguntas);
			tblPrueba.AddCell(clRespuestas);

			Random rng = new Random(); 
			for (int k = 0; k < listaPreguntas.Count; k++) {
				// Llenamos la tabla con información
				clPreguntas = new PdfPCell (new Phrase (listaEnunciados[k], _standardFont));
				clPreguntas.BorderWidth = 0;
				tblPrueba.AddCell(clPreguntas);
				List<int> listaRespuestas = preguntaRespuestaDAO.getRespuestasPregunta (listaPreguntas [k]);

				this.barajar (listaRespuestas, rng);

				String cadenaRespuestas = "";
				for(int i=0; i<listaRespuestas.Count; i++){
					cadenaRespuestas += preguntaRespuestaDAO.findRespuestaById (listaRespuestas [i]) + "\n";
				}
				clRespuestas = new PdfPCell (new Phrase (cadenaRespuestas, _standardFont));
				clRespuestas.BorderWidth = 0;
				tblPrueba.AddCell(clRespuestas);
			}

			// Finalmente, añadimos la tabla al documento PDF y cerramos el documento
			doc.Add(tblPrueba);

			doc.Close();
			writer.Close();
		}

		private void barajar(List<int> list, Random rng)  
		{
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = rng.Next(n + 1);  
				int value = list[k];  
				list[k] = list[n];  
				list[n] = value;  
			}  
		}
    }
}