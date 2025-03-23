using System.Linq.Expressions;
namespace Practical4
{
    public partial class Form1 : Form
    {
        private string? fileNameOpenedFile = null;

        public Form1()
        {
            this.InitializeComponent();
        }

        private string TextBox_GetSerializableText()
        {
            return this.textBox.Text.Trim();
        }

        private void TextBox_TextChanged(object p_sender, EventArgs p_args)
        {
            this.Text = "";
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

        private void MenuItemCut_Click(object p_sender, EventArgs p_args)
        {
            this.textBox.Cut();
        }

        private void MenuItemCopy_Click(object p_sender, EventArgs p_args)
        {
            this.textBox.Copy();
        }

        private void MenuItemPaste_Click(object p_sender, EventArgs p_args)
        {
            this.textBox.Paste();
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
