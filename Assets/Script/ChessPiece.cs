using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public Transform playerTransform;
    public float movementSpeed;
    public List<Vector3> path;
    protected SpriteRenderer spriteRenderer;
    protected CircleCollider2D circleCollider;
    public bool isMoving;
    public bool isOutOfBase = false;

    public Dice GameDie;
    public List<Vector3> playerBase;
    public int currentPositionIndex;
    public int firstIndex;
    public int shift;



    protected virtual void Start()
    {
        playerTransform = transform;
        movementSpeed = 5.0f;
        currentPositionIndex = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        isMoving = false;
        isOutOfBase = false;

        GameDie = FindObjectOfType<Dice>();

    }

    public void Initialize(int startIndex, List<Vector3> planePath, List<Vector3> baseCoordinates, int pieceNumber)
    {
        path = planePath;
        Debug.Log("initialize path size" + path.Count);
        shift = startIndex;
        playerBase = baseCoordinates;
        currentPositionIndex = 0;
        Debug.Log("start index " + currentPositionIndex);
        playerTransform.position = playerBase[pieceNumber];
    }
    void OnMouseDown()
    {
        Debug.Log("pressed1");

        if (GameDie.Rolled)
        {
            Debug.Log("pressed");
            if (isOutOfBase)
            {
                Move(GameDie.randomDiceSide + 1);
                GameDie.Rolled = false;
            }
            else
            {
                if (GameDie.randomDiceSide == 5)
                {
                    Debug.Log("MOVING OUT OF BASE, GAMEDIE FALSE");

                    GettingOutOfBase();
                    isOutOfBase = true;
                    GameDie.Rolled = false;
                }
            }

        }
    }

    public void GettingOutOfBase()
    {
        StartCoroutine(MoveOutOfBase());
    }

    private IEnumerator MoveOutOfBase()
    {
        Vector3 nextPosition = playerBase[4];
        while (Vector3.Distance(playerTransform.position, nextPosition) > 0.01f)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void Move(int steps)
    {
        if (isMoving)
            return;


        StartCoroutine(MoveSteps(steps));
    }

    private IEnumerator MoveSteps(int steps)
    {
        isMoving = true;
        for (int i = 0; i < steps; i++)
        {
            Debug.Log("move size check " + currentPositionIndex);

            Vector3 nextPosition = path[(currentPositionIndex + 1 + shift) % 60];


            while (Vector3.Distance(playerTransform.position, nextPosition) > 0.01f)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
            currentPositionIndex++;
            currentPositionIndex = currentPositionIndex % 60;
        }
        isMoving = false;
        Debug.Log($"{gameObject.name} reached position {currentPositionIndex}");

    }
  
}
