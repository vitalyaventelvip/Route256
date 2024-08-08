using System.Globalization;

decimal CalculcateCommission(decimal price, decimal percent) => price * (percent / 100);

decimal FindMissingSum(decimal price, decimal percent)
{
    var commissionVal = CalculcateCommission(price, percent);

    return Math.Round(commissionVal, 2, MidpointRounding.ToEven) - Math.Floor(commissionVal);
}

using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

var testCaseCount = int.Parse(input.ReadLine());
for (int i = 0; i < testCaseCount; i++)
{
    var testCaseInput = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
    var productCount = testCaseInput[0]; var commissionPercent = testCaseInput[1];

    decimal sum = 0;
    for (int j = 0; j < productCount; j++)
    {
        var productPrice = decimal.Parse(input.ReadLine());
        sum += FindMissingSum(productPrice, commissionPercent);
    }

    var formattedSum = sum.ToString("0.00", CultureInfo.InvariantCulture);
    output.WriteLine(formattedSum);
}
