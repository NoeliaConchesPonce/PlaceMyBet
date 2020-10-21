using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE2.Models
{
    public class Eventos
    {
        public Eventos(int idEvento, string equipoLocal, string equipoVisitante, string fecha)
        {
            this.idEvento = idEvento;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.fecha = fecha;
        }

        public int idEvento { get; set; }
        public string equipoLocal { get; set; }
        public string equipoVisitante { get; set; }
        public string fecha { get; set; }
    }


}