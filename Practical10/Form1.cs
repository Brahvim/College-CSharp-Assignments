using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Practical10
{
    public partial class Form1 : Form
    {
        readonly static string configPath = ".\\config.conf";

        private readonly Dictionary<string, string> config;

        public Form1()
        {
            this.InitializeComponent();

            this.config = File.ReadLines(Form1.configPath) // "Here is what `var config` shall be:"
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

            // Using `using` like this grants access till the end of the current block:
            using var connection = new MySqlConnection(string.Concat([
                $"Server={this.config["host"]};",
                $"User ID={this.config["user"]};",
                $"Password={this.config["pass"]};",
            ]));

            using var adapter = new MySqlDataAdapter(File.ReadAllText(".\\Sql\\Create.sql"), connection);
            var table = new DataTable();
            adapter.Fill(table);

            this.dataGridView.DataSource = table;
            this.dataGridView.AllowUserToResizeRows = true;
            this.dataGridView.AllowUserToResizeColumns = true;

            // Specified in Designer:
            //this.dataGridView.AllowUserToAddRows = false;
            //this.dataGridView.AllowUserToDeleteRows = false;
            //this.dataGridView.AllowUserToOrderColumns = false;
        }

        private void ButtonConfig_Click(object? p_sender, EventArgs p_args)
        {
            // Notepad *probably is* in `%PATH%`!:
            Process.Start(new ProcessStartInfo("notepad.exe", Form1.configPath));
        }
    }
}
