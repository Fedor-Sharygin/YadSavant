using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] m_Clips;
    [SerializeField]
    private AudioSource m_Source;
    public void PlayRandom()
    {
        PlayClip(Random.Range(0, m_Clips.Length));
    }
    public void PlayClip(int p_Idx)
    {
        if (p_Idx < 0 || p_Idx >= m_Clips.Length)
        {
            return;
        }

        m_Source?.PlayOneShot(m_Clips[p_Idx]);
    }
    public void PlayClip(string p_ClipName)
    {
        p_ClipName = p_ClipName.ToLower();
        foreach (var Clip in m_Clips)
        {
            if (Clip.name.ToLower() != p_ClipName)
            {
                continue;
            }

            m_Source?.PlayOneShot(Clip);
            return;
        }
    }
}
