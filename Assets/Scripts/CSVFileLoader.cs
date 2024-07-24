using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public static class CSVFileLoader
{
    public static void LoadTable(string p_TablePath, System.Action<string> p_FileProcessor, MonoBehaviour p_Caller)
    {
        string CSVFilePath;
        // Determine the correct path based on the platform
        #if UNITY_WEBGL && !UNITY_EDITOR
            CSVFilePath = Path.Combine(Application.streamingAssetsPath, $"{p_TableName}.csv");
        #else
            CSVFilePath = "file://" + Path.Combine(Application.streamingAssetsPath, $"{p_TablePath}.csv");
        #endif

        p_Caller.StartCoroutine(LoadCSVFile(CSVFilePath, p_FileProcessor));
    }

    private static IEnumerator LoadCSVFile(string p_FilePath, System.Action<string> p_FileProcessor)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(p_FilePath))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to load CSV file: " + www.error);
                yield return null;
            }
            else
            {
                string CSVData = www.downloadHandler.text;
                p_FileProcessor?.Invoke(CSVData);
            }
        }
    }
}
