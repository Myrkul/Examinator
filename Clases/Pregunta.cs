using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
    class Pregunta
    {
        String enunciado;
		int idPregunta;
		int idTema;
		int idCorrecta;

        public Pregunta(String enunciado, int idCorrecta, int idTema)
        {
			this.idCorrecta = idCorrecta;
			this.idTema = idTema;
            this.enunciado = enunciado;
        }

        public void setEnunciado(String enunciado)
        {
            this.enunciado = enunciado;
        }

        public String getEnunciado()
        {
            return this.enunciado;
        }

		public int getCorrecta()
		{
			return this.idCorrecta;
		}
		
		public int getTema()
		{
			return this.idTema;
		}
		
		public void setIdPregunta(int idPregunta)
		{
			this.idPregunta = idPregunta;
		}
		
		public int getIdPregunta()
		{
			return this.idPregunta;
		}
    }
}
