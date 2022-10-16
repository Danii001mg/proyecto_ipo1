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
    /// Lógica de interacción para Reservas.xaml
    /// </summary>
    public partial class Reservas : Window
    {
        public List<Parcela> parcelas = crearListaParcelas();
        public List<Bungalow> bungalows = crearListaBungalows();
        public Usuario usuario;
        string language;
        public Reservas(Usuario usuario, string language)
        {
            this.language = language;
            InitializeComponent();
            this.usuario = usuario;
            BitmapImage image = new BitmapImage(new Uri(usuario.imagen, UriKind.Relative));
            imgUsuario.Source = image;
            lblUsername.Content = usuario.username;
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

        private void btnAceptarFechaEntrada_Click(object sender, RoutedEventArgs e)
        {
            if (calenFechaEntrada.SelectedDate >= DateTime.Now)
            {
                lblFechaEntrada.Content = Convert.ToDateTime(calenFechaEntrada.SelectedDate).ToString("d", CultureInfo.CreateSpecificCulture(this.language));
                FechaSalida.Visibility = Visibility.Visible;
                FechaEntrada.Visibility = Visibility.Hidden;
            }
            else
            {
                lblFechaEntradaInfo.Foreground = Brushes.Red;
                lblFechaEntradaInfo.Content = "Fecha no válida!";
            }

        }
        private void btnAceptarFechaSalida_Click(object sender, RoutedEventArgs e)
        {
            if (calenFechaSalida.SelectedDate > Convert.ToDateTime(lblFechaEntrada.Content))
            {
                lblFechaSalida.Content = Convert.ToDateTime(calenFechaSalida.SelectedDate).ToString("d", CultureInfo.CreateSpecificCulture(this.language));
                FechaSalida.Visibility = Visibility.Hidden;
                Huespedes.Visibility = Visibility.Visible;
            }
            else
            {
                lblFechaSalidaInfo.Foreground = Brushes.Red;
                lblFechaSalidaInfo.Content = "Fecha no válida!";
            }
        }
        private void btnAceptarHuespedes_Click(object sender, RoutedEventArgs e)
        {
            lblHuespedes.Content = ((Convert.ToInt32(txtAdultos.Text) + Convert.ToInt32(txtNinios.Text)).ToString());
            Huespedes.Visibility = Visibility.Hidden;
        }
        String tipoAlojamiento = "Parcelas";
        private void btnParcelas_Click(object sender, RoutedEventArgs e)
        {
            tipoAlojamiento = "Parcelas";
            btnParcelas.IsEnabled = false;
            btnBungalows.IsEnabled = true;
            
            
        }
        //BOTONES CANCELAR
        private void btnBungalows_Click(object sender, RoutedEventArgs e)
        {
            tipoAlojamiento = "Bungalows";
            btnParcelas.IsEnabled = true;
            btnBungalows.IsEnabled = false;
        }
        private void btnCalcelarFechaSalida_Click(object sender, RoutedEventArgs e)
        {
            FechaSalida.Visibility = Visibility.Hidden;
        }
        private void btnCancelarHuespedes_Click(object sender, RoutedEventArgs e)
        {
            Huespedes.Visibility = Visibility.Hidden;
        }
        private void btnCancelarFechaEntrada_Click(object sender, RoutedEventArgs e)
        {
            FechaEntrada.Visibility = Visibility.Hidden;
        }
        //BOTONES GENERALES
        private void btnFechaEntrada_Click(object sender, RoutedEventArgs e)
        {
            FechaEntrada.Visibility = Visibility.Visible;
            FechaSalida.Visibility = Visibility.Hidden;
            Huespedes.Visibility = Visibility.Hidden;
        }

        private void btnFechaSalida_Click(object sender, RoutedEventArgs e)
        {
            FechaSalida.Visibility = Visibility.Visible;
            Huespedes.Visibility = Visibility.Hidden;
            FechaEntrada.Visibility = Visibility.Hidden;
        }
        private void btnHuespedes_Click(object sender, RoutedEventArgs e)
        {
            Huespedes.Visibility = Visibility.Visible;
            FechaSalida.Visibility = Visibility.Hidden;
            FechaEntrada.Visibility = Visibility.Hidden;
        }
        private void btntipoAlojamiento_Click(object sender, RoutedEventArgs e)
        {

        }
        //BOTONES AÑADIR Y QUITAR HUESPEDES
        private void cmdUp4_Click(object sender, RoutedEventArgs e)
        {
            int NumAdultos = Convert.ToInt32(txtAdultos.Text);
            if (NumAdultos < 8)
            {
                txtAdultos.Text = (NumAdultos + 1).ToString();
            }
            else
            {
                txtAdultos.Text = "8";
            }

        }

        private void cmdDown4_Click(object sender, RoutedEventArgs e)
        {
            int NumAdultos = Convert.ToInt32(txtAdultos.Text);
            if (NumAdultos > 1)
            {
                txtAdultos.Text = (NumAdultos - 1).ToString();
            }
            else
            {
                txtAdultos.Text = "1";
            }
        }

        private void cmdDown2_Click(object sender, RoutedEventArgs e)
        {
            int NumNinios = Convert.ToInt32(txtNinios.Text);
            if (NumNinios > 0)
            {
                txtNinios.Text = (NumNinios - 1).ToString();
            }
            else
            {
                txtNinios.Text = "0";
            }
        }

        private void cmdUp2_Click(object sender, RoutedEventArgs e)
        {
            int NumNinios = Convert.ToInt32(txtNinios.Text);
            if (NumNinios < 8)
            {
                txtNinios.Text = (NumNinios + 1).ToString();
            }
            else
            {
                txtNinios.Text = "8";
            }
        }

        //BUSCAR
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spReservas.Children.Clear();
            String[] Huespedes = new string[2];
            Huespedes[0] = txtAdultos.Text;
            Huespedes[1] = txtNinios.Text;
            if (String.Equals(lblFechaEntrada.Content, "-"))
            {
                btnFechaEntrada_Click(sender, e);
            }
            else if (String.Equals(lblFechaSalida.Content, "-"))
            {

                btnFechaSalida_Click(sender, e);
            }
            else
            {
                DatosReserva reserva = new DatosReserva(Convert.ToDateTime(lblFechaEntrada.Content), Convert.ToDateTime(lblFechaSalida.Content), Huespedes, tipoAlojamiento);
                if (btnParcelas.IsEnabled == false)
                {
                    for (int i = 0; i < parcelas.Count; i++)
                    {
                        if (parcelas[i].ComprobarFecha(reserva.FechaEntrada, reserva.FechaSalida))
                        {
                            spReservas.Children.Add(new ControlAlojamientoPersonalizado(reserva, parcela: parcelas[i]));
                        }
                    }
                }
                else if (btnBungalows.IsEnabled == false)
                {
                    for (int i = 0; i < bungalows.Count; i++)
                    {
                        if (bungalows[i].capacidad >= (Int32.Parse(reserva.Huespedes[0]) + Int32.Parse(reserva.Huespedes[1])) && bungalows[i].ComprobarFecha(reserva.FechaEntrada, reserva.FechaSalida))
                        {
                            spReservas.Children.Add(new ControlAlojamientoPersonalizado(reserva, bungalow: bungalows[i]));
                        }
                    }
                }
            }
        }

        public static List<Parcela> crearListaParcelas()
        {
            List<string> tamanio = new List<string>() { "deluxe", "mediana", "mediana", "pequeña", "autocaravana" };
            List<string> ubicacion = new List<string>() { "cerca puerto lago", "cerca entrada resort", "cerca entrada resort", "cerca piscina resort", "cerca pistas de tenis" };
            List<string> caracteristicasAdicionales = new List<string>() { "piscina incluida", "jacuzzi", "billar", "1 toma de agua", "1 toma de agua y de luz" };
            List<double> precio = new List<double>() { 120, 70, 65, 30, 35 };
            List<List<string>> imagenes = new List<List<string>>();
            imagenes.Add(new List<string> { "./Imagenes/par5.jpg", "./Imagenes/par6.jpg" });
            imagenes.Add(new List<string> { "./Imagenes/par3.jpg", "./Imagenes/par4.jpg" });
            imagenes.Add(new List<string> { "./Imagenes/par3.jpg", "./Imagenes/par4.jpg" });
            imagenes.Add(new List<string> { "./Imagenes/par1.jpg", "./Imagenes/par2.jpg" });
            imagenes.Add(new List<string> { "./Imagenes/par5.jpg", "./Imagenes/par6.jpg" });
            List<Parcela> parcelas = new List<Parcela>();
            for (int i = 0; i < tamanio.Count; i++)
            {
                Parcela parcela = new Parcela(tamanio[i], ubicacion[i], precio[i], caracteristicasAdicionales[i], imagenes[i]);
                parcelas.Add(parcela);
            }

            return parcelas;
        }
        public static List<Bungalow> crearListaBungalows()
        {
            List<string> tamanio = new List<string>() { "deluxe", "mediana", "mediana", "pequeña", "pequeña" };
            List<int> capacidad = new List<int>() { 12, 7, 6, 2, 3 };
            List<double> precio = new List<double>() { 120, 70, 65, 30, 35 };
            List<string> caracteristicasAdicionales = new List<string>() { "internet, objetos utiles de aseo", "3 habitaciones", "internet", "2 baños", "objetos utiles de aseo" };
            List<List<string>> imagenes = new List<List<string>>();
            imagenes.Add(new List<string> { "./imagenes/bu5.jpg", "./imagenes/bu6.jpg" });
            imagenes.Add(new List<string> { "./imagenes/bu3.jpg", "./imagenes/bu4.jpg" });
            imagenes.Add(new List<string> { "./imagenes/bu3.jpg", "./imagenes/bu4.jpg" });
            imagenes.Add(new List<string> { "./imagenes/bu1.jpg", "./imagenes/bu2.jpg" });
            imagenes.Add(new List<string> { "./imagenes/bu1.jpg", "./imagenes/bu2.jpg" });
            List<Bungalow> bungalows = new List<Bungalow>();
            for (int i = 0; i < tamanio.Count; i++)
            {
                Bungalow bungalow = new Bungalow(tamanio[i], capacidad[i], precio[i], caracteristicasAdicionales[i], imagenes[i]);
                bungalows.Add(bungalow);
            }

            return bungalows;
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