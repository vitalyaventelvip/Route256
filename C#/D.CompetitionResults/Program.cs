const int BEST_SPORTSMAN_POSITION = 1;

var testCaseCount = int.Parse(Console.ReadLine());
for (int i = 0; i < testCaseCount; i++)
{
    var sportsmansCount = int.Parse(Console.ReadLine());
    var sportsmansResults = Console.ReadLine().Split(' ')
        .Select((it, index) => new Sportsman
        {
            Index = index,
            Time = int.Parse(it)
        })
        .OrderBy(it => it.Time)
        .ToArray();

    Sportsman lastSportsmanResult = null;
    var nextSportsmanPosition = BEST_SPORTSMAN_POSITION;
    foreach (var sportsmansResult in sportsmansResults)
    {
        if (lastSportsmanResult is null)
        {
            sportsmansResult.Position = nextSportsmanPosition;
        }
        else if (Equals(lastSportsmanResult.Time, sportsmansResult.Time) ||
                 Equals(sportsmansResult.Time - lastSportsmanResult.Time, 1))
        {
            sportsmansResult.Position = lastSportsmanResult.Position;
        }
        else
        {
            sportsmansResult.Position = nextSportsmanPosition;
        }

        lastSportsmanResult = sportsmansResult;
        nextSportsmanPosition++;
    }

    Console.WriteLine("{0}", string.Join(' ', sportsmansResults.OrderBy(it => it.Index).Select(it => it.Position)));
}

public class Sportsman
{
    public int Index { get; set; }
    public int Time { get; set; }
    public int Position { get; set; } = 0;
}
