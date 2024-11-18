// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Coordinate : MonoBehaviour
// {
//     public ArrayList list_coordinates;
//     // Start is called before the first frame update
//     void Start(){
//         list_coordinates = new ArrayList();

//     }
//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0)) // 0 = left click, 1 = right click, 2 = middle click
//         {
//             Vector2 screenPosition = Input.mousePosition;
//             list_coordinates.Add(screenPosition);
//             Debug.Log(screenPosition);
//         }

//         if(Input.GetMouseButtonDown(1)){
//             string output = string.Join(", ", list_coordinates.ToArray());
//             Debug.Log(output);
//         }
//         // Debug.Log("HI");
//         // Get mouse position in screen coordinates
//     }
// }
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class xy{
    public double x;
    public double y;
    public xy(double x, double y){
        this.x = x;
        this.y = y;
    }
}

public class Color_Location{
    public List<xy> home_base = new List<xy>();
    public List<xy> runway = new List<xy>();
    public Color_Location(List<xy> current, List<xy> run){
        this.home_base = current;
        this.runway = run;
    }
}
public class Coordinate : MonoBehaviour
{
    public ArrayList list_coordinates;
    public List<xy> base_coordinates;

    // Start is called before the first frame update
    void Start(){
        list_coordinates = new ArrayList();
        var batch = new List<xy>
        {
            new xy(220.00, 352.00),
            new xy(247.00, 361.00),
            new xy(273.00, 360.00),
            new xy(301.00, 350.00),
            new xy(319.00, 372.00),
            new xy(309.00, 401.00),
            new xy(308.00, 428.00),
            new xy(320.00, 455.00),
            new xy(346.00, 466.00),
            new xy(372.00, 466.00),
            new xy(397.00, 463.00),
            new xy(423.00, 467.00),
            new xy(447.00, 466.00),
            new xy(474.00, 455.00),
            new xy(484.00, 429.00),
            new xy(484.00, 402.00),
            new xy(474.00, 371.00),
            new xy(492.00, 352.00),
            new xy(521.00, 361.00),
            new xy(546.00, 362.00),
            new xy(572.00, 350.00),
            new xy(581.00, 322.00),
            new xy(581.00, 295.00),
            new xy(581.00, 268.00),
            new xy(580.00, 241.00),
            new xy(581.00, 216.00),
            new xy(572.00, 186.00),
            new xy(545.00, 175.00),
            new xy(520.00, 177.00),
            new xy(493.00, 185.00),
            new xy(474.00, 166.00),
            new xy(484.00, 135.00),
            new xy(483.00, 109.00),
            new xy(474.00, 83.00),
            new xy(447.00, 71.00),
            new xy(422.00, 71.00),
            new xy(396.00, 74.00),
            new xy(371.00, 72.00),
            new xy(346.00, 71.00),
            new xy(319.00, 82.00),
            new xy(310.00, 110.00),
            new xy(310.00, 135.00),
            new xy(321.00, 166.00),
            new xy(300.00, 187.00),
            new xy(272.00, 177.00),
            new xy(247.00, 177.00),
            new xy(220.00, 189.00),
            new xy(213.00, 216.00),
            new xy(213.00, 243.00),
            new xy(213.00, 268.00),
            new xy(212.00, 295.00),
            new xy(213.00, 321.00)
        };
        var group = new List<xy>
        {
            new xy(211.00, 461.00), //0
            new xy(260.00, 459.00),
            new xy(210.00, 412.00),
            new xy(260.00, 413.00), //
            new xy(257.00, 268.00),
            new xy(281.00, 268.00),
            new xy(304.00, 268.00),
            new xy(325.00, 268.00),
            new xy(346.00, 267.00),
            new xy(369.00, 269.00), // 9

            new xy(535.00, 461.00), 
            new xy(583.00, 461.00),
            new xy(536.00, 412.00),
            new xy(584.00, 411.00), //
            new xy(397.00, 416.00),
            new xy(396.00, 393.00),
            new xy(397.00, 368.00),
            new xy(397.00, 345.00),
            new xy(397.00, 323.00),
            new xy(397.00, 301.00),

            new xy(535.00, 122.00),
            new xy(584.00, 120.00),
            new xy(536.00, 74.00),
            new xy(585.00, 72.00),
            new xy(535.00, 267.00),
            new xy(512.00, 268.00),
            new xy(492.00, 268.00),
            new xy(468.00, 267.00),
            new xy(446.00, 268.00),
            new xy(425.00, 266.00),

            new xy(211.00, 123.00),
            new xy(259.00, 121.00),
            new xy(211.00, 74.00),
            new xy(260.00, 74.00),
            new xy(397.00, 119.00),
            new xy(397.00, 141.00),
            new xy(397.00, 166.00),
            new xy(396.00, 187.00),
            new xy(397.00, 210.00),
            new xy(396.00, 236.00)
        };
        list_coordinates.AddRange(batch);
        base_coordinates.AddRange(group);
    }

    private Dictionary<string, List<Vector3>> paths;

    void Awake()
{
    paths = new Dictionary<string, List<Vector3>>();
    paths["Red"] = new List<Vector3>
    {
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(2, 1, 0),  // Add your path coordinates
    };
    Debug.Log("Coordinate paths initialized.");
}

    public List<Vector3> GetPath(string color)
    {
        return paths.ContainsKey(color) ? paths[color] : new List<Vector3>();
    }
}
