using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AnimeTv.Entity
{
    public class GestorVideos
    {
        private MySqlConnection mConexion;

        public GestorVideos(MySqlConnection pConexion)
        {
            mConexion = pConexion;
        }

        public bool EliminarVideo(int pAnime, int pCapitulo)
        {
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"DELETE FROM videos WHERE anime = '{pAnime}' AND capitulo = '{pCapitulo}';";
            int resultado = comando.ExecuteNonQuery();
            mConexion.Close();
            if (resultado == 0)
            {
                return false;
            }
            return true;
        }

        public List<Video> CargarTodosLosVideos()
        {         
            List<Video> lista = new List<Video>();
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"SELECT * FROM videos";
            var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Video video = new Video(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                    lista.Add(video);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            mConexion.Close();

            return lista;
        }

        public bool InsertarVideo(string pVideoID, int pAnime, int pTemporada, int pCapitulo)
        {
            try
            {
                int videoID = Int32.Parse(pVideoID);
                mConexion.Open();
                MySqlCommand comando = mConexion.CreateCommand();
                comando.CommandText = $"INSERT INTO videos (videoid, anime, temporada, capitulo) values ('{videoID}','{pAnime}','{pTemporada}','{pCapitulo}');";
                int resultado = comando.ExecuteNonQuery();
                mConexion.Close();
                if (resultado == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mConexion.Close();
                return false;
            }
                    
        }
    }
}
