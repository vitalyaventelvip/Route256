var testCaseCount = int.Parse(Console.ReadLine());
Console.ReadLine();
while (testCaseCount > 0)
{
    var tableSize = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    var rows = tableSize[0];
    var cols = tableSize[1];
    int[][] table = new int[rows][];

    for (int i = 0; i < rows; i++)
    {
        table[i] = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    }

    var clickCount = int.Parse(Console.ReadLine());
    var clickedCols = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    Console.ReadLine();

    int? prevClickedCol = null;
    for (int j = 0; j < clickCount; j++)
    {
        var clickedCol = clickedCols[j] - 1;
        if (prevClickedCol != null && prevClickedCol == clickedCol)
            continue;

        var proxy = table.OrderBy(p => p, new ColComparer(clickedCol)).ToArray();
        prevClickedCol = clickedCol;

        table = proxy;
    }

    for (int i = 0; i < rows; i++)
    {
        Console.WriteLine("{0}", string.Join(' ', table[i]));
    }
    Console.WriteLine();

    testCaseCount--;
}

public class ColComparer : IComparer<int[]>
{
    private int ClickedCol { get; set; }
    public ColComparer(int clickedCol)
    {
        ClickedCol = clickedCol;
    }
    public int Compare(int[]? x, int[]? y)
    {
        return x[ClickedCol] - y[ClickedCol];
    }
}