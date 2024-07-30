using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontKill : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    
    [System.Serializable]
    struct LevelAudio
    {
        public string m_LevelName;
        public AudioClip m_Clip;
    }
    [SerializeField]
    private LevelAudio[] m_AudioPerLevel;
    [SerializeField]
    private AudioSource m_Source;

    private void OnLevelWasLoaded(int _p_Level)
    {
        //if (p_Level >= m_AudioPerLevel.Length)
        //{
        //    return;
        //}

        foreach (var LA in m_AudioPerLevel)
        {
            if (LA.m_LevelName != SceneManager.GetActiveScene().name)
            {
                continue;
            }
            if (LA.m_Clip.name == m_Source.clip.name)
            {
                break;
            }
            m_Source.clip = LA.m_Clip;
            m_Source.loop = true;
            m_Source.Play();
            break;
        }
    }
}
