using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace proyecto_ipo1
{
    /// <summary>
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        public Usuario usuario;
        string language;

        public Empleados(Usuario usuario, string language)
        {
            InitializeComponent();
            this.language = language;
            this.usuario = usuario;
            lblUsername.Content = usuario.username;
            BitmapImage image = new BitmapImage(new Uri(usuario.imagen, UriKind.Relative));
            imgUsuario.Source = image;
            Empleado empleado = new Empleado();
            List<Empleado> empleados = crearListaEmpleado(empleado);
            for (int i = 0; i < empleados.Count; i++)
            {
                spContratos.Children.Add(new ControlEmpleadosPersonalizado(empleados[i]));
            }
            if (language == "ES") cbIdiomas.SelectedIndex = 0;
            else if (language == "EN") cbIdiomas.SelectedIndex = 1;

        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        public void btnContratarMonitor_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.BorderBrush = Brushes.Gray;
            txtdni.BorderBrush = Brushes.Gray;
            txtFormacion.BorderBrush = Brushes.Gray;
            txtTelf.BorderBrush = Brushes.Gray;
            txtEmail.BorderBrush = Brushes.Gray;
            txtIdiomas.BorderBrush = Brushes.Gray;
            txtDisponibilidad.BorderBrush = Brushes.Gray;
            lblErrorContratar.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                txtNombre.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrEmpty(txtFormacion.Text))
            {
                txtFormacion.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrEmpty(txtdni.Text) || !((txtdni.Text.Length == 9) && txtdni.Text.Substring(0, 7).All(char.IsDigit) && txtdni.Text.Substring(8).All(char.IsLetter)))
            {
                txtdni.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrEmpty(txtTelf.Text) || !(txtTelf.Text.All(char.IsDigit) && txtTelf.Text.Length == 9))
            {
                txtTelf.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrEmpty(txtIdiomas.Text))
            {
                txtIdiomas.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else if (String.IsNullOrEmpty(txtDisponibilidad.Text))
            {
                txtDisponibilidad.BorderBrush = Brushes.Red;
                lblErrorContratar.Visibility = Visibility.Visible;
            }
            else
            {
                Empleado empleado = new Empleado(txtNombre.Text, txtdni.Text, txtFormacion.Text, Convert.ToInt32(txtTelf.Text), txtEmail.Text, txtIdiomas.Text, txtDisponibilidad.Text);
                spContratos.Children.Add(new ControlEmpleadosPersonalizado(empleado));
                gridConfrmaAnyadir.Visibility = Visibility.Visible;
                txtNombre.Text = "";
                txtFormacion.Text = "";
                txtdni.Text = "";
                txtTelf.Text = "";
                txtEmail.Text = "";
                txtIdiomas.Text = "";
                txtDisponibilidad.Text = "";
            }
        }

        //BOTONES MENU VENTANAS
        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Empleados ventana = new Empleados(usuario, language);
            this.Close();
            ventana.Show();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Informacion ventana = new Informacion(usuario, language);
            this.Close();
            ventana.Show();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventana = new MainWindow();
            this.Close();
            ventana.Show();
        }

        private void btnActividades_Click(object sender, RoutedEventArgs e)
        {
            Actividades ventana = new Actividades(usuario, this.language);
            this.Close();
            ventana.Show();
        }

        private void btnPrincipal_Click(object sender, RoutedEventArgs e)
        {
            infoUser ventana = new infoUser(language);
            this.Close();
            ventana.Show();
        }
        private void btnReservas_Click(object sender, RoutedEventArgs e)
        {
            Reservas ventana = new Reservas(usuario, language);
            this.Close();
            ventana.Show();
        }



        public List<Empleado> crearListaEmpleado(Empleado empleado)
        {

            List<string> nombre = new List<string>() { "David Martín González", "Guillermo Sanchez Diaz", "Laura Jiménez González", "Ruben Delgado Martín" };
            List<string> dni = new List<string>() { "05634623F", "02342456P", "02782682L", "04854631R" };
            List<string> formacion = new List<string>() { "FP Educacion fisica", "TAFAD", "FP Deportes", "FP Educacion fisica" };
            List<Int32> telefono = new List<Int32>() { 610237218, 625896720, 691568291, 610696254 };
            List<string> email = new List<string>() { "davidmef@gmail.com", "willysanchd@gmail.com", "laujmnzg98@gmail.com", "rubendlgmartin@gmail.com" };
            List<string> idiomas = new List<string>() { "Inglés", "Francés", "Inglés", "Inglés y alemán" };
            List<string> disponibilidad = new List<string>() { "Dias laborables", "Completa", "Dias laborables", "Fines de semana" };
            List<Empleado> contratados = new List<Empleado>();
            for (int i = 0; i < 4; i++)
            {
                Empleado emp = new Empleado(nombre[i], formacion[i], dni[i], telefono[i], email[i], idiomas[i], disponibilidad[i]);
                contratados.Add(emp);
            }

            return contratados;
        }
        private void btnAceptarEli_Click(object sender, RoutedEventArgs e)
        {
            gridConfrmaEli.Visibility = Visibility.Hidden;
        }

        private void btnAceptarAnyadir_Click(object sender, RoutedEventArgs e)
        {
            gridConfrmaAnyadir.Visibility = Visibility.Hidden;
        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbIdiomas.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP"))
            && !CultureInfo.CurrentCulture.Name.Equals("es-US"))
            {
                this.language = "ES";
                App.SelectCulture("es-ES");
            }
            else if (selectedText.Equals("EN")
            && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                this.language = "EN";
                App.SelectCulture("en-US");
            }
        }

    }


}
