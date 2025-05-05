using System.Data;

namespace Practical12
{
    public partial class FormXmlReader : Form
    {
        public readonly DataSet xmlDataSet = new();

        public FormXmlReader()
        {
            this.InitializeComponent();

            this.dataGridView.AllowDrop = true;

            this.dataGridView.DragDrop += this.DataGridView_DragDrop;
            this.dataGridView.DragEnter += this.DataGridView_DragEnter;

            this.labelFilePrompt.Anchor = AnchorStyles.Top;
            this.buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private void ButtonSave_Click(object? p_sender, EventArgs p_event)
        {
            var dialog = new SaveFileDialog
            {
                FileName = "New",
                Title = "Save XML",
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.xmlDataSet.WriteXml(dialog.FileName);
            }
        }

        private void ButtonClear_Click(object? p_sender, EventArgs p_event)
        {
            this.xmlDataSet.Reset();
        }

        protected override bool ProcessCmdKey(ref Message p_msg, Keys p_keys)
        {
            if (p_keys.HasFlag(Keys.Control | Keys.S))
            {
                this.ButtonSave_Click(this, new());
            }
            else if (p_keys.HasFlag(Keys.Control | Keys.Q))
            {
                this.ButtonClear_Click(this, new());
            }
            else
            {
                return base.ProcessCmdKey(ref p_msg, p_keys);
            }

            return true;
        }

        private void DataGridView_DragDrop(object? p_sender, DragEventArgs p_event)
        {
            if (p_event.Data?.GetData(DataFormats.FileDrop) is string[] paths)
            {
                foreach (string p in paths)
                {
                    try
                    {
                        this.xmlDataSet.ReadXml(p);
                        this.dataGridView.DataSource = this.xmlDataSet.Tables[0];
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(
                            $"`{Path.GetFileName(p)}` does not have valid XML.",
                            "Reading Error!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void DataGridView_DragEnter(object? p_sender, DragEventArgs p_event)
        {
            if (p_event.Data == null)
            {
                return;
            }

            if (p_event.Data.GetDataPresent(DataFormats.FileDrop))
            {
                p_event.Effect = DragDropEffects.Copy;
            }
            else
            {
                p_event.Effect = DragDropEffects.None;
            }
        }
    }
}
