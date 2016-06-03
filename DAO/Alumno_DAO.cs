using System;
using System.Data;

namespace Examinator.DAO
{
	public class Alumno_DAO : DAO.Comun_DAO
	{
		public Alumno_DAO () : base()
		{}

		public Clases.Alumno insertAlumno(Clases.Alumno alumno)
		{
			String cadena = "INSERT " +
				"INTO Alumnos (Nombre, Apellidos, idClase) " +
				"VALUES ('" + alumno.getNombre() + "', '" + alumno.getApellidos() + "', '" + alumno.getIdClase() + "')";
			this.execNonQuery(cadena);
			alumno.setIdAlumno(this.findAlumnoByName(alumno.getNombre()));
			return alumno;
		}

		public void deleteAlumno(int idAlumno)
		{
			String cadena = "DELETE " +
				"FROM Alumnos " +
				"WHERE idAlumno IS (" + idAlumno + ")";
			this.execNonQuery(cadena);
		}

		private int findAlumnoByName(String alumno)
		{
			String cadena = "SELECT idAlumno " +
				"FROM Alumnos " +
				"WHERE Nombre IS '" + alumno + "'";
			return this.execQueryInt(cadena);
		}

		public DataTable actualizarTablaAlumnos(int idClase)
		{
			String cadena = "SELECT idAlumno AS ID, Apellidos, Nombre " +
				"FROM Alumnos " +
				"WHERE idClase IS '" + idClase + "' " +
				"ORDER BY Apellidos";
			return this.execQueryTable(cadena);
		}
	}
}

