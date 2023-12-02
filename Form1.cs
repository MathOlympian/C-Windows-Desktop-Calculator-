using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculatorCSharp
{
    public partial class Form1 : Form
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double result = 0.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void DigitButtonClick(object sender, EventArgs e) 
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            UpdateDisplay();
        }

        private void OperatorButtonClick(object sender, EventArgs e) 
        {
            Button button = (Button)sender;
            currentOperator = button.Text;
            if (double.TryParse(currentInput, out result))
            {
                currentInput = "";
                UpdateDisplay();
            }
            else 
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        private void EqualsButtonClick(object sender, EventArgs e) 
        {
            if (double.TryParse(currentInput, out double newInput))
            {
                switch (currentOperator)
                {
                    case "+":
                        result += newInput;
                        break;
                    case "-":
                        result -= newInput;
                        break;
                    case "*":
                        result *= newInput;
                        break;
                    case "/":
                        if (newInput != 0)
                        {
                            result /= newInput;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Clear();
                        }
                        break;
                }
                currentInput = result.ToString();
                UpdateDisplay();
            }
            else 
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        private void ClearButtonClick(object sender, EventArgs e) 
        {
            Clear();
            UpdateDisplay();
        }

        private void UpdateDisplay() 
        {

            textBox1.Text = currentInput;
        }

        private void Clear() 
        {
            currentInput = "";
            currentOperator = "";
            result = 0.0;
        }
    }
}
