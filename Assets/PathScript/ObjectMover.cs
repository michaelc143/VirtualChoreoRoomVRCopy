using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    private int currentPosition = 0;

    void Start()
    {
        LoadPositions();
    }

    void LoadPositions()
    {
        string[] lines = File.ReadAllLines(CSVManager.GetFilePath());
        for (int i = 1; i < lines.Length; i++) // Start at 1 to skip headers
        {
            string[] values = lines[i].Split(',');
            Vector3 position = new Vector3(
                float.Parse(values[0]),
                float.Parse(values[1]),
                float.Parse(values[2]));
            positions.Add(position);
        }
    }

    public void MoveToNextPosition()
    {
        if (currentPosition < positions.Count)
        {
            StartCoroutine(MoveObject(positions[currentPosition]));
            currentPosition++;
        }
    }

    IEnumerator MoveObject(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            yield return null;
        }
    }
}
