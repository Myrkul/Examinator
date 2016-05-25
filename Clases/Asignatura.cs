using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	public class Asignatura
	{
		String nombre;
		int idAsig;
		int idClase;
		
		public Asignatura(String nombre)
		{
			this.nombre = nombre;
		}
		
		public void setNombre(String nombre)
		{
			this.nombre = nombre;
		}
		
		public void setIdAsig(int idAsig)
		{
			this.idAsig = idAsig;
		}
		
		public int getIdAsig()
		{
			return this.idAsig;
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