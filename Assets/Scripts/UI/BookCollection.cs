using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCollection : MonoBehaviour
{
    public void OpenBook()
    {

    }
    public void CloseBook()
    {

    }

    private int m_CurPage = -1;
    private int m_MaxPageCount = 0;
    private List<string> m_Pages   = new List<string>();
    private List<string> m_Ingreds = new List<string>();
    private List<string> m_Races   = new List<string>();
    private List<string> m_Classes = new List<string>();
    private List<string> m_Lands   = new List<string>();
    private void Awake()
    {
        StartCoroutine(LoadPages());
    }
    private IEnumerator LoadPages()
    {
        Coroutine IngLoader = StartCoroutine(CSVFileLoader.LoadTable("Descriptions/Ingredients", OnTableLoaded, m_Ingreds));
        Coroutine RacLoader = StartCoroutine(CSVFileLoader.LoadTable("Descriptions/Races",       OnTableLoaded, m_Races));
        Coroutine ClsLoader = StartCoroutine(CSVFileLoader.LoadTable("Descriptions/Classes",     OnTableLoaded, m_Classes));
        Coroutine LndLoader = StartCoroutine(CSVFileLoader.LoadTable("Descriptions/Lands",       OnTableLoaded, m_Lands));

        yield return IngLoader;
        yield return RacLoader;
        yield return ClsLoader;
        yield return LndLoader;

        m_Pages.AddRange(m_Ingreds);
        m_Pages.AddRange(m_Races);
        m_Pages.AddRange(m_Classes);
        m_Pages.AddRange(m_Lands);

        TurnPage(1);
    }
    private void OnTableLoaded(string p_Table, params object[] p_Array)
    {
        List<string> CurPageList = (List<string>)p_Array[0];
        var RowsList = p_Table.Split('\n');
        m_MaxPageCount += RowsList.Length;

        CurPageList.Add($"<size=60><b><align=center>{RowsList[0].Split(';')[0]}");
        for (int i = 1; i < RowsList.Length; ++i)
        {
            var RowSplit = RowsList[i].Split(';');
            CurPageList.Add($"<size=48><align=center><b>{RowSplit[0].ToUpper()}</b></align></size>\n\n\n\n\n<align=justified>{RowSplit[1].Replace("\"", "")}");
        }
    }


    [SerializeField]
    private TMPro.TextMeshProUGUI m_PageText;
    [SerializeField]
    private Image m_PageImage;
    [SerializeField]
    private List<Sprite> m_PageSprites;
    public void TurnPage(int p_TurnedPages)
    {
        int PrevPage = m_CurPage;
        m_CurPage += p_TurnedPages;
        m_CurPage = Mathf.Max(m_CurPage, 0);
        m_CurPage = Mathf.Min(m_CurPage, m_MaxPageCount - 1);

        if (PrevPage == m_CurPage)
        {
            return;
        }

        if (m_PageText != null)
        {
            m_PageText.text = m_Pages[m_CurPage];
        }
        if (m_PageImage != null)
        {
            m_PageImage.sprite = m_PageSprites[m_CurPage];
        }
    }
}
