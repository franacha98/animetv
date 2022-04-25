using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class UtilConexion
    {
        public static MySqlConnection Conexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=localhost;user=root;password=;database=animetv");
            return conexion;
        }

        public static void AbrirConexion(MySqlConnection pConexion)
        {
            pConexion.Open();
        }

        public static void CerrarConexion(MySqlConnection pConexion)
        {
            pConexion.Close();
        }

    }
}
