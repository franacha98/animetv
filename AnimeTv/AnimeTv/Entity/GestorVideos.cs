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

        public int ObtenerVideoPorAnimeYCapitulo(int pAnime, int pCapitulo)
        {
            int video = 0;
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"SELECT videoid FROM videos where anime='{pAnime}' AND capitulo='{pCapitulo}'";
            var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    video = reader.GetInt32(0);
                }
            }
            mConexion.Close();
            return video;
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

        public bool Login(string pEmail, string pPassword)
        {
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"SELECT * FROM usuarios WHERE correo='{pEmail}' AND clave='{pPassword}'";
            bool loginCorrecto = false;
            var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                loginCorrecto = true;
            }
            mConexion.Close();

            return loginCorrecto;
        }

        public bool Registro(string pEmail, string pNombre, string pPassword)
        {
            try
            {
                mConexion.Open();
                MySqlCommand comando = mConexion.CreateCommand();
                comando.CommandText = $"INSERT INTO usuarios (correo, nombre, clave, esadmin) values ('{pEmail}','{pNombre}','{pPassword}','0');";
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

        public string ObtenerNombreUsuario(string pEmail)
        {
            string nombre = "";
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"SELECT nombre FROM usuarios where correo='{pEmail}'";
            var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nombre = reader.GetString(0);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            mConexion.Close();

            return nombre;
        }

        public List<int> ObtenerListaDeUnUsuario(string pEmail)
        {
            List<int> lista = new List<int>();
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"SELECT anime FROM lista where usuario='{pEmail}'";
            var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     lista.Add(reader.GetInt32(0));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            mConexion.Close();

            return lista;
        }


        public void AnadirALista(string pEmail, int pAnime)
        {
            try
            {
                mConexion.Open();
                MySqlCommand comando = mConexion.CreateCommand();
                comando.CommandText = $"INSERT INTO lista (usuario, anime) values ('{pEmail}','{pAnime}');";
                int resultado = comando.ExecuteNonQuery();
                mConexion.Close();      
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                mConexion.Close();
            }
        }
        public bool MarcarVisto(string pEmail, int pVideo, int pAnime, int pEpisodio)
        {
            try
            {
                mConexion.Open();

                MySqlCommand comando = mConexion.CreateCommand();
                comando.CommandText = $"INSERT INTO vistos (usuario, video, anime, episodio) values ('{pEmail}','{pVideo}','{pAnime}','{pEpisodio}');";
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

        public bool YaVisto(string pEmail, int pVideo)
        {
            mConexion.Open();
            MySqlCommand comando = mConexion.CreateCommand();
            comando.CommandText = $"SELECT * FROM vistos WHERE usuario='{pEmail}' AND video='{pVideo}'";
            var reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                mConexion.Close();
                return true;
            }
            mConexion.Close();
            return false;
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
