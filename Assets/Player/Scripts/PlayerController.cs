using DG.Tweening;
using System.Collections;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private readonly BoardManager _boardManager;
    private  Tile _currentTile;

    [SerializeField]
    private float jumpDuration = 0.5f;
    [SerializeField]
    private float jumpHeight = 0.5f;

    public void MovePlayer(int steps)
    {
        MoveMultipleSteps(steps);
    }

    public void SetPlayerInitialPosition()
    {
        _currentTile = _boardManager.GetRandomTileInFirstRaw();
        transform.position = _currentTile.Position;
    }
    private void MoveMultipleSteps(int steps)
    {
        Tile nextTile = _boardManager.GetNextTile(_currentTile);
        StartCoroutine(JumpToTile(nextTile, steps));
    }
    private IEnumerator JumpToTile(Tile target, int steps)
    {
        if (steps <= 0) yield break;

        Vector3 targetPosition = target.transform.position;

        yield return transform.DOJump(targetPosition, jumpHeight, 1, jumpDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                steps--;

                if (steps == 0)
                {
                    _currentTile = target;
                    target.OnLand();
                }
                else
                {
                    target.OnPass();
                    Tile nextTile = _boardManager.GetNextTile(target);
                    if (nextTile == null)
                    {
                        Debug.Log("Player wins");
                    }
                    StartCoroutine(JumpToTile(nextTile, steps));
                }
            });
    }

}
