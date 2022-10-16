using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Lógica de interacción para ControlAlojamientoPersonalizado.xaml
    /// </summary>
    public partial class ControlAlojamientoPersonalizado : UserControl
    {
        Bungalow bungalow = null;
        Parcela parcela = null;
        DatosReserva reserva = null;
        public ControlAlojamientoPersonalizado(DatosReserva reserva, Bungalow bungalow = null, Parcela parcela = null)
        {
            InitializeComponent();
            this.reserva = reserva;
            if (bungalow == null)
            {
                this.parcela = parcela;
                mostrar(parcela.nombre, parcela.ToString(), parcela.imagenes);
            }
            else if (parcela == null)
            {
                this.bungalow = bungalow;
                mostrar(bungalow.nombre, bungalow.ToString(), bungalow.imagenes);
            }

        }


        private void mostrar(String nombre, String info, List<String> imagenes)
        {
            lblNombreAlojamiento.Content = nombre;
            lblDescipcion.Content = info;
            BitmapImage source = new BitmapImage(new Uri(imagenes[0], UriKind.Relative));
            imagen1.Source = source;
            source = new BitmapImage(new Uri(imagenes[1], UriKind.Relative));
            imagen2.Source = source;
        }

       
       
        private void reservar_click(object sender, RoutedEventArgs e)
        {
            PagoReserva win2 = null;
            if (bungalow == null) win2 = new PagoReserva(this.reserva, parcela: this.parcela);
            else if (parcela == null) win2 = new PagoReserva(this.reserva, bungalow: this.bungalow);

            win2.Show();
        }
    }
}