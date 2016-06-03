using System;
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