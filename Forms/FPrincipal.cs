using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Examinator
{
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
			String directorio = Directory.GetCurrentDirectory ();
			bool existe = File.Exists (directorio + "\\examinator.db3");
			Console.WriteLine (directorio);
			if (!existe) {
				MessageBox.Show ("Base de datos no encontrada.\nSeleccione el archivo.");
				using (OpenFileDialog dialog = new OpenFileDialog())
				{
					dialog.Filter = "Archivos .db3|*.db3"  ;
					dialog.FilterIndex = 2 ;
					dialog.RestoreDirectory = true ;

					DialogResult resultado = dialog.ShowDialog ();
					if (resultado == DialogResult.OK) {
						String fichero = dialog.FileName;
						String actual = Directory.GetCurrentDirectory () + "\\examinator.db3";
						File.Move (fichero, actual);
					} else if (resultado == DialogResult.Cancel || resultado == DialogResult.Abort) {
						MessageBox.Show ("No se puede continuar sin una base de datos.");
						Environment.Exit (0);
					}
				}
			}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Forms.FAddPreguntas addPreguntas = new Forms.FAddPreguntas();
            addPreguntas.Show();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Forms.FGenerar generaExamen = new Forms.FGenerar();
            generaExamen.Show();
        }

        private void gestionarAsignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FAsignaturas gestionAsig = new Forms.FAsignaturas();
            gestionAsig.Show();
        }
		private void gestionarClasesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.FClases gestionClases = new Forms.FClases();
			gestionClases.Show();
		}
    }
}
