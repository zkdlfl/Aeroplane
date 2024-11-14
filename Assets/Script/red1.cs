using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red1 :RedPiece
{
    private void Start()
    {
        position = -1; // Not on the board initially
        isActive = false; // Start as inactive
    }

    public override void Move(int steps)
    {
        // Example of a specific override (if needed)
        Debug.Log("Red Piece 1 moving!");
        base.Move(steps);
    }
}

