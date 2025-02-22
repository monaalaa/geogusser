using UnityEngine;

public class EmptyTile : Tile
{
    [SerializeField] private ParticleSystem landEffect;    
    [SerializeField] private ParticleSystem passEffect;    

    public override void OnLand()
    {
        if (landEffect != null)
        {
            landEffect.Play();
        }

        Debug.Log("Player landed on an empty tile!");
    }

    public override void OnPass()
    {
        if (passEffect != null)
        {
            passEffect.Play();
        }

        Debug.Log("Player passed through an empty tile!");
    }
}

