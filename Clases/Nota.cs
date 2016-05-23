using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
    class Nota
    {
		int idNota;
		int idAlumno;
		float nota;

        public Nota(float nota, int idAlumno)
        {
            this.nota = nota;
			this.idAlumno = idAlumno;
        }

        public void setNota(float nota)
        {
            this.nota = nota;
        }

        public float getNota()
        {
            return this.nota;
        }
		
		public void setIdAlumno(int idAlumno)
		{
			this.idAlumno = idAlumno;
		}
		
		public int getIdAlumno()
		{
			return this.idAlumno;
		}
    }
}