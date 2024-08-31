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
    public partial class FrmModificar : Form
    {
        public FrmModificar()
        {
            InitializeComponent();
        }
        public void ObtenerContactos() { 
            DbContactos dbContactos = new DbContactos();
            dgvContactos.DataSource = dbContactos.ObtenerContactos();  
        }
        private void FrmModificar_Load(object sender, EventArgs e)
        {
            DbContactos dbContactos = new DbContactos();
            DataTable dt = dbContactos.ObtenerContactos();
            dgvContactos.DataSource = dt;


          
           //frmModificar.ContactoModificado += ObtenerContactos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmAgendaApp frm = new FrmAgendaApp();
            frm.ShowDialog();
            this.Close();
        }
        // metodo para capturar la info del contacto
        private void dgvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvContactos.Rows[e.RowIndex];

                FrmModificarContacto frm = new FrmModificarContacto();

                // Pasar datos al formulario de modificación
                frm.txtIdContacto.Text = row.Cells["Id"].Value.ToString();
                frm.txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                frm.txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                frm.txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                frm.txtEmail.Text = row.Cells["Correo"].Value.ToString();
                frm.cmbCategoria.Text = row.Cells["Categoria"].Value.ToString();

                frm.ShowDialog();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvContactos.Rows[e.RowIndex];

                FrmModificarContacto frm = new FrmModificarContacto();

                // Pasar datos al formulario de modificación
                frm.txtIdContacto.Text = row.Cells["Id"].Value.ToString();
                frm.txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                frm.txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                frm.txtTelefono.Text = row.Cells["Teléfono"].Value.ToString();
                frm.txtEmail.Text = row.Cells["Correo"].Value.ToString();
                frm.cmbCategoria.Text = row.Cells["Categoría"].Value.ToString();

                frm.ShowDialog();

            }
        }
    }
}
