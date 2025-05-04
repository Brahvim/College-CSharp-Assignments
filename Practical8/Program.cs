using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().AddUserSecrets<AssemblyId>().Build();

Console.WriteLine(config["dbPass"]);
using (
    // `new()` is lovely but `var` is great, too!:
    var connection = new MySqlConnection(string.Concat([

        "User ID=root;",
        "Server=localhost;",
        $"Password={config["dbPass"]};", // VS2022 stores this. Can chill.
        // (Right-click `Practical8`, click "Manage User Secrets". NuGet needed I think).

])) // Passing a collection. Can use as many commas as I want!
    ) // End of `using()`.
{
    int rows = new MySqlCommand(File.ReadAllText(".\\Sql.sql"), connection).ExecuteNonQuery();
    Console.WriteLine($"{rows} rows affected by all transactions done by the loaded script.");
}

class AssemblyId { }; // Fake class to identify this assembly and fetch config stuff.
