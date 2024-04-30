using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dancer : MonoBehaviour
{
    public List<float[]> dancerPositions;
    public int formationNum;

    //sets the position and stage as manager instantiates
    public void setPositionData(List<float[]> positions)
    {
        dancerPositions = positions;
        formationNum = 1;
        Debug.Log("success! I think");
        // Do something with the data, e.g., assign it to a variable
    }


    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
