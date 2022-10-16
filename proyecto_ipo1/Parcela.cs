using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ipo1
{
    public class Parcela
    {
        public String nombre { get; set; }
        public String tamanio { get; set; }
        public String ubicacion { get; set; }
        public double precio { get; set; }
        public String caracteristicasAdicionales { get; set; }
        public List<String> imagenes { get; set; }
        public List<List<DateTime>> fechas { get; set; }

        public Parcela(String tamanio, String ubicacion, double precio, String caracteristicasAdicionales, List<String> imagenes)
        {
            this.nombre = "Parcela ";
            this.tamanio = tamanio;
            this.ubicacion = ubicacion;
            this.precio = precio;
            this.caracteristicasAdicionales = caracteristicasAdicionales;
            this.imagenes = imagenes;
            this.fechas = new List<List<DateTime>>();
        }

        override
        public String ToString()
        {
            return this.nombre + this.tamanio + "\n" + "Ubicación: " + this.ubicacion + "\n" + "Características: " + this.caracteristicasAdicionales + "\n" + "Precio: " + this.precio.ToString() + " €";
        }

        public String Descripcion()
        {
            return this.nombre + this.tamanio + "\n" + "Ubicación: " + this.ubicacion + "\n" + "Características: " + this.caracteristicasAdicionales;
        }

        public Boolean ComprobarFecha(DateTime inicio, DateTime fin)
        {
            if (this.fechas == null) return true;
            for (int i = 0; i < this.fechas.Count(); i++)
            {
                if (inicio <= this.fechas[i][0] && fin >= this.fechas[i][0]) return false;
                if (inicio >= this.fechas[i][0] && inicio <= this.fechas[i][1] && fin >= this.fechas[i][1]) return false;
            }
            return true;
        }
    }
}