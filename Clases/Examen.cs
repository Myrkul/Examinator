using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	class Examen
	{
		int idExamen;
		int idTema;
		
		public Examen(int idTema)
		{
			this.idTema = idTema;
		}
		
		public int getIdExamen()
		{
			return this.idExamen;
		}
		
		public int getIdTema()
		{
			return this.idTema;
		}
		public void setIdExamen(int idExamen)
		{
			this.idExamen = idExamen;
		}
	}
}