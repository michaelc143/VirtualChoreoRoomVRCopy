using UnityEngine;

public class PositionRecorder : MonoBehaviour
{
    public void SaveStartPosition()
    {
        CSVManager.AppendToReport(transform.position);
    }

    public void SaveEndPosition()
    {
        CSVManager.AppendToReport(transform.position);
    }
}
