using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class PlayersManager
{
    [Inject]
    private IObjectResolver objectResolver;

    private PlayerController _playerController;

    List<PlayerController> _players = new List<PlayerController>();

    [Inject]
    private void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void MovePlayer(int steps)
    {
        _players[0].MovePlayer(steps);
    }

    public void InitPlayer()
    {
        var player = objectResolver.Instantiate(_playerController);
        player.SetPlayerInitialPosition();
        _players.Add(player);
    }
}
