using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ubiety.Dns.Core.Records.General;
using MySql.Data;

namespace AE2.Models
{
    public class Eventos_Repository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }

        internal List<Eventos> retrieve()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Eventos";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<Eventos> evento = new List<Eventos>();
                while (reader.Read())
                {
                    Eventos d = new Eventos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetMySqlDateTime(3).ToString());

                    evento.Add(d);

                }

                conectar.Close();
                return evento;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("No ha podido realizarse la conexión con la base de datos.");
                return null;

            }
        }
        internal List<EventosDTO> retrieveDTO()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Eventos";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<EventosDTO> eventoDTO = new List<EventosDTO>();
                while (reader.Read())
                {
                    EventosDTO d = new EventosDTO(reader.GetString(0), reader.GetString(1), reader.GetMySqlDateTime(2).ToString());

                    eventoDTO.Add(d);

                }

                conectar.Close();
                return eventoDTO;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("No ha podido realizarse la conexión con la base de datos.");
                return null;

            }
        }
    }
    
}
