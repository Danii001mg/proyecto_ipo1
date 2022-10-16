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

namespace proyecto_ipo1
{
    /// <summary>
    /// Lógica de interacción para PagoReserva.xaml
    /// </summary>
    public partial class PagoReserva : Window
    {
        Bungalow bungalow = null;
        Parcela parcela = null;
        DatosReserva reserva = null;
        public PagoReserva(DatosReserva reserva, Bungalow bungalow = null, Parcela parcela = null)
        {
            InitializeComponent();
            this.reserva = reserva;
            TimeSpan difFechas = reserva.FechaSalida - reserva.FechaEntrada;
            int dias = difFechas.Days;
            if (bungalow == null)
            {
                this.parcela = parcela;
                mostrar(parcela.Descripcion() + "\n" + reserva.ToString(), parcela.precio * dias);
            }
            else if (parcela == null)
            {
                this.bungalow = bungalow;
                mostrar(bungalow.Descripcion() + "\n" + reserva.ToString(), bungalow.precio * dias);
            }
        }

        private void mostrar(String info, double precio)
        {
            lblDescripcion.Content = info;
            lblPrecio.Content = precio.ToString() + " €";
        }

        private void btnDatosReservaContinuar_Click(object sender, RoutedEventArgs e)
        {
            txtNombreApellidos.BorderBrush = Brushes.Gray;
            txtTelefono.BorderBrush = Brushes.Gray;
            txtHoraEntrada.BorderBrush = Brushes.Gray;
            txtHoraSalida.BorderBrush = Brushes.Gray;
            lblErrorNombreApellidos.Visibility = Visibility.Hidden;
            lblErrorTelefono.Visibility = Visibility.Hidden;
            lblErrorHoraEntrada.Visibility = Visibility.Hidden;
            lblErrorHoraSalida.Visibility = Visibility.Hidden;
            if (String.IsNullOrEmpty(txtNombreApellidos.Text))
            {
                lblErrorNombreApellidos.Visibility = Visibility.Visible;
                txtNombreApellidos.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtTelefono.Text) || !(txtTelefono.Text.All(char.IsDigit) && txtTelefono.Text.Length == 9))
            {
                lblErrorTelefono.Visibility = Visibility.Visible;
                txtTelefono.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtHoraEntrada.Text) || !(txtHoraEntrada.Text.Length <= 2 && txtHoraEntrada.Text.All(char.IsDigit) && Int32.Parse(txtHoraEntrada.Text) < 24 && Int32.Parse(txtHoraEntrada.Text) >= 0))
            {
                lblErrorHoraEntrada.Visibility = Visibility.Visible;
                txtHoraEntrada.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtHoraSalida.Text) || !(txtHoraSalida.Text.Length <= 2 && txtHoraSalida.Text.All(char.IsDigit) && Int32.Parse(txtHoraSalida.Text) < 24 && Int32.Parse(txtHoraSalida.Text) >= 0))
            {
                lblErrorHoraSalida.Visibility = Visibility.Visible;
                txtHoraSalida.BorderBrush = Brushes.Red;
            }
            else
            {
                DatosReserva.Visibility = Visibility.Hidden;
                Información_de_pago.Visibility = Visibility.Visible;
            }
        }

        private void DatosReservaCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InfoPagoContinuar(object sender, RoutedEventArgs e)
        {
            lblErrorTitular.Visibility = Visibility.Hidden;
            lblErrorTarjeta.Visibility = Visibility.Hidden;
            lblErrorCaducidad.Visibility = Visibility.Hidden;
            lblErrorSeguridad.Visibility = Visibility.Hidden;
            txtTitular.BorderBrush = Brushes.Gray;
            txtTarjeta.BorderBrush = Brushes.Gray;
            txtMes.BorderBrush = Brushes.Gray;
            txtAnio.BorderBrush = Brushes.Gray;
            txtSeguridad.BorderBrush = Brushes.Gray;
            if (String.IsNullOrEmpty(txtTitular.Text))
            {
                lblErrorTitular.Visibility = Visibility.Visible;
                txtTitular.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtTarjeta.Text) || !txtTarjeta.Text.All(char.IsDigit))
            {
                lblErrorTarjeta.Visibility = Visibility.Visible;
                txtTarjeta.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtMes.Text) || !(txtMes.Text.All(char.IsDigit) && Int32.Parse(txtMes.Text) <= 12 && Int32.Parse(txtMes.Text) >= 0))
            {
                lblErrorCaducidad.Visibility = Visibility.Visible;
                txtMes.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtAnio.Text) || !(txtAnio.Text.All(char.IsDigit) && Int32.Parse(txtAnio.Text) >= 2021))
            {
                lblErrorCaducidad.Visibility = Visibility.Visible;
                txtAnio.BorderBrush = Brushes.Red;
            }
            else if (String.IsNullOrEmpty(txtSeguridad.Text) || !txtSeguridad.Text.All(char.IsDigit))
            {
                lblErrorSeguridad.Visibility = Visibility.Visible;
                txtSeguridad.BorderBrush = Brushes.Red;
            }
            else
            {
                lblConfirmacion.Content = txtNombreApellidos.Text + "\n" + lblDescripcion.Content.ToString() + "\n" + lblPrecio.Content.ToString();

                Información_de_pago.Visibility = Visibility.Hidden;
                Confirmación.Visibility = Visibility.Visible;
            }
        }

        private void InfoPagoAtras(object sender, RoutedEventArgs e)
        {
            DatosReserva.Visibility = Visibility.Visible;
            Información_de_pago.Visibility = Visibility.Hidden;
        }


        private void ConfirmacionFinalizar(object sender, RoutedEventArgs e)
        {
            if (this.bungalow == null)
            {
                this.parcela.fechas.Add(new List<DateTime> { this.reserva.FechaEntrada, this.reserva.FechaSalida });
            }
            else if (this.parcela == null)
            {
                this.bungalow.fechas.Add(new List<DateTime> { this.reserva.FechaEntrada, this.reserva.FechaSalida });
            }
            this.Close();
        }

        private void ConfirmacionAtras(object sender, RoutedEventArgs e)
        {
            Información_de_pago.Visibility = Visibility.Visible;
            Confirmación.Visibility = Visibility.Hidden;
        }
    }
}

