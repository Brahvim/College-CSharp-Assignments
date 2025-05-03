namespace Practical5
{
    // These things need to get finished. I give up on styling my code.
    // At this point, it's all about finding the fastest way to the end.
    public partial class Form1 : Form
    {
        static readonly char[] operations = ['+', '-', '*', '/'];

        readonly List<string> historyExprs = [];
        int historyId;

        public Form1()
        {
            this.InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (this.historyExprs.Count != 0)
                    {
                        this.historyId = historyExprs.Count - 1;
                        this.textBox1.Text = historyExprs[historyId];
                    }

                    this.textBox1.SelectionLength = 0;
                    this.textBox1.SelectionStart = this.textBox1.Text.Length;
                    break;

                case Keys.Enter:
                    string result = "";
                    string uin = this.textBox1.Text.Replace(" ", "");

                    foreach (char c in operations)
                    {
                        int posOp = uin.IndexOf(c);

                        if (posOp == -1)
                            continue;

                        double left = 0, right = 0;

                        try
                        {
                            left = double.Parse(uin[..posOp]);
                            right = double.Parse(uin[(posOp + 1)..]);
                        }
                        catch
                        {
                            MessageBox.Show("Please enter a valid expression.");
                            break;
                        }

                        switch (c)
                        {
                            case '+': result = "" + (left + right); break;
                            case '-': result = "" + (left - right); break;
                            case '*': result = "" + (left * right); break;
                            case '/':
                                if (left == 0.0 || right == 0.0)
                                {
                                    MessageBox.Show("Please enter a valid expression.");
                                    break;
                                }
                                result = "" + (left / right);
                                break;
                        }

                        this.historyExprs.Add(textBox1.Text);
                        this.historyId = historyExprs.Count;
                        this.historyExprs.Add(result);

                        this.textBox1.Text = result;
                        this.textBox1.SelectionLength = 0;
                        this.textBox1.SelectionStart = result.Length;
                    }
                    break;

                case Keys.Down:
                    if (this.historyExprs.Count == 0)
                        break;

                    if (this.historyId > this.historyExprs.Count - 2)
                        this.historyId = this.historyExprs.Count - 2; // ...So the increment lands at `Count - 1`.
                    ++this.historyId;
                    this.textBox1.Text = this.historyExprs[this.historyId];
                    break;

                case Keys.Up:
                    if (this.historyExprs.Count == 0)
                        break;

                    if (this.historyId < 1)
                        this.historyId = 1;
                    --this.historyId;
                    this.textBox1.Text = this.historyExprs[this.historyId];
                    break;
            }
        }
    }
}
