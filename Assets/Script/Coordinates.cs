
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Coordinate : MonoBehaviour
{
    public bool canUpdate = false;
    public List<Vector3> mainPathsOriginal;
    public List<Vector3> RedHanger;

    // Start is called before the first frame update
    void Start()
    {
        mainPathsOriginal = new List<Vector3> {

        new Vector3(3.425f, 0f, 0f),

        new Vector3(3.425f, -0.48f, 0f),
        new Vector3(3.425f, -0.98f, 0f),
        new Vector3(3.285f, -1.52f, 0f),
        new Vector3(2.785f, -1.725f, 0f),
        new Vector3(2.32f, -1.725f, 0f),
        new Vector3(1.8f, -1.52f, 0f),
        new Vector3(1.42f, -1.935f, 0f),
        new Vector3(1.62f, -2.5f, 0f),
        new Vector3(1.62f, -2.98f, 0f),
        new Vector3(1.43f, -3.5f, 0f),
        new Vector3(0.935f, -3.7f, 0f),
        new Vector3(0.47f, -3.7f, 0f),

        new Vector3(0f, -3.65f, 0f),

        new Vector3(-0.47f, -3.7f, 0f),
        new Vector3(-0.935f, -3.7f, 0f),
        new Vector3(-1.43f, -3.5f, 0f),
        new Vector3(-1.62f, -2.98f, 0f),
        new Vector3(-1.62f, -2.5f, 0f),
        new Vector3(-1.42f, -1.935f, 0f),
        new Vector3(-1.8f, -1.52f, 0f),
        new Vector3(-2.32f, -1.725f, 0f),
        new Vector3(-2.785f, -1.725f, 0f),
        new Vector3(-3.285f, -1.52f, 0f),
        new Vector3(-3.425f, -0.98f, 0f),
        new Vector3(-3.425f, -0.48f, 0f),


        new Vector3(-3.425f, 0f, 0f),

        new Vector3(-3.425f, 0.48f, 0f),
        new Vector3(-3.425f, 0.98f, 0f),
        new Vector3(-3.285f, 1.52f, 0f),
        new Vector3(-2.785f, 1.725f, 0f),
        new Vector3(-2.32f, 1.725f, 0f),
        new Vector3(-1.8f, 1.52f, 0f),
        new Vector3(-1.42f, 1.935f, 0f),
        new Vector3(-1.62f, 2.5f, 0f),
        new Vector3(-1.62f, 2.98f, 0f),
        new Vector3(-1.43f, 3.5f, 0f),
        new Vector3(-0.935f, 3.7f, 0f),
        new Vector3(-0.47f, 3.7f, 0f),

        new Vector3(0f, 3.65f, 0f),

        new Vector3(0.47f, 3.7f, 0f),
        new Vector3(0.935f, 3.7f, 0f),
        new Vector3(1.43f, 3.5f, 0f),
        new Vector3(1.62f, 2.98f, 0f),
        new Vector3(1.62f, 2.5f, 0f),
        new Vector3(1.42f, 1.935f, 0f),
        new Vector3(1.8f, 1.52f, 0f),
        new Vector3(2.32f, 1.725f, 0f),
        new Vector3(2.785f, 1.725f, 0f),
        new Vector3(3.285f, 1.52f, 0f),
        new Vector3(3.425f, 0.98f, 0f),
        new Vector3(3.425f, 0.48f, 0f),


        };



        /* old coordinates v.2
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
    new Vector3(-2.78f, -1.715f, 0f),
    new Vector3(-2.81f, -1.715f, 0f),
    new Vector3(-3.33f, -1.52f, 0f),
    new Vector3(-3.46f, -0.48f, 0f),
    new Vector3(-3.46f, -1f, 0f),


    new Vector3(-3.46f, 0f, 0f),

    new Vector3(-3.46f, 0.48f, 0f),
    new Vector3(-3.46f, 1f, 0f),
    new Vector3(-3.33f, 1.52f, 0f),
    new Vector3(-2.81f, 1.715f, 0f),
    new Vector3(-2.78f, 1.715f, 0f),
    new Vector3(-2.32f, 1.715f, 0f),
    new Vector3(-2.32f, 1.715f, 0f),
    new Vector3(-1.8f, 1.52f, 0f),
    new Vector3(-1.42f, 1.93f, 0f),
    new Vector3(-1.62f, 2.5f, 0f),
    new Vector3(-1.62f, 2.98f, 0f),
    new Vector3(-1.44f, 3.5f, 0f),
    new Vector3(-0.935f, 3.7f, 0f),
    new Vector3(-0.47f, 3.7f, 0f),


    new Vector3(0f, 3.65f, 0f),

    new Vector3(0.47f, 3.7f, 0f),
    new Vector3(0.935f, 3.7f, 0f),
    new Vector3(1.44f, 3.5f, 0f),
    new Vector3(1.62f, 2.98f, 0f),
    new Vector3(1.62f, 2.5f, 0f),
    new Vector3(1.42f, 1.93f, 0f),
    new Vector3(1.8f, 1.52f, 0f),
    new Vector3(2.32f, 1.715f, 0f),
    new Vector3(2.32f, 1.715f, 0f),
    new Vector3(2.78f, 1.715f, 0f),
    new Vector3(2.81f, 1.715f, 0f),
    new Vector3(3.33f, 1.52f, 0f),
    new Vector3(3.46f, 1f, 0f),
    new Vector3(3.46f, 0.48f, 0f),


    new Vector3(3.46f, 0f, 0f),

    new Vector3(3.46f, -0.48f, 0f),
    new Vector3(3.46f, -1f, 0f),
    new Vector3(3.33f, -1.52f, 0f),
    new Vector3(2.81f, -1.715f, 0f),
    new Vector3(2.78f, -1.715f, 0f),
    new Vector3(2.32f, -1.715f, 0f),
    new Vector3(2.32f, -1.715f, 0f),
    new Vector3(1.8f, -1.52f, 0f),
    new Vector3(1.42f, -1.93f, 0f),
    new Vector3(1.62f, -2.5f, 0f),
    new Vector3(1.62f, -2.98f, 0f),
    new Vector3(1.44f, -3.5f, 0f),
    new Vector3(0.935f, -3.7f, 0f),
    new Vector3(0.47f, -3.7f, 0f)
*/
        canUpdate = true;
    }

    private Dictionary<string, List<Vector3>> paths = new Dictionary<string, List<Vector3>>();

    void Awake()
    {

        /*
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
        new Vector3(-2.78f, -1.715f, 0f),
        new Vector3(-2.81f, -1.715f, 0f),
        new Vector3(-3.33f, -1.52f, 0f),
        new Vector3(-3.46f, -1f, 0f),
        new Vector3(-3.46f, -0.48f, 0f),


        new Vector3(-3.46f, 0f, 0f),

        new Vector3(-3.46f, 0.48f, 0f),
        new Vector3(-3.46f, 1f, 0f),
        new Vector3(-3.33f, 1.52f, 0f),
        new Vector3(-2.81f, 1.715f, 0f),
        new Vector3(-2.78f, 1.715f, 0f),
        new Vector3(-2.32f, 1.715f, 0f),
        new Vector3(-2.32f, 1.715f, 0f),
        new Vector3(-1.8f, 1.52f, 0f),
        new Vector3(-1.42f, 1.93f, 0f),
        new Vector3(-1.62f, 2.5f, 0f),
        new Vector3(-1.62f, 2.98f, 0f),
        new Vector3(-1.44f, 3.5f, 0f),
        new Vector3(-0.935f, 3.7f, 0f),
        new Vector3(-0.47f, 3.7f, 0f),


        new Vector3(0f, 3.65f, 0f),
        new Vector3(0.47f, 3.7f, 0f),
        new Vector3(0.935f, 3.7f, 0f),
        new Vector3(1.44f, 3.5f, 0f),
        new Vector3(1.62f, 2.98f, 0f),
        new Vector3(1.62f, 2.5f, 0f),
        new Vector3(1.42f, 1.93f, 0f),
        new Vector3(1.8f, 1.52f, 0f),
        new Vector3(2.32f, 1.715f, 0f),
        new Vector3(2.32f, 1.715f, 0f),
        new Vector3(2.78f, 1.715f, 0f),
        new Vector3(2.81f, 1.715f, 0f),
        new Vector3(3.33f, 1.52f, 0f),
        new Vector3(3.46f, 1f, 0f),
        new Vector3(3.46f, 0.48f, 0f),

        new Vector3(3.46f, 0f, 0f),
        new Vector3(3.46f, -0.48f, 0f),
        new Vector3(3.46f, -1f, 0f),
        new Vector3(3.33f, -1.52f, 0f),
        new Vector3(2.81f, -1.715f, 0f),
        new Vector3(2.78f, -1.715f, 0f),
        new Vector3(2.32f, -1.715f, 0f),
        new Vector3(2.32f, -1.715f, 0f),
        new Vector3(1.8f, -1.52f, 0f),
        new Vector3(1.42f, -1.93f, 0f),
        new Vector3(1.62f, -2.5f, 0f),
        new Vector3(1.62f, -2.98f, 0f),
        new Vector3(1.44f, -3.5f, 0f),
        new Vector3(0.935f, -3.7f, 0f),
        new Vector3(0.47f, -3.7f, 0f)


        // old coordinates
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

    };
*/
        paths["RedBase"] = new List<Vector3>
        {
        new Vector3(2.59f, -3.63f, 0f),
        new Vector3(2.59f, -2.73f, 0f),
        new Vector3(3.5f, -2.73f, 0f),
        new Vector3(3.5f, -3.63f, 0f),  // Add your path coordinates
        new Vector3(3.7f, -1.9f, 0f)
    };
        paths["YellowBase"] = new List<Vector3>
        {
        new Vector3(-2.59f, 3.63f, 0f),
        new Vector3(-2.59f, 2.73f, 0f),
        new Vector3(-3.5f, 2.73f, 0f),
        new Vector3(-3.5f, 3.63f, 0f),  // Add your path coordinates
        new Vector3(-3.7f, 1.9f, 0f)

        // new Vector3(211, 461, 0),
        // new Vector3(260, 459, 0),
        // new Vector3(210, 412, 0),
        // new Vector3(260, 413, 0)  // Add your path coordinates
    };
        paths["BlueBase"] = new List<Vector3>
        {
        new Vector3(-2.59f, -3.63f, 0f),
        new Vector3(-2.59f, -2.73f, 0f),
        new Vector3(-3.5f, -2.73f, 0f),
        new Vector3(-3.5f, -3.63f, 0f),  // Add your path coordinates
        new Vector3(-1.8f,-3.9f,  0f)


        // new Vector3(535, 461, 0),
        // new Vector3(583, 461, 0),
        // new Vector3(536, 412, 0),
        // new Vector3(584, 411, 0)  // Add your path coordinates
    };
        paths["GreenBase"] = new List<Vector3>
        {
        new Vector3(2.59f, 3.63f, 0f),
        new Vector3(2.59f, 2.73f, 0f),
        new Vector3(3.5f, 2.73f, 0f),
        new Vector3(3.5f, 3.63f, 0f),  // Add your path coordinates
        new Vector3(1.8f, 3.9f, 0f)
    
        // new Vector3(535, 122, 0),
        // new Vector3(584, 120, 0),
        // new Vector3(536, 74, 0),
        // new Vector3(585, 72, 0)  // Add your path coordinates
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
        RedHanger = new List<Vector3> // filled
        {
        new Vector3(2.58f, 0.01f, 0),
        new Vector3(2.17f, 0.01f, 0), // RUNWAY TO LEAVE
        new Vector3(1.77f, 0.01f, 0),
        new Vector3(1.34f, 0.01f, 0),
        new Vector3(0.94f, 0.01f, 0),
        new Vector3(0.5f, 0.01f, 0),
        new Vector3(-8.72f, 5.59f, 0)
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

