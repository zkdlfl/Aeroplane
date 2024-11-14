using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class PlayerBase
{
    public Transform playerTransform;
    public float movementSpeed;
    int[,] BlueLocations = { // {{x_1, y_1}, {x_2, y_2}, ...}
            {0,1},
            {1,0},
        };
    int[] Direction = { }; // 1 - Up | 2 - Right | 3 - Down | 4 - Left
    int StartIndex;
    int GoalIndex;


    public PlayerBase(Transform transform, float speed)
    {
        this.playerTransform = transform;
        this.movementSpeed = speed;
        this.StartIndex = 0;
        this.GoalIndex = BlueLocations.GetLength(0) - 1;
    }
    public void Pressed()
    {
        if (StartIndex >= BlueLocations.Length)
        {
            StartIndex = 0;
        }

        playerTransform.position = new Vector3(BlueLocations[StartIndex, 0] * movementSpeed * Time.deltaTime, BlueLocations[StartIndex, 1] * movementSpeed * Time.deltaTime, 0);


        if (StartIndex == GoalIndex)
        {
            PlaneFinished();
            StartIndex = 0;
        }
        StartIndex++;

    }
    public void PlaneFinished()
    {

    }
}





public class BluePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerBase piece;
    public float movementSpeed = 5.0f;

    void Start()
    {
        piece = new PlayerBase(transform, movementSpeed);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        piece.Pressed();
    }

}
