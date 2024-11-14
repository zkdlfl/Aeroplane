using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public string pieceColor; 
    public int position;
    public bool isActive;

    public virtual void Move(int steps){
        if (isActive){
        }
    }
    public void ActivatePiece()
    {
        isActive = true;  
    }

}
