using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Calcuator
{
    public partial class Form1 : Form
    {
        private string expression = "";
        private readonly List<string> inputSequence = new();
        private readonly List<string> secretSequence = new() { "1", "2", "3", "4" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn)
                return;

            string btnText = btn.Text;

            if (btnText == "=")
            {
                try
                {
                    var result = new DataTable().Compute(expression, null);
                    textBoxDisplay.Text = result.ToString();
                    expression = result.ToString();
                    inputSequence.Clear();
                }
                catch
                {
                    textBoxDisplay.Text = "Error";
                    expression = "";
                    inputSequence.Clear();
                }
            }
            else if (btnText == "C")
            {
                expression = "";
                inputSequence.Clear();
                textBoxDisplay.Text = "";
            }
            else
            {
                expression += btnText;
                textBoxDisplay.Text = expression;

                if (char.IsDigit(btnText, 0))
                {
                    inputSequence.Add(btnText);
                    if (inputSequence.Count > secretSequence.Count)
                        inputSequence.RemoveAt(0);

                    if (IsSecretSequence())
                    {
                        MessageBox.Show("You've unlocked the secret!", "Secret");
                        inputSequence.Clear();
                    }
                }
                else
                {
                    inputSequence.Clear();
                }
            }
        }

        private bool IsSecretSequence()
        {
            if (inputSequence.Count != secretSequence.Count)
                return false;

            for (int i = 0; i < secretSequence.Count; i++)
            {
                if (inputSequence[i] != secretSequence[i])
                    return false;
            }

            return true;
        }
    }
}
