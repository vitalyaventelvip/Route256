const string Success = "SUCCESS";
const string Fail = "FAIL";

var testCaseCount = int.Parse(Console.ReadLine());
while(testCaseCount > 0)
{
    Console.ReadLine();
    var collection = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();
    var coupeCount = collection[0];
    var requestCount = collection[1];

    int[][] coupeCollection = new int[coupeCount][];
    for(int i = 0; i < coupeCount; i++)
    {
        coupeCollection[i] = new int[2];
    }

    testCaseCount--;
}