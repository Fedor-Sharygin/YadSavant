using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    private int m_CurDay = 0;
    private int m_CurCustomer = -1;
    private List<List<PersonDescription>> m_Days = new List<List<PersonDescription>>();
    public PersonDescription CurrentCustomer
    {
        get
        {
            return m_Days[m_CurDay-1][m_CurCustomer];
        }
    }

    private void Awake()
    {
        StartCoroutine(LoadTable());
    }
    private IEnumerator LoadTable()
    {
        yield return CSVFileLoader.LoadTable("Days", OnDayListLoaded, null);
        GetNextCustomer();
        ShowNextCustomer();
    }
    private void OnDayListLoaded(string p_TableText, params object[] _p_Params)
    {
        int CurParsedDay = 0;
        var DaysDescription = p_TableText.Split('\n');
        for (int i = 1; i < DaysDescription.Length; ++i)
        {
            var RowSplit = DaysDescription[i].Split(',');
            if (!string.IsNullOrEmpty(RowSplit[0]) && CurParsedDay != int.Parse(RowSplit[0]))
            {
                CurParsedDay = int.Parse(RowSplit[0]);
                m_Days.Add(new List<PersonDescription>());
            }

            m_Days[CurParsedDay-1].Add(
                new PersonDescription
                {
                    m_Race  =  (RaceType)int.Parse(RowSplit[1]),
                    m_Class = (ClassType)int.Parse(RowSplit[2]),
                    m_Land  =  (LandType)int.Parse(RowSplit[3]),

                    m_TargetRangeMin = int.Parse(RowSplit[4]),
                    m_TargetRangeMax = int.Parse(RowSplit[5])
                }
            );
        }
    }

    [SerializeField]
    private UnityEvent m_NextDayReaction;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_DayText;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_ResultsText;
    private void OnNextDay()
    {
        m_DayText.text = $"Day {m_CurDay}";
        m_ResultsText.text = "";
        for (int i = 0; i < m_Days[m_CurDay-1].Count; ++i)
        {
            m_ResultsText.text += $"{m_Days[m_CurDay-1][i].GetRaceName()} {m_Days[m_CurDay-1][i].GetClassName()} from the land of {m_Days[m_CurDay-1][i].GetLandName()} was {m_Days[m_CurDay-1][i].GetResult(m_CustResult[i])} - {m_Days[m_CurDay-1][i].GetResultState(m_CustResult[i])}\n\n\n\n";
        }

        m_CurDay++;
        m_CurCustomer = 0;
        m_CustResult.Clear();
        m_NextDayReaction?.Invoke();

        if (m_CurDay > m_Days.Count)
        {
            //END THE GAME
        }
    }
    public void GetNextCustomer()
    {
        if (m_CurDay == 0)
        {
            m_CurDay = 1;
        }

        m_CurCustomer++;
        if (m_CurCustomer >= m_Days[m_CurDay-1].Count)
        {
            OnNextDay();
        }
    }
    private List<int> m_CustResult = new List<int>();
    [SerializeField]
    private Timer m_NextOrderTimer;
    public void ReceiveResult(int p_BrewResult)
    {
        m_CustResult.Add(p_BrewResult);
        m_OrderAnimator?.SetTrigger("SlideOut");
        if (m_CurCustomer < m_Days[m_CurDay - 1].Count - 1)
        {
            m_NextOrderTimer?.ResetTimer();
            m_NextOrderTimer?.Play();
        }
    }

    [SerializeField]
    private TMPro.TextMeshProUGUI m_OrderText;
    [SerializeField]
    private Animator m_OrderAnimator;
    public void ShowNextCustomer()
    {
        m_OrderText.text = $"{CurrentCustomer.GetRaceName()} {CurrentCustomer.GetClassName()} {CurrentCustomer.GetLandName()}";
        m_OrderAnimator?.SetTrigger("SlideIn");
    }
}
