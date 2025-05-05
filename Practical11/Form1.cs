using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Practical10
{
    public partial class Form1 : Form
    {
        readonly static string textConnnectionNotConnected = "No Connections!";
        readonly static string textConnnectionOk = "Connected.";
        readonly static string configPath = ".\\config.conf";

        private Dictionary<string, string>? config;
        private MySqlConnection? connection;
        private MySqlDataAdapter? adapter;
        private DataTable? table;

        public Form1()
        {
            this.InitializeComponent();
            this.ButtonReconnect_Click(this, new());
            this.FormClosed += this.Form1_FormClosed;
            this.dataGridView.UserDeletingRow += this.DataGridView_UserDeletingRow;
        }

        private void ConfigRead()
        {
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
        }

        private void ConnectionCreate()
        {
            this.connection = new(string.Concat([
                $"AllowBatch=True;",
                $"Allow User Variables=True;",
                //$"AllowLoadLocalInfile=True;",        // If somebody wants a CSV...!
                //$"AllowMultipleStatements=True;",     // Disallowed >:(!
                //$"Database=db_dotnet_practicals;",    // Won't always be available!
                $"Server={this.config?["host"]};",
                $"User ID={this.config?["user"]};",
                $"Password={this.config?["pass"]};",
            ]));

            this.connection.Open();

            // USED TO work but since the script lost its `SELECT`, it doesn't!
            //new MySqlCommand(
            //    File.ReadAllText(".\\Sql\\Create.sql"),
            //    this.connection
            //).ExecuteNonQuery();
            // Use `MySqlScript` instead!

            new MySqlScript(
                this.connection,
                File.ReadAllText(".\\Sql\\Create.sql")
            ).Execute();

            this.adapter = new("SELECT * FROM students;", connection);
            MySqlCommandBuilder builder = new(this.adapter);

            //this.adapter.DeleteCommand = builder.GetDeleteCommand(); // It KEEPS *NOT* working!
            this.adapter.InsertCommand = builder.GetInsertCommand();
            this.adapter.UpdateCommand = builder.GetUpdateCommand();

            this.adapter.Fill(this.table = new());
            this.table.PrimaryKey = [this.table?.Columns?["roll"]];
            this.dataGridView.DataSource = table;

            //Debug.WriteLine(this.adapter.DeleteCommand.CommandText);
            //Debug.WriteLine(this.adapter.InsertCommand.CommandText);
            //Debug.WriteLine(this.adapter.UpdateCommand.CommandText);
        }

        private void CommitChanges()
        {
            if (!this.ChangesFlagGet())
                return;

            try
            {
                if (this.table?.Rows != null)
                {
                    foreach (DataRow row in this.table.Rows)
                    {
                        if (row.RowState == DataRowState.Deleted)
                        {
                            // TEMP: Hard delete manually to meet deadline
                            var roll = (int)row["roll", DataRowVersion.Original];
                            new MySqlCommand(
                                $"DELETE FROM students WHERE roll = {roll}",
                                this.connection
                            ).ExecuteNonQuery();
                        }
                    }
                }

                // Should never be!:
                //if (this.table is null)
                //    this.table = new();

                this.adapter?.Update(this.table);
                this.ChangesFlagEnsureFolded();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Error!:\n\n{e.Message}\n\nPlease ping Brahvim for assistance.",
                    "Save Failed!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ChangesFlagGet()
        {
            return this.Text[^1] == '*';
        }

        private void ChangesFlagEnsureFolded()
        {
            if (this.Text[^1] == '*')
            {
                this.Text = this.Text[..^1];
            }
        }

        private void ChangesFlagEnsureRaised()
        {
            if (this.Text[^1] != '*')
            {
                this.Text += '*';
            }
        }

        private void ButtonCommit_Click(object? p_sender, EventArgs p_event)
        {
            this.CommitChanges();
        }

        private void ButtonConfig_Click(object? p_sender, EventArgs p_args)
        {
            // Notepad *probably is* in `%PATH%`!:
            Process.Start(new ProcessStartInfo("notepad.exe", Form1.configPath));
        }

        private void ButtonReconnect_Click(object? p_sender, EventArgs p_event)
        {
            if (this.connection is null || this.connection.State != ConnectionState.Open)
            {
                try
                {
                    this.ConfigRead();
                    this.ConnectionCreate();
                    this.labelConnectivity.ForeColor = Color.Green;
                    this.labelConnectivity.Text = Form1.textConnnectionOk;
                }
                catch (Exception)
                {
                    this.labelConnectivity.ForeColor = Color.Red;
                    this.labelConnectivity.Text = Form1.textConnnectionNotConnected;
                    switch (MessageBox.Show(
                        "Would you like to open the config file?",
                        "Connection Failed!",
                        MessageBoxButtons.YesNoCancel
                    ))
                    {
                        case DialogResult.Yes:
                            // I don't think WinForms has any button-specific or general "`ClickEventArgs`"!
                            this.ButtonConfig_Click(this, new());
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message p_msg, Keys p_keys)
        {
            if (p_keys == (Keys.Control | Keys.S))
            {
                this.ButtonCommit_Click(this, new());
            }
            else if (p_keys == (Keys.Control | Keys.R))
            {
                this.ButtonReconnect_Click(this, new());
            }
            else if (p_keys == (Keys.Control | Keys.O))
            {
                this.ButtonConfig_Click(this, new());
            }
            else
            {
                return base.ProcessCmdKey(ref p_msg, p_keys);
            }

            return true;
        }

        private void Form1_FormClosed(object? p_sender, FormClosedEventArgs p_event)
        {
            this.adapter?.Dispose();
            this.connection?.Close();
        }

        private void DataGridView_CellValueChanged(object? p_sender, DataGridViewCellEventArgs p_event)
        {
            this.ChangesFlagEnsureRaised();
        }

        private void DataGridView_UserDeletingRow(object? p_sender, DataGridViewRowCancelEventArgs p_event)
        {
            // This stuff never works:
            //if (p_event.Row?.DataBoundItem is DataRowView view)
            //{
            //    view.Row.Delete();
            //}
        }
    }
}
