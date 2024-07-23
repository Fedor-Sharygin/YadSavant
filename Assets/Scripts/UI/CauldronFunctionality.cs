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
            CurIngred.SetParent(m_PotionTarget);
            ++idx;
        }
    }
}
