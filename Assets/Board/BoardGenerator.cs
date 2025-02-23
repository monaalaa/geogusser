using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject tilePrefab; // Tile prefab to be instantiated
    [SerializeField] private float tileSpacing = 1.0f; // Distance between tiles

    private int numRows;
    private int numCols;

    private void Start()
    {
        InitializeBoard();
    }

    // Initialize the board based on the camera's view
    private void InitializeBoard()
    {
        // Calculate the camera's visible width and height
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculate how many tiles fit in the camera's view (horizontal and vertical)
        numRows = Mathf.CeilToInt(cameraHeight / tileSpacing);
        numCols = Mathf.CeilToInt(cameraWidth / tileSpacing);

        // Adjust the camera's orthographic size to make sure the board fits the view if needed
        AdjustCameraForBoard();

        // Generate the tiles dynamically based on camera's view
        SpawnBoardTiles();
    }

    // Adjust the camera's orthographic size if necessary based on the number of tiles
    private void AdjustCameraForBoard()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Adjust the camera size so that the board fits the screen properly
        if (cameraWidth < numCols * tileSpacing || cameraHeight < numRows * tileSpacing)
        {
            float newSize = Mathf.Max(numRows * tileSpacing, numCols * tileSpacing) / 2f;
            mainCamera.orthographicSize = newSize;
        }
    }

    // Spawn the tiles dynamically within the camera's view
    private void SpawnBoardTiles()
    {
        // Calculate the starting point to ensure tiles are centered
        Vector3 startPosition = new Vector3(-(numCols - 1) * tileSpacing / 2, (numRows - 1) * tileSpacing / 2, 0);

        // Create tiles dynamically in the camera's view
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector3 position = startPosition + new Vector3(col * tileSpacing, -row * tileSpacing, 0);
                Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }
}



