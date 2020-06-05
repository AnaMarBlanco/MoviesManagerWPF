using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoviesManagerWPF
{
    /// <summary>
    /// Interaction logic for rPeliculas.xaml
    /// </summary>
    public partial class rPeliculas : Window
    {
        private Peliculas pelicula = new Peliculas();
        public rPeliculas()
        {
            InitializeComponent();
            this.DataContext = pelicula;


        }


        private void Limpiar()
        {
            pelicula = new Peliculas();
            this.DataContext = pelicula;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = PeliculaBLL.Buscar(int.Parse(PeliculaIdTextBox.Text));

            if (encontrado != null)
            {
                this.pelicula = encontrado;

                this.DataContext = encontrado;
            }

            else
                this.pelicula = new Peliculas();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool Validar()
        {
            bool esValido = true;

            if (TituloTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            

            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PeliculaBLL.Guardar(pelicula);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PeliculaBLL.Eliminar(Convert.ToInt32(PeliculaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

       
    }
}
