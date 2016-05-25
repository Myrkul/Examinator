using System;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class PreguntaRespuesta_DAO : DAO.Comun_DAO
	{
		public PreguntaRespuesta_DAO (){}

		public Clases.Pregunta insertPregunta(Clases.Pregunta pregunta, List<Clases.Respuesta> respuestas)
		{
			String enunciado = pregunta.getEnunciado();
			int correcta = pregunta.getCorrecta();
			int idTema = pregunta.getTema();

			String cadena = "INSERT INTO Preguntas (Enunciado, idCorrecta, idTema) VALUES ('" + enunciado + "', '" + correcta + "', '" + idTema + "')";
			this.execNonQuery(cadena);
			pregunta.setIdPregunta(this.findPreguntaByEnunciado(pregunta.getEnunciado()));

			for (int k = 0; k < respuestas.Count; k++)
			{
				this.insertRespuesta(respuestas[k]);
				respuestas[k].setIdRespuesta(this.findRespuestaByTexto(respuestas[k].getTexto()));
				this.updateRelacionPreguntaRespuesta(pregunta, respuestas[k]);
			}

			return pregunta;
		}

		private void insertRespuesta(Clases.Respuesta respuesta)
		{
			String cadena = "INSERT INTO Respuestas (Texto) VALUES ('" + respuesta.getTexto() + "')";
			this.execNonQuery(cadena);
		}

		public List<int> getPreguntas(int idTema, int numRespuestas)
		{
			String cadena = "SELECT p.idPregunta " +
			                "FROM  Preguntas p INNER JOIN Preguntas_Respuestas pr ON pr.idPregunta = p.idPregunta " +
			                "WHERE p.idTema IS '" + idTema + "'" +
			                "GROUP BY pr.idPregunta " +
			                "HAVING COUNT(pr.idPregunta) > '" + numRespuestas + "'";
			return execQueryListInt(cadena);
		}

		private int findRespuestaByTexto(String respuesta)
		{
			String cadena = "SELECT idRespuesta FROM Respuestas WHERE Texto IS '" + respuesta + "'";
			return execQueryInt(cadena);
		}

		private int findPreguntaByEnunciado(String pregunta)
		{
			String cadena = "SELECT idPregunta FROM Preguntas WHERE Enunciado IS '" + pregunta + "'";
			return execQueryInt(cadena);
		}
	}
}