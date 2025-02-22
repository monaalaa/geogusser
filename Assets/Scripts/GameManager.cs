
using VContainer.Unity;

public class GameManager : IStartable
{
    private readonly BoardManager _boardManager;
    private readonly PlayersManager _playersManager;
    private readonly RollDiceUI _rollDiceUI;

    public GameManager(BoardManager boardManager,
        PlayersManager playersManager)
    {
        _boardManager = boardManager;
        _playersManager = playersManager;
    }

    public void Start()
    {
        _boardManager.InitializeBoard();
        _playersManager.InitPlayer();

    }

    public void TriggerMinigame()
    {
        // _minigameManager.StartMinigame();
    }
}
