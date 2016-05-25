using System;
using System.Data;

namespace Examinator.DAO
{
	public class Clase_DAO : DAO.Comun_DAO
	{
		public Clase_DAO (){}

		public void deleteClase(int idClase)
		{
			String cadena = "DELETE FROM Clases WHERE idClase IS (" + idClase + ")";
			this.execNonQuery(cadena);
		}

		public Clases.Clase insertClase(Clases.Clase clase)
		{
			String cadena = "INSERT INTO Clases (Nombre) VALUES ('" + clase.getNombre() + "')";
			execNonQuery(cadena);
			clase.setIdClase(this.findClaseByName(clase.getNombre()));
			return clase;
		}

		private int findClaseByName(String clase)
		{
			String cadena = "SELECT idClase FROM Clases WHERE Nombre IS '" + clase + "'";
			return execQueryInt(cadena);
		}

		public DataTable actualizarTablaClases()
		{
			String cadena = "SELECT idClase AS ID, Nombre FROM Clases";
			return execQueryTable(cadena);
		}
	}
}

