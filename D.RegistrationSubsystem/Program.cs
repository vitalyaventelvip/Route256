using System.Text.RegularExpressions;

//const int MinLoginLen = 2;
//const int MaxLoginLen = 24;
const string LoginPattern = "[0-9a-zA-Z_][0-9a-zA-Z_-]{1,23}";

const string Failed = "NO";
const string Success = "YES";

var regex = new Regex(LoginPattern);
var testCaseCount = int.Parse(Console.ReadLine());
while (testCaseCount > 0)
{
    var registredLogins = new HashSet<string>();
    var registrationCount = int.Parse(Console.ReadLine());
    var loginCollection = new string[registrationCount];
    for (int j = 0; j < registrationCount; j++)
    {
        loginCollection[j] = Console.ReadLine();
    }
    Console.ReadLine();
    for (int j = 0; j < loginCollection.Length; j++)
    {
        var login = loginCollection[j];
        if (regex.IsMatch(login) && !registredLogins.Contains(login.ToLower()))
        {
            registredLogins.Add(login.ToLower());
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

Console.ReadKey();