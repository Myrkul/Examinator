using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class Asignatura_DAO : DAO.Comun_DAO
	{
		public Asignatura_DAO () : base()
		{}

        //Inserta una asignatura
		public Clases.Asignatura insertAsignatura(Clases.Asignatura asignatura)
		{
			String cadena = "INSERT " +
				"INTO Asignaturas (Nombre, idClase) " +
				"VALUES ('" + asignatura.getNombre() + "', '" + asignatura.getIdClase() + "')";
			this.execNonQuery(cadena);
			asignatura.setIdAsig(this.findAsignaturaByName(asignatura.getNombre()));
			return asignatura;
		}

        //Elimina una asignatura por ID
		public void deleteAsignatura(int idAsig)
		{
            String cadena = "DELETE " +
                "FROM Asignaturas " +
                "WHERE idAsignatura IS (" + idAsig + ")";
            this.execNonQuery(cadena);
		}

        //Actualiza el DataGridView de todas las asignaturas
		public DataTable actualizarTablaAsig()
		{
            String cadena = "SELECT a.idAsignatura AS ID, c.Nombre AS Clase, a.Nombre AS Asignatura " +
				"FROM Asignaturas a INNER JOIN Clases c ON c.idClase = a.idClase";
			return execQueryTable(cadena);
		}

        //Devuelve todas las asignaturas en una lista de strings para añadirlas a un combo
		public List<String> getAsignaturas()
		{
			String cadena = "SELECT Nombre " +
				"FROM Asignaturas";
			return execQueryListString(cadena);
		}

        //Devuelve las asignaturas de una clase dada una ID
		public List<String> getAsignaturasByClase(int idClase)
		{
			String cadena = "SELECT Nombre " +
				"FROM Asignaturas " +
				"WHERE idClase IS " + idClase;
			return execQueryListString(cadena);
		}

        //Devuelve el ID de una asignatura dado su nombre
		public int findAsignaturaByName(String asignatura)
		{
			String cadena = "SELECT idAsignatura " +
				"FROM Asignaturas " +
				"WHERE Nombre IS '" + asignatura + "'";
			return execQueryInt(cadena);
		}

        //Devuelve el nombre de una asignatura dada su ID
		public String findAsignaturaById(int idAsignatura)
		{
			String cadena = "SELECT Nombre " +
				"FROM Asignaturas " +
                "WHERE idAsignatura IS " + idAsignatura;
			return execQueryString(cadena);
		}

        //Devuelve la asignatura a la que pertenece un tema
        public String findAsignaturaByTema(int idTema)
        {
            String cadena = "SELECT a.Nombre " +
                "FROM Temas t INNER JOIN Asignaturas a ON a.idAsignatura = t.idAsignatura " +
                "WHERE t.idTema IS " + idTema;
            return execQueryString(cadena);
        }

        //Devuelve todos los temas de una asignatura en una lista de strings para añadirlos a un combo
		public List<String> getTemas(int idAsignatura)
		{
			String cadena = "SELECT T.nombre " +
				"FROM Asignaturas A " +
				"INNER JOIN Temas T ON A.idAsignatura = T.idAsignatura " +
				"WHERE T.idAsignatura IS " + idAsignatura;
			return execQueryListString(cadena);
		}
	}
}

