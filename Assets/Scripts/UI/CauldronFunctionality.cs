using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFunctionality : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_IngredientHolders = new Transform[3];
    [SerializeField]
    private ObjectSocket m_DumpTarget;
    [SerializeField]
    private ObjectSocket m_PotionTarget;
    private PotionResult m_Potion = new PotionResult();

    public void DumpIngredients()
    {
        foreach (var IH in m_IngredientHolders)
        {
            if (IH.childCount <= 0)
            {
                continue;
            }

            IH.GetChild(0).GetComponent<DraggableObject>().m_SelfMovement = false;
            m_DumpTarget.ForceStack(IH.GetChild(0));
            IH.GetComponent<DropArea>()?.LetGoOfIngredient();
        }
    }


    [SerializeField]
    private DayManager m_DayManager;
    //private PersonDescription m_Target;
    //public void ReceiveCustomer(PersonDescription p_Target) => m_Target = p_Target;
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
            CurIngred.GetComponent<DraggableObject>().m_SelfMovement = false;
            m_PotionTarget.ForceStack(CurIngred);
            IH.GetComponent<DropArea>()?.LetGoOfIngredient();
            ++idx;
        }

        //not all ingredients were present
        if (idx != m_IngredientHolders.Length)
        {
            return;
        }

        m_DayManager.ReceiveResult(m_Potion.GetPotionTargetScore(m_DayManager.CurrentCustomer));
        m_DayManager.GetNextCustomer();
    }
}
