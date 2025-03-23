namespace Practical4
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
        /// <param name="p_disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool p_disposing)
        {
            if (p_disposing && (this.components != null))
            {
                components.Dispose();
            }
            base.Dispose(p_disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            menuItemFile = new ToolStripMenuItem();
            menuItemOpen = new ToolStripMenuItem();
            menuItemSave = new ToolStripMenuItem();
            menuItemSaveAs = new ToolStripMenuItem();
            menuItemExit = new ToolStripMenuItem();
            menuItemEdit = new ToolStripMenuItem();
            menuItemCut = new ToolStripMenuItem();
            menuItemCopy = new ToolStripMenuItem();
            menuItemPaste = new ToolStripMenuItem();
            textBox = new TextBox();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuItemFile, menuItemEdit });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            menuItemFile.DropDownItems.AddRange(new ToolStripItem[] { menuItemOpen, menuItemSave, menuItemSaveAs, menuItemExit });
            menuItemFile.Name = "menuItemFile";
            menuItemFile.Size = new Size(46, 24);
            menuItemFile.Text = "File";
            // 
            // menuItemOpen
            // 
            menuItemOpen.Name = "menuItemOpen";
            menuItemOpen.ShortcutKeys = Keys.Control | Keys.O;
            menuItemOpen.Size = new Size(233, 26);
            menuItemOpen.Text = "Open";
            menuItemOpen.Click += MenuItemOpen_Click;
            // 
            // menuItemSave
            // 
            menuItemSave.Name = "menuItemSave";
            menuItemSave.ShortcutKeys = Keys.Control | Keys.S;
            menuItemSave.Size = new Size(233, 26);
            menuItemSave.Text = "Save";
            menuItemSave.Click += MenuItemSave_Click;
            // 
            // menuItemSaveAs
            // 
            menuItemSaveAs.Name = "menuItemSaveAs";
            menuItemSaveAs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            menuItemSaveAs.Size = new Size(233, 26);
            menuItemSaveAs.Text = "Save As";
            menuItemSaveAs.Click += MenuItemSave_Click;
            // 
            // menuItemExit
            // 
            menuItemExit.Name = "menuItemExit";
            menuItemExit.ShortcutKeys = Keys.Control | Keys.W;
            menuItemExit.Size = new Size(233, 26);
            menuItemExit.Text = "Exit";
            menuItemExit.Click += MenuItemExit_Click;
            // 
            // menuItemEdit
            // 
            menuItemEdit.DropDownItems.AddRange(new ToolStripItem[] { menuItemCut, menuItemCopy, menuItemPaste });
            menuItemEdit.Name = "menuItemEdit";
            menuItemEdit.Size = new Size(49, 24);
            menuItemEdit.Text = "Edit";
            // 
            // menuItemCut
            // 
            menuItemCut.Name = "menuItemCut";
            menuItemCut.ShortcutKeys = Keys.Control | Keys.X;
            menuItemCut.Size = new Size(177, 26);
            menuItemCut.Text = "Cut";
            menuItemCut.Click += MenuItemCut_Click;
            // 
            // menuItemCopy
            // 
            menuItemCopy.Name = "menuItemCopy";
            menuItemCopy.ShortcutKeys = Keys.Control | Keys.C;
            menuItemCopy.Size = new Size(177, 26);
            menuItemCopy.Text = "Copy";
            menuItemCopy.Click += MenuItemCopy_Click;
            // 
            // menuItemPaste
            // 
            menuItemPaste.Name = "menuItemPaste";
            menuItemPaste.ShortcutKeys = Keys.Control | Keys.V;
            menuItemPaste.Size = new Size(177, 26);
            menuItemPaste.Text = "Paste";
            menuItemPaste.Click += MenuItemPaste_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(0, 31);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new Size(800, 424);
            textBox.TabIndex = 1;
            textBox.TextChanged += TextBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Form1";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private TextBox textBox;
        private MenuStrip menuStrip;

        // On the strip:
        private ToolStripMenuItem menuItemFile;
        private ToolStripMenuItem menuItemEdit;

        // Under `File`:
        private ToolStripMenuItem menuItemOpen;
        private ToolStripMenuItem menuItemSave;
        private ToolStripMenuItem menuItemExit;

        // Under `Edit`:
        private ToolStripMenuItem menuItemCut;
        private ToolStripMenuItem menuItemCopy;
        private ToolStripMenuItem menuItemPaste;
        private ToolStripMenuItem menuItemSaveAs;
    }
}
