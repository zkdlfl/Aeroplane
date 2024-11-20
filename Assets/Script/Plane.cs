using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Plane{
    public string Color;
    public int numPlanes;
    public int kills;
    public bool [] finalSpace; // checks which home bases are taken
    public int [][] coordinates; // finds the (x, y) coordinates of the four planes
    public Player_Plane(int numPlanes, string color, int kill){
        this.numPlanes = numPlanes;
        this.kills = kill;
        this.Color = color;
    }
}
public class Plane : MonoBehaviour
{
    // Text
    public TextMeshProUGUI yellow_Text;
    public TextMeshProUGUI red_Text;
    public TextMeshProUGUI blue_Text;
    public TextMeshProUGUI green_Text;
    public TextMeshProUGUI player_turn_text;
    Player_Plane yellow_profile = new Player_Plane(4, "Yellow", 0);
    Player_Plane red_profile = new Player_Plane(4, "Red", 0);
    Player_Plane blue_profile = new Player_Plane(4, "Blue", 0);
    Player_Plane green_profile = new Player_Plane(4, "Green", 0);

    public string PlayerTurn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTurn = "Yellow";
    }

    // Update is called once per frame
    void Update()
    {
        player_turn_text.text = PlayerTurn;
        yellow_Text.text = "Planes: " + yellow_profile.numPlanes.ToString() + ", Kills: " + yellow_profile.kills.ToString();
        red_Text.text = "Planes: " + red_profile.numPlanes.ToString() + ", Kills: " + red_profile.kills.ToString();
        blue_Text.text = "Planes: " + blue_profile.numPlanes.ToString() + ", Kills: " + blue_profile.kills.ToString();
        green_Text.text = "Planes: " + green_profile.numPlanes.ToString() + ", Kills: " + green_profile.kills.ToString();
    }
}
