using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	public class Tema
	{
		String nombre;
		int idAsig;
		int idTema;
		
		public Tema(String nombre, int idAsig)
		{
			this.nombre = nombre;
			this.idAsig = idAsig;
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
		
		public String getNombre()
		{
			return this.nombre;
		}
		
		public int getIdTema()
		{
			return this.idTema;
		}
		
		public void setIdTema(int idTema)
		{
			this.idTema = idTema;
		}
	}
}