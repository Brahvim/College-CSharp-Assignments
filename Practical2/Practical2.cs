Console.Write("Please enter a character to check if it is a vowel: ");

switch ((char)Console.Read())
{
	case 'a':
	case 'e':
	case 'i':
	case 'o':
	case 'u': Console.WriteLine("That is a vowel."); break;
	default: Console.WriteLine("That is NOT a vowel!"); break;
}
