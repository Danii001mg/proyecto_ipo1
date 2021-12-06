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
    /// Lógica de interacción para VentanaUsuario.xaml
    /// </summary>
    public partial class VentanaUsuario : Window
    {
        public VentanaUsuario()
        {
            InitializeComponent();
            App.SelectCulture("es-ES");
            txtApellidos.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtUltimoAcceso.IsEnabled = false;
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

        private void salir(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
