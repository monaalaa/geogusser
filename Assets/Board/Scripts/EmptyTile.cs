using DG.Tweening;
using UnityEngine;
public class EmptyTile : Tile
{
    [SerializeField] private ParticleSystem paricleEffect;
    [SerializeField] private GameObject floatingNumber;
    public override void OnLand()
    {
        paricleEffect.gameObject.SetActive(true);
        FloatText();
        Debug.Log("Player landed on an empty tile!");
    }

    public override void OnPass()
    {
        FloatText();
        paricleEffect.gameObject.SetActive(true);
        Debug.Log("Player passed through an empty tile!");
    }

    private void FloatText()
    {
        floatingNumber.transform
            .DOMoveY(0, 0.2f)
            .SetEase(Ease.InOutBounce)
            .OnComplete(() => floatingNumber.SetActive(false));
    }
}

