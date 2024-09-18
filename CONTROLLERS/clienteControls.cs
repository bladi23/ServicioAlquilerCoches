using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ServicioAlquiler.CONFIG;
using ServicioAlquiler.VIEWS;

namespace ServicioAlquiler.CONTROLLERS
{
    public class clienteControls
    {
       
            private ConexionDB conexionBDD = new ConexionDB();

            public List<Clientes> ObtenerClientes()
            {
                List<Clientes> clientes = new List<Clientes>();
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Clientes cliente = new Clientes
                        {
                            ID_Cliente = (int)reader["ID_Cliente"],
                            Nombre = reader["Nombre"].ToString()
                        };
                        clientes.Add(cliente);
                    }
                }
                return clientes;
            }

            public void AgregarCliente(Clientes cliente)
            {
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Clientes (Nombre) VALUES (@Nombre)", con);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }

            public void ActualizarCliente(Clientes cliente)
            {
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Nombre = @Nombre WHERE ID_Cliente = @ID_Cliente", con);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@ID_Cliente", cliente.ID_Cliente);
                    cmd.ExecuteNonQuery();
                }
            }

            public void EliminarCliente(int idCliente)
            {
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE ID_Cliente = @ID_Cliente", con);
                    cmd.Parameters.AddWithValue("@ID_Cliente", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
}
