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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Pizzeria
{
    public partial class MainWindow : Window {

        private String EscribirTodo(StackPanel panel) {
            string texto = "";

            foreach (UIElement element in panel.Children)
            {
                if (element is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)element;
                    if (checkBox.IsChecked == true)
                    {
                        texto += checkBox.Content.ToString() + "\n";
                    }
                }
                else if (element is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)element;
                    if (radioButton.IsChecked == true)
                    {
                        texto += radioButton.Content.ToString() + "\n";
                    }
                }
            }

            return texto;
        }

        private void ResetearTodo(StackPanel panel)
        {
            foreach (Control ctl in panel.Children)
            {
                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(Label))
                    ((Label)ctl).Content = String.Empty;
                if (ctl.GetType() == typeof(RadioButton))
                    ((RadioButton)ctl).IsChecked = false;
            }
        }

        private void ponerImagen(System.Windows.Controls.Image image, String ruta)
        {
            image.Visibility = Visibility.Visible;
            image.Source = new BitmapImage(new Uri(ruta));
        }

        public MainWindow()
        {
            InitializeComponent();



        }


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ResetearTodo(stackPedido);
            txtPedido.Content += EscribirTodo(stackMasas);
            txtPedido.Content += EscribirTodo(stackBebidas);
            txtPedido.Content += EscribirTodo(stackIngredientes);


        }

        private void btnResetear_Click(object sender, RoutedEventArgs e)
        {
            ResetearTodo(stackMasas);
            ResetearTodo(stackBebidas);
            ResetearTodo(stackIngredientes);
            ResetearTodo(stackPedido);
            imagenBebida.Visibility = Visibility.Hidden;

        }

        private void radioBebidaAgua_Checked(object sender, RoutedEventArgs e)
        {
            String imagenPath = "E:\\Todo\\Informatica\\Grado Superior\\2023-2024\\Desarrollo de Interfaces\\1er Trimestre\\Tema 2\\WPF\\Pizzeria\\agua.jpg";
            ponerImagen(imagenBebida,imagenPath);

        }

        private void radioBebidaCocacola_Checked(object sender, RoutedEventArgs e)
        {
            String imagenPath = "E:\\Todo\\Informatica\\Grado Superior\\2023-2024\\Desarrollo de Interfaces\\1er Trimestre\\Tema 2\\WPF\\Pizzeria\\cocacola.jpg";
            ponerImagen(imagenBebida, imagenPath);
        }

        private void radioBebidaNaranja_Checked(object sender, RoutedEventArgs e)
        {
            String imagenPath = "E:\\Todo\\Informatica\\Grado Superior\\2023-2024\\Desarrollo de Interfaces\\1er Trimestre\\Tema 2\\WPF\\Pizzeria\\fanta.jpg";
            ponerImagen(imagenBebida, imagenPath);
        }

        private void radioBebidaFanta_Checked(object sender, RoutedEventArgs e)
        {
            String imagenPath = "E:\\Todo\\Informatica\\Grado Superior\\2023-2024\\Desarrollo de Interfaces\\1er Trimestre\\Tema 2\\WPF\\Pizzeria\\nestea.jpg";
            ponerImagen(imagenBebida, imagenPath);
        }

    }
}
