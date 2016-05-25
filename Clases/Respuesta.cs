using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	public class Respuesta
    {
        String texto;
		int idRespuesta;

        public Respuesta(String texto)
        {
            this.texto = texto;
        }

        public void setTexto(String texto)
        {
            this.texto = texto;
        }

        public String getTexto()
        {
            return this.texto;
        }
		
		public void setIdRespuesta(int idRespuesta)
		{
			this.idRespuesta = idRespuesta;
		}
		
		public int getIdRespuesta()
		{
			return this.idRespuesta;
		}
    }
}