using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace proyecto_ipo1
{
    /// <summary>
    /// Lógica de interacción para ControlActividadesPersonalizado.xaml
    /// </summary>
    public partial class ControlActividadesPersonalizado : UserControl
    {
        Actividad actividad;
        public ControlActividadesPersonalizado(Actividad actividad)
        {
            InitializeComponent();
            this.actividad = actividad;
            mostrar(actividad);

        }

        private void mostrar(Actividad actividad)
        {
            txtActividad.Text = actividad.nombre;
            txtMonitores.Text = actividad.nombreMonitor; 
            txtHorario.Text = Convert.ToString(actividad.horaInicio);
            txtDuracion.Text = Convert.ToString(actividad.duracion);
            txtUbicacion.Text = actividad.ubicacion;
            txtCupo.Text = Convert.ToString(actividad.cupo);
            txtDescripcion.Text = actividad.descripcion;
            txtDia.Text = Convert.ToString(actividad.dia.ToString("dd/MM/yy"));
            txtPrecio.Text = Convert.ToString(actividad.precio) + "€";
            txtInscritos.Text = Convert.ToString(actividad.inscritos);
        }


        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            enabled();

            btnCancelar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Hidden;
            btnEliminar.Visibility = Visibility.Hidden;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            disabled();
            mostrar(this.actividad);
            btnCancelar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
        }

        private void enabled()
        {
            txtMonitores.IsEnabled = true;
            txtHorario.IsEnabled = true;
            txtUbicacion.IsEnabled = true;
            txtDuracion.IsEnabled = true;
            txtCupo.IsEnabled = true;
            txtDescripcion.IsEnabled = true;
            txtPrecio.IsEnabled = true;
        }
        private void disabled()
        {
            txtMonitores.IsEnabled = false;
            txtHorario.IsEnabled = false;
            txtUbicacion.IsEnabled = false;
            txtDuracion.IsEnabled = false;
            txtCupo.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
            txtPrecio.IsEnabled = false;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;

        }

        private void btnIncribirse_Click(object sender, RoutedEventArgs e)
        {
            actividad.inscritos = actividad.inscritos + 1;
            txtInscritos.Text = Convert.ToString(actividad.inscritos);
            string[] cup = actividad.cupo.Split('/');
            if (actividad.inscritos >= Convert.ToInt32(cup[1]))
            {
                btnIncribirse.IsEnabled = false;
            }
            if (btnEliminar2.IsEnabled == false)
            {
                btnEliminar2.IsEnabled = true;
            }
            gridConfrmaEli.Visibility = Visibility.Visible;
        }

        private void btnAceptarEli_Click(object sender, RoutedEventArgs e)
        {
            gridConfrmaEli.Visibility = Visibility.Hidden;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            this.actividad.nombre = txtActividad.Text;
            this.actividad.nombreMonitor = txtMonitores.Text;
            this.actividad.horaInicio = txtHorario.Text;
            this.actividad.duracion = double.Parse(txtDuracion.Text);
            this.actividad.ubicacion = txtUbicacion.Text;
            this.actividad.cupo = txtCupo.Text;
            this.actividad.descripcion = txtDescripcion.Text;
            this.actividad.dia = Convert.ToDateTime(txtDia.Text);
            this.actividad.precio = Int32.Parse(txtPrecio.Text.Substring(0, txtPrecio.Text.Length - 1));

            disabled();
            btnCancelar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;
        }

        private void txtInscritos_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEliminar2_Click(object sender, RoutedEventArgs e)
        {
            actividad.inscritos = actividad.inscritos - 1;
            txtInscritos.Text = Convert.ToString(actividad.inscritos);
            if (btnIncribirse.IsEnabled==false)
            {
                btnIncribirse.IsEnabled = true;
            }
            if (actividad.inscritos ==0)
            {
                btnEliminar2.IsEnabled = false;
            }
        }
    }
}