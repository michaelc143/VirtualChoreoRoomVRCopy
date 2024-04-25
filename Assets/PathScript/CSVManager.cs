using System.IO;
using UnityEngine;

public static class CSVManager
{
    private static string reportDirectoryName = "CSV";
    private static string reportFileName = "positions.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[3] {
        "PositionX",
        "PositionY",
        "PositionZ"
    };

    public static void AppendToReport(Vector3 position)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = position.x + reportSeparator + position.y + reportSeparator + position.z;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine(string.Join(reportSeparator, reportHeaders));
            }
        }
    }

    public static string GetDirectoryPath()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    public static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }
}
