using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator m_CreditsAnimator;
    private bool m_CreditsShown = false;
    private bool m_AnimationPlaying = false;
    private int m_FuncCallVal = 0;
    public void SwitchAnimationPlaying()
    {
        m_FuncCallVal++;
        if (m_FuncCallVal == 1)
        {
            return;
        }
        m_AnimationPlaying = !m_AnimationPlaying;
        m_FuncCallVal = 0;
    }
    public void SwitchCreditsState()
    {
        if (m_CreditsAnimator == null || m_AnimationPlaying)
        {
            return;
        }

        switch(m_CreditsShown)
        {
            case false:
                {
                    m_CreditsAnimator.SetTrigger("SlideIn");
                    m_CreditsShown = true;
                    m_AnimationPlaying = true;
                }
                break;
            case true:
                {
                    m_CreditsAnimator.SetTrigger("SlideOut");
                    m_CreditsShown = false;
                    m_AnimationPlaying = true;
                }
                break;
        }
    }

    [SerializeField]
    private string m_GameLevelName = "";
    public void LoadGameLevel()
    {
        SceneManager.LoadScene(m_GameLevelName);
    }
}
