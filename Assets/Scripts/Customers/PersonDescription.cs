using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum RaceType
{
    EMPTY_VAL = -1,

    RACE_HUMAN,
    RACE_DWARF,
    RACE_ELF,
    RACE_ORC,
    RACE_CELESTIAL,

    DEFAULT
}
[System.Serializable]
public enum ClassType
{
    EMPTY_VAL = -1,

    CLASS_MAGE,
    CLASS_WARRIOR,
    CLASS_THIEF,
    CLASS_NOBLE,

    DEFAULT
}
[System.Serializable]
public enum LandType
{
    EMPTY_VAL = -1,

    LAND_KAMNIA,
    LAND_FEUIVETER,
    LAND_VARVORGRUD,
    LAND_BOGRAVEN,

    DEFAULT
}


//[CreateAssetMenu(fileName = "PersonDescription", menuName = "ScriptableObjects/PersonDescription", order = 2)]
public struct PersonDescription
{
    public RaceType  m_Race;
    public ClassType m_Class;
    public LandType  m_Land;

    public int m_TargetRangeMin;
    public int m_TargetRangeMax;

    public string GetRaceName()
    {
        switch(m_Race)
        {
            case RaceType.RACE_HUMAN:
                {
                    return "Human";
                }
            case RaceType.RACE_DWARF:
                {
                    return "Dwarven";
                }
            case RaceType.RACE_ELF:
                {
                    return "Elven";
                }
            case RaceType.RACE_ORC:
                {
                    return "Orcish";
                }
            case RaceType.RACE_CELESTIAL:
                {
                    return "Celestial";
                }


            default:
                {
                    return "";
                }
        }
    }
    public string GetClassName()
    {
        switch (m_Class)
        {
            case ClassType.CLASS_MAGE:
                {
                    return "Mage";
                }
            case ClassType.CLASS_WARRIOR:
                {
                    return "Warrior";
                }
            case ClassType.CLASS_THIEF:
                {
                    return "Thief";
                }
            case ClassType.CLASS_NOBLE:
                {
                    return "Noble";
                }


            default:
                {
                    return "";
                }
        }
    }
    public string GetLandName()
    {
        switch (m_Land)
        {
            case LandType.LAND_KAMNIA:
                {
                    return "Kamnia";
                }
            case LandType.LAND_FEUIVETER:
                {
                    return "Feuiveter";
                }
            case LandType.LAND_VARVORGRUD:
                {
                    return "Varvorgrud";
                }
            case LandType.LAND_BOGRAVEN:
                {
                    return "Bograven";
                }


            default:
                {
                    return "";
                }
        }
    }
    public string GetResult(int p_PoisonScore)
    {
        if (p_PoisonScore < -8)
        {
            return "rejuvenated";
        }
        else if (p_PoisonScore < -4)
        {
            return "strengthened";
        }
        else if (p_PoisonScore < 0)
        {
            return "pleasantly surprised";
        }
        else if (p_PoisonScore < 3)
        {
            return "unaffected";
        }
        else if (p_PoisonScore < 7)
        {
            return "left with an upset stomach";
        }
        else if (p_PoisonScore < 12)
        {
            return "left dead";
        }
        else if (p_PoisonScore < 15)
        {
            return "unrecognizable";
        }
        else
        {
            return "melted to a puddle";
        }
    }
    public string GetResultState(int p_PoisonScore) => (p_PoisonScore < m_TargetRangeMin || p_PoisonScore > m_TargetRangeMax) ? "Failed" : "Success";
    public bool GetResultSuccess(int p_PoisonScore) => !(p_PoisonScore < m_TargetRangeMin || p_PoisonScore > m_TargetRangeMax);
}
