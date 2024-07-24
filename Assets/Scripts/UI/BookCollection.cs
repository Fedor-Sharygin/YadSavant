using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollection : MonoBehaviour
{
    public void OpenBook()
    {

    }
    public void CloseBook()
    {

    }

    private int m_CurPage = 0;
    private int m_MaxPageCount = 0;
    private List<string> m_Pages = new List<string>();
    private void Awake()
    {
        CSVFileLoader.LoadTable("Descriptions/Ingredients", OnTableLoaded, this);
        CSVFileLoader.LoadTable("Descriptions/Races",       OnTableLoaded, this);
        CSVFileLoader.LoadTable("Descriptions/Classes",     OnTableLoaded, this);
        CSVFileLoader.LoadTable("Descriptions/Lands",       OnTableLoaded, this);
    }
    private void OnTableLoaded(string p_Table)
    {
        var RowsList = p_Table.Split('\n');
        m_MaxPageCount += RowsList.Length;

        m_Pages.Add(RowsList[0].Split(',')[0]);
        for (int i = 1; i < RowsList.Length; ++i)
        {
            var RowSplit = RowsList[i].Split(',');
            m_Pages.Add(RowSplit[0] + '\n' + RowSplit[1].Replace("\"", ""));
        }
    }


    public void TurnPage(int p_TurnedPages)
    {
        m_CurPage += p_TurnedPages;
        m_CurPage = Mathf.Max(m_CurPage, 0);
        m_CurPage = Mathf.Min(m_CurPage, m_MaxPageCount - 1);
    }
}
