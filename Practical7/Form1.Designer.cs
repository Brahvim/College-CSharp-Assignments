namespace Practical7
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            labelQuestion = new Label();
            labelTimer = new Label();
            button1 = new Button();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(3, 80);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(45, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "A)";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(255, 80);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(44, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "B)";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(4, 172);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(44, 24);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "C)";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(253, 172);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(46, 24);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "D)";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(3, 0);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(220, 20);
            labelQuestion.TabIndex = 5;
            labelQuestion.Text = "Click the button to start the test.";
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.Location = new Point(3, 41);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(44, 20);
            labelTimer.TabIndex = 7;
            labelTimer.Text = "00:00";
            // 
            // button1
            // 
            button1.Location = new Point(190, 37);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Start Test";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 254);
            Controls.Add(labelTimer);
            Controls.Add(button1);
            Controls.Add(labelQuestion);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Label labelQuestion;
        private Button button1;
        private Label labelTimer;
        private System.Windows.Forms.Timer timer;
    }
}
