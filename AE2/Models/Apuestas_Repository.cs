using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AE2.Models
{
    public class Apuestas_Repository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }
        internal List<Apuestas> retrieve()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Apuestas";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<Apuestas> apuesta = new List<Apuestas>();
                while (reader.Read())
                {
                    Apuestas a = new Apuestas(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3),reader.GetMySqlDateTime(4).ToString(), reader.GetInt32(5), reader.GetString(6));

                    apuesta.Add(a);

                }

                conectar.Close();
                return apuesta;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("No ha podido realizarse la conexión con la base de datos.");
                return null;

            }
        }
    }
}