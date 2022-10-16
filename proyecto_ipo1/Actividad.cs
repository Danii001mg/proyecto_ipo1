using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ipo1
{
    public class Actividad
    {
        public string nombre { get; set; }
        public DateTime dia { get; set; }
        public string nombreMonitor { get; set; }
        public string ubicacion { get; set; }
        public double duracion { get; set; }
        public string horaInicio { get; set; }
        public string cupo { get; set; }
        public int inscritos { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }

        public Actividad(string nombre, DateTime dia, string nombreMonitor, double duracion, string horaInicio, string ubicacion, string cupo, int inscritos, string descripcion, double precio)
        {
            this.nombre = nombre;
            this.dia = dia;
            this.nombreMonitor = nombreMonitor;
            this.duracion = duracion;
            this.horaInicio = horaInicio;
            this.ubicacion = ubicacion;
            this.cupo = cupo;
            this.inscritos = inscritos;
            this.descripcion = descripcion;
            this.precio = precio;
        }
    }
}