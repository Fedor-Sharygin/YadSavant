using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum IngredientType
{
    INGREDIENT_MUDROOT,
    INGREDIENT_FEUIL_PLANT,
    INGREDIENT_CYANEM_NUT,
    INGREDIENT_DROGGART,
    INGREDIENT_DREADBELL,

    DEFAULT
}

[CreateAssetMenu(fileName = "IngredientDescriptor", menuName = "ScriptableObjects/IngredientDescriptor", order = 1)]
public class IngredientDescriptor : ScriptableObject
{
    private static int[] m_EffectivenessScore = { -4, -2, -1, 0, 1, 3, 6 };

    public IngredientType m_IngredientType;

    public string m_IngredientName;
    public Sprite m_IngredientSprite;

    [Space(10)]
    public RaceType[]  m_RaceEffectiveness  = new RaceType[7];
    public ClassType[] m_ClassEffectiveness = new ClassType[7];
    public LandType[]  m_LandEffectiveness  = new LandType[7];


    public int GetEffectivenessScore(RaceType p_Race)
    {
        for (int i = 0; i < m_RaceEffectiveness.Length; ++i)
        {
            if (m_RaceEffectiveness[i] != p_Race)
            {
                continue;
            }

            return m_EffectivenessScore[i];
        }

        return 0;
    }
    public int GetEffectivenessScore(ClassType p_Class)
    {
        for (int i = 0; i < m_ClassEffectiveness.Length; ++i)
        {
            if (m_ClassEffectiveness[i] != p_Class)
            {
                continue;
            }

            return m_EffectivenessScore[i];
        }

        return 0;
    }
    public int GetEffectivenessScore(LandType p_Land)
    {
        for (int i = 0; i < m_LandEffectiveness.Length; ++i)
        {
            if (m_LandEffectiveness[i] != p_Land)
            {
                continue;
            }

            return m_EffectivenessScore[i];
        }

        return 0;
    }
}
