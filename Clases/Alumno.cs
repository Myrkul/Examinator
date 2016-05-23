using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinator.Clases
{
	class Alumno
	{
		String nombre;
		String apellidos;
		int idAlumno;
		int idClase;
		
		public Alumno(String nombre, String apellidos, int idClase)
		{
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.idClase = idClase;
		}
		
		public void setNombre(String nombre)
		{
			this.nombre = nombre;
		}
		
		public void setIdAlumno(int idAlumno)
		{
			this.idAlumno = idAlumno;
		}
		
		public int getIdAlumno()
		{
			return this.idAlumno;
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
		
		public String getApellidos()
		{
			return this.apellidos;
		}
		public void setApellidos(String apellidos)
		{
			this.apellidos = apellidos;
		}
	}
}