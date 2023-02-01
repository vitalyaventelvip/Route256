using System.Text.RegularExpressions;

const string SUCCESS = "YES";
const string FAILURE = "NO";

const string pattern = @"(([0|1]\d)|(2[0-3]))\:([0-5]\d)\:([0-5]\d)";

var testCaseCount = int.Parse(Console.ReadLine());
var allTestCaseCount = testCaseCount;
while (testCaseCount > 0)
{
    var result = SUCCESS;
    var ranges = new List<Range>();
    var rangesCount = int.Parse(Console.ReadLine());
    while (rangesCount > 0)
    {
        var rangeValues = Console.ReadLine().Split('-').ToArray();

        if (!Regex.IsMatch(rangeValues[0], pattern, RegexOptions.Compiled) ||
            !Regex.IsMatch(rangeValues[1], pattern, RegexOptions.Compiled))
        {
            result = FAILURE;
        }

        if (TimeSpan.TryParse(rangeValues[0], out var startRangeVal) &&
            TimeSpan.TryParse(rangeValues[1], out var endRangeVal))
        {
            ranges.Add(new Range { Id = rangesCount, Start = startRangeVal, End = endRangeVal });
        }

        rangesCount--;
    }

    if (result != FAILURE)
    {
        foreach (var range in ranges)
        {
            if (!range.HasRightBoundaries)
            {
                result = FAILURE; break;
            }

            if (ranges.Any(it => (!Equals(it.Id, range.Id)) &&
                ((TimeSpan.Compare(range.Start, it.Start) >= 0 && TimeSpan.Compare(range.Start, it.End) <= 0) ||
                (TimeSpan.Compare(range.End, it.Start) >= 0 && TimeSpan.Compare(range.End, it.End) <= 0))))
            {
                result = FAILURE; break;
            }
        }
    }

    Console.WriteLine("{0}", result);

    testCaseCount--;
}

public class Range
{
    public int Id { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public bool HasRightBoundaries => TimeSpan.Compare(Start, End) <= 0;
}