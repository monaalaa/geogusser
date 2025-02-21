using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameManager : IStartable
{
    readonly BoardManager _boardManager;
    //private PlayerController _playerController;
    //private MinigameManager _minigameManager;
    //private UIManager _uiManager;

   
    public  GameManager(BoardManager boardManager /*,PlayerController playerController, MinigameManager minigameManager, UIManager uiManager*/)
    {
        _boardManager = boardManager;
        //_playerController = playerController;
        //_minigameManager = minigameManager;
        //_uiManager = uiManager;
    }

    void IStartable.Start()
    {
        // Initialize the board and player
        _boardManager.InitializeBoard();
       // _playerController.SetupPlayer();

        // Start the first round
        StartRound();
    }

    public void StartRound()
    {
        // Simulate a random move for the player (e.g., roll a dice)
        int steps = Random.Range(1, 7); // Random dice roll (1-6)
        Vector3 targetTile = _boardManager.GetTilePosition(steps);

        // Move the player to the target tile
       // _playerController.MovePlayerToTile(targetTile);

        // Trigger tile interaction
        _boardManager.OnPlayerLandsOnTile(targetTile);
    }

    public void TriggerMinigame()
    {
       // _minigameManager.StartMinigame();
    }

    
     
}
