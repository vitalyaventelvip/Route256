using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var testCaseCount = int.Parse(Console.ReadLine());
        for (var i = 0; i < testCaseCount; i++)
        {
            var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
            Console.WriteLine(collection.Sum());
        }
    }
}
