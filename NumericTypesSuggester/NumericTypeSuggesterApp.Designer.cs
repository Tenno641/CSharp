namespace NumericTypesSuggester
{
    partial class NumericTypeSuggesterApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CounterText = new Label();
            IncreaseCounterButton = new Button();
            SuspendLayout();
            // 
            // CounterText
            // 
            CounterText.AutoSize = true;
            CounterText.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CounterText.Location = new Point(90, 81);
            CounterText.Name = "CounterText";
            CounterText.Size = new Size(24, 30);
            CounterText.TabIndex = 0;
            CounterText.Text = "0";
            // 
            // IncreaseCounterButton
            // 
            IncreaseCounterButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IncreaseCounterButton.Location = new Point(131, 69);
            IncreaseCounterButton.Name = "IncreaseCounterButton";
            IncreaseCounterButton.Size = new Size(236, 53);
            IncreaseCounterButton.TabIndex = 1;
            IncreaseCounterButton.Text = "Increase Counter";
            IncreaseCounterButton.UseVisualStyleBackColor = true;
            IncreaseCounterButton.Click += IncreaseCounterButton_Click;
            // 
            // NumericTypeSuggesterApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 450);
            Controls.Add(IncreaseCounterButton);
            Controls.Add(CounterText);
            Name = "NumericTypeSuggesterApp";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CounterText;
        private Button IncreaseCounterButton;
    }
}
