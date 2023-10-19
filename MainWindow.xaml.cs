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
        }
    }
}
