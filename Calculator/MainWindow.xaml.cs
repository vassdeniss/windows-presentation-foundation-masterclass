using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber;
        private double result;
        private Operator currentOperator;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button)!.Content.ToString()!;

            if (this.resultLabel.Content.ToString() == "0")
            {
                this.resultLabel.Content = value.ToString();
            }
            else
            {
                this.resultLabel.Content += value.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.resultLabel.Content.ToString(), out this.lastNumber))
            {
                this.resultLabel.Content = "0";
            }

            if (sender == this.multiplicationButton)
                this.currentOperator = Operator.Multiplication;
            if (sender == this.divisionButton)
                this.currentOperator = Operator.Division;
            if (sender == this.plusButton)
                this.currentOperator = Operator.Addition;
            if (sender == this.minusButton)
                this.currentOperator = Operator.Subtraction;
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            this.resultLabel.Content = "0";
            this.lastNumber = 0;
            this.result = 0;
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.resultLabel.Content.ToString(), out this.lastNumber))
            {
                this.lastNumber *= -1;
                this.resultLabel.Content = this.lastNumber.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.resultLabel.Content.ToString(), out double tempNumber))
            {
                tempNumber /= 100;

                if (this.lastNumber != 0)
                {
                    tempNumber *= this.lastNumber;
                }


                this.resultLabel.Content = tempNumber.ToString();
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.resultLabel.Content.ToString()!.Contains('.'))
            {
                this.resultLabel.Content += ".";
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.resultLabel.Content.ToString(), out double newNumber))
            {
                switch (this.currentOperator)
                {
                    case Operator.Addition:
                        this.result = this.Add(this.lastNumber, newNumber);
                        break;
                    case Operator.Subtraction:
                        this.result = this.Subtract(this.lastNumber, newNumber);
                        break;
                    case Operator.Multiplication:
                        this.result = this.Multiply(this.lastNumber, newNumber);
                        break;
                    case Operator.Division:
                        this.result = this.Division(this.lastNumber, newNumber);
                        break;
                }

                this.resultLabel.Content = this.result.ToString();
            }
        }

        private double Add(double numberOne, double numberTwo) => numberOne + numberTwo;

        private double Subtract(double numberOne, double numberTwo) => numberOne - numberTwo;

        private double Multiply(double numberOne, double numberTwo) => numberOne * numberTwo;

        private double Division(double numberOne, double numberTwo)
        {
            if (numberTwo == 0)
            {
                MessageBox.Show("Division by 0 is not supported!",
                                "Wrong operation!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return 0;
            }

            return numberOne / numberTwo;
        }
    }
}
