using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public GameObject piecePrefab; // Assign in the Inspector
    protected List<ChessPiece> pieces = new List<ChessPiece>();
    protected Coordinate coordinateManager;
    protected List<Vector3> mainPath;
    protected List<Vector3> basePath;

    public string mainPathKey; // Assign specific key values in subclasses
    public string basePathKey;

    protected virtual void Start()
    {
        coordinateManager = GameObject.FindObjectOfType<Coordinate>();
        if (coordinateManager == null)
        {
            Debug.LogError("Coordinate Manager not found in the scene!");
            return;
        }

        mainPath = coordinateManager.GetPath(mainPathKey);
        basePath = coordinateManager.GetPath(basePathKey);

        if (mainPath == null || mainPath.Count == 0)
        {
            Debug.LogError($"{mainPathKey} is not initialized properly in Coordinates.cs");
            return;
        }

        if (basePath == null || basePath.Count == 0)
        {
            Debug.LogError($"{basePathKey} is not initialized properly in Coordinates.cs");
            return;
        }

        if (piecePrefab == null)
        {
            Debug.LogError("Piece Prefab is not assigned in the Inspector!");
            return;
        }

        InitializePieces();
    }

    protected virtual void InitializePieces()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject pieceObject = Instantiate(piecePrefab, mainPath[0], Quaternion.identity);
            ChessPiece chessPiece = pieceObject.GetComponent<ChessPiece>();

            if (chessPiece != null)
            {
                chessPiece.Initialize(mainPath, basePath, i);
                pieceObject.name = $"{GetType().Name} Piece {i + 1}";
                pieces.Add(chessPiece);
            }
        }
    }
}
