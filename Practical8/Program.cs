// VERY compact program!
using MySql.Data.MySqlClient;
string pass = "";
try
{
    pass = File.ReadAllText(".\\password.txt");
    Console.WriteLine($"`password.txt` said, `{pass}`!");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Please make a `password.txt`!");
}
// `new()` is lovely but `var` is great, too!:
var connection = new MySqlConnection($"User ID=root;Server=localhost;Password={pass};");
connection.Open();
Console.WriteLine($"Connection status: `{connection.State}`.");
int rows = new MySqlCommand(File.ReadAllText(".\\Sql.sql"), connection).ExecuteNonQuery();
Console.WriteLine($"{rows} rows affected by all transactions done by the loaded script.");
connection.Close(); // Saved *a lot of lines* not using `using() {}`!
