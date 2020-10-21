using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Usuarios_Repository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }

        internal List<Usuarios> retrieve()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Usuarios";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<Usuarios> usuario = new List<Usuarios>();
                while (reader.Read())
                {
                    Usuarios u = new Usuarios(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));

                    usuario.Add(u);

                }

                conectar.Close();
                return usuario;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
                return null;

            }
        }
    }
}
