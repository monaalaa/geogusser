using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public Vector3 Position { get; private set; }

    public void Initialize(Vector3 position)
    {
        Position = position;
        transform.position = position;
    }
    public abstract void OnLand();
    public abstract void OnPass();
}
