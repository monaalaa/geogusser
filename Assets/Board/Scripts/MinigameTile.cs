
using UnityEngine;

public class MinigameTile : Tile
{
    [SerializeField] private GameObject[] minigames;  

    public override void OnLand()
    {
        int randomIndex = Random.Range(0, minigames.Length);
        GameObject selectedMinigame = minigames[randomIndex];

        Debug.Log($"Triggered a random minigame: {selectedMinigame.name}");

        Instantiate(selectedMinigame, transform.position, Quaternion.identity);
    }

    public override void OnPass()
    {
        Debug.Log("Player passed through an Minigame tile!");

    }
}

