using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TextPresenter : MonoBehaviour
{
    [SerializeField]
    private string[] m_Texts;
    private int m_CurTextIdx = 0;
    private int m_StrIdx = 0;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_TextMesh;
    [SerializeField]
    private UnityEvent m_OnTextShownEvent;
    [SerializeField]
    private UnityEvent m_OnLastTextShownEvent;

    public void SetTextArray(string[] p_Texts) => m_Texts = p_Texts;

    public void ShowNextLetter()
    {
        if (m_CurTextIdx >= m_Texts.Length)
        {
            m_OnLastTextShownEvent?.Invoke();
            return;
        }

        m_TextMesh.text += m_Texts[m_CurTextIdx][m_StrIdx++];
        if (m_StrIdx >= m_Texts[m_CurTextIdx].Length)
        {
            m_CurTextIdx++;
            m_StrIdx = 0;
            m_OnTextShownEvent?.Invoke();
        }
    }

    [SerializeField]
    private string m_NextLevelName;
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(m_NextLevelName);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_CurTextIdx < m_Texts.Length)
        {
            m_TextMesh.text = m_Texts[m_CurTextIdx];
            m_CurTextIdx++;
            m_StrIdx = 0;
            m_OnTextShownEvent?.Invoke();
        }
    }
}
