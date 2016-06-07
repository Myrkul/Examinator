using System;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace Examinator.DAO
{
    //Clase de la que heredan los demás DAOs
    //Contiene todos los métodos que acceden directamente a la base de datos

	public class Comun_DAO
	{
		private static String rutaBBDD = "";
        private String conexion;

		public Comun_DAO ()
		{
			rutaBBDD = Directory.GetCurrentDirectory () + "\\examinator.db3";
			conexion = "Data Source=" + rutaBBDD + ";Synchronous=Full;Compress=True;";
		}

        //Ejecuta una sentencia que no devuelve datos
		protected void execNonQuery(String cadena)
		{
            using (SQLiteConnection conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cadena, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
		}

        //Ejecuta una sentencia y devuelve un entero
		protected int execQueryInt(String cadena)
		{
            using (SQLiteConnection conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cadena, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        return rdr.GetInt32(0);
                    }
                }
            }
		}

        //Ejecuta una sentencia y devuelve un string
		protected String execQueryString(String cadena)
		{
            using (SQLiteConnection conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cadena, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        return rdr.GetString(0);
                    }
                }
            }
		}

        //Ejecuta una sentencia para el llenado de un DataGridView
		protected DataTable execQueryTable(String cadena)
		{
            using (SQLiteConnection conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cadena, conn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
		}

        //Ejecuta una sentencia y devuelve una lista de enteros
		protected List<int> execQueryListInt(String cadena)
		{
            List<int> lista = new List<int>();
            using (SQLiteConnection conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cadena, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(rdr.GetInt32(0));
                        }
                        return lista;
                    }
                }
            }
		}

        //Ejecuta una sentencia y devuelve una lista de strings
		protected List<String> execQueryListString(String cadena)
		{
			List<String> lista = new List<String>();
            using (SQLiteConnection conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(cadena, conn))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(rdr.GetString(0));
                        }
                        return lista;
                    }
                }
            }
		}

        //Devuelve el ID de la última fila insertada
		protected int findLastID()
		{
			String cadena = "SELECT idExamen " + 
                "FROM Examenes " + 
                "ORDER BY idExamen DESC " + 
                "LIMIT 1";

                return this.execQueryInt(cadena);
		}

        //Actualiza la tabla con la relación entre las preguntas y respuestas
		protected void updateRelacionPreguntaRespuesta(Clases.Pregunta pregunta, Clases.Respuesta respuesta)
		{
			String cadena = "INSERT " +
				"INTO Preguntas_Respuestas (idPregunta, idRespuesta) " +
				"VALUES ('" + pregunta.getIdPregunta() + "', '" + respuesta.getIdRespuesta() + "')";
			this.execNonQuery(cadena);
		}

        //Actualiza la tabla con la relación entre los exámenes y las notas (No implementado aún)
		protected void updateRelacionExamenNota(Clases.Examen examen, Clases.Nota nota)
		{
			String cadena = "INSERT " +
				"INTO Examenes_Notas (idExamen, idNota) " +
				"VALUES ('" + examen.getIdExamen() + "', '" + nota.getIdNota() + "')";
			this.execNonQuery(cadena);
		}
	}
}

