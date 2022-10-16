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
    /// Lógica de interacción para Actividades.xaml
    /// </summary>
    public partial class Actividades : Window
    {
        public Usuario usuario;
        List<Actividad> ActividadesYRutas;
        string language;

        public Actividades(Usuario usuario, string language)
        {
            InitializeComponent();
            this.language = language;
            this.ActividadesYRutas = crearListaActividadesYRutas();
            MostrarTodas();
            this.usuario = usuario;
            lblUsername.Content = usuario.username;
            BitmapImage image = new BitmapImage(new Uri(usuario.imagen, UriKind.Relative));
            imgUsuario.Source = image;
            if (language == "ES") cbIdiomas.SelectedIndex = 0;
            else if (language == "EN") cbIdiomas.SelectedIndex = 1;
        }

        public List<Actividad> crearListaActividadesYRutas()
        {
            List<string> nombre = new List<string> { "Natación", "Tenis", "Gymkana", "Senderismo" };
            List<DateTime> dia = new List<DateTime> { DateTime.ParseExact("20/07/2022", "d", CultureInfo.CreateSpecificCulture("es-ES")), DateTime.ParseExact("29/06/2022", "d", CultureInfo.CreateSpecificCulture("es-ES")), DateTime.ParseExact("21/06/2022", "d", CultureInfo.CreateSpecificCulture("es-ES")), DateTime.ParseExact("02/07/2022", "d", CultureInfo.CreateSpecificCulture("es-ES")) };
            List<string> nombreMonitor = new List<string> { "Rafael", "Daniel", "Raquel", "David" };
            List<string> ubicacion = new List<string> { "Piscina resort", "Pistas resort", "Centro del resort", "Entrada del resort" };
            List<double> duracion = new List<double> { 100, 120, 90, 120 };
            List<string> horaInicio = new List<string> { "11:00", "19:00", "10:00", "9:00" };
            List<string> cupo = new List<string> { "5/40", "4/10", "5/30", "2/20" };
            List<int> inscritos = new List<int> { 17, 5, 9, 6 };
            List<string> descripcion = new List<string> { "Clases de natación para cualquier edad", "Partidos de tenis por parejas", "Gymkana para los más pequeños con diversas actividades", "Senderismo en el monte cercano al resort, quedada en la entrada del recinto"};
            List<double> precio = new List<double> { 10, 15, 2, 5 };
            List<Actividad> actividades = new List<Actividad>();

            for (int i = 0; i < nombre.Count; i++)
            {
                Actividad actividad = new Actividad(nombre[i], dia[i], nombreMonitor[i], duracion[i], horaInicio[i], ubicacion[i], cupo[i], inscritos[i], descripcion[i], precio[i]);
                actividades.Add(actividad);
            }

            return actividades;
        }


        public void MostrarTodas()
        {
            spActividades.Children.Clear();

            for (int i = 0; i < this.ActividadesYRutas.Count; i++)
            {
                spActividades.Children.Add(new ControlActividadesPersonalizado(this.ActividadesYRutas[i]));
            }

        }


        private void btnCrearActividad_Click(object sender, RoutedEventArgs e)
        {
            Esconder();

            if (String.IsNullOrEmpty(txtNombreActividad.Text) || !txtNombreActividad.Text.All(char.IsLetter))
            {
                lblError.Visibility = Visibility.Visible;
                txtNombreActividad.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtMonitor.Text) || !txtMonitor.Text.All(char.IsLetter))
            {
                lblError.Visibility = Visibility.Visible;
                txtMonitor.BorderBrush = Brushes.Red;
            }
            else if (calenFechaActividad.SelectedDate < DateTime.Now)
            {
                lblError.Visibility = Visibility.Visible;
                calenFechaActividad.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtDuracion.Text) || !(txtDuracion.Text.All(char.IsDigit) && Int32.Parse(txtDuracion.Text) > 0))
            {
                lblError.Visibility = Visibility.Visible;
                txtDuracion.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtUbicacion.Text) || !txtUbicacion.Text.All(char.IsLetter))
            {
                lblError.Visibility = Visibility.Visible;
                txtUbicacion.BorderBrush = Brushes.Red;
            }
            else if ((String.IsNullOrEmpty(txtCupoMin.Text) && String.IsNullOrEmpty(txtCupoMax.Text)) || !(txtCupoMin.Text.All(char.IsDigit) && txtCupoMax.Text.All(char.IsDigit)))
            {

                lblError.Visibility = Visibility.Visible;
                txtCupoMin.BorderBrush = Brushes.Red;
                txtCupoMax.BorderBrush = Brushes.Red;

            }
            else if (Convert.ToInt32(txtCupoMax.Text) < Convert.ToInt32(txtCupoMin.Text))
            {
                lblError.Visibility = Visibility.Visible;
                txtCupoMin.BorderBrush = Brushes.Red;
                txtCupoMax.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblError.Visibility = Visibility.Visible;
                txtDescripcion.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtPrecio.Text) || !(txtPrecio.Text.All(char.IsDigit) && Double.Parse(txtPrecio.Text) >= 0))
            {
                lblError.Visibility = Visibility.Visible;
                txtPrecio.BorderBrush = Brushes.Red;
            }
            else
            {
                Actividad actividad = new Actividad(txtNombreActividad.Text, Convert.ToDateTime(calenFechaActividad.SelectedDate), txtMonitor.Text, Convert.ToDouble(txtDuracion.Text),
                                                       DateTime.Now.ToString(), txtUbicacion.Text, txtCupoMin.Text + "/" + txtCupoMax.Text, 0, txtDescripcion.Text, Convert.ToDouble(txtPrecio.Text));
                spActividades.Children.Add(new ControlActividadesPersonalizado(actividad));
                MostrarTodas();
                gridConfrmaEli.Visibility = Visibility.Visible;
            }
            
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void btnActividades_Click(object sender, RoutedEventArgs e)
        {
            Actividades ventana = new Actividades(usuario, this.language);
            this.Close();
            ventana.Show();
        }

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
        private void btnPrincipal_Click(object sender, RoutedEventArgs e)
        {
            infoUser ventana = new infoUser(language);
            this.Close();
            ventana.Show();
        }
        private void btnReservas_Click(object sender, RoutedEventArgs e)
        {
            Reservas ventana = new Reservas(usuario, this.language);
            this.Close();
            ventana.Show();
        }


        private void Esconder()
        {
            txtNombreActividad.BorderBrush = Brushes.Gray;
            txtMonitor.BorderBrush = Brushes.Gray;
            calenFechaActividad.BorderBrush = Brushes.Gray;
            txtDuracion.BorderBrush = Brushes.Gray;
            txtUbicacion.BorderBrush = Brushes.Gray;
            txtCupoMin.BorderBrush = Brushes.Gray;
            txtCupoMax.BorderBrush = Brushes.Gray;
            txtDescripcion.BorderBrush = Brushes.Gray;
            txtPrecio.BorderBrush = Brushes.Gray;
            lblError.Visibility = Visibility.Hidden;

        }

        private void btnRutas_Click(object sender, RoutedEventArgs e)
        {
            NuevaRuta ventana = new NuevaRuta();
            ventana.Show();
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


        private void btnAceptarEli_Click(object sender, RoutedEventArgs e)
        {
            gridConfrmaEli.Visibility = Visibility.Hidden;
        }
    }
}
