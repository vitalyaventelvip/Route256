var testCaseCount = int.Parse(Console.ReadLine());
for (int i = 0; i < testCaseCount; i++)
{
    var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    Console.WriteLine(collection.Sum());
}
