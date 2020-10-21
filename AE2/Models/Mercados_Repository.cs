using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Mercados_Repository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }

        internal List<Mercados> retrieve()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Mercados";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<Mercados> mercado = new List<Mercados>();
                while (reader.Read())
                {
                    Mercados m = new Mercados(reader.GetInt32(0),reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6));

                    mercado.Add(m);

                }

                conectar.Close();
                return mercado;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("No ha podido realizarse la conexión con la base de datos.");
                return null;

            }
        }
        internal List<MercadosDTO> retrieveDTO()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Mercados";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<MercadosDTO> mercadoDTO = new List<MercadosDTO>();
                while (reader.Read())
                {
                    MercadosDTO m = new MercadosDTO(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6));

                    mercadoDTO.Add(m);

                }

                conectar.Close();
                return mercadoDTO;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("No ha podido realizarse la conexión con la base de datos.");
                return null;

            }
        }
    }
}
