using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public static class CSVFileLoader
{
    public static IEnumerator LoadTable(string p_TablePath, System.Action<string, object[]> p_FileProcessor, params object[] p_Params)
    {
        string CSVFilePath;
        // Determine the correct path based on the platform
        #if UNITY_WEBGL && !UNITY_EDITOR
            CSVFilePath = Path.Combine(Application.streamingAssetsPath, $"{p_TablePath}.csv");
        #else
            CSVFilePath = "file://" + Path.Combine(Application.streamingAssetsPath, $"{p_TablePath}.csv");
        #endif
        
        using (UnityWebRequest www = UnityWebRequest.Get(CSVFilePath))
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
                p_FileProcessor?.Invoke(CSVData, p_Params);
            }
        }
    }
}
