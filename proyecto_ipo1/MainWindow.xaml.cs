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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyecto_ipo1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int contador = 0;
        public MainWindow()
        {
            InitializeComponent();
            App.SelectCulture("es-ES");      
        }

        private void comprobarUsuario(object sender, RoutedEventArgs e)
        {
            string usuario = "admin";
            VentanaUsuario ventanaNueva = new VentanaUsuario();
            if (!String.IsNullOrEmpty(tbxEmail.Text) && tbxEmail.Text.Equals(usuario, StringComparison.InvariantCultureIgnoreCase))
            {
                // comprobación correcta
                pbxContraseña.IsEnabled = true;
                tbxEmail.BorderBrush = Brushes.Transparent;
                comprobarContraseña(pbxContraseña.Password);
                if (contador++ == 2)
                {
                    Close();
                    ventanaNueva.Show();
                }

            }
            else
            {
                // comprobación errónea
                tbxEmail.BorderBrush = Brushes.Red;
                tbxEmail.BorderThickness = new Thickness(2);
                if (pbxContraseña.IsEnabled)
                {
                    pbxContraseña.IsEnabled = false;
                }
                contador = 0;
            }
        }

        private void comprobarContraseña(string contraseña)
        {
            string pass_usuario = "admin";
            if (pbxContraseña.IsEnabled && !String.IsNullOrEmpty(pbxContraseña.Password))
            {
                if (!pbxContraseña.Password.Equals(pass_usuario))
                {
                    // marcamos borde en rojo
                    pbxContraseña.BorderBrush = Brushes.Red;
                    pbxContraseña.BorderThickness = new Thickness(2);
                }
                else
                {
                    // restauramos estado normal del borde
                    pbxContraseña.BorderBrush = Brushes.Transparent;
                }
            }
        }

        private void salir(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cb_elementoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cbIdiomas.SelectedItem;
            string selectedText = cbi.Content.ToString();
            if ((selectedText.Equals("ES") || selectedText.Equals("SP"))
            && !CultureInfo.CurrentCulture.Name.Equals("es-ES"))
            {
                App.SelectCulture("es-ES");
            }
            else if (selectedText.Equals("EN")
            && !CultureInfo.CurrentCulture.Name.Equals("en-US"))
            {
                App.SelectCulture("en-US");
            }
        }
    }

   
}
