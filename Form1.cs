using System.Data;

namespace ZebyFormBgd
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            output_box.Text = currentCalculation;
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            string replaced_operators = currentCalculation.ToString().Replace("X", "*");
            string formattedCalculation = replaced_operators;

            try
            {
                output_box.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = output_box.Text;
            }
            catch (Exception ex)
            {
                output_box.Text = "";
                currentCalculation = "";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            // Reset the calculation and empty the textbox
            output_box.Text = "";
            currentCalculation = "";
        }

        private void button_ClearEntry_Click(object sender, EventArgs e)
        {
            // If the calculation is not empty, remove the last number/operator entered
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }

            // Re-display the calculation onto the screen
            output_box.Text = currentCalculation;
        }
    }
}