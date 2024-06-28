using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        double lastNumber;
        double result;

        SelectedOperator selectedOperator;

        public MainWindow() {
            InitializeComponent();
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e) {

            if(double.TryParse(LbResult.Content.ToString(), out lastNumber)) {
                LbResult.Content = "0";
            }

            if (sender == BtnMultiply)
                selectedOperator = SelectedOperator.Multiplication;
            else if (sender == BtnDivide)
                selectedOperator = SelectedOperator.Division;
            else if (sender == BtnPlus)
                selectedOperator = SelectedOperator.Addition;
            else if (sender == BtnMinus)
                selectedOperator = SelectedOperator.Subtraction;

        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e) {

            _ = int.TryParse((sender as Button).Content.ToString(), out int selectedValue);

            if(LbResult.Content.ToString() == "0") {
                LbResult.Content = selectedValue;
            } else {
                LbResult.Content += $"{selectedValue}";
            }

        }

        private void BtnAC_Click(object sender, RoutedEventArgs e) {
            LbResult.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void BtnReverseSignal_Click(object sender, RoutedEventArgs e) {

            if (LbResult.Content.ToString() == "0")
                return;

            if (double.TryParse(LbResult.Content.ToString(), out lastNumber)) {
                LbResult.Content = (lastNumber *= -1);
            }

        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e) {

            if (double.TryParse(LbResult.Content.ToString(), out double tempNumber)) {

                tempNumber /= 100;

                if (lastNumber != 0)
                    tempNumber *= lastNumber;

                LbResult.Content = $"{tempNumber}";
            }


        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e) {

            if(double.TryParse(LbResult.Content.ToString(), out double newNumber)) {

                switch (selectedOperator) {

                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;

                }
            }

            LbResult.Content = result.ToString();
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e) {
            if (!LbResult.Content.ToString().Contains('.'))
                LbResult.Content += $".";
        }
    }

    public enum SelectedOperator {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

}