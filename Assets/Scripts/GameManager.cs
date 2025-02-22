
using VContainer.Unity;

public class GameManager : IStartable
{
    private readonly BoardManager _boardManager;
    private readonly PlayersManager _playersManager;
    private readonly RollDiceUI _rollDiceUI;
    //private MinigameManager _minigameManager;

    public GameManager(BoardManager boardManager,
        PlayersManager playersManager/*, MinigameManager minigameManager, UIManager uiManager*/)
    {
        _boardManager = boardManager;
        _playersManager = playersManager;
        //_rollDiceUI = rollDiceUI;
        //_minigameManager = minigameManager;
        //_uiManager = uiManager;

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
