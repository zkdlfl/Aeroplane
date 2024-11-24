using System.Collections.Generic;
using UnityEngine;

public abstract class GamePlayer : MonoBehaviour
{
    public GameObject piecePrefab; // Assign in the Inspector
    protected List<ChessPiece> pieces = new List<ChessPiece>();
    protected Coordinate coordinateManager;
    protected List<Vector3> mainPath;
    protected List<Vector3> basePath;

    public string mainPathKey; // Assign specific key values in subclasses
    public string basePathKey;
    public bool onceUpdate = true;

    protected virtual void Start()
    {

        coordinateManager = GameObject.FindObjectOfType<Coordinate>();
        if (coordinateManager == null)
        {
            Debug.LogError("Coordinate Manager not found in the scene!");
            return;
        }

    }
    public void Update()
    {
        if (coordinateManager.canUpdate && onceUpdate)
        {
            InitializePieces();
            onceUpdate = false;
        }
    }
    protected virtual void InitializePieces()
    {
        basePath = coordinateManager.GetPath(basePathKey);
        mainPath = coordinateManager.mainPathsOriginal;


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

        if (mainPath.Count == 0)
        {
            Debug.LogError("big path is null!");

        }

        if (mainPath == null || mainPath.Count == 0)
        {
            Debug.LogError($"{mainPathKey} is not initialized properly in Coordinates.cs");
            return;
        }

        int startingIndex = mainPathKey switch
        {
            "Red" => 2,
            "Blue" => 15,
            "Yellow" => 28,
            "Green" => 41,

            _ => 0
        };

        for (int i = 0; i < 4; i++)
        {
            GameObject pieceObject = Instantiate(piecePrefab, mainPath[startingIndex], Quaternion.identity);
            ChessPiece chessPiece = pieceObject.GetComponent<ChessPiece>();

            if (chessPiece != null)
            {
                chessPiece.Initialize(startingIndex, mainPath, basePath, i);
                pieceObject.name = $"{mainPathKey} Piece {i + 1}";
                pieces.Add(chessPiece);
            }
        }
    }
}