namespace Practical12
{
    partial class FormXmlReader
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
            labelFilePrompt = new Label();
            buttonClear = new Button();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 32);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(801, 420);
            dataGridView.TabIndex = 0;
            // 
            // labelFilePrompt
            // 
            labelFilePrompt.AutoSize = true;
            labelFilePrompt.Location = new Point(259, 9);
            labelFilePrompt.Name = "labelFilePrompt";
            labelFilePrompt.Size = new Size(281, 20);
            labelFilePrompt.TabIndex = 2;
            labelFilePrompt.Text = "Please drag-and-drop an XML file below:";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(677, 0);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(124, 29);
            buttonClear.TabIndex = 3;
            buttonClear.Text = "Clear (Ctrl + Q)";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += ButtonClear_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(0, 0);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(113, 29);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save (Ctrl + S)";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // FormXmlReader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSave);
            Controls.Add(buttonClear);
            Controls.Add(labelFilePrompt);
            Controls.Add(dataGridView);
            Name = "FormXmlReader";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Label labelFilePrompt;
        private Button buttonClear;
        private Button buttonSave;
    }
}
