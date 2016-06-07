using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class ExamenNota_DAO : DAO.Comun_DAO
	{
		public ExamenNota_DAO () : base()
		{}

		public Clases.Nota insertNota(Clases.Nota nota)
		{
			String cadena = "INSERT " +
				"INTO Notas (idAlumno, nota) " +
				"VALUES ('" + nota.getIdAlumno() + "', '" + nota.getNota() + "')";
			execNonQuery(cadena);
			return nota;
		}

		public Clases.Examen insertExamen(Clases.Examen examen, List<int> preguntas)
		{
			String cadena = "INSERT " +
				"INTO Examenes (idTema) " +
				"VALUES ('" + examen.getIdTema() + "')";
			execNonQuery(cadena);
			examen.setIdExamen (this.findLastID());
			this.updateRelacionExamenPreguntas(examen, preguntas);
			return examen;
		}

		public void insertPreguntaEnExamen(int idExamen, int idPregunta)
		{
			String cadena = "INSERT " +
			                "INTO Examenes_Preguntas " +
			                "VALUES ('" + idExamen + "',' " + idPregunta + "')";
			execNonQuery(cadena);
		}

        public void deleteExamen(int idExamen)
        {
            String cadena = "DELETE " +
                "FROM Examenes " +
                "WHERE idExamen IS (" + idExamen + ")";
            this.execNonQuery(cadena);
        }

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

		public DataTable actualizarTablaExamenes(int idTema)
        {
            String cadena = "SELECT e.idExamen AS ID, t.Nombre " +
                "FROM Examenes e INNER JOIN Temas t ON e.idTema = t.idTema " +
				"WHERE e.idTema IS " + idTema;
			Console.WriteLine (cadena);
            return execQueryTable(cadena);
        }

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