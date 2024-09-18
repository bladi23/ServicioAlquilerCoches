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
    public class cocheControls
    {
        private ConexionDB conexionBDD = new ConexionDB();

        public List<coches> ObtenerCoches()
        {
            List<coches> coches = new List<coches>();
            using (SqlConnection con = conexionBDD.GetConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Coches", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    coches coche = new coches
                    {
                        ID_Coche = (int)reader["ID_Coche"],
                        Matricula = reader["Matricula"].ToString(),
                        ID_Modelo = (int)reader["ID_Modelo"]
                    };
                    coches.Add(coche);
                }
            }
            return coches;
        }

        public void AgregarCoche(coches coche)
        {
            using (SqlConnection con = ConexionDB.GetConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Coches (Matricula, ID_Modelo) VALUES (@Matricula, @ID_Modelo)", con);
                cmd.Parameters.AddWithValue("@Matricula", coche.Matricula);
                cmd.Parameters.AddWithValue("@ID_Modelo", coche.ID_Modelo);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarCoche(coches coche)
        {
            using (SqlConnection con = conexionBDD.GetConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Coches SET Matricula = @Matricula, ID_Modelo = @ID_Modelo WHERE ID_Coche = @ID_Coche", con);
                cmd.Parameters.AddWithValue("@Matricula", coche.Matricula);
                cmd.Parameters.AddWithValue("@ID_Modelo", coche.ID_Modelo);
                cmd.Parameters.AddWithValue("@ID_Coche", coche.ID_Coche);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCoche(int idCoche)
        {
            using (SqlConnection con = conexionBDD.GetConexion())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Coches WHERE ID_Coche = @ID_Coche", con);
                cmd.Parameters.AddWithValue("@ID_Coche", idCoche);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
   