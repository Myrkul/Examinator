using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class Asignatura_DAO : DAO.Comun_DAO
	{
		public Asignatura_DAO (){}

		public Clases.Asignatura insertAsignatura(Clases.Asignatura asignatura)
		{
			String cadena = "INSERT INTO Asignaturas (Nombre, idClase) VALUES ('" + asignatura.getNombre() + "', '" + asignatura.getIdClase() + "')";
			this.execNonQuery(cadena);
			asignatura.setIdAsig(this.findAsignaturaByName(asignatura.getNombre()));
			return asignatura;
		}

		public void deleteAsignatura(int idAsig)
		{
			String cadena = "DELETE FROM Asignaturas WHERE idAsignatura IS (" + idAsig + ")";
			this.execNonQuery(cadena);
		}

		public DataTable actualizarTablaAsig()
		{
			String cadena = "SELECT idAsignatura AS ID, Nombre FROM Asignaturas";
			return execQueryTable(cadena);
		}

		public List<String> getAsignaturas()
		{
			String cadena = "SELECT Nombre FROM Asignaturas";
			return execQueryListString(cadena);
		}

		private int findAsignaturaByName(String asignatura)
		{
			String cadena = "SELECT idAsignatura FROM Asignaturas WHERE Nombre IS '" + asignatura + "'";
			return execQueryInt(cadena);
		}

		public List<String> cargarAsignaturas(String nombreAsig)
		{
			int asignaturaActual = this.findAsignaturaByName(nombreAsig);
			String cadena = "SELECT T.nombre " +
				"FROM Asignaturas A " +
				"INNER JOIN Temas T ON A.idAsignatura = T.idAsignatura " +
				"WHERE T.idAsignatura IS " + asignaturaActual;
			return execQueryListString(cadena);
		}
	}
}

