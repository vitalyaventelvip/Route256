using System.Text.RegularExpressions;

const string Pattern = "^[0-9a-z_][0-9a-z_-]{1,23}$";
const string Failed = "NO";
const string Success = "YES";

var testCaseCount = int.Parse(Console.ReadLine());
while (testCaseCount > 0)
{
    var registrationCount = int.Parse(Console.ReadLine());
    var loginCollection = new string[registrationCount];
    for (int j = 0; j < registrationCount; j++)
    {
        loginCollection[j] = Console.ReadLine().ToLower();
    }

    var registeredLoginCollection = new HashSet<string>();
    for (int j = 0; j < loginCollection.Length; j++)
    {
        var login = loginCollection[j];
        if (Regex.IsMatch(login, Pattern, RegexOptions.IgnoreCase)
            && !registeredLoginCollection.Contains(login))
        {
            registeredLoginCollection.Add(login);
            Console.WriteLine(Success);
        }
        else
        {
            Console.WriteLine(Failed);
        }
    }
    Console.WriteLine();
    testCaseCount--;
}
