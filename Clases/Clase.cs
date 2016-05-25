using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	public class Clase
	{
		int idClase;
		String nombre;
		
		public Clase(String nombre)
		{
			this.nombre = nombre;
		}
		
		public void setNombre(String nombre)
		{
			this.nombre = nombre;
		}
		
		public void setIdClase(int idClase)
		{
			this.idClase = idClase;
		}
		
		public int getIdClase()
		{
			return this.idClase;
		}
		
		public String getNombre()
		{
			return this.nombre;
		}
	}
}