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
        formationNum = 0;
        // Do something with the data, e.g., assign it to a variable
    }

    public void goToNext(int stage) {

        Debug.Log("new stage : " + stage);

        //make sure you don't exceed formation num
        if (stage <= dancerPositions.Count) {

            //get new and old positions
            Vector3 newPosition = new Vector3(dancerPositions[stage][0], dancerPositions[stage][1], dancerPositions[stage][2]);
            //Vector3 oldPosition = new Vector3(dancerPositions[stage-1][0], dancerPositions[stage-1][1], dancerPositions[stage-1][2]);

            float speed = 5f;

            while (transform.position != newPosition) {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

            }
            

            formationNum = stage;

        }
      

        
    }

    public void goToPrev(int stage) {

        Debug.Log("new stage : " + stage);

        //make sure you don't exceed formation num
        if (stage >= 0) {

            //get new and old positions
            Vector3 newPosition = new Vector3(dancerPositions[stage][0], dancerPositions[stage][1], dancerPositions[stage][2]);
            //Vector3 oldPosition = new Vector3(dancerPositions[stage-1][0], dancerPositions[stage-1][1], dancerPositions[stage-1][2]);

            float speed = 5f;

            while (transform.position != newPosition) {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

            }
            

            formationNum = stage;

        }
      

        
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
