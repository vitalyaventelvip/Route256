var testCaseCount = int.Parse(Console.ReadLine());

while(testCaseCount > 0)
{
    var abonentCount = int.Parse(Console.ReadLine());
    var abonentCollection = new Dictionary<string, List<string>>();

    for (int i = 0; i < abonentCount; i++)
    {
        var journalRecordCollection = Console.ReadLine().Split(' ').ToArray();
        var abonentName = journalRecordCollection[0];
        var abonentPhone = journalRecordCollection[1];

        if (abonentCollection.TryGetValue(abonentName, out var phoneCollection))
        {
            if (phoneCollection.Contains(abonentPhone))
            {
                phoneCollection.Remove(abonentPhone);
            }

            if (phoneCollection.Count == 5)
            {
                phoneCollection.RemoveAt(0);
            }

            phoneCollection.Add(abonentPhone);

            abonentCollection[abonentName] = phoneCollection;
        }
        else
        {
            abonentCollection.Add(abonentName, new List<string>() { abonentPhone });
        }
    }

    foreach (var abonent in abonentCollection.OrderBy(p => p.Key))
    {
        abonent.Value.Reverse();

        Console.WriteLine("{0}: {1} {2}", abonent.Key, abonent.Value.Count, string.Join(' ', abonent.Value));
    }
    Console.WriteLine();

    testCaseCount--;
}