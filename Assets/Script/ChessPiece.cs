using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public Transform playerTransform;
    public float movementSpeed;
    public List<Vector3> path;
    public int currentPositionIndex;
    protected SpriteRenderer spriteRenderer;
    protected CircleCollider2D circleCollider;
    public bool isMoving;

    public Dice GameDie;



    protected virtual void Start()
    {
        playerTransform = transform;
        movementSpeed = 5.0f;
        currentPositionIndex = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        isMoving = false;

        GameDie = FindObjectOfType<Dice>();

    }

    public void Initialize(List<Vector3> planePath)
    {
        path = planePath;
        currentPositionIndex = 0;
        playerTransform.position = path[0];
    }
    void OnMouseDown()
    {
        Debug.Log("pressed1");

        if (GameDie.Rolled)
        {
            Debug.Log("pressed");
            Move(GameDie.randomDiceSide + 1);
            GameDie.Rolled = false;
        }
    }

    public void Move(int steps)
    {

        if (isMoving || currentPositionIndex + steps >= path.Count)
            return;

        StartCoroutine(MoveSteps(steps));
    }

    private IEnumerator MoveSteps(int steps)
    {
        isMoving = true;
        for (int i = 0; i < steps; i++)
        {
            currentPositionIndex++;
            Vector3 nextPosition = path[currentPositionIndex];
            while (Vector3.Distance(playerTransform.position, nextPosition) > 0.01f)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }
        isMoving = false;
        Debug.Log($"{gameObject.name} reached position {currentPositionIndex}");
    }
    /*
        protected void OnMouseDown()
        {
            Move(1);
        }
        */
}
