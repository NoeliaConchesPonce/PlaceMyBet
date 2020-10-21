using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Mercados
    {
        public Mercados(int idMercado, double overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int idEvento)
        {
            this.idMercado = idMercado;
            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.idEvento = idEvento;
        }

        public int idMercado { get; set; }
        public double overUnder { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public int idEvento { get; set; }
    }
    public class MercadosDTO
    {
        public MercadosDTO(int idMercado, double overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int idEvento)
        {

            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
        }

        public double overUnder { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
    }
}
