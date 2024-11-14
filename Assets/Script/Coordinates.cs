using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : MonoBehaviour
{
    public ArrayList list_coordinates;
    // Start is called before the first frame update
    void Start(){
        list_coordinates = new ArrayList();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = left click, 1 = right click, 2 = middle click
        {
            Vector2 screenPosition = Input.mousePosition;
            list_coordinates.Add(screenPosition);
            Debug.Log(screenPosition);
        }

        if(Input.GetMouseButtonDown(1)){
            string output = string.Join(", ", list_coordinates.ToArray());
            Debug.Log(output);
        }
        // Debug.Log("HI");
        // Get mouse position in screen coordinates
    }
}
