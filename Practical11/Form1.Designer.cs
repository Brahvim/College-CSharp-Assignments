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
            dataGridView = new DataGridView();
            buttonConfig = new Button();
            buttonCommit = new Button();
            buttonReconnect = new Button();
            labelConnectivity = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(637, 450);
            dataGridView.TabIndex = 0;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
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
            // buttonCommit
            // 
            buttonCommit.Location = new Point(643, 105);
            buttonCommit.Name = "buttonCommit";
            buttonCommit.Size = new Size(145, 29);
            buttonCommit.TabIndex = 3;
            buttonCommit.Text = "Commit (Ctrl +S)";
            buttonCommit.UseVisualStyleBackColor = true;
            buttonCommit.Click += ButtonCommit_Click;
            // 
            // buttonReconnect
            // 
            buttonReconnect.Location = new Point(643, 163);
            buttonReconnect.Name = "buttonReconnect";
            buttonReconnect.Size = new Size(145, 29);
            buttonReconnect.TabIndex = 4;
            buttonReconnect.Text = "Reconnect";
            buttonReconnect.UseVisualStyleBackColor = true;
            buttonReconnect.Click += ButtonReconnect_Click;
            // 
            // labelConnectivity
            // 
            labelConnectivity.AutoSize = true;
            labelConnectivity.ForeColor = Color.Red;
            labelConnectivity.Location = new Point(659, 21);
            labelConnectivity.Name = "labelConnectivity";
            labelConnectivity.Size = new Size(112, 20);
            labelConnectivity.TabIndex = 1;
            labelConnectivity.Text = "No Connection!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonReconnect);
            Controls.Add(buttonCommit);
            Controls.Add(buttonConfig);
            Controls.Add(labelConnectivity);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonConfig;
        private Button buttonCommit;
        private Button buttonReconnect;
        private Label labelConnectivity;
    }
}
