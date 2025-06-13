namespace Calcuator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxDisplay;
        private System.Windows.Forms.Button[] buttons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxDisplay = new System.Windows.Forms.TextBox();
            this.buttons = new System.Windows.Forms.Button[17];

            this.SuspendLayout();

            // 
            // textBoxDisplay
            // 
            this.textBoxDisplay.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.textBoxDisplay.Location = new System.Drawing.Point(12, 12);
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.ReadOnly = true;
            this.textBoxDisplay.Size = new System.Drawing.Size(260, 43);
            this.textBoxDisplay.TabIndex = 0;
            this.textBoxDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // 
            // Buttons
            // Define buttons text and positions
            // 
            string[] btnTexts = { "7", "8", "9", "/",
                                  "4", "5", "6", "*",
                                  "1", "2", "3", "-",
                                  "0", ".", "=", "+",
                                  "C" };

            int startX = 12;
            int startY = 65;
            int btnWidth = 60;
            int btnHeight = 45;
            int spacing = 5;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new System.Windows.Forms.Button();
                buttons[i].Text = btnTexts[i];
                buttons[i].Size = new System.Drawing.Size(btnWidth, btnHeight);

                int col = i % 4;
                int row = i / 4;

                // For the 'C' button (index 16), place it on the bottom left, spanning full row width except last column
                if (i == 16)
                {
                    buttons[i].Location = new System.Drawing.Point(startX, startY + row * (btnHeight + spacing));
                    buttons[i].Size = new System.Drawing.Size(btnWidth * 3 + spacing * 2, btnHeight);
                }
                else
                {
                    buttons[i].Location = new System.Drawing.Point(startX + col * (btnWidth + spacing), startY + row * (btnHeight + spacing));
                }

                buttons[i].TabIndex = i + 1;
                buttons[i].UseVisualStyleBackColor = true;
                buttons[i].Click += new System.EventHandler(this.Button_Click);

                this.Controls.Add(buttons[i]);
            }

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.textBoxDisplay);
            this.Name = "Form1";
            this.Text = "Secret Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
