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
    public class alquilerControls
    {
       
            private ConexionDB conexionBDD = new ConexionDB();

            public List<Alquiler> ObtenerAlquileres()
            {
                List<Alquiler> alquileres = new List<Alquiler>();
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Alquileres", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Alquiler alquiler = new Alquiler
                        {
                            ID_Alquiler = (int)reader["ID_Alquiler"],
                            ID_Coche = (int)reader["ID_Coche"],
                            ID_Cliente = (int)reader["ID_Cliente"],
                            Fecha_Inicio = (DateTime)reader["Fecha_Inicio"],
                            Fecha_Fin = (DateTime)reader["Fecha_Fin"]
                        };
                        alquileres.Add(alquiler);
                    }
                }
                return alquileres;
            }

            public void AgregarAlquiler(Alquiler alquiler)
            {
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Alquileres (ID_Coche, ID_Cliente, Fecha_Inicio, Fecha_Fin) VALUES (@ID_Coche, @ID_Cliente, @Fecha_Inicio, @Fecha_Fin)", con);
                    cmd.Parameters.AddWithValue("@ID_Coche", alquiler.ID_Coche);
                    cmd.Parameters.AddWithValue("@ID_Cliente", alquiler.ID_Cliente);
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", alquiler.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Fin", alquiler.Fecha_Fin);
                    cmd.ExecuteNonQuery();
                }
            }

            public void ActualizarAlquiler(Alquiler alquiler)
            {
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Alquileres SET ID_Coche = @ID_Coche, ID_Cliente = @ID_Cliente, Fecha_Inicio = @Fecha_Inicio, Fecha_Fin = @Fecha_Fin WHERE ID_Alquiler = @ID_Alquiler", con);
                    cmd.Parameters.AddWithValue("@ID_Coche", alquiler.ID_Coche);
                    cmd.Parameters.AddWithValue("@ID_Cliente", alquiler.ID_Cliente);
                    cmd.Parameters.AddWithValue("@Fecha_Inicio", alquiler.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Fin", alquiler.Fecha_Fin);
                    cmd.Parameters.AddWithValue("@ID_Alquiler", alquiler.ID_Alquiler);
                    cmd.ExecuteNonQuery();
                }
            }

            public void EliminarAlquiler(int idAlquiler)
            {
                using (SqlConnection con = conexionBDD.GetConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Alquileres WHERE ID_Alquiler = @ID_Alquiler", con);
                    cmd.Parameters.AddWithValue("@ID_Alquiler", idAlquiler);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}