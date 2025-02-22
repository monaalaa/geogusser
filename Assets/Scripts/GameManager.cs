using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameManager : IStartable
{
    [Inject] private IObjectResolver objectResolver;
    private readonly BoardManager _boardManager;
    private readonly PlayerController _playerController;
    //private MinigameManager _minigameManager;
    //private UIManager _uiManager;

    List<PlayerController> _players = new List<PlayerController>();
    public  GameManager(BoardManager boardManager,
        PlayerController playerController/*, MinigameManager minigameManager, UIManager uiManager*/)
    {
        _boardManager = boardManager;
        _playerController=playerController;
        //_minigameManager = minigameManager;
        //_uiManager = uiManager;

    }

     public void Start()
    {
        _boardManager.InitializeBoard();
        InitPlayer();
    }

    public void StartRound()
    {
        int steps = Random.Range(1, 7);
      //  _playerController.MovePlayer(steps);
    }

    public void TriggerMinigame()
    {
       // _minigameManager.StartMinigame();
    }

    private void InitPlayer()
    {
        var player = GameObject.Instantiate(_playerController);
        objectResolver.Inject(player);
        player.SetPlayerInitialPosition();
        _players.Add( player );
    }
}
