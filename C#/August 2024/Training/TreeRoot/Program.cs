public class Program
{
    public static void Main(string[] args)
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        var testCaseCount = int.Parse(input.ReadLine());
        for (int i = 0; i < testCaseCount; i++)
        {
            var codedTreeCollection = new List<CodedTree>();
            var testCaseInputLen = int.Parse(input.ReadLine());
            var testCaseInput = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            while (testCaseInput.Any())
            {
                var codedTreeId = testCaseInput[0];
                var codedTreeChildCount = testCaseInput[1];

                var codedTreeChildIds = testCaseInput.Skip(2).Take(codedTreeChildCount).ToArray();
                codedTreeCollection.Add(new CodedTree(codedTreeId, codedTreeChildIds));
                testCaseInput = testCaseInput.Skip(2 + codedTreeChildCount).ToArray();
            }

            var root = codedTreeCollection.First();
            var parent = codedTreeCollection.FirstOrDefault(x => x.ChildIds.Contains(root.Id));

            while (parent != null)
            {
                root = parent;
                parent = codedTreeCollection.FirstOrDefault(x => x.ChildIds.Contains(root.Id));
            }

            Console.WriteLine(root.Id);
        }
    }

    class CodedTree
    {
        public CodedTree(int id, int[] child)
        {
            Id = id;
            ChildIds = child;
        }

        public int Id { get; set; }
        public int[] ChildIds { get; set; }
    }
}
