using UnityEngine;


public class GlobalUtilities
{
    private static float m_MaxFrameTime = .16f;
    public static float DeltaTime
    {
        get
        {
            return Mathf.Min(Time.deltaTime, m_MaxFrameTime);
        }
    }
}
