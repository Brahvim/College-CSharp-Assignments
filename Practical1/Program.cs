namespace Practical1
{
	class Program
	{
		public static void Main(string[] _)
		{
			Console.Write("Please enter a character to check the case of: ");
			Console.WriteLine(
				char.IsUpper((char)Console.Read())
				? "That is an uppercase character."
				: "That is NOT an uppercase character!"
				);
		}
	}
}

