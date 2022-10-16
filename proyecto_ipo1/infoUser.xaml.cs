using Microsoft.Win32;
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
    /// Lógica de interacción para infoUser.xaml
    /// </summary>
    public partial class infoUser : Window
    {
        String UltAcceso = DateTime.Now.ToString();
        Usuario principal = new Usuario("Rafa", "Rafael", "González Llamas", "630273857", "02847336T", new DateTime(2001, 5, 24), "Talavera", DateTime.Now.ToString(), "imagenes/avatar.png");

        string language;
        public infoUser(string language)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();
            this.language = language;
            if (language == "ES") cbIdiomas.SelectedIndex = 0;
            else if (language == "EN") cbIdiomas.SelectedIndex = 1;
            mostrar();
        }

        public void mostrar()
        {
            txtUsername.Text = principal.username;
            txtBoxNombre.Text = principal.nombre;
            txtBoxApellidos.Text = principal.apellido;
            txtBoxTelf.Text = principal.telefono;
            txtBoxDni.Text = principal.dni;
            DatePicker.SelectedDate = principal.fechaNacimiento;
            txtBoxLocalidad.Text = principal.localidad;
            lblUltAcceso.Content = lblUltAcceso.Content + " " + UltAcceso;
            BitmapImage image = new BitmapImage(new Uri(principal.imagen, UriKind.Relative));
            imgUsuario.Source = image;
        }

        private void editar(object sender, RoutedEventArgs e)
        {
            enabled();
        }

        private void guardar(object sender, RoutedEventArgs e)
        {
            principal.username = txtUsername.Text;
            principal.nombre = txtBoxNombre.Text;
            principal.apellido = txtBoxApellidos.Text;
            principal.telefono = txtBoxTelf.Text;
            principal.dni = txtBoxLocalidad.Text;
            principal.fechaNacimiento = Convert.ToDateTime(DatePicker.SelectedDate);
            principal.localidad = txtBoxLocalidad.Text;
            disabled();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCambiarImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    imgUsuario.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen. " + ex.Message);
                    MessageBox.Show("Error al cargar la imagen. " + ex.Message);
                }
            }
        }



        public void enabled()
        {
            txtUsername.IsEnabled = true;
            txtBoxNombre.IsEnabled = true;
            txtBoxApellidos.IsEnabled = true;
            txtBoxTelf.IsEnabled = true;
            txtBoxDni.IsEnabled = true;
            DatePicker.IsEnabled = true;
            txtBoxLocalidad.IsEnabled = true;
            btnCancelar.Visibility = Visibility.Visible;
            btnGuardar.Visibility = Visibility.Visible;
        }

        public void disabled()
        {
            txtUsername.IsEnabled = false;
            txtBoxNombre.IsEnabled = false;
            txtBoxApellidos.IsEnabled = false;
            txtBoxTelf.IsEnabled = false;
            txtBoxDni.IsEnabled = false;
            DatePicker.IsEnabled = false;
            txtBoxLocalidad.IsEnabled = false;
            btnCancelar.Visibility = Visibility.Hidden;
            btnGuardar.Visibility = Visibility.Hidden;
        }

        private void cancelar(object sender, RoutedEventArgs e)
        {
            disabled();
            mostrar();
        }

        private void btnEliminarImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage(new Uri("imagenes/usuario.png", UriKind.Relative));
                imgUsuario.Source = bitmap;
                principal.imagen = "imagenes/usuario.png";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen. " + ex.Message);
            }
        }
        private void btnReservas_Click(object sender, RoutedEventArgs e)
        {
            Reservas ventana = new Reservas(principal, language);
            this.Close();
            ventana.Show();
        }

        private void btnActividades_Click(object sender, RoutedEventArgs e)
        {
            Actividades ventana = new Actividades(principal, language);
            this.Close();
            ventana.Show();
        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Empleados ventana = new Empleados(principal, language);
            this.Close();
            ventana.Show();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Informacion ventana = new Informacion(principal, language);
            this.Close();
            ventana.Show();
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventana = new MainWindow();
            this.Close();
            ventana.Show();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
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
