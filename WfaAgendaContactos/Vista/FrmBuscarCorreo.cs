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
    public partial class FrmBuscarCorreo : Form
    {
        public FrmBuscarCorreo()
        {
            InitializeComponent();
        }

        private void FrmBuscarCorreo_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmAgendaApp frmAgendaApp = new FrmAgendaApp();
            frmAgendaApp.ShowDialog();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            if (!string.IsNullOrEmpty(correo))
            {
                DbContactos dbContactos = new DbContactos();
                DataTable dt = dbContactos.BuscarContactoCorreo(correo);
                if (dt.Rows.Count > 0)
                {
                    dgvContactos.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No existen contactos con ese correo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un correo válido para buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
