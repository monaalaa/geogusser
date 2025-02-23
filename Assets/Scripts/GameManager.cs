using VContainer.Unity;

public class GameManager : IStartable
{
    private readonly BoardManager _boardManager;
    private readonly PlayersManager _playersManager;
    private readonly QuizManager _quiManager;

    public GameManager(BoardManager boardManager,
        PlayersManager playersManager,
        QuizManager quiManager)
    {
        _boardManager = boardManager;
        _playersManager = playersManager;
        _quiManager = quiManager;
    }

    public void Start()
    {
        _boardManager.InitializeBoard();
        _playersManager.InitPlayer();
        _quiManager.InitQuizs();
    }
}
