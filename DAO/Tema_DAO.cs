using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class Tema_DAO : DAO.Comun_DAO
	{
		public Tema_DAO () : base()
		{}

        //Inserta un tema
		public Clases.Tema insertTema(Clases.Tema tema)
		{
			String cadena = "INSERT " +
				"INTO Temas (Nombre, idAsignatura) " +
				"VALUES ('" + tema.getNombre() + "', '" + tema.getIdAsig() + "')";
			this.execNonQuery(cadena);
			tema.setIdTema(this.findTemaByName(tema.getNombre()));
			return tema;
		}

        //Elimina un tema
		public void deleteTema(int idTema)
		{
			String cadena = "DELETE " +
				"FROM Temas " +
				"WHERE idTema IS (" + idTema + ")";
			this.execNonQuery(cadena);
		}

        //Actualiza el DataGridView de los temas de una asignatura
		public DataTable actualizarTablaTemas(int idAsig)
		{
			String cadena = "SELECT idTema AS ID, Nombre " + 
				"FROM Temas " + 
				"WHERE idAsignatura IS '" + idAsig + "'";
			return execQueryTable(cadena);
		}

        //Devuelve la ID de un tema dado su nombre
		public int findTemaByName(String tema)
		{
			String cadena = "SELECT idTema " +
				"FROM Temas WHERE " +
				"Nombre IS '" + tema + "'";
			return execQueryInt(cadena);
		}

        //Devuelve el nombre de un tema dada su ID
		public String findTemaById(int id)
		{
			String cadena = "SELECT Nombre " +
				"FROM Temas " +
				"WHERE idTema IS " + id;
			return execQueryString(cadena);
		}

        //Devuelve la ID del tema al que pertenece un examen
		public int findTemaByExamen(int idExamen)
		{
			String cadena = "SELECT idTema " +
				"FROM Examenes " +
				"WHERE idExamen IS " + idExamen;
			return execQueryInt(cadena);
		}
	}
}

