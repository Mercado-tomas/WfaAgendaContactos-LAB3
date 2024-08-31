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
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void Eliminar_Load(object sender, EventArgs e)
        {
            DbContactos dbContactos = new DbContactos();
            DataTable dt = dbContactos.ObtenerContactos();
            dgvContactos.DataSource = dt;
        }

        // capturamos el id
        private int idContactoSeleccionado;
        // metodo para devolver el nro de id mediante el evento click
        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                DataGridViewRow fila = dgvContactos.Rows[e.RowIndex];
                idContactoSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idContactoSeleccionado > 0)
            {
                DbContactos db = new DbContactos();
                db.EliminarContacto(idContactoSeleccionado);
                // cargamos nuevamente
                dgvContactos.DataSource = db.ObtenerContactos();
                idContactoSeleccionado = 0;

            }
            else {
                MessageBox.Show("Seleccione un contacto para eliminar!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmAgendaApp frmAgendaApp = new FrmAgendaApp();
            frmAgendaApp.ShowDialog();
        }
    }
}
