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
            int value = 0;

            if (sender == this.zeroButton)
                value = 0;
            if (sender == this.oneButton)
                value = 1;
            if (sender == this.twoButton)
                value = 2;
            if (sender == this.threeButton)
                value = 3;
            if (sender == this.fourButton)
                value = 4;
            if (sender == this.fiveButton)
                value = 5;
            if (sender == this.sixButton)
                value = 6;
            if (sender == this.sevenButton)
                value = 7;
            if (sender == this.eightButton)
                value = 8;
            if (sender == this.nineButton)
                value = 9;

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
            if (double.TryParse(this.resultLabel.Content.ToString(), out this.lastNumber))
            {
                this.lastNumber /= 100;
                this.resultLabel.Content = this.lastNumber.ToString();
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.resultLabel.Content.ToString().Contains('.'))
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
                        this.result = this.lastNumber + newNumber;
                        break;
                    case Operator.Subtraction:
                        this.result = this.lastNumber - newNumber;
                        break;
                    case Operator.Multiplication:
                        this.result = this.lastNumber * newNumber;
                        break;
                    case Operator.Division:
                        this.result = this.lastNumber / newNumber;
                        break;
                }

                this.resultLabel.Content = this.result.ToString();
            }
        }
    }
}
