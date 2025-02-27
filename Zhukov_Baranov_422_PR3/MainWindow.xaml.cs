using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zhukov_Baranov_422_PR3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.textBox1.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.textBox2.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.textBox3.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string currentText = textBox.Text;
            string pattern = @"^-?\d*[.]?\d*$";
            string newText = currentText.Insert(textBox.SelectionStart, e.Text);
            if (!Regex.IsMatch(newText, pattern))
            {
                e.Handled = true;
            }
            else if (e.Text == "." && currentText.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void Summ_Click(object sender, RoutedEventArgs e)
        {

            bool error = false;
            double material = 0;
            if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Уважаемый пользователь! Заполните все поля!!!");
                error = true;

            }
            if (olovoRB.IsChecked == true)
            {
                material = 7.31;
            }
            else if (swinesRB.IsChecked == true)
            {
                material = 11.34;
            }
            else if (IronRB.IsChecked == true)
            {
                material = 7.8;
            }
            else if (IceRB.IsChecked == true)
            {
                material = 90000;
            }
            else
            {
                MessageBox.Show("Уважаемый пользователь! Заполните все поля !!!");
                error = true;
            }
            if (error != true)
            {
                double height = Convert.ToDouble(textBox1.Text);
                double width = Convert.ToDouble(textBox2.Text);
                double length = Convert.ToDouble(textBox3.Text);
                double v = length * width * height;
                double result = v * material;
                ResultBox.Text = "" + result;
            }
        }

    }
}