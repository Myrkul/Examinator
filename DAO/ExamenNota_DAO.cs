using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class ExamenNota_DAO : DAO.Comun_DAO
	{
		public ExamenNota_DAO () : base()
		{}

        //Inserta una nota (No implementado aún)
		public Clases.Nota insertNota(Clases.Nota nota)
		{
			String cadena = "INSERT " +
				"INTO Notas (idAlumno, nota) " +
				"VALUES ('" + nota.getIdAlumno() + "', '" + nota.getNota() + "')";
			execNonQuery(cadena);
			return nota;
		}

        //Inserta un examen
		public Clases.Examen insertExamen(Clases.Examen examen, List<int> preguntas, int numPreguntas, int numRespuestas)
		{
			String cadena = "INSERT " +
				"INTO Examenes (idTema, numPreguntas, numRespuestas) " +
				"VALUES ('" + examen.getIdTema() + "', '" + numPreguntas + "', '" + numRespuestas + "')";
			execNonQuery(cadena);
			examen.setIdExamen (this.findLastID());
			this.updateRelacionExamenPreguntas(examen, preguntas);
			return examen;
		}

        //Inserta una pregunta en un examen ya existente
		public void insertPreguntaEnExamen(int idExamen, int idPregunta)
		{
			String cadena = "INSERT " +
			                "INTO Examenes_Preguntas " +
			                "VALUES ('" + idExamen + "',' " + idPregunta + "')";
			execNonQuery(cadena);

			cadena = "SELECT numPreguntas " +
				"FROM Examenes " +
				"WHERE idExamen IS " + idExamen;
			Console.WriteLine (cadena);
			int numPreguntas = execQueryInt(cadena);

			cadena = "UPDATE Examenes " +
				"SET numPreguntas = " + (numPreguntas+1) + " " +
				"WHERE idExamen IS " + idExamen;
			execNonQuery(cadena);
		}

        //Elimina un examen por ID
        public void deleteExamen(int idExamen)
        {
            String cadena = "DELETE " +
                "FROM Examenes " +
                "WHERE idExamen IS (" + idExamen + ")";
            this.execNonQuery(cadena);
        }

        //Devuelve un examen a partir de una ID
        public Clases.Examen getExamen(int idExamen)
        {
            Clases.Examen examen;
            int idTema;
            int numPreguntas;
            int numRespuestas;

            String cadena = "SELECT idTema " +
                "FROM Examenes " +
                "WHERE idExamen IS (" + idExamen + ")";
            idTema = this.execQueryInt(cadena);

            cadena = "SELECT numPreguntas " +
                "FROM Examenes " +
                "WHERE idExamen IS (" + idExamen + ")";
            numPreguntas = this.execQueryInt(cadena);

            cadena = "SELECT numRespuestas " +
                "FROM Examenes " +
                "WHERE idExamen IS (" + idExamen + ")";
            numRespuestas = this.execQueryInt(cadena);

            examen = new Clases.Examen(idTema, numPreguntas, numRespuestas);
            return examen;
        }

        //Actualiza el DataGridView de los exámenes de un tema
		public DataTable actualizarTablaExamenes(int idTema)
        {
            String cadena = "SELECT e.idExamen AS ID, t.Nombre " +
                "FROM Examenes e INNER JOIN Temas t ON e.idTema = t.idTema " +
				"WHERE e.idTema IS " + idTema;
			Console.WriteLine (cadena);
            return execQueryTable(cadena);
        }

        //Actualiza la tabla con la relación entre los exámenes y las preguntas
		private void updateRelacionExamenPreguntas(Clases.Examen examen, List<int> preguntas)
		{
			for (int k = 0; k < preguntas.Count; k++) {
				String cadena = "INSERT " +
					"INTO Examenes_Preguntas (idExamen, idPregunta) " +
					"VALUES('" + examen.getIdExamen () + "', '" + preguntas[k] + "')";
				this.execNonQuery (cadena);
			}
		}
	}
}