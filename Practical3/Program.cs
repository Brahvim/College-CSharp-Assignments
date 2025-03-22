Console.WriteLine("Please enter a string of characters:");
string uin = Console.ReadLine() ?? "", result = "";

foreach (char c in uin)
{
    result += char.IsLower(c)
        ? char.ToUpperInvariant(c)
        : char.ToLowerInvariant(c);
}

Console.WriteLine(result);
