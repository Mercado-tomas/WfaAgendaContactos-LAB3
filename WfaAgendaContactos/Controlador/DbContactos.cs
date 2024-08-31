using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace WfaAgendaContactos.Controlador
{
    public class DbContactos
    {
        // conexion con proveedor y ruta de base de datos
        public string ruta = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Modelado\DbContactos.accdb";
        
        // metodo para devolver todos los contactos
        public DataTable ObtenerContactos() {
            DataTable dtContactos = new DataTable();
            try {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) { 
                    conexion.Open();
                    string query = "SELECT * FROM DbContactos";
                    using (OleDbDataAdapter adaptador = new OleDbDataAdapter(query,conexion)) { 
                        adaptador.Fill(dtContactos);
                    }
                }
            }
            catch (Exception e){
                MessageBox.Show("No se pueden mostrar los contactos"+e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

                return dtContactos;
        }

        // metodo para agregar un nuevo contacto
        public void AgregarContacto(string nombre,string apellido,string telefono, string correo,string categoria)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) {
                    // abrimos conexion
                    conexion.Open();
                    string query ="INSERT INTO DbContactos(Nombre,Apellido,Teléfono,Correo,Categoría) VALUES(@nombre,@apellido,@telefono,@correo,@categoria)";
                    using (OleDbCommand comando = new OleDbCommand(query,conexion)) {
                        // se asignan parametros de la consulta
                        comando.Parameters.AddWithValue("@nombre",nombre);
                        comando.Parameters.AddWithValue("@apellido",apellido);
                        comando.Parameters.AddWithValue("@telefono", telefono);
                        comando.Parameters.AddWithValue("@correo", correo);
                        comando.Parameters.AddWithValue("@categoria",categoria);
                        // ejecutamos la query
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Contacto agregado con exito!","Exito!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception e) {
                MessageBox.Show("Error al agregar contacto."+e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // metodo para eliminar
        public void EliminarContacto(int id) {
            try {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) {
                    conexion.Open();
                    string query = "DELETE * FROM DbContactos WHERE Id = @id";
                    using (OleDbCommand comando = new OleDbCommand(query, conexion)) {
                        comando.Parameters.AddWithValue("@id",id);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Contacto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el contacto a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error al eliminar el contacto."+e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
