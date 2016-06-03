using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class Tema_DAO : DAO.Comun_DAO
	{
		public Tema_DAO () : base()
		{}

		public Clases.Tema insertTema(Clases.Tema tema)
		{
			String cadena = "INSERT " +
				"INTO Temas (Nombre, idAsignatura) " +
				"VALUES ('" + tema.getNombre() + "', '" + tema.getIdAsig() + "')";
			this.execNonQuery(cadena);
			tema.setIdTema(this.findTemaByName(tema.getNombre()));
			return tema;
		}

		public void deleteTema(int idTema)
		{
			String cadena = "DELETE " +
				"FROM Temas " +
				"WHERE idTema IS (" + idTema + ")";
			this.execNonQuery(cadena);
		}

		public DataTable actualizarTablaTemas(int idAsig)
		{
			String cadena = "SELECT idTema AS ID, Nombre " + 
				"FROM Temas " + 
				"WHERE idAsignatura IS '" + idAsig + "'";
			return execQueryTable(cadena);
		}

		public int findTemaByName(String tema)
		{
			String cadena = "SELECT idTema " +
				"FROM Temas WHERE " +
				"Nombre IS '" + tema + "'";
			return execQueryInt(cadena);
		}

		public String findTemaById(int id)
		{
			String cadena = "SELECT Nombre " +
				"FROM Temas " +
				"WHERE idTema IS " + id;
			return execQueryString(cadena);
		}
	}
}

