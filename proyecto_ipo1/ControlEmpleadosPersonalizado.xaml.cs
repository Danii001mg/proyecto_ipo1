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
    /// Lógica de interacción para ControlEmpleadosPersonalizado.xaml
    /// </summary>
    public partial class ControlEmpleadosPersonalizado : UserControl
    {
        Empleado empleado;
        public ControlEmpleadosPersonalizado(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
            disabled();
            mostrar(empleado);

        }
        public void mostrar(Empleado empleado)
        {
            lblNombre1.Content = empleado.nombreApellidos;
            txtForma.Text = empleado.formacion;
            txtDni.Text = empleado.dni;
            txtTelf.Text = Convert.ToString(empleado.telefono);
            txtEmail.Text = empleado.email;
            txtIdiomas.Text = empleado.idiomas;
            txtDispo.Text = empleado.disponibilidad;
        }
        private void enabled()
        {
            lblNombre1.IsEnabled = true;
            txtForma.IsEnabled = true;
            txtDni.IsEnabled = true;
            txtTelf.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtIdiomas.IsEnabled = true;
            txtDispo.IsEnabled = true;
            btnAceptar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Hidden;
            btnEliminar.Visibility = Visibility.Hidden;
        }
        private void disabled()
        {
            lblNombre1.IsEnabled = false;
            txtForma.IsEnabled = false;
            txtDni.IsEnabled = false;
            txtTelf.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtIdiomas.IsEnabled = false;
            txtDispo.IsEnabled = false;
            btnAceptar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Visible;
            btnEliminar.Visibility = Visibility.Visible;

        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            enabled();
            btnAceptar.Visibility = Visibility.Visible;
            btnAceptar.IsEnabled = true;
        }


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado((string)lblNombre1.Content, txtForma.Text, txtDni.Text, Convert.ToInt32(txtTelf.Text), txtEmail.Text, txtIdiomas.Text, txtDispo.Text);
            this.empleado = empleado;
            mostrar(empleado);
            disabled();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            disabled();
            mostrar(this.empleado);
        }
    }
}