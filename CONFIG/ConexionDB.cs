using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioAlquiler.CONFIG
{
    internal class ConexionDB
    {
        private string cadenaConexion = "Server=BLADIMIR-DESKTO\\SQLEXPRESS;Database=ServicioAlquilerCoches;User Id=sa;Password=123;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
