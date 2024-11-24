using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public Transform playerTransform;
    public float movementSpeed;
    public List<Vector3> path;
    public List<Vector3> current_color_home_path;

    public List<Vector3> [] HomeBase;
    protected SpriteRenderer spriteRenderer;
    protected CircleCollider2D circleCollider;
    public bool isMoving;
    public bool isOutOfBase = false;

    public Dice GameDie;
    public List<Vector3> playerBase;
    public int currentPositionIndex;
    public int firstIndex;
    public int shift;
    public string [] color_array = {"green", "red", "blue", "yellow"};
    public int [] mega_jump_array = {5, 18, 31, 44}; 

    public int [] home_base_array = {37, 50, 11, 24}; 
    public string current_color = "red";
    public bool have_moved_to_original_color = false; // checks whether the plane has skipped to it's color already


    public int color_index = 1; // fix this part later
    public int more_steps = 0;

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

    public void Initialize(int startIndex, List<Vector3> planePath, List<Vector3> baseCoordinates, List<Vector3> redHanger, int pieceNumber)
    {
        path = planePath;
        HomeBase = new List<Vector3>[4];
        HomeBase[1] = redHanger;

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


        have_moved_to_original_color = false;
        StartCoroutine(MoveSteps(steps));

    }
    private IEnumerator MoveSteps(int steps)
    {
        isMoving = true;
        int before_hanger = home_base_array[color_index];
        current_color_home_path = HomeBase[color_index];

        if(currentPositionIndex + steps > before_hanger){
            more_steps = steps;
            steps = currentPositionIndex + steps - before_hanger;

            more_steps = more_steps - steps;
        }

        if(more_steps == 0){
            for (int i = 0; i < steps; i++)
            {
                Debug.Log("move size check " + currentPositionIndex);

                Vector3 nextPosition = path[(currentPositionIndex + 1 + shift) % 52];


                while (Vector3.Distance(playerTransform.position, nextPosition) > 0.01f)
                {
                    playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, movementSpeed * Time.deltaTime);
                    yield return null;
                }
                currentPositionIndex++;
                currentPositionIndex = currentPositionIndex % 52;
            }
            isMoving = false;
            Debug.Log($"{gameObject.name} reached position {currentPositionIndex}");


            // check to see if the plane is on the it's color

            int find_current_color = currentPositionIndex % 4;
            int standing_color_index = (find_current_color - 1 + color_array.Length) % color_array.Length;
            string standing_color = color_array[standing_color_index];


            if(standing_color == current_color)
            {
                if (currentPositionIndex == mega_jump_array[standing_color_index])
                {
                    Debug.Log("IMHERE");
                    
                    isMoving = true;

                    int mega_jump_target_index = (currentPositionIndex + 14) % path.Count;
                    Vector3 nextPosition_megajump = path[currentPositionIndex + 14];
                    while (Vector3.Distance(playerTransform.position, nextPosition_megajump) > 0.01f)
                    {
                        playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition_megajump, movementSpeed * Time.deltaTime);
                        yield return null;
                    }
                    // playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition_megajump, movementSpeed * Time.deltaTime);

                    currentPositionIndex = mega_jump_target_index;
                    isMoving = false;
                }
                else
                {
                    if(have_moved_to_original_color == false)
                    {
                        have_moved_to_original_color = true;
                        yield return StartCoroutine(MoveSteps(4));
                    }
                }
            }
        }
        else{
            if(currentPositionIndex > 0){
                currentPositionIndex = -5;
            }
            for (int i = 0; i < more_steps; i++)
            {
                Debug.Log("move size check " + currentPositionIndex);
                Vector3 nextPosition = current_color_home_path[(currentPositionIndex+1)*-1];

                while (Vector3.Distance(playerTransform.position, nextPosition) > 0.01f)
                {
                    playerTransform.position = Vector3.MoveTowards(playerTransform.position, nextPosition, movementSpeed * Time.deltaTime);
                    yield return null;
                }
                currentPositionIndex++;
                // currentPositionIndex = currentPositionIndex % 52;
            }
            isMoving = false;
            Debug.Log($"{gameObject.name} reached position {currentPositionIndex}");
        }   
    }
}
