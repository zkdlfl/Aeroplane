using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Plane{
    public string PlayerName;
    public string Color;
    public bool [] finalSpace; // checks which home bases are taken
    public int [][] coordinates; // finds the (x, y) coordinates of the four planes
    public Player_Plane(string PlayerName, string color){
        this.PlayerName = PlayerName;
        this.Color = color;
    }
}
public class Plane : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
