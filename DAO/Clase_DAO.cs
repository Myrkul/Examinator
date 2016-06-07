using System;
using System.Data;
using System.Collections.Generic;

namespace Examinator.DAO
{
	public class Clase_DAO : DAO.Comun_DAO
	{
		public Clase_DAO () : base()
		{}

        //Elimina una clase dada una ID
		public void deleteClase(int idClase)
		{
			String cadena = "DELETE " +
				"FROM Clases " +
				"WHERE idClase IS (" + idClase + ")";
			this.execNonQuery(cadena);
		}

        //Inserta una clase
		public Clases.Clase insertClase(Clases.Clase clase)
		{
			String cadena = "INSERT " +
				"INTO Clases (Nombre) " +
				"VALUES ('" + clase.getNombre() + "')";
			execNonQuery(cadena);
			clase.setIdClase(this.findClaseByName(clase.getNombre()));
			return clase;
		}

        //Delve la ID de una clase dado su nombre
		public int findClaseByName(String clase)
		{
			String cadena = "SELECT idClase " +
				"FROM Clases WHERE " +
				"Nombre IS '" + clase + "'";
			return execQueryInt(cadena);
		}

        //Devuelve el nombre de una clase dada su ID
		public String findClaseById(int id)
		{
			String cadena = "SELECT Nombre " +
				"FROM Clases " +
				"WHERE idClase IS " + id;
			return execQueryString(cadena);
		}

        //Actualiza el DataGridView de todas las clases
		public DataTable actualizarTablaClases()
		{
			String cadena = "SELECT idClase AS ID, Nombre " +
				"FROM Clases";
			return execQueryTable(cadena);
		}

        //Devuelve una lista de string con todas las clases para añadirlas a un combo
        public List<String> getClases()
        {
            String cadena = "SELECT Nombre " +
                "FROM Clases";
            return execQueryListString(cadena);
        }
	}
}

