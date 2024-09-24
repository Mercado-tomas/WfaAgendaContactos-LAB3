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
    public partial class FrmBuscarTelefono : Form
    {
        public FrmBuscarTelefono()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmAgendaApp frmAgendaApp = new FrmAgendaApp();
            frmAgendaApp.ShowDialog();
            Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();
            if (!string.IsNullOrEmpty(telefono))
            {
                DbContactos dbContactos = new DbContactos();
                DataTable dt = dbContactos.BuscarContactoNombre(telefono);
                if (dt.Rows.Count > 0)
                {
                    dgvContactos.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No existen contactos con ese nombre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre válido para buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
