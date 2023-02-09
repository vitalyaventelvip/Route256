using System.Text.RegularExpressions;

const string pattern = @"([A-Z]{1})([0-9]{1,2})([A-Z]{2})";

var testCaseCount = int.Parse(Console.ReadLine());
for (int i = 0; i < testCaseCount; i++)
{
    var input = Console.ReadLine();

    if (Regex.IsMatch(input, pattern, RegexOptions.Compiled))
    {
        var matches = Regex.Matches(input, pattern, RegexOptions.Compiled);
        if (matches.Count() > 0)
        {
            var numbers = matches.Select(it => it.Value).ToArray();
            if (Equals(input, string.Join("", numbers)))
            {
                Console.WriteLine("{0}", string.Join(' ', numbers));
            }
            else
            {
                Console.WriteLine("-");
            }
        }
        else
        {
            Console.WriteLine("-");
        }
    }
    else
    {
        Console.WriteLine("-");
    }
}