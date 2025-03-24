namespace Practical4
{
	class Form1 : Form
	{
		#region Fields.
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

		private string? fileNameOpenedFile = null;

		///  Required by Visual Studio Designer.
		private System.ComponentModel.IContainer components = null;
		#endregion

		public Form1()
		{
			this.textBox = new TextBox();
			this.menuStrip.SuspendLayout();
			this.menuStrip = new MenuStrip();

			this.menuItemEdit = new ToolStripMenuItem();
			this.menuItemFile = new ToolStripMenuItem();

			this.menuItemExit = new ToolStripMenuItem();
			this.menuItemOpen = new ToolStripMenuItem();
			this.menuItemSave = new ToolStripMenuItem();
			this.menuItemSaveAs = new ToolStripMenuItem();

			this.menuItemCut = new ToolStripMenuItem();
			this.menuItemCopy = new ToolStripMenuItem();
			this.menuItemPaste = new ToolStripMenuItem();

			#region Components init.
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Text = "menuStrip1";
			this.menuStrip.Size = new Size(800, 28);
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.ImageScalingSize = new Size(20, 20);
			this.menuStrip.Items.AddRange(new ToolStripItem[] {

				this.menuItemEdit,
				this.menuItemFile,

			});

			this.menuItemFile.Text = "File";
			this.menuItemFile.Name = "menuItemFile";
			this.menuItemFile.Size = new Size(46, 24);
			this.menuItemFile.DropDownItems.AddRange(new ToolStripItem[] {

				this.menuItemExit,
				this.menuItemOpen,
				this.menuItemSave,
				this.menuItemSaveAs,

			});

			this.menuItemOpen.Text = "Open";
			this.menuItemOpen.Name = "menuItemOpen";
			this.menuItemOpen.Size = new Size(233, 26);
			this.menuItemOpen.Click += this.MenuItemOpen_Click;
			this.menuItemOpen.ShortcutKeys = Keys.Control | Keys.O;

			this.menuItemSave.Text = "Save";
			this.menuItemSave.Name = "menuItemSave";
			this.menuItemSave.Size = new Size(233, 26);
			this.menuItemSave.ShortcutKeys = Keys.Control | Keys.S;
			this.menuItemSave.Click += this.MenuItemSave_Click;

			this.menuItemSaveAs.Text = "Save As";
			this.menuItemSaveAs.Name = "menuItemSaveAs";
			this.menuItemSaveAs.Size = new Size(233, 26);
			this.menuItemSaveAs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
			this.menuItemSaveAs.Click += this.MenuItemSave_Click;

			this.menuItemExit.Text = "Exit";
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new Size(233, 26);
			this.menuItemExit.ShortcutKeys = Keys.Control | Keys.W;
			this.menuItemExit.Click += this.MenuItemExit_Click;

			this.menuItemEdit.Text = "Edit";
			this.menuItemEdit.Name = "menuItemEdit";
			this.menuItemEdit.Size = new Size(49, 24);
			this.menuItemEdit.DropDownItems.AddRange(new ToolStripItem[] {

				this.menuItemCut,
				this.menuItemCopy,
				this.menuItemPaste,

			});

			this.menuItemCut.Text = "Cut";
			this.menuItemCut.Name = "menuItemCut";
			this.menuItemCut.Size = new Size(177, 26);
			this.menuItemCut.Click += this.MenuItemCut_Click;
			this.menuItemCut.ShortcutKeys = Keys.Control | Keys.X;

			this.menuItemCopy.Text = "Copy";
			this.menuItemCopy.Name = "menuItemCopy";
			this.menuItemCopy.Size = new Size(177, 26);
			this.menuItemCopy.Click += this.MenuItemCopy_Click;
			this.menuItemCopy.ShortcutKeys = Keys.Control | Keys.C;

			this.menuItemPaste.Text = "Paste";
			this.menuItemPaste.Name = "menuItemPaste";
			this.menuItemPaste.Size = new Size(177, 26);
			this.menuItemPaste.Click += this.MenuItemPaste_Click;
			this.menuItemPaste.ShortcutKeys = Keys.Control | Keys.V;

			this.textBox.TabIndex = 1;
			this.textBox.Name = "textBox";
			this.textBox.Multiline = true;
			this.textBox.Size = new Size(800, 424);
			this.textBox.Location = new Point(0, 31);
			this.textBox.TextChanged += this.TextBox_TextChanged;
			#endregion

			this.Name = "Form1";
			this.Text = "Form1";

			// NEEDED in this order!:
			this.SuspendLayout();
			this.PerformLayout();
			this.ResumeLayout(false);

			this.menuStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.MainMenuStrip = this.menuStrip;

			this.Controls.Add(this.textBox);
			this.Controls.Add(this.menuStrip);
			this.ClientSize = new Size(800, 450);
			this.AutoScaleDimensions = new SizeF(8, 20);
			this.AutoScaleMode = this.AutoScaleMode.Font;
		}

		private string TextBox_GetSerializableText()
		{
			return this.textBox.Text.Trim();
		}

		protected override void Dispose(bool p_disposeComponents)
		{
			if (p_disposeComponents && (this.components != null))
			{
				components.Dispose();
			}

			base.Dispose(p_disposeComponents);
		}

		private void MenuItemCut_Click(object p_sender, EventArgs p_args)
		{
			this.textBox.Cut();
		}

		private void MenuItemExit_Click(object p_sender, EventArgs p_args)
		{
			this.Close();
		}

		private void MenuItemOpen_Click(object p_sender, EventArgs p_args)
		{
			using (OpenFileDialog dialog = new())
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					this.fileNameOpenedFile = dialog.FileName;
				}
				else
				{
					return;
				}
			}

			this.textBox.Text = File.ReadAllText(this.fileNameOpenedFile);
		}

		private void MenuItemSave_Click(object p_sender, EventArgs p_args)
		{
			if (this.fileNameOpenedFile != null)
			{
				File.WriteAllText(this.fileNameOpenedFile, this.TextBox_GetSerializableText());
			}
			else
			{
				this.MenuItemSaveAs_Click(this, new());
			}
		}

		private void MenuItemCopy_Click(object p_sender, EventArgs p_args)
		{
			this.textBox.Copy();
		}

		private void MenuItemPaste_Click(object p_sender, EventArgs p_args)
		{
			this.textBox.Paste();
		}

		private void TextBox_TextChanged(object p_sender, EventArgs p_args)
		{
			if (this.Text[this.Text.Length] == '*')
			{
				this.textBox.Click -= this.TextBox_TextChanged;
			}
		}

		private void MenuItemSaveAs_Click(object p_sender, EventArgs p_args)
		{
			using (SaveFileDialog dialog = new())
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					this.fileNameOpenedFile = dialog.FileName;
				}
				else
				{
					return;
				}
			}

			File.WriteAllText(this.fileNameOpenedFile, this.TextBox_GetSerializableText());
		}
	}
}
