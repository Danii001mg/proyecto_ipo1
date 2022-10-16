using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ipo1
{
    public class Bungalow
    {
        public String nombre { get; set; }
        public String tamanio { get; set; }
        public int capacidad { get; set; }
        public double precio { get; set; }
        public String caracteristicasAdicionales { get; set; }
        public List<String> imagenes { get; set; }
        public List<List<DateTime>> fechas { get; set; } 

        public Bungalow(String tamanio, int capacidad, double precio, String caracteristicasAdicionales, List<String> imagenes)
        {
            this.nombre = "Bungalow ";
            this.tamanio = tamanio;
            this.capacidad = capacidad;
            this.precio = precio;
            this.caracteristicasAdicionales = caracteristicasAdicionales;
            this.imagenes = imagenes;
            this.fechas = new List<List<DateTime>>();
        }

        override
        public String ToString()
        {
            return this.nombre + this.tamanio + "\n" + "Capacidad: " + this.capacidad.ToString() + "\n" + "Precio/noche: " + this.precio.ToString() + "€" + "\n" + "Características: " + this.caracteristicasAdicionales + "\n" + "Precio: " + this.precio.ToString() + " €";
        }

        public String Descripcion()
        {
            return this.nombre + this.tamanio + "\n" + "Capacidad: " + this.capacidad.ToString() + "\n" + "Precio/noche: " + this.precio.ToString() + "€" + "\n" + "Características: " + this.caracteristicasAdicionales;
        }

        public Boolean ComprobarFecha(DateTime inicio, DateTime fin)
        {
            if (this.fechas == null) return true;
            for (int i = 0; i < fechas.Count(); i++)
            {
                if (inicio <= fechas[i][0] && fin >= fechas[i][0]) return false;
                if (inicio >= fechas[i][0] && inicio <= fechas[i][1] && fin >= fechas[i][1]) return false;
            }
            return true;
        }
    }
}
