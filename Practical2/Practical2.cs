Console.Write("Please enter a character to check if it is a vowel: ");

string output;
switch ((char)Console.Read())
{
	case 'a':
	case 'e':
	case 'i':
	case 'o':
	case 'u': { output = "That is a vowel."; } break;
	default: { output = "That is NOT a vowel!"; } break;
}

Console.WriteLine(output);
