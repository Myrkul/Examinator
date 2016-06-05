using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	public class Examen
	{
		int idExamen;
		int idTema;
        int numPreguntas;
        int numRespuestas;
		
		public Examen(int idTema, int numPreguntas, int numRespuestas)
		{
			this.idTema = idTema;
            this.numPreguntas = numPreguntas;
            this.numRespuestas = numRespuestas;
		}

        public int getNumPreguntas()
        {
            return this.numPreguntas;
        }

        public int getNumRespuestas()
        {
            return this.numRespuestas;
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