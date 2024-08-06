var socialNetworkSettings = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

var usersCount = socialNetworkSettings[0];
var pairsCount = socialNetworkSettings[1];

var users = new Dictionary<int, int[]>();
var pairs = new HashSet<(int UserId, int FriendId)>();

while (pairsCount > 0)
{
    var pair = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

    pairs.Add((pair[0], pair[1]));
    pairs.Add((pair[1], pair[0]));

    pairsCount--;
}

for (var userId = 1; userId <= usersCount; userId++)
{
    var friendIds = pairs.Where(it => Equals(it.UserId, userId)).Select(it => it.FriendId).ToArray();

    users.Add(userId, friendIds);
}

for (var userId = 1; userId <= usersCount; userId++)
{
    var result = "0";

    var friendIds = users.GetValueOrDefault(userId);
    if (friendIds?.Length > 0)
    {
        var possibleFriendInfos = pairs.Where(it => !Equals(it.UserId, userId) && friendIds.Contains(it.FriendId))
            .GroupBy(it => it.UserId).Select(it => new { FriendId = it.Key, PossibleFriendsCount = it.Count() })
            .Where(it => !users.Any(u => Equals(u.Key, it.FriendId) && u.Value.Contains(userId))).ToArray();

        if (possibleFriendInfos?.Length > 0)
        {
            var maxPossibleFriendsCount = possibleFriendInfos.Max(it => it.PossibleFriendsCount);

            var possibleFriendIds = possibleFriendInfos
                .Where(it => Equals(it.PossibleFriendsCount, maxPossibleFriendsCount))
                .Select(it => it.FriendId).ToArray();

            result = string.Join(' ', possibleFriendIds.OrderBy(it => it));
        }
    }

    Console.WriteLine("{0}", result);
}
