using DG.Tweening;
using System.Collections;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [Inject] 
    private BoardManager boardManager; 

    private Tile currentTile;
    private Tile targetTile;

    [SerializeField] 
    private float jumpDuration = 1f;

    public void MovePlayer(int steps)
    {
        StartCoroutine(MoveMultipleSteps(steps));
    }
 
    public void SetPlayerInitialPosition()
    {
        currentTile = boardManager.GetRandomTileInFirstRaw();
        transform.position = currentTile.Position;
    }
    private IEnumerator MoveMultipleSteps(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            Tile nextTile = boardManager.GetNextTile(currentTile);
            yield return StartCoroutine(JumpToTile(nextTile));
            currentTile = nextTile;
        }
    }

    private IEnumerator JumpToTile(Tile target)
    {
        Vector3 targetPosition = target.transform.position;
        yield return transform.DOMove(targetPosition, jumpDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => target.OnLand())
            .OnKill(() => currentTile.OnPass());
    }
}
