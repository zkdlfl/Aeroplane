
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Coordinate : MonoBehaviour
{
    public class xy
    {
        public double x;
        public double y;
        public xy(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Color_Location
    {
        public List<xy> home_base = new List<xy>();
        public List<xy> runway = new List<xy>();
        public Color_Location(int start, List<xy> base_coordinates)
        {
            for (int a = start; a < start + 5; a++)
            {
                this.home_base.Add(base_coordinates[a]);
            }
            for (int b = start + 5; b < start + 11; b++)
            {
                this.runway.Add(base_coordinates[b]);
            }
        }
    }
    public List<xy> list_coordinates;
    public List<xy> base_coordinates;

    // Start is called before the first frame update
    void Start()
    {
        list_coordinates = new List<xy>();
        base_coordinates = new List<xy>();
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
            new xy(203.00, 369.00), // 1st one of the list is the first step outside the hanger
            new xy(211.00, 461.00), // HOME BASE
            new xy(260.00, 459.00),
            new xy(210.00, 412.00),
            new xy(260.00, 413.00),
            new xy(257.00, 268.00), // RUNWAY TO LEAVE
            new xy(281.00, 268.00),
            new xy(304.00, 268.00),
            new xy(325.00, 268.00),
            new xy(346.00, 267.00),
            new xy(369.00, 269.00), //

            new xy(492.00, 475.00),
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

            new xy(587.00, 164.00),
            new xy(535.00, 122.00),
            new xy(584.00, 120.00),
            new xy(536.00, 74.00),
            new xy(585.00, 72.00),
            new xy(535.00, 267.00), //
            new xy(512.00, 268.00),
            new xy(492.00, 268.00),
            new xy(468.00, 267.00),
            new xy(446.00, 268.00),
            new xy(425.00, 266.00),

            new xy(300.00, 63.00),
            new xy(211.00, 123.00),
            new xy(259.00, 121.00),
            new xy(211.00, 74.00),
            new xy(260.00, 74.00),
            new xy(397.00, 119.00), //
            new xy(397.00, 141.00),
            new xy(397.00, 166.00),
            new xy(396.00, 187.00),
            new xy(397.00, 210.00),
            new xy(396.00, 236.00)
        };
        list_coordinates.AddRange(batch);
        base_coordinates.AddRange(group);
        Color_Location yellow = new Color_Location(0, base_coordinates);
        Color_Location green = new Color_Location(11, base_coordinates);
        Color_Location blue = new Color_Location(22, base_coordinates);
        Color_Location red = new Color_Location(33, base_coordinates);
    }

    private Dictionary<string, List<Vector3>> paths;

    void Awake()
    {
        paths = new Dictionary<string, List<Vector3>>();
        paths["Red"] = new List<Vector3>
    {
        new Vector3(2.78f, -1.715f, 0f),
        new Vector3(2.32f, -1.715f, 0f),
        new Vector3(2.32f, -1.715f, 0f),
        new Vector3(1.8f, -1.52f, 0f),
        new Vector3(1.42f, -1.93f, 0f),
        new Vector3(1.62f, -2.5f, 0f),
        new Vector3(1.62f, -2.98f, 0f),
        new Vector3(1.44f, -3.5f, 0f),
        new Vector3(0.935f, -3.7f, 0f),
        new Vector3(0.47f, -3.7f, 0f),

        new Vector3(0f, -3.65f, 0f),

        new Vector3(-0.47f, -3.7f, 0f),
        new Vector3(-0.935f, -3.7f, 0f),
        new Vector3(-1.44f, -3.5f, 0f),
        new Vector3(-1.62f, -2.98f, 0f),
        new Vector3(-1.62f, -2.5f, 0f),
        new Vector3(-1.42f, -1.93f, 0f),
        new Vector3(-1.8f, -1.52f, 0f),
        new Vector3(-2.32f, -1.715f, 0f),
        new Vector3(-2.32f, -1.715f, 0f),
        new Vector3(-2.78f, -1.715f, 0f)




        /*
        new Vector3(220, 352, 0), // 2nd step for Yellow
        new Vector3(247, 361, 0),
        new Vector3(273, 360, 0),
        new Vector3(301, 350, 0),
        new Vector3(319, 372, 0),
        new Vector3(309, 401, 0),
        new Vector3(308, 428, 0),
        new Vector3(320, 455, 0),
        new Vector3(346, 466, 0),
        new Vector3(372, 466, 0),
        new Vector3(397, 463, 0), // step before green's hanger
        new Vector3(423, 467, 0),
        new Vector3(447, 466, 0),
        new Vector3(474, 455, 0), // 2nd step for green
        new Vector3(484, 429, 0),
        new Vector3(484, 402, 0),
        new Vector3(474, 371, 0),
        new Vector3(492, 352, 0),
        new Vector3(521, 361, 0),
        new Vector3(546, 362, 0),
        new Vector3(572, 350, 0),
        new Vector3(581, 322, 0),
        new Vector3(581, 295, 0),
        new Vector3(581, 268, 0), // step before red's hanger
        new Vector3(580, 241, 0),
        new Vector3(581, 216, 0),
        new Vector3(572, 186, 0), // 2nd step for red
        new Vector3(545, 175, 0),
        new Vector3(520, 177, 0),
        new Vector3(493, 185, 0),
        new Vector3(474, 166, 0),
        new Vector3(484, 135, 0),
        new Vector3(483, 109, 0),
        new Vector3(474, 83, 0),
        new Vector3(447, 71, 0),
        new Vector3(422, 71, 0),
        new Vector3(396, 74, 0), // step before blue's hanger
        new Vector3(371, 72, 0),
        new Vector3(346, 71, 0),
        new Vector3(319, 82, 0), // 2nd step for blue
        new Vector3(310, 110, 0),
        new Vector3(310, 135, 0),
        new Vector3(321, 166, 0),
        new Vector3(300, 187, 0),
        new Vector3(272, 177, 0),
        new Vector3(247, 177, 0),
        new Vector3(220, 189, 0),
        new Vector3(213, 216, 0),
        new Vector3(213, 243, 0),
        new Vector3(213, 268, 0), // step before yellow's hanger
        new Vector3(212, 295, 0),
        new Vector3(213, 321, 0)
*/
    };

        paths["RedBase"] = new List<Vector3>
        {
        new Vector3(2.59f, -3.63f, 0f),
        new Vector3(2.59f, -2.73f, 0f),
        new Vector3(3.5f, -2.73f, 0f),
        new Vector3(3.5f, -3.63f, 0f)  // Add your path coordinates
    };
        paths["YellowBase"] = new List<Vector3>
        {
        new Vector3(211, 461, 0),
        new Vector3(260, 459, 0),
        new Vector3(210, 412, 0),
        new Vector3(260, 413, 0)  // Add your path coordinates
    };
        paths["BlueBase"] = new List<Vector3>
        {
        new Vector3(535, 461, 0),
        new Vector3(583, 461, 0),
        new Vector3(536, 412, 0),
        new Vector3(584, 411, 0)  // Add your path coordinates
    };
        paths["GreenBase"] = new List<Vector3>
        {
        new Vector3(535, 122, 0),
        new Vector3(584, 120, 0),
        new Vector3(536, 74, 0),
        new Vector3(585, 72, 0)  // Add your path coordinates
    };

        // first coordinates are the first step that the planes take before going on the color board
        paths["YellowHanger"] = new List<Vector3> // filled out
        {
        new Vector3(203, 369, 0),
        new Vector3(257, 268, 0), // RUNWAY TO LEAVE
        new Vector3(281, 268, 0),
        new Vector3(304, 268, 0),
        new Vector3(325, 268, 0),
        new Vector3(346, 267, 0),
        new Vector3(369, 269, 0), //
    };
        paths["GreenHanger"] = new List<Vector3> // filled out
        {
        new Vector3(492, 475, 0),
        new Vector3(397, 416, 0), // RUNWAY TO LEAVE
        new Vector3(396, 393, 0),
        new Vector3(397, 368, 0),
        new Vector3(397, 345, 0),
        new Vector3(397, 323, 0),
        new Vector3(397, 301, 0),
    };
        paths["RedHanger"] = new List<Vector3> // filled
        {
        new Vector3(587, 164, 0),
        new Vector3(535, 268, 0), // RUNWAY TO LEAVE
        new Vector3(512, 268, 0),
        new Vector3(492, 268, 0),
        new Vector3(468, 268, 0),
        new Vector3(446, 268, 0),
        new Vector3(425, 268, 0), //
    };
        paths["BlueHanger"] = new List<Vector3> // filled out
        {
        new Vector3(300, 63, 0),
        new Vector3(397, 119, 0), // RUNWAY TO LEAVE
        new Vector3(397, 141, 0),
        new Vector3(397, 166, 0),
        new Vector3(397, 187, 0),
        new Vector3(397, 210, 0),
        new Vector3(397, 236, 0), //
    };
        Debug.Log("Coordinate paths initialized.");
    }

    public List<Vector3> GetPath(string color)
    {
        return paths.ContainsKey(color) ? paths[color] : new List<Vector3>();
    }
}
