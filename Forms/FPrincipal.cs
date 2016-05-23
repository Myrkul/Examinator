using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examinator
{
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
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
    }
}
