namespace Practical4
{
    class NotesApp : Form
    {
        #region Fields.
        private readonly TextBox textBox;
        private readonly MenuStrip menuStrip;
        private string fileNameOpenedFile = "";

        // On the strip:
        private readonly ToolStripMenuItem menuItemFile;
        private readonly ToolStripMenuItem menuItemEdit;

        // Under `File`:
        private readonly ToolStripMenuItem menuItemOpen;
        private readonly ToolStripMenuItem menuItemSave;
        private readonly ToolStripMenuItem menuItemExit;

        // Under `Edit`:
        private readonly ToolStripMenuItem menuItemCut;
        private readonly ToolStripMenuItem menuItemCopy;
        private readonly ToolStripMenuItem menuItemPaste;
        private readonly ToolStripMenuItem menuItemSaveAs;

        /// Required by Visual Studio Designer.
        private readonly System.ComponentModel.IContainer? components = null;
        #endregion

        public NotesApp()
        {
            this.textBox = new();
            this.menuStrip = new();

            this.menuItemEdit = new();
            this.menuItemFile = new();

            this.menuItemCut = new();
            this.menuItemCopy = new();
            this.menuItemPaste = new();

            this.menuItemExit = new();
            this.menuItemOpen = new();
            this.menuItemSave = new();
            this.menuItemSaveAs = new();

            #region Components init.
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Items.AddRange([

                this.menuItemFile,
                this.menuItemEdit,

            ]);
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Size = new(800, 28);
            this.menuStrip.Location = new(0, 0);
            this.menuStrip.ImageScalingSize = new(20, 20);

            this.menuItemFile.Text = "File";
            this.menuItemFile.Size = new(46, 24);
            this.menuItemFile.DropDownItems.AddRange([

                this.menuItemExit,
                this.menuItemOpen,
                this.menuItemSave,
                this.menuItemSaveAs,

            ]);

            this.menuItemOpen.Text = "Open";
            this.menuItemOpen.Size = new(233, 26);
            this.menuItemOpen.Click += this.MenuItemOpen_Click;
            this.menuItemOpen.ShortcutKeys = Keys.Control | Keys.O;

            this.menuItemSave.Text = "Save";
            this.menuItemSave.Size = new(233, 26);
            this.menuItemSave.Click += this.MenuItemSaveAs_Click;
            this.menuItemSave.ShortcutKeys = Keys.Control | Keys.S;

            this.menuItemSaveAs.Text = "Save As";
            this.menuItemSaveAs.Size = new(233, 26);
            this.menuItemSaveAs.Click += this.MenuItemSaveAs_Click;
            this.menuItemSaveAs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Size = new(233, 26);
            this.menuItemExit.Click += this.MenuItemExit_Click;
            this.menuItemExit.ShortcutKeys = Keys.Control | Keys.W;

            this.menuItemEdit.Text = "Edit";
            this.menuItemEdit.Size = new(49, 24);
            this.menuItemEdit.DropDownItems.AddRange([

                this.menuItemCut,
                this.menuItemCopy,
                this.menuItemPaste,

            ]);

            this.menuItemCut.Text = "Cut";
            this.menuItemCut.Size = new(177, 26);
            this.menuItemCut.Click += this.MenuItemCut_Click;
            this.menuItemCut.ShortcutKeys = Keys.Control | Keys.X;

            this.menuItemCopy.Text = "Copy";
            this.menuItemCopy.Size = new(177, 26);
            this.menuItemCopy.Click += this.MenuItemCopy_Click;
            this.menuItemCopy.ShortcutKeys = Keys.Control | Keys.C;

            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.Size = new(177, 26);
            this.menuItemPaste.Click += this.MenuItemPaste_Click;
            this.menuItemPaste.ShortcutKeys = Keys.Control | Keys.V;

            this.textBox.TabIndex = 1;
            this.textBox.Multiline = true;
            this.textBox.Size = new(800, 424);
            this.textBox.Location = new(0, 31);
            this.textBox.TextChanged += this.TextBox_TextChanged;
            #endregion

            this.Text = "Notes App";

            // NEEDED in this order!:
            this.SuspendLayout();
            this.PerformLayout();
            this.ResumeLayout(false);

            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip);

            this.Resize += this.Form_Resize;
            this.MainMenuStrip = this.menuStrip;
            this.FormClosing += this.Form_Closing;

            this.AutoSize = false;
            this.menuStrip.PerformLayout();
            this.ClientSize = new(800, 450);
            this.MinimumSize = new(350, 350);
            this.menuStrip.ResumeLayout(false);
            this.AutoScaleDimensions = new(8, 20);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.menuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private bool TextBox_StarExists()
        {
            return this.Text[^1] == '*';
        }

        private void TextBox_AppendStar()
        {
            this.Text += '*';
        }

        private void TextBox_RemoveStar()
        {
            this.Text = this.Text[..^1]; // Visual Studio suggested this over `string::Substring()`.
        }

        private void TextBox_AppendStar_IfAbsent()
        {
            if (!this.TextBox_StarExists())
            {
                this.TextBox_AppendStar();
            }
        }

        private void TextBox_RemoveStar_IfExists()
        {
            if (this.TextBox_StarExists())
            {
                this.TextBox_RemoveStar();
            }
        }

        private void TextBox_AppendStarNextUpdate()
        {
            this.textBox.TextChanged += this.TextBox_TextChanged;
        }

        private string TextBox_GetSerializableText()
        {
            return this.textBox.Text.Trim();
        }

        protected override void Dispose(bool p_disposeComponents)
        {
            if (p_disposeComponents && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(p_disposeComponents);
        }

        private void Form_Resize(object? p_sender, EventArgs p_args)
        {
            if (this.Width < this.MinimumSize.Width)
            {
                this.Width = this.MinimumSize.Width;
            }

            if (this.Height < this.MinimumSize.Height)
            {
                this.Height = this.MinimumSize.Height;
            }
        }

        private void MenuItemCut_Click(object? p_sender, EventArgs? p_args)
        {
            this.textBox.Cut();
        }

        private void MenuItemExit_Click(object? p_sender, EventArgs? p_args)
        {
            this.Close();
        }

        private void MenuItemOpen_Click(object? p_sender, EventArgs? p_args)
        {
            using (OpenFileDialog dialog = new())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                this.fileNameOpenedFile = dialog.FileName;
                this.menuItemSave.Click += this.MenuItemSave_Click_FilePresent;
            }

            // Order matters! The following assignment is an update!:
            this.textBox.Text = File.ReadAllText(this.fileNameOpenedFile); // TODO Check this and the other `File.*()` call.
            this.TextBox_AppendStarNextUpdate();
            this.TextBox_RemoveStar();
        }

        private void MenuItemCopy_Click(object? p_sender, EventArgs? p_args)
        {
            this.textBox.Copy();
        }

        private void MenuItemPaste_Click(object? p_sender, EventArgs? p_args)
        {
            this.textBox.Paste();
        }

        private void TextBox_TextChanged(object? p_sender, EventArgs? p_args)
        {
            if (!this.TextBox_StarExists())
            {
                this.TextBox_AppendStar();
                this.textBox.TextChanged -= this.TextBox_TextChanged;
            }
        }

        private void MenuItemSaveAs_Click(object? p_sender, EventArgs? p_args)
        {
            DialogResult result;
            using (SaveFileDialog dialog = new())
            {
                result = dialog.ShowDialog(this);
                this.fileNameOpenedFile = dialog.FileName;
            }

            if (DialogResult.OK != result)
            {
                return;
            }

            this.TextBox_RemoveStar_IfExists();
            this.TextBox_AppendStarNextUpdate();
            this.menuItemSave.Click += this.MenuItemSave_Click_FilePresent;

            bool succeeded = false;
            while (!succeeded)
            {
                try
                {
                    File.WriteAllText(this.fileNameOpenedFile, this.TextBox_GetSerializableText());
                    succeeded = true;
                }
                catch (Exception e)
                {
                    if (DialogResult.Cancel == MessageBox.Show(
                        "FAILED to save! Try again?",
                        "FAILURE",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error
                    ))
                    {
                        break;
                    }
                }
            }
        }

        private void Form_Closing(object? p_sender, FormClosingEventArgs p_args)
        {
            if (this.TextBox_StarExists())
            {
                DialogResult result = MessageBox.Show(
                    "Would you like to save before leaving?",
                    "Save Before Leaving?",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (DialogResult.Yes == result)
                {
                    this.menuItemSave.PerformClick();
                }

                // if (DialogResult.No == result)
                // {
                //     return;
                // }

                if (DialogResult.Cancel == result)
                {
                    p_args.Cancel = true;
                }
            }
        }

        private void MenuItemSave_Click_FilePresent(object? p_sender, EventArgs? p_args)
        {
            File.WriteAllText(this.fileNameOpenedFile, this.TextBox_GetSerializableText());
            this.TextBox_AppendStarNextUpdate();
            this.TextBox_RemoveStar_IfExists();
        }
    }
}
