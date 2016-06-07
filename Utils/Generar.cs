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

            doc.AddTitle("Examen tema: " + nombreTema);

            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            doc.Add(new Paragraph(nombreAsignatura));
            doc.Add(new Paragraph("Examen tema: " + nombreTema));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Nombre: "));
            doc.Add(Chunk.NEWLINE);

            List<String> listaEnunciados = new List<String>();

            for (int k = 0; k < listaPreguntas.Count; k++)
            {
                listaEnunciados.Add(preguntaRespuestaDAO.findPreguntaById(listaPreguntas[k]));
            }
            PdfPTable tblPrueba = new PdfPTable(2);
            tblPrueba.WidthPercentage = 100;

            PdfPCell clPreguntas = new PdfPCell();
            clPreguntas.BorderWidth = 1;
            clPreguntas.BorderWidthBottom = 0.75f;

            PdfPCell clRespuestas = new PdfPCell();
            clRespuestas.BorderWidth = 1;
            clRespuestas.BorderWidthBottom = 0.75f;

            tblPrueba.AddCell(clPreguntas);
            tblPrueba.AddCell(clRespuestas);

            Random rng = new Random();
            for (int k = 0; k < listaPreguntas.Count; k++)
            {
                clPreguntas = new PdfPCell(new Phrase(listaEnunciados[k], _standardFont));
                clPreguntas.BorderWidth = 0;
                tblPrueba.AddCell(clPreguntas);
                List<int> listaRespuestas = preguntaRespuestaDAO.getRespuestasPregunta(listaPreguntas[k], numRespuestas);

                barajar(listaRespuestas, rng);

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
