using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionResult
{
    public IngredientDescriptor m_RaceIngredient;
    public IngredientDescriptor m_ClassIngredient;
    public IngredientDescriptor m_LandIngredient;


    public int GetPotionTargetScore(PersonDescription p_TargetDescription) =>
        (m_RaceIngredient  == null ? 0 : m_RaceIngredient .GetEffectivenessScore(p_TargetDescription.m_Race)) +
        (m_ClassIngredient == null ? 0 : m_ClassIngredient.GetEffectivenessScore(p_TargetDescription.m_Class)) +
        (m_LandIngredient  == null ? 0 : m_LandIngredient .GetEffectivenessScore(p_TargetDescription.m_Land));

    public void ClearPotion()
    {
        m_RaceIngredient  = null;
        m_ClassIngredient = null;
        m_LandIngredient  = null;
    }
}
