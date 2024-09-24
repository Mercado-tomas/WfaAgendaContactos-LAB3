using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        // metodo para modificar contacto
        public void ModificarContacto(int id,string nombre, string apellido, string telefono, string correo, string categoria)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) {
                    conexion.Open();
                    string query = "UPDATE DbContactos SET Nombre=@nombre,Apellido=@apellido,Teléfono=@telefono,Correo=@correo,Categoría=@categoria WHERE Id = @id";
                    using (OleDbCommand comando = new OleDbCommand(query,conexion)) {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@telefono", telefono);
                        comando.Parameters.AddWithValue("@correo", correo);
                        comando.Parameters.AddWithValue("@categoria", categoria);
                        comando.Parameters.AddWithValue("@Id", id);

                        int rowsAfectados = comando.ExecuteNonQuery();
                        if (rowsAfectados == 0) {
                            throw new Exception("No se encontró el contacto con el ID especificado.");
                        }
                    }
                
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error al modificar el contacto"+e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // metodo para buscar contactos
        public DataTable BuscarContactoNombre(string nombre) { 
            DataTable dtContacto = new DataTable();
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) {
                    conexion.Open();
                    string query = "SELECT * FROM DbContactos WHERE Nombre Like @nombre";
                    using (OleDbCommand comando = new OleDbCommand(query,conexion)) {
                        comando.Parameters.AddWithValue("@nombre","%"+nombre+"%");
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando)) {
                            adaptador.Fill(dtContacto);
                        }
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show("No se pudo realizar la busqueda"+e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


                return dtContacto;
        }
        // Método para buscar contactos por correo
        public DataTable BuscarContactoCorreo(string correo)
        {
            DataTable dtContacto = new DataTable();
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();

                    // Consulta para buscar contactos por correo
                    string query = "SELECT * FROM DbContactos WHERE Correo LIKE @correo";

                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@correo", "%" + correo + "%");

                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            adaptador.Fill(dtContacto);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo realizar la búsqueda: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtContacto;
        }

        // Método para buscar contactos por teléfono
        public DataTable BuscarContactoTelefono(string telefono)
        {
            DataTable dtContacto = new DataTable();
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();

                    // Consulta para buscar contactos por teléfono
                    string query = "SELECT * FROM DbContactos WHERE Teléfono LIKE @telefono";

                    using (OleDbCommand comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@telefono", "%" + telefono + "%");

                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                        {
                            adaptador.Fill(dtContacto);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo realizar la búsqueda: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtContacto;
        }


    }
}
