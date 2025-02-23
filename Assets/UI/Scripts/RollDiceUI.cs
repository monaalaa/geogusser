using UnityEngine;
using VContainer;

public class RollDiceUI : MonoBehaviour
{
    private PlayersManager _playersManager;

    [Inject]
    private void Construct(PlayersManager playersManager)
    {
        _playersManager = playersManager;
    }
    public void RollDice()
    {
        var steps = Random.Range(1, 7);
        _playersManager.MovePlayer(steps);
    }
}
