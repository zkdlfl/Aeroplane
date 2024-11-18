using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    public GameObject redPiecePrefab; 
    private List<RedPiece> redPieces = new List<RedPiece>();
    private Coordinate coordinateManager;
    private List<Vector3> redPath;

    void Start()
    {
        coordinateManager = GameObject.FindObjectOfType<Coordinate>();
        if (coordinateManager == null)
        {
            Debug.LogError("Coordinate Manager not found in the scene!");
            return;
        }

        redPath = coordinateManager.GetPath("Red");
        if (redPath == null || redPath.Count == 0)
        {
            Debug.LogError("Red Path is not initialized properly in Coordinates.cs");
            return;
        }

        if (redPiecePrefab == null)
        {
            Debug.LogError("Red Piece Prefab is not assigned in the Inspector!");
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            GameObject redPieceObject = Instantiate(redPiecePrefab, redPath[0], Quaternion.identity);
            RedPiece redPiece = redPieceObject.GetComponent<RedPiece>();
            
            if (redPiece != null)
            {
                redPiece.Initialize(redPath);
                redPieceObject.name = $"Red Piece {i + 1}";
                redPieces.Add(redPiece);
            }
        }
    }
}
