using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_ipo1
{
    public class Empleado
    {
        public String nombreApellidos { get; set; }
        public long telefono { get; set; }
        public String dni { get; set; }
        public String idiomas { get; set; }
        public String email { get; set; }
        public String formacion { get; set; }
        public String disponibilidad { get; set; }



        public Empleado(String nombreApellidos, String formacion, String dni, int telefono, String email, String idiomas, String disponibilidad)
        {
            this.nombreApellidos = nombreApellidos;
            this.formacion = formacion;
            this.dni = dni;
            this.telefono = telefono;
            this.email = email;
            this.idiomas = idiomas;
            this.disponibilidad = disponibilidad;
        }

        public Empleado()
        {
        }
    }
}