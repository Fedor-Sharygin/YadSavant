using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        CSVFileLoader.LoadTable("Days", OnDayListLoaded, null);
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

            m_Days[CurParsedDay - 1].Add(
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
    private void OnNextDay()
    {
        m_CurDay++;
        m_CurCustomer = 0;
        m_NextDayReaction?.Invoke();

        if (m_CurDay > m_Days.Capacity)
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
        if (m_CurCustomer >= m_Days[m_CurDay-1].Capacity)
        {
            OnNextDay();
        }
    }
}
