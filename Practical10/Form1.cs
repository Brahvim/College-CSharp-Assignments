using System.Diagnostics;

namespace Practical10
{
    public partial class Form1 : Form
    {
        readonly static string configPath = ".\\config.conf";

        public Form1()
        {
            this.InitializeComponent();

            var config = File.ReadLines(Form1.configPath) // "Here is what `var config` shall be:"
            .Select(l => l.Trim()) // "select all `ReadLines()`, `string::Trim()`med they be!"
            .Where(l => !string.IsNullOrEmpty(l)) // "Where there are no `null`s and empties...!"
            .Where(l => !l.StartsWith('#')) // "Where there are no comments!"
            .Select(l => // "Be the birther of pairs, where a pair should be..."
            {
                var pair = l.Split('=', 2); // "...a `string::Split()` into two, upon an `'='`!"
                return new KeyValuePair<string, string>( // "Which each be a `KeyValuePair<string, string>`!
                    pair[0].Trim(), // "Where the key be the first string split, like all, `string::Trim()`med!"
                    pair.Length > 1 ? pair[1].Trim() : "" // "Too be a second, *if* there is; or be empty!"
                );
            })
            .ToDictionary( // "That is what SHALL make the `Dictionary<string, string>`,"
                p_keySelector => p_keySelector.Key, // "connecting every single value,"
                p_elementSelector => p_elementSelector.Value // "every single key."
            );
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("notepad.exe", Form1.configPath));
        }
    }
}
