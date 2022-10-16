using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ipo1
{
    public class DatosReserva
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public String[] Huespedes { get; set; }
        public String TipoAlojamiento { get; set; }

        public DatosReserva(DateTime FechaEntrada, DateTime FechaSalida, String[] Huespedes, String TipoAlojamiento)
        {
            this.FechaEntrada = FechaEntrada;
            this.FechaSalida = FechaSalida;
            this.Huespedes = Huespedes;
            this.TipoAlojamiento = TipoAlojamiento;
        }

        public override string ToString()
        {
            return this.FechaEntrada.ToString("dd/MM/yyyy") + " -> " + this.FechaSalida.ToString("dd/MM/yyyy") + "\n" + this.Huespedes[0] + " Adultos + " + this.Huespedes[1] + " Niños";
        }
    }
}
