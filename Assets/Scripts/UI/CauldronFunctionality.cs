using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFunctionality : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_IngredientHolders = new Transform[3];
    [SerializeField]
    private Transform m_DumpTarget;
    [SerializeField]
    private Transform m_PotionTarget;
    [SerializeField]
    private PotionResult m_Potion;

    private void Start()
    {
        CSVFileLoader.LoadTable("Days", OnDayListLoaded, this);
    }
    private void OnDayListLoaded(string p_TableText)
    {
        //Debug.Log($"YEZYEZYEZ - {p_TableText}");
    }

    public void DumpIngredients()
    {
        foreach (var IH in m_IngredientHolders)
        {
            if (IH.childCount <= 0)
            {
                continue;
            }

            IH.GetChild(0).SetParent(m_DumpTarget);
        }
    }


    private PersonDescription m_Target;
    public void ReceiveCustomer(PersonDescription p_Target) => m_Target = p_Target;
    public void BrewPotion()
    {
        int idx = 0;
        foreach (var IH in m_IngredientHolders)
        {
            if (IH.childCount <= 0)
            {
                continue;
            }

            var CurIngred = IH.GetChild(0);
            switch (idx)
            {
                case 0:
                    {
                        m_Potion.m_RaceIngredient  = CurIngred.GetComponent<IngredientContainer>().m_IngredientDescription;
                    }
                    break;
                case 1:
                    {
                        m_Potion.m_ClassIngredient = CurIngred.GetComponent<IngredientContainer>().m_IngredientDescription;
                    }
                    break;
                case 2:
                    {
                        m_Potion.m_LandIngredient  = CurIngred.GetComponent<IngredientContainer>().m_IngredientDescription;
                    }
                    break;

                default: break;
            }
            //CurIngred.SetParent(m_PotionTarget);
            ++idx;
        }

        m_Potion.GetPotionTargetScore(m_Target);
    }

    public int m_CurDay { get; private set; } = 0;
    public void NextDay()
    {
        m_CurDay++;
    }
}
