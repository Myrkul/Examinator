using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Examinator.Utils
{
    //Clase auxiliar para el generado de PDFs

    class Generar
    {
        public static void generarPDF(Clases.Examen examen)
        {
            DAO.PreguntaRespuesta_DAO preguntaRespuestaDAO = new DAO.PreguntaRespuesta_DAO ();
            DAO.Tema_DAO temaDAO = new DAO.Tema_DAO();
            DAO.Asignatura_DAO asignaturaDAO = new DAO.Asignatura_DAO();

            List<int> listaPreguntas = preguntaRespuestaDAO.getPreguntasExamen(examen.getIdExamen());
            String nombreTema = temaDAO.findTemaById(examen.getIdTema());
            String nombreAsignatura = asignaturaDAO.findAsignaturaByTema(examen.getIdTema());
            int numRespuestas = examen.getNumRespuestas();

            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = null;

            //Se pregunta por la ruta de guardado
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    writer = PdfWriter.GetInstance(doc,
                        new FileStream(dialog.FileName, FileMode.Create));
                }
            }

            //Título del PDF
            doc.AddTitle("Examen tema: " + nombreTema);

            doc.Open();

            //Fuente por defecto
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            //Cabecera del examen
            doc.Add(new Paragraph(nombreAsignatura));
            doc.Add(new Paragraph("Examen tema: " + nombreTema));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Nombre: "));
            doc.Add(Chunk.NEWLINE);

            List<String> listaEnunciados = new List<String>();

            //Se crea la tabla donde se pintarán las preguntas y las respuestas

            PdfPTable tblPrueba = new PdfPTable(2); //Tabla con dos columnas

            PdfPCell clPreguntas = new PdfPCell();

            PdfPCell clRespuestas = new PdfPCell();

            for (int k = 0; k < listaPreguntas.Count; k++)
            {
                //Se guardan los enunciados de las preguntas
                listaEnunciados.Add(preguntaRespuestaDAO.findPreguntaById(listaPreguntas[k]));
            }

            Random rng = new Random();
            for (int k = 0; k < listaPreguntas.Count; k++)
            {
                //Se añaden los enunciados a la celda de las preguntas
                clPreguntas = new PdfPCell(new Phrase(listaEnunciados[k], _standardFont));
                clPreguntas.BorderWidth = 0;
                tblPrueba.AddCell(clPreguntas);

                //Se guardan las respuestas de la pregunta en orden aleatorio
                List<int> listaRespuestas = preguntaRespuestaDAO.getRespuestasPregunta(listaPreguntas[k], numRespuestas);
                barajar(listaRespuestas, rng);

                //Se añaden las respuestas a la celda como una sola cadena
                String cadenaRespuestas = "";
                for (int i = 0; i < listaRespuestas.Count; i++)
                {
                    
                    cadenaRespuestas += preguntaRespuestaDAO.findRespuestaById(listaRespuestas[i]) + "\n\n\n";
                }
                clRespuestas = new PdfPCell(new Phrase(cadenaRespuestas, _standardFont));
                clRespuestas.BorderWidth = 0;
                tblPrueba.AddCell(clRespuestas);
            }

            doc.Add(tblPrueba);
            doc.Close();
            writer.Close();
        }

        //Método usado para dar aleatoriedad a las respuestas de cada pregunta
        private static void barajar(List<int> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
