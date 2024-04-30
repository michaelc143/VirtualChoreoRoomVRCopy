using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Collections.Generic;

public class dancer_manager : MonoBehaviour
{
    public GameObject originalModel; //all dancers cloned from this model
    public GameObject[] dancerArray;

    public int formationNum; //current formation number we are on
    public int totalNumFormations; //total number of formations

    public string folderPath = "dancer_csv_files"; // Path to the folder containing CSV files

    // Start is called before the first frame update
    // will load in the dancers
    void Start()
    {

        // Get all CSV files in the folder
        string[] csvFiles = Directory.GetFiles(folderPath, "*.csv");
        dancerArray = new GameObject[csvFiles.Length];

        // Loop through each dancer CSV file
        int i = 0;
        foreach (string filePath in csvFiles)
        {
            // Read the file line by line
            StreamReader reader = new StreamReader(filePath);
            List<string[]> data = new List<string[]>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                data.Add(values);
            }

            reader.Close();

            //get first position for dancer
            Vector3 position = new Vector3(float.Parse(data[0][0]), float.Parse(data[0][1]), float.Parse(data[0][2]));

            // Now 'data' contains the CSV content of the current file
            // each row is a formation postition
            // TODO: save these values into the dancer 
             List<float[]> dancerPositions = new List<float[]>();
             totalNumFormations = data.Count;
            foreach (string[] row in data)
            {
                float[] curPosition = new float[3];
                curPosition[0] = float.Parse(row[0]);
                curPosition[1] = float.Parse(row[1]);
                curPosition[2] = float.Parse(row[2]);

                dancerPositions.Add(curPosition);

                // // print row values
                // foreach (string value in row)
                // {
                //     Debug.Log(value);
                // }
            }

            //instantiate dancer object
            GameObject dupDancer = Instantiate(originalModel, position, Quaternion.identity);

            //Get script of dancer, pass down data
            dancer script = dupDancer.GetComponent<dancer>();
            if (script != null)
            {
                // Call the public method to pass values
                script.setPositionData(dancerPositions);
                //Debug.Log("The dancer script was found!!!");
            }
            else
            {
                Debug.LogError("MyScript component not found on duplicate ");
            }

            //add dancer to dancer array
            dancerArray[i] = dupDancer;
            i += 1;

        }

        formationNum = 0;
        
    }

    public void nextFormation() {
        Debug.Log("going to next");
        int stage = formationNum + 1;

        if (stage <= totalNumFormations) {
            foreach (GameObject dancer in dancerArray) {
                dancer script = dancer.GetComponent<dancer>();
                script.goToNext(stage);
            }
            formationNum = stage;

        }
        
    }

    public void prevFormation() {
        Debug.Log("going to prev");
        int stage = formationNum - 1;

        if (stage >= 0) {
            foreach (GameObject dancer in dancerArray) {
                dancer script = dancer.GetComponent<dancer>();
                script.goToPrev(stage);
            }
            formationNum = stage;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
