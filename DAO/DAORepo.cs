using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Examinator.DAO
{
    class DAORepo
    {
        private static SQLiteConnection conn;
        private DirectoryInfo temp;
        private DirectoryInfo directorio;

        public DAORepo()
        {
            temp = new DirectoryInfo(Directory.GetCurrentDirectory());
            directorio = temp.Parent.Parent;
            String conexion = "Data Source=" + directorio.FullName + "\\examinator.db3;New=True;Compress=True;";
            conn = new SQLiteConnection(conexion);
            conn.Open();
        }

        public Clases.Asignatura insertAsignatura(Clases.Asignatura asignatura)
        {
            String cadena = "INSERT INTO Asignaturas (Nombre, idClase) VALUES ('" + asignatura.getNombre() + "', '" + asignatura.getIdClase() + "')";
			this.execNonQuery(cadena);
			asignatura.setIdAsig(this.findAsignaturaByName(asignatura.getNombre()));
			return asignatura;
        }

        public Clases.Tema insertTema(Clases.Tema tema)
        {
            String cadena = "INSERT INTO Temas (Nombre, idAsignatura) VALUES ('" + tema.getNombre() + "', '" + tema.getIdAsig() + "')";
            this.execNonQuery(cadena);
			tema.setIdTema(this.findTemaByName(tema.getNombre()));
			return tema;
        }

        public Clases.Alumno insertAlumno(Clases.Alumno alumno)
        {
            String cadena = "INSERT INTO Alumnos (Nombre, Apellidos, idClase) VALUES ('" + alumno.getNombre() + "', '" + alumno.getApellidos() + "', '" + alumno.getIdClase() + "')";
            this.execNonQuery(cadena);
            alumno.setIdAlumno(this.findAlumnoByName(alumno.getNombre()));
            return alumno;
        }

        public void deleteAsignatura(int idAsig)
        {
            String cadena = "DELETE FROM Asignaturas WHERE idAsignatura IS (" + idAsig + ")";
            this.execNonQuery(cadena);
        }

        public void deleteTema(int idTema)
        {
            String cadena = "DELETE FROM Temas WHERE idTema IS (" + idTema + ")";
            this.execNonQuery(cadena);
        }

        public void deleteClase(int idClase)
        {
            String cadena = "DELETE FROM Clases WHERE idClase IS (" + idClase + ")";
            this.execNonQuery(cadena);
        }

        public void deleteAlumno(int idAlumno)
        {
            String cadena = "DELETE FROM Alumnos WHERE idAlumno IS (" + idAlumno + ")";
            this.execNonQuery(cadena);
        }
		
		public DataTable actualizarTablaAsig()
		{
            String cadena = "SELECT idAsignatura AS ID, Nombre FROM Asignaturas";
            return execQueryTable(cadena);
		}

        public DataTable actualizarTablaTemas(int idAsig)
		{
            String cadena = "SELECT idTema AS ID, Nombre " + 
                            "FROM Temas " + 
                            "WHERE idAsignatura IS '" + idAsig + "'";
            return execQueryTable(cadena);
		}
		
		public Clases.Pregunta insertPregunta(Clases.Pregunta pregunta, List<Clases.Respuesta> respuestas)
		{
			String enunciado = pregunta.getEnunciado();
			int correcta = pregunta.getCorrecta();
		
			String cadena = "INSERT INTO Preguntas (Enunciado, idCorrecta) VALUES ('" + enunciado + "', '" + correcta + "')";
			this.execNonQuery(cadena);
            pregunta.setIdPregunta(this.findPreguntaByEnunciado(pregunta.getEnunciado()));

            for (int k = 0; k < respuestas.Count; k++)
            {
                this.insertRespuesta(respuestas[k]);
                respuestas[k].setIdRespuesta(this.findRespuestaByTexto(respuestas[k].getTexto()));
                this.updateRelacionPreguntaRespuesta(pregunta, respuestas[k]);
            }
			
			return pregunta;
		}
		
		private void updateRelacionPreguntaRespuesta(Clases.Pregunta pregunta, Clases.Respuesta respuesta)
		{
			String cadena = "INSERT INTO Preguntas_Respuestas (idPregunta, idRespuesta) VALUES ('" + pregunta.getIdPregunta() + "', '" + respuesta.getIdRespuesta() + "')";
            this.execNonQuery(cadena);
		}
		
		private void updateRelacionExamenNota(Clases.Examen examen, Clases.Nota nota)
		{
			String cadena = "INSERT INTO Examenes_Notas (idExamen, idNota) VALUES ('" + examen.getIdExamen() + "', '" + nota.getIdNota() + "')";
			this.execNonQuery(cadena);
		}
		
		private void insertRespuesta(Clases.Respuesta respuesta)
		{
			String cadena = "INSERT INTO Respuestas (Texto) VALUES ('" + respuesta.getTexto() + "')";
            this.execNonQuery(cadena);
		}
		
		public List<String> cargarTemas(String nombreAsig)
		{
            int asignaturaActual = this.findAsignaturaByName(nombreAsig);
            String cadena = "SELECT T.nombre " +
                            "FROM Asignaturas A " +
                            "INNER JOIN Temas T ON A.idAsignatura = T.idAsignatura " +
                            "WHERE T.idAsignatura IS " + asignaturaActual;
			return execQueryListString(cadena);
		}
		
		public List<String> getAsignaturas()
		{
			String cadena = "SELECT Nombre FROM Asignaturas";
            return execQueryListString(cadena);
		}
		
		public List<int> getPreguntas(String tema, String asignatura)
		{
			int idTema = this.findTemaByName(tema);
			int idAsig = this.findAsignaturaByName(asignatura);
			
			String cadena = "SELECT idPregunta " +
                            "FROM Preguntas " +
                            "WHERE idAsignatura IS " + idAsig + " " + 
                            "AND idTema IS " + idTema;
            return execQueryListInt(cadena);
		}
		
		public Clases.Clase insertClase(Clases.Clase clase)
		{
			String cadena = "INSERT INTO Clases (Nombre) VALUES ('" + clase.getNombre() + "')";
            execNonQuery(cadena);
			clase.setIdClase(this.findClaseByName(clase.getNombre()));
			return clase;
		}
		
		public Clases.Nota insertNota(Clases.Nota nota)
		{
            String cadena = "INSERT INTO Notas (idAlumno, nota) VALUES ('" +nota.getIdAlumno() + "', '" + nota.getNota() + "')";
			execNonQuery(cadena);
            return nota;
		}
		
		public Clases.Examen insertExamen(Clases.Examen examen)
		{
            String cadena = "INSERT INTO Examenes (idTema) VALUES ('" + examen.getIdTema() + "')";
			execNonQuery(cadena);
            return examen;
		}
		
		private int findClaseByName(String clase)
		{
			String cadena = "SELECT idClase FROM Clases WHERE Nombre IS '" + clase + "'";
            return execQueryInt(cadena);
		}

        private int findAlumnoByName(String alumno)
        {
            String cadena = "SELECT idAlumno FROM Alumnos WHERE Nombre IS '" + alumno + "'";
            return execQueryInt(cadena);
        }
		
		private int findAsignaturaByName(String asignatura)
        {
            String cadena = "SELECT idAsignatura FROM Asignaturas WHERE Nombre IS '" + asignatura + "'";
            return execQueryInt(cadena);
        }

        public int findTemaByName(String tema)
        {
            String cadena = "SELECT idTema FROM Temas WHERE Nombre IS '" + tema + "'";
            return execQueryInt(cadena);
        }
		
		private int findRespuestaByTexto(String respuesta)
		{
			String cadena = "SELECT idRespuesta FROM Respuestas WHERE Texto IS '" + respuesta + "'";
            return execQueryInt(cadena);
		}
		
		private int findPreguntaByEnunciado(String pregunta)
		{
			String cadena = "SELECT idPregunta FROM Preguntas WHERE Enunciado IS '" + pregunta + "'";
            return execQueryInt(cadena);
		}

        public DataTable actualizarTablaClases()
        {
            String cadena = "SELECT idClase AS ID, Nombre FROM Clases";
            return execQueryTable(cadena);
        }

        public DataTable actualizarTablaAlumnos(int idClase)
        {
            String cadena = "SELECT idAlumno AS ID, Apellidos, Nombre " +
                            "FROM Alumnos " +
                            "WHERE idClase IS '" + idClase + "' " +
                            "ORDER BY Apellidos";
            return execQueryTable(cadena);
        }
		
		private void execNonQuery(String cadena)
		{
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			cmd.ExecuteNonQuery();
		}
		
		private int execQueryInt(String cadena)
		{
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
			SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return rdr.GetInt32(0);
		}
		
		private DataTable execQueryTable(String cadena)
		{
			SQLiteDataAdapter da = new SQLiteDataAdapter(cadena, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
			return ds.Tables[0];
		}
		
		private List<int> execQueryListInt(String cadena)
		{
			List<int> lista = new List<int>();
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(rdr.GetInt32(0));
            }
			return lista;
		}
		
		private List<String> execQueryListString(String cadena)
		{
			List<String> lista = new List<String>();
			SQLiteCommand cmd = new SQLiteCommand(cadena, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(rdr.GetString(0));
            }
			return lista;
		}
    }
}