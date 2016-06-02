using System;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class Comun_DAO
	{
		private static SQLiteConnection conn;
		private DirectoryInfo temp;
		private DirectoryInfo directorio;

		public Comun_DAO ()
		{
			temp = new DirectoryInfo(Directory.GetCurrentDirectory());
			directorio = temp.Parent.Parent;
			String conexion = "Data Source=" + directorio.FullName + "\\examinator.db3;Synchronous=Full;Compress=True;";
			conn = new SQLiteConnection(conexion);
			conn.Open();
		}

		protected void execNonQuery(String cadena)
		{
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			cmd.ExecuteNonQuery();
		}

		protected int execQueryInt(String cadena)
		{
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			SQLiteDataReader rdr = cmd.ExecuteReader();
			rdr.Read();
			return rdr.GetInt32(0);
		}

		protected String execQueryString(String cadena)
		{
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			SQLiteDataReader rdr = cmd.ExecuteReader();
			rdr.Read();
			return rdr.GetString(0);
		}

		protected DataTable execQueryTable(String cadena)
		{
			SQLiteDataAdapter da = new SQLiteDataAdapter(cadena, conn);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds.Tables[0];
		}

		protected List<int> execQueryListInt(String cadena)
		{
			List<int> lista = new List<int>();
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			SQLiteDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				lista.Add(rdr.GetInt32(0));
			}
			return lista;
		}

		protected List<String> execQueryListString(String cadena)
		{
			List<String> lista = new List<String>();
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			SQLiteDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				lista.Add(rdr.GetString(0));
			}
			return lista;
		}

		protected int findLastID()
		{
			String cadena = "SELECT last_insert_rowid()";
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			return Convert.ToInt32(cmd.ExecuteScalar ());
		}

		protected void updateRelacionPreguntaRespuesta(Clases.Pregunta pregunta, Clases.Respuesta respuesta)
		{
			String cadena = "INSERT " +
				"INTO Preguntas_Respuestas (idPregunta, idRespuesta) " +
				"VALUES ('" + pregunta.getIdPregunta() + "', '" + respuesta.getIdRespuesta() + "')";
			this.execNonQuery(cadena);
		}

		protected void updateRelacionExamenNota(Clases.Examen examen, Clases.Nota nota)
		{
			String cadena = "INSERT " +
				"INTO Examenes_Notas (idExamen, idNota) " +
				"VALUES ('" + examen.getIdExamen() + "', '" + nota.getIdNota() + "')";
			this.execNonQuery(cadena);
		}
	}
}

