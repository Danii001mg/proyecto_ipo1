using Microsoft.Win32;
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
    /// Lógica de interacción para rutas.xaml
    /// </summary>
    public partial class NuevaRuta : Window
    {
        public NuevaRuta()
        {
            InitializeComponent();
           inkCanvas1.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void inicioArrastrar(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject((Image)sender);
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void añadirObjeto(object sender, DragEventArgs e)
        {
            Image imgDragged = (Image)e.Data.GetData(typeof(Image));
            Image imgToUpdate = (Image)e.OriginalSource;
            imgToUpdate.Source = imgDragged.Source;
        }

        private void inkCanvas1_Gesture(object sender, InkCanvasGestureEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.Strokes.Clear();
        }

        private void btnCrearActividad_Click(object sender, RoutedEventArgs e)
        {
            txtNombreRuta.BorderBrush = Brushes.Gray;
            txtDuracion.BorderBrush = Brushes.Gray;
            txtEncuentro.BorderBrush = Brushes.Gray;
            txtDificultad.BorderBrush = Brushes.Gray;
            if (String.IsNullOrEmpty(txtNombreRuta.Text)) txtNombreRuta.BorderBrush = Brushes.Red;
            else if (String.IsNullOrEmpty(txtDuracion.Text)) txtDuracion.BorderBrush = Brushes.Red;
            else if (String.IsNullOrEmpty(txtEncuentro.Text)) txtEncuentro.BorderBrush = Brushes.Red;
            else if (String.IsNullOrEmpty(txtDificultad.Text)) txtDificultad.BorderBrush = Brushes.Red;
            else
            {
                MessageBox.Show("Se ha creado la ruta!");
                this.Close();
            }

        }

        private void btnRojo_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void btnVerde_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void btnAzul_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.LightBlue;
        }
        private void btnNegro_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void btnBlanco_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.White;
        }
    }
}
