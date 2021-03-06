﻿using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class PreguntaRespuesta_DAO : DAO.Comun_DAO
	{
		public PreguntaRespuesta_DAO () : base()
		{}

        //Inserta una pregunta
		public Clases.Pregunta insertPregunta(Clases.Pregunta pregunta, List<Clases.Respuesta> respuestas)
		{
			String enunciado = pregunta.getEnunciado();
			int correcta = pregunta.getCorrecta();
			int idTema = pregunta.getTema();

			String cadena = "INSERT " +
				"INTO Preguntas (Enunciado, idCorrecta, idTema) " +
				"VALUES ('" + enunciado + "', '" + correcta + "', '" + idTema + "')";
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

        //Inserta una respuesta (Usado solo por el método anterior)
		private void insertRespuesta(Clases.Respuesta respuesta)
		{
			String cadena = "INSERT " +
				"INTO Respuestas (Texto) " +
				"VALUES ('" + respuesta.getTexto() + "')";
			this.execNonQuery(cadena);
		}

        //Devuelve una lista de preguntas de un tema que tengan más de un número de respuestas
		public List<int> getPreguntas(int idTema, int numRespuestas)
		{
			String cadena = "SELECT p.idPregunta " +
			                "FROM  Preguntas p INNER JOIN Preguntas_Respuestas pr ON pr.idPregunta = p.idPregunta " +
			                "WHERE p.idTema IS '" + idTema + "' " +
			                "GROUP BY pr.idPregunta " +
			                "HAVING COUNT(pr.idPregunta) > " + numRespuestas + "";
			return execQueryListInt(cadena);
		}

        //Actualiza el DataGridView de las preguntas de un tema
		public DataTable getPreguntasByTemaDataTable(int idTema)
		{
			String cadena = "SELECT idPregunta AS ID, Enunciado " +
				"FROM Preguntas " + 
				"WHERE idTema IS " + idTema;
			return execQueryTable(cadena);
		}

        //Devuelve la ID de la respuesta dado su texto
		private int findRespuestaByTexto(String respuesta)
		{
			String cadena = "SELECT idRespuesta " +
				"FROM Respuestas " +
				"WHERE Texto IS '" + respuesta + "'";
			return execQueryInt(cadena);
		}

        //Devuelve el texto de una respuesta dada su ID
		public String findRespuestaById(int id)
		{
			String cadena = "SELECT Texto " +
				"FROM Respuestas " +
				"WHERE idRespuesta IS '" + id + "'";
			return execQueryString(cadena);
		}

        //Elimina una pregunta (Y sus respuestas)
        public void deletePregunta(int idPregunta)
        {

            String cadena = "SELECT r.idRespuesta " +
                            "FROM Respuestas r INNER JOIN Preguntas_Respuestas pr ON r.idRespuesta = pr.idRespuesta " +
                            "WHERE pr.idPregunta IS " + idPregunta;

            List<int> listaRespuestas = execQueryListInt(cadena);

            cadena = "DELETE " +
                "FROM Preguntas_Respuestas " +
                "WHERE idPregunta IS (" + idPregunta + ")";
            this.execNonQuery(cadena);

            cadena = "DELETE " +
                "FROM Preguntas " +
                "WHERE idPregunta IS (" + idPregunta + ")";
            this.execNonQuery(cadena);

            for (int k = 0; k < listaRespuestas.Count; k++)
            {
                cadena = "DELETE " +
                "FROM Respuestas " +
                "WHERE idRespuesta IS (" + listaRespuestas[k] + ")";
                this.execNonQuery(cadena);
            }
        }

        //Devuelve las respuestas de una pregunta en orden aleatorio
		public List<int> getRespuestasPregunta(int id, int numRespuestas)
		{
			String cadena = "SELECT idCorrecta" +
				" FROM Preguntas" +
				" WHERE idPregunta IS " + id;
			
			int correcta = execQueryInt (cadena);

			cadena = "SELECT r.idRespuesta " +
			                "FROM Respuestas r INNER JOIN Preguntas_Respuestas pr ON r.idRespuesta = pr.idRespuesta " +
			                "WHERE pr.idPregunta IS " + id;
			
			List<int> listaTotalRespuestas = execQueryListInt (cadena);
			List<int> listaFinalRespuestas = new List<int> ();
			listaFinalRespuestas.Add (listaTotalRespuestas [correcta - 1]);

			Random rng = new Random ();
			int k = 0;
			do {
				int indice = rng.Next(0, listaTotalRespuestas.Count - 1);
				if(!listaFinalRespuestas.Contains(listaTotalRespuestas[indice]))
				{
					k++;
					listaFinalRespuestas.Add(listaTotalRespuestas[indice]);
				}
			} while(k < numRespuestas - 1);

			return listaFinalRespuestas;
		}

        //Actualiza el DataGridView de las preguntas de un examen
        public DataTable actualizarTablaPreguntas(int idExamen)
        {
            String cadena = "SELECT p.idPregunta AS ID, p.Enunciado " +
                "FROM Preguntas p INNER JOIN Examenes_Preguntas ep ON p.idPregunta = ep.idPregunta " + 
                "WHERE ep.idExamen IS " + idExamen;
            return execQueryTable(cadena);
        }

        //Devuelve la ID de una pregunta dado su texto
		private int findPreguntaByEnunciado(String pregunta)
		{
			String cadena = "SELECT idPregunta " +
				"FROM Preguntas " +
				"WHERE Enunciado IS '" + pregunta + "'";
			return execQueryInt(cadena);
		}

        //Devuelve el texto de una pregunta dada su ID
		public String findPreguntaById(int id)
		{
			String cadena = "SELECT Enunciado " +
				"FROM Preguntas " +
				"WHERE idPregunta IS " + id;
			return execQueryString(cadena);
		}

        //Devuelve las preguntas de un examen
		public List<int> getPreguntasExamen(int idExamen)
		{
			String cadena = "SELECT p.idPregunta " +
				"FROM Preguntas p INNER JOIN Examenes_Preguntas ep ON p.idPregunta = ep.idPregunta " +
				"WHERE ep.idExamen IS " + idExamen;
			return execQueryListInt(cadena);
		}
	}
}