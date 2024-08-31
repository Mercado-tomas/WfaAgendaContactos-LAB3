using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfaAgendaContactos.Controlador;

namespace WfaAgendaContactos.Vista
{
    public partial class FrmAgendaApp : Form
    {
        public FrmAgendaApp()
        {
            InitializeComponent();
        }

        private void FrmAgendaApp_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarContacto frmAgregarContacto = new FrmAgregarContacto();
            frmAgregarContacto.Show();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbContactos db = new DbContactos();
            DataTable dt = db.ObtenerContactos();
            if (dt.Rows.Count > 0)
            {
                dgvContactos.DataSource = dt;
            }
            else {
                MessageBox.Show("No se encontraron datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar frmEliminar = new Eliminar();
            frmEliminar.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificar frmModificar = new FrmModificar();
            frmModificar.Show();
        }

        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarNombre frmBuscarNombre = new FrmBuscarNombre();
            frmBuscarNombre.Show();
        }

        private void teléfonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarTelefono frmBuscarTelefono = new FrmBuscarTelefono();
            frmBuscarTelefono.Show();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarCorreo frmBuscarCorreo = new FrmBuscarCorreo();
            frmBuscarCorreo.Show();
        }
    }
}
