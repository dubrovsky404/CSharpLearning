using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double firstOperand = 0;
        private double secondOperand = 0;
        private char currentOperation = '+';
        private bool isCounted = true;

        private Font defaultFont = new Font("Microsoft Sans Serif", 20);
        private Font smallFont = new Font("Microsoft Sans Serif", 16);
        private Font verySmallFont = new Font("Microsoft Sans Serif", 12);


        public Form1()
        {
            InitializeComponent();
        }

        // Метод для добавления чисел или точки в поле ввода
        private void AddLetter(string letter)
        {
            if (isCounted && letter == ".")
            {
                mainTextBox.Text = "0.";
                isCounted = false;
            }
            else if ((mainTextBox.Text == "0" || isCounted) && letter != ".")
            {
                mainTextBox.Text = letter;
                isCounted = false;
            }
            else
                mainTextBox.Text += letter;
        }

        // Метод, выполняющий выбранную арифметическую операцию
        private double DoOperation(double firstOperand, double secondOperand, char operation)
        {
            switch (operation)
            {
                case '+':
                    return firstOperand + secondOperand;
                case '-':
                    return firstOperand - secondOperand;
                case '×':
                    return firstOperand * secondOperand;
                case '÷':
                    return firstOperand / secondOperand;
            }
            return 0;
        }

        // Событие нажатия на кнопки с цифрами или точкой
        private void btn7_Click(object sender, EventArgs e)
        {
            string btnValue = (sender as Button).Text;

            if (btnValue == "." && mainTextBox.Text.Contains('.') && !isCounted)
                return;

            if (mainTextBox.Text.Length < 16)
                AddLetter(btnValue);
        }

        // Событие клика на кнопки операций
        private void operationBtn_Click(object sender, EventArgs e)
        {
            string currentOperand = mainTextBox.Text;

            if (firstOperand == 0)
            {
                firstOperand = double.Parse(currentOperand);
            }
            else
            {
                secondOperand = double.Parse(currentOperand);
                firstOperand = DoOperation(firstOperand, secondOperand, currentOperation);
                secondOperand = 0;
                currentOperand = firstOperand.ToString();
            }

            string btnValue = (sender as Button).Text;
            currentOperation = btnValue[0];
            operationsView.Text = $"{currentOperand} {btnValue}";
            mainTextBox.Text = "0";
        }

        // Событие клика на кнопку "="
        private void btnResult_Click(object sender, EventArgs e)
        {
            isCounted = true;
            if (firstOperand == 0)
                return;

            secondOperand = double.Parse(mainTextBox.Text);
            mainTextBox.Text = DoOperation(firstOperand, secondOperand, currentOperation).ToString();
            firstOperand = 0;
            secondOperand = 0;
            operationsView.Text = "";
        }

        // Событие клика на кнопку "±"
        private void btnNegative_Click(object sender, EventArgs e)
        {
            string currentOperand = mainTextBox.Text;
            if (currentOperand == "0")
                return;

            if (currentOperand.Contains('-'))
                mainTextBox.Text = currentOperand.Replace("-", "");
            else
                mainTextBox.Text = "-" + currentOperand;
        }

        // Событие клика на кнопку сброса
        private void btnClear_Click(object sender, EventArgs e)
        {
            firstOperand = 0;
            secondOperand = 0;
            isCounted = true;
            mainTextBox.Text = "0";
            operationsView.Text = "";
        }

        // Событие клика на кнопку удаления символа
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string currentOperand = mainTextBox.Text;
            if (currentOperand == "0")
                return;

            if (currentOperand.Length == 1)
                mainTextBox.Text = "0";
            else
                mainTextBox.Text = currentOperand.Substring(0, currentOperand.Length - 1);
        }

        // Событие при изменении текста основного текстового поля
        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            var length = mainTextBox.Text.Length;

            if (length > 18)
                mainTextBox.Font = verySmallFont;
            else if (length > 12)
                mainTextBox.Font = smallFont;
            else
                mainTextBox.Font = defaultFont;
        }
    }
}
