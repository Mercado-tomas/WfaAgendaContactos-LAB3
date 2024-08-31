using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfaAgendaContactos.Controlador;

namespace WfaAgendaContactos.Vista
{
    public partial class FrmModificarContacto : Form
    {

        public event Action ContactoModificado;
        public FrmModificarContacto()
        {
            InitializeComponent();
        }

        private void FrmModificarContacto_Load(object sender, EventArgs e)
        {
            
        }
        
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            bool contactoActualizado = false;
        // Obtener los datos del formulario
            int idContacto = int.Parse(txtIdContacto.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            string categoria = cmbCategoria.Text;

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DbContactos dbContactos = new DbContactos();
            dbContactos.ModificarContacto(idContacto,nombre,apellido,telefono,email,categoria);
            MessageBox.Show("El contacto se modificó con exito!","Exito!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            
           // Disparar el evento para notificar que el contacto ha sido modificado
            ContactoModificado?.Invoke();
            contactoActualizado = true;
            

            this.Close();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmModificar frmModificar = new FrmModificar();
            frmModificar.ShowDialog();
        }
    }
}
