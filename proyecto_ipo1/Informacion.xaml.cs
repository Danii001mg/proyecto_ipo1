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
using System.Windows.Shapes;
using System.Globalization;

namespace proyecto_ipo1
{
    /// <summary>
    /// Lógica de interacción para Reservas.xaml
    /// </summary>
    public partial class Informacion : Window
    {
        public Usuario usuario;
        string language;
        public Informacion(Usuario usuario, string language)
        {
            InitializeComponent();
            this.language = language;
            this.usuario = usuario;
            lblUsername.Content = usuario.username;
            BitmapImage image = new BitmapImage(new Uri(usuario.imagen, UriKind.Relative));
            imgUsuario.Source = image;
            if (language == "ES") cbIdiomas.SelectedIndex = 0;
            else if (language == "EN") cbIdiomas.SelectedIndex = 1;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }



        private void btnActividades_Click(object sender, RoutedEventArgs e)
        {
            Actividades ventana = new Actividades(usuario, language);
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
            Reservas ventana = new Reservas(usuario, language);
            this.Close();
            ventana.Show();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        private void salir(object sender, RoutedEventArgs e)
        {
            this.Close();

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


