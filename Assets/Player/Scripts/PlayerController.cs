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
    private float jumpDuration = 0.5f;
    [SerializeField]
    private float jumpHeight = 0.5f;

    public void MovePlayer(int steps)
    {
        MoveMultipleSteps(steps);
    }

    public void SetPlayerInitialPosition()
    {
        currentTile = boardManager.GetRandomTileInFirstRaw();
        transform.position = currentTile.Position;
    }
    private void MoveMultipleSteps(int steps)
    {
        Tile nextTile = boardManager.GetNextTile(currentTile);
        StartCoroutine(JumpToTile(nextTile, steps));
    }

    /*   private IEnumerator JumpToTile(Tile target, int steps)
       {
           Vector3 targetPosition = target.transform.position;
           yield return transform.DOMove(targetPosition, jumpDuration)
                 .OnComplete(() =>
                 {
                     steps--;
                     if (steps == 0)
                     {
                         target.OnLand();  
                     }
                     else
                     {
                         target.OnPass();
                         Tile nextTile = boardManager.GetNextTile(target);
                         StartCoroutine(JumpToTile(nextTile, steps));
                         target = nextTile;
                     }
                 });
       }*/

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
                    target.OnLand();
                }
                else
                {
                    target.OnPass();
                    Tile nextTile = boardManager.GetNextTile(target);
                    if (nextTile == null)
                    {
                        //Note: we need to init the board to be bigger when player reach the end of board and move camera
                        //To the new position but for simlicity now will debug that player wins
                        Debug.Log("Player wins");
                    }
                    StartCoroutine(JumpToTile(nextTile, steps));
                }
            });
    }

}
