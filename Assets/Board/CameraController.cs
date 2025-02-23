using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float verticalPadding = 1.5f;

    void Start()
    {
        AdjustCameraForPortrait();
    }

    // Adjust the camera's orthographic size based on the board's dimensions
    private void AdjustCameraForPortrait()
    {
        // Adjust the orthographic size for portrait view based on tile count and spacing
        float screenRatio = (float)Screen.height / Screen.width;
        float boardHeight = 10f * verticalPadding; // Change based on the board's size
        float cameraSize = boardHeight / screenRatio;

        mainCamera.orthographicSize = cameraSize;
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraSize, mainCamera.transform.position.z);
    }
}
