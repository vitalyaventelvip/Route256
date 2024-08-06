const int saleCount = 3;
var testCaseCount = int.Parse(Console.ReadLine());
for (int i = 0; i < testCaseCount; i++)
{
    _ = int.Parse(Console.ReadLine());
    var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    Console.WriteLine(
        collection.GroupBy(it => it,el => el,
            (baseIt, its) => its.Skip(its.Count() / saleCount).Sum()).Sum());
}