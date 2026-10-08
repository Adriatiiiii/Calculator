using System;
using System.Data;

namespace Calculator_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AppendToCalculationString(object sender, EventArgs e)
        {
            Button invokedBtn = sender as Button;
            if (invokedBtn != null)
            {
                resultBox.Text += invokedBtn.Text;
            }
        }

        private void ClearEntry(object sender, EventArgs e)
        {
            resultBox.Text = string.Empty;
        }

        private void EvaluateCalculation(object sender, EventArgs e)
        {
            string expression = resultBox.Text;
            var result = new DataTable();
            try
            {
                double evaluatedResult = Convert.ToDouble(result.Compute(expression, null));
                if (double.IsInfinity(evaluatedResult) || double.IsNaN(evaluatedResult))
                {
                    MessageBox.Show("Expression was evaluated to be undefined.", "Evaluated Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resultBox.Text = string.Empty;
                    return;
                }
                resultBox.Text = evaluatedResult.ToString();
            }
            catch (System.Data.SyntaxErrorException)
            {
                MessageBox.Show("Expression was not valid.", "Syntax Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultBox.Text = string.Empty;
            }
        }
    }
}
