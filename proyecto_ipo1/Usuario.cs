using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace proyecto_ipo1
{
    public class Usuario
    {
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String telefono { get; set; }
        public String dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String ultAcceso { get; set; }
        public String localidad { get; set; }
        public String username { get; set; }
        public String imagen { get; set; }

        public Usuario() { }
        public Usuario(String username, String nombre, String apellido, String telefono, String dni, DateTime fechaNacimiento, String localidad, String ultAcceso, String imagen)
        {
            this.username = username;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.localidad = localidad;
            this.ultAcceso = ultAcceso;
            this.imagen = imagen;
        }

    }
}