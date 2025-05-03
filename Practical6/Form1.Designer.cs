namespace Practical6
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
            dateTimePicker1 = new DateTimePicker();
            labelDay = new Label();
            labelMonth = new Label();
            labelYear = new Label();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(2, -1);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(291, 27);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.Value = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // labelDay
            // 
            labelDay.AutoSize = true;
            labelDay.Location = new Point(2, 46);
            labelDay.Name = "labelDay";
            labelDay.Size = new Size(64, 20);
            labelDay.TabIndex = 1;
            labelDay.Text = "Day: DD";
            // 
            // labelMonth
            // 
            labelMonth.AutoSize = true;
            labelMonth.Location = new Point(2, 86);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(98, 20);
            labelMonth.TabIndex = 2;
            labelMonth.Text = "Month: MMM";
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(2, 66);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(76, 20);
            labelYear.TabIndex = 3;
            labelYear.Text = "Year: YYYY";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 105);
            Controls.Add(labelYear);
            Controls.Add(labelMonth);
            Controls.Add(labelDay);
            Controls.Add(dateTimePicker1);
            Name = "Form1";
            Text = "Dates";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label labelDay;
        private Label labelMonth;
        private Label labelYear;
    }
}
