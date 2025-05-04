namespace Practical10
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
            dataGridView1 = new DataGridView();
            labelConnectivity = new Label();
            buttonConfig = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(637, 450);
            dataGridView1.TabIndex = 0;
            // 
            // labelConnectivity
            // 
            labelConnectivity.AutoSize = true;
            labelConnectivity.Location = new Point(659, 21);
            labelConnectivity.Name = "labelConnectivity";
            labelConnectivity.Size = new Size(0, 20);
            labelConnectivity.TabIndex = 1;
            // 
            // buttonConfig
            // 
            buttonConfig.Location = new Point(643, 44);
            buttonConfig.Name = "buttonConfig";
            buttonConfig.Size = new Size(145, 29);
            buttonConfig.TabIndex = 2;
            buttonConfig.Text = "Open Config...";
            buttonConfig.UseVisualStyleBackColor = true;
            buttonConfig.Click += ButtonConfig_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonConfig);
            Controls.Add(labelConnectivity);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label labelConnectivity;
        private Button buttonConfig;
    }
}
