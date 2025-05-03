using System;

namespace Practical6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.UpdateDateLabels();
        }

        private void UpdateDateLabels()
        {
            int chars;
            Span<char> span = stackalloc char[4];

            dateTimePicker1.Value.TryFormat(span, out chars, "dd");
            labelDay.Text = string.Format("Day: {0}", span.Slice(0, chars).ToString());

            dateTimePicker1.Value.TryFormat(span, out chars, "yyyy");
            labelYear.Text = string.Format("Year: {0}", span.Slice(0, chars).ToString());

            dateTimePicker1.Value.TryFormat(span, out chars, "MMM");
            labelMonth.Text = string.Format("Month: {0}", span.Slice(0, chars).ToString());
        }

        private void DateTimePicker1_ValueChanged(object p_sender, EventArgs p_args)
        {
            this.UpdateDateLabels();
        }
    }
}
