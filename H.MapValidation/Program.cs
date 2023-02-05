const string SUCCESS = "YES";
const string FAILURE = "NO";

var testCaseCount = int.Parse(Console.ReadLine());
while (testCaseCount > 0)
{
    var gameBoardSettings = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    var rowsCount = gameBoardSettings[0];
    var colsCount = gameBoardSettings[1];
    var gameBoard = new char[rowsCount, colsCount];

    for (var i = 0; i < rowsCount; i++)
    {
        var gameBoardlineSettings = Console.ReadLine().ToCharArray();

        for (int j = 0; j < colsCount; j++)
        {
            gameBoard[i, j] = gameBoardlineSettings[j];
        }
    }

    var result = SUCCESS;

    for (var i = 0; i < rowsCount; i++)
    {
        for (int j = 0; j < colsCount; j++)
        {
            var gameBoardCell = gameBoard[i, j];

            if (i % 2 == 1 || j % 2 == 0)
            {
                continue;
            }
        }
    }

    Console.WriteLine("{0}", result);

    /*Console.WriteLine();

    for (var i = 0; i < rowsCount; i++)
    {
        var gameMapLine = new char[colsCount];

        for (var j = 0; j < colsCount; j++)
        {
            gameMapLine[j] += gameMap[i, j];
        }

        Console.WriteLine(string.Join("", gameMapLine));
    }*/

    testCaseCount--;
}