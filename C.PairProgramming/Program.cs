var testCaseCount = int.Parse(Console.ReadLine());
while (testCaseCount > 0)
{
    var developerCount = int.Parse(Console.ReadLine());
    var developers = Console.ReadLine().Split(' ').Reverse()
        .Select(it => new Developer { Index = developerCount--, Skill = int.Parse(it) })
        .OrderBy(it => it.Index).ToList();

    while (developers.Any())
    {
        var firstDeveloper = developers.First();
        var secondDeveloper = developers.Skip(1)
            .OrderBy(it => Math.Abs(firstDeveloper.Skill - it.Skill)).First();

        Console.WriteLine("{0} {1}", firstDeveloper.Index, secondDeveloper.Index);

        developers.Remove(firstDeveloper);
        developers.Remove(secondDeveloper);
    }

    testCaseCount--;
}

public class Developer
{
    public int Index { get; set; }
    public int Skill { get; set; }
}