using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Instrumentation;
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
        internal List<ApuestasDTO> retrieveDTO()
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = "Select * from Apuestas";
            try
            {
                conectar.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                List<ApuestasDTO> apuestaDTO = new List<ApuestasDTO>();
                while (reader.Read())
                {
                    ApuestasDTO a = new ApuestasDTO(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetMySqlDateTime(4).ToString(), reader.GetInt32(5), reader.GetString(6));

                    apuestaDTO.Add(a);

                }

                conectar.Close();
                return apuestaDTO;

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("No ha podido realizarse la conexión con la base de datos.");
                return null;

            }
        }
        internal object conseguirCuotaOver(int mercado)
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = string.Format("SELECT Cuota_Over FROM mercados WHERE IdMercado=" + mercado + ";");
            Debug.WriteLine("El comando es " + comando.CommandText);

            conectar.Open();
            double cuota = Convert.ToDouble(comando.ExecuteScalar());
            Debug.WriteLine("Y vale " + cuota);

            return cuota;
        }

        internal object conseguirCuotaUnder(int mercado)
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = string.Format("SELECT Cuota_Under FROM mercados WHERE IdMercados=" + mercado + ";");

            conectar.Open();
            double cuota = Convert.ToDouble(comando.ExecuteScalar());
            Debug.WriteLine("Y vale" + cuota);
            conectar.Close();

            return cuota;
        }
        internal void Save(Apuestas a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            MySqlCommand comandocuotas = conectar.CreateCommand();
            MySqlCommand commandcambiarcuota = conectar.CreateCommand();
            MySqlCommand cambiardinero = conectar.CreateCommand();

            DateTime dt = DateTime.Now;
            string s = dt.ToString("yyyyMMddHHmmss");

            double over = conseguirDineroOver(a.idMercado);
            double under = conseguirDineroUnder(a.idMercado);
            double probunder = calcularProbUnder(over, under);
            double probover = calcularProbOver(over, under);

            double cuota;
            if(a.tipoApuesta == "over")
            {
                Debug.WriteLine("Antes de la cuota " + a.idMercado);
                cuota = (double)conseguirCuotaOver(a.idMercado);
                Debug.WriteLine("Despues de cuota" + cuota);
                Debug.WriteLine("El dinero es " + a.dineroApuesta);

                double calcover = calculoCuota(probover);
                double calcunder = calculoCuota(probunder);
                calcunder = Math.Round(calcunder, 2);
                calcover = Math.Round(calcover, 2);

                comando.CommandText = "INSERT INTO `apuestas` VALUES ('" + a.idMercado + "','" + a.tipoApuesta + "','" + cuota + "','" + a.dineroApuesta + "','" + s + "','" + a.idEvento + "','" + a.emailUsuario + "');'";
                cambiardinero.CommandText = "UPDATE mercados SET Dinero_Over=Dinero_Over+'" + a.dineroApuesta + "' WHERE IdMercado=" + a.idMercado + ";";
                comandocuotas.CommandText = "UPDATE `mercados` SET `Cuota_Over`=" + calcover + "WHERE IdMercado=" + a.idMercado + ";";
            }
            else
            {
                Debug.WriteLine("Antes de la cuota " + a.idMercado);
                cuota = (double)conseguirCuotaUnder(a.idMercado);
                Debug.WriteLine("Despues de cuota" + cuota);
                Debug.WriteLine("El dinero es " + a.dineroApuesta);

                double calculoover = calculoCuota(probover);
                double calculounder = calculoCuota(probunder);
                calculounder = Math.Round(calculounder, 2);
                calculoover = Math.Round(calculoover, 2);

                comando.CommandText = "INSERT INTO `apuestas` VALUES ('" + a.idMercado + "','" + a.tipoApuesta + "','" + cuota + "','" + a.dineroApuesta + "','" + s + "','" + a.idEvento + "','" + a.emailUsuario + "');";
                cambiardinero.CommandText = "UPDATE `mercados` SET `Dinero_Under`=Dinero_Under + " + a.dineroApuesta + "WHERE IdMercado=" + a.idMercado + ";";
                comandocuotas.CommandText = "UPDATE `mercados` SET `Cuota_Under`=" + calculounder + "WHERE IdMercado=" + a.idMercado + ";";
            }

            Debug.WriteLine("Comando: " + comando.CommandText);

            try
            {
                conectar.Open();

                comando.ExecuteNonQuery();
                cambiardinero.ExecuteNonQuery();
                comandocuotas.ExecuteNonQuery();

                conectar.Close();

            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);

            }
        }

        internal double conseguirDineroOver(int mercado)
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = string.Format("SELECT Dinero_Over FROM mercados WHERE IdMercado = " + mercado + ";");
            Debug.WriteLine("El comando es " + comando.CommandText);

            conectar.Open();
            double prob = Convert.ToDouble(comando.ExecuteScalar());

            conectar.Close();

            return prob;
        }
        internal double calcularProbOver(double dineroOver, double dineroUnder)
        {
            double probabilidad = dineroOver / (dineroOver + dineroUnder);

            return probabilidad;
        }

        internal double calcularProbUnder(double dineroOver, double dineroUnder)
        {
            double probabilidad = dineroUnder / (dineroOver + dineroUnder);

            return probabilidad;
        }
        internal double conseguirDineroUnder(int mercado)
        {
            MySqlConnection conectar = Connect();
            MySqlCommand comando = conectar.CreateCommand();
            comando.CommandText = string.Format("SELECT Dinero_Under FROM mercados WHERE IdMercado = " + mercado + ";");
            Debug.WriteLine("El comando es " + comando.CommandText);

            conectar.Open();
            double prob = Convert.ToDouble(comando.ExecuteScalar());

            conectar.Close();

            return prob;
        }

        internal double calculoCuota(double probabilidad)
        {
            double cuota = (1 / probabilidad) * 0.95;

            return cuota;
        }
    }
}