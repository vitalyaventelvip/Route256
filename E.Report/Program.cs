const string SUCCESS = "YES";
const string FAILURE = "NO";

var testCaseCount = int.Parse(Console.ReadLine());
for (int t = 0; t < testCaseCount; t++)
{
    var daysCount = int.Parse(Console.ReadLine());
    var tasks = Console.ReadLine().Split(' ').Reverse()
        .Select(it => new Task { DayNum = daysCount--, ReportId = int.Parse(it) })
        .OrderBy(it => it.ReportId).ThenBy(it => it.DayNum).ToList();

    var result = SUCCESS;

    while (tasks.Any())
    {
        var task = tasks.First();
        var taskDayNum = task.DayNum;
        var sameTasks = tasks.Where(it => it.ReportId.Equals(task.ReportId)).ToList();

        foreach (var sameTask in sameTasks)
        {
            var sumTaskDay = taskDayNum + 1;

            if (sameTask.DayNum > sumTaskDay)
            {
                result = FAILURE;
                break;
            }

            if (sameTask.DayNum == sumTaskDay)
            {
                taskDayNum = sameTask.DayNum;
            }
        }

        if (result == FAILURE)
        {
            break;
        }

        tasks.RemoveAll(it => it.ReportId == task.ReportId);
    }

    Console.WriteLine(result);
}

public class Task
{
    public int DayNum { get; set; }
    public int ReportId { get; set; }
}