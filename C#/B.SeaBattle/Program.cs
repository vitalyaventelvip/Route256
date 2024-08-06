const string SUCCESS = "YES";
const string FAILURE = "NO";

const int SINGLE_DECK_SHIPS_COUNT = 4;
const int DOUBLE_DECK_SHIPS_COUNT = 3;
const int TREE_DECK_SHIPS_COUNT = 2;
const int FOUR_DECK_SHIPS_COUNT = 1;

var deckShipsTypes = Enum.GetValues(typeof(DeckShipsType)).Cast<DeckShipsType>();

var testCaseCount = int.Parse(Console.ReadLine());
for (var i = 0; i < testCaseCount; i++)
{
    var result = SUCCESS;
    var ships = Console.ReadLine().Split(' ').Select(it => int.Parse(it)).ToArray();

    foreach (var _deckShipsType in deckShipsTypes)
    {
        var (deckShipsType, deckShipsCount) = _deckShipsType switch
        {
            DeckShipsType.Single => ((int)DeckShipsType.Single, SINGLE_DECK_SHIPS_COUNT),
            DeckShipsType.Double => ((int)DeckShipsType.Double, DOUBLE_DECK_SHIPS_COUNT),
            DeckShipsType.Tree => ((int)DeckShipsType.Tree, TREE_DECK_SHIPS_COUNT),
            DeckShipsType.Four => ((int)DeckShipsType.Four, FOUR_DECK_SHIPS_COUNT),
        };

        if (!Equals(ships.Count(it => Equals(it, deckShipsType)), deckShipsCount))
        {
            result = FAILURE; break;
        }
    }

    Console.WriteLine(result);
}

public enum DeckShipsType : int
{
    Single = 1,
    Double = 2,
    Tree = 3,
    Four = 4
}