namespace Practical7
{
    public partial class Form1 : Form
    {
        static readonly uint SECONDS_PER_QUESTION = 10;

        readonly List<RadioButton> radioButtons = [];
        readonly string[] mcqStrings;
        readonly byte[] mcqAnswers;
        uint currentQuestion;
        uint currentSeconds;
        int questionsCount;
        int currentAnswer;

        public Form1()
        {
            this.InitializeComponent();
            this.radioButtons.Add(this.radioButton1);
            this.radioButtons.Add(this.radioButton2);
            this.radioButtons.Add(this.radioButton3);
            this.radioButtons.Add(this.radioButton4);

            #region Parsing.

            string[] lines = File.ReadAllLines(".\\Mcq.txt");
            List<string> stage1 = new(lines.Length);

            // Remove empty lines:
            foreach (string line in lines)
            {
                if (line != "")
                    stage1.Add(line);
            }

            List<string> stage2 = new(stage1.Count);

            // Remove comment-lines:
            foreach (string line in stage1)
            {
                if (line[0] != '#')
                    stage2.Add(line);
            }

            this.questionsCount = stage2.Count / 6;
            this.mcqAnswers = new byte[this.questionsCount];
            this.mcqStrings = new string[6 * this.questionsCount];

            for (int i = 0; i < this.questionsCount * 6; i += 6)
            {
                this.mcqStrings[i + 0] = stage2[i + 0];
                //this.mcqStrings[i + 1] = stage2[i + 1]; // Contains the correct answer number!
                this.mcqStrings[i + 1] = stage2[i + 2];
                this.mcqStrings[i + 2] = stage2[i + 3];
                this.mcqStrings[i + 3] = stage2[i + 4];
                this.mcqStrings[i + 4] = stage2[i + 5];
            }

            // For all correct answers:
            for (int i = 1; i < this.questionsCount * 6; i += 6)
            {
                int qId = (i - 1) / 6;
                byte answer = byte.Parse(stage2[i]);

                if (answer < 1 || answer > 4)
                {
                    MessageBox.Show(
                        $"The question:" +
                        $"\n{this.mcqStrings[qId]}\n\n" +
                        $"...has an invalid correct answer, `{answer}`.",
                        "Malformed test!");
                    this.Load += (p_sender, p_event) => this.Close(); // Will prevent loading.
                    return;
                }

                this.mcqAnswers[qId] = answer;
            }

            #endregion

            // Let every `RadioButton` report which answer is represents:
            for (int i = 0; i < this.radioButtons.Count; i++)
            {
                int id = i; // Local allows lambda scoping. (Not `const`, though!)
                this.radioButtons[i].Click += (s, e) => this.currentAnswer = 1 + id;
            }

            this.radioButtons.ForEach(b => b.Hide());
            this.timer.Tick += this.Timer_Tick_DuringTest;
            this.button1.Click += this.Button1_Click_TestStart;
            this.radioButtons.ForEach(b => b.Click += this.RadioButton_Click_DuringTest);
        }

        void QuestionsFail()
        {
            this.BeginInvoke(() => this.radioButtons.ForEach(b => b.Hide()));
            this.button1.Text = $"Restart Quiz";
            this.currentQuestion = 0;
            this.currentSeconds = 0;
            this.button1.Show();
            this.timer.Stop();
        }

        void QuestionsAssign()
        {
            this.labelQuestion.Text = $"Q) {this.mcqStrings[6 * this.currentQuestion + 0]}";
            this.radioButton1.Text = $"A) {this.mcqStrings[6 * this.currentQuestion + 1]}";
            this.radioButton2.Text = $"B) {this.mcqStrings[6 * this.currentQuestion + 2]}";
            this.radioButton3.Text = $"C) {this.mcqStrings[6 * this.currentQuestion + 3]}";
            this.radioButton4.Text = $"D) {this.mcqStrings[6 * this.currentQuestion + 4]}";
        }

        void Timer_Tick_DuringTest(object? p_sender, EventArgs p_event)
        {
            ++this.currentSeconds;
            this.labelTimer.Text = TimeSpan.FromSeconds(this.currentSeconds).ToString(@"mm\:ss");

            if (this.currentSeconds >= Form1.SECONDS_PER_QUESTION)
            {
                this.QuestionsFail();
                return;
            }

            this.timer.Interval = 1_000;
            this.timer.Start();
        }

        void Button1_Click_TestStart(object? p_sender, EventArgs p_event)
        {
            this.Focus();
            this.button1.Hide();
            this.QuestionsAssign();

            this.BeginInvoke(() =>
            {
                this.radioButtons.ForEach(b => b.Show());
                this.timer.Interval = 1_000;
                this.timer.Start();
            });
        }

        void RadioButton_Click_DuringTest(object? p_sender, EventArgs p_event)
        {
            this.currentSeconds = 0;
            this.labelTimer.Text = TimeSpan.FromSeconds(this.currentSeconds).ToString(@"mm\:ss");

            if (this.currentAnswer != this.mcqAnswers[this.currentQuestion])
            {
                this.labelQuestion.Text = "Wrong answer...!";
                this.QuestionsFail();
                return;
            }

            ++this.currentQuestion;
            if (this.currentQuestion >= this.questionsCount)
            {
                this.labelQuestion.Text = "Congrats, you have answered all questions right!";
                this.radioButtons.ForEach((b) => b.Hide());
                this.QuestionsFail();
                return;
            }

            this.QuestionsAssign();
        }
    }
}
