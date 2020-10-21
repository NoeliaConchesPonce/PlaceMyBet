using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Apuestas
    {
        public Apuestas(int idMercado, string tipoApuesta, double cuota, double dineroApuesta, string fecha, int idEvento, string emailUsuario)
        {
            this.idMercado = idMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApuesta = dineroApuesta;
            this.fecha = fecha;
            this.idEvento = idEvento;
            this.emailUsuario = emailUsuario;
        }

        public int idMercado { get; set; }
        public string tipoApuesta { get; set; }
        public double cuota { get; set; }
        public double dineroApuesta { get; set; }
        public string fecha { get; set; }
        public int idEvento { get; set; }
        public string emailUsuario { get; set; }
    }
}