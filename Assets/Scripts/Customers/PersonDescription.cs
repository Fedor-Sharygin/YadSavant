using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum RaceType
{
    EMPTY_VAL = -1,

    RACE_DWARF,
    RACE_ELF,
    RACE_HUMAN,
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
    CLASS_DRUID,
    CLASS_NOBLE,

    DEFAULT
}
[System.Serializable]
public enum LandType
{
    EMPTY_VAL = -1,

    LAND_FOREST,
    LAND_CITY,
    LAND_OCEAN,
    LAND_FARM,

    DEFAULT
}


[CreateAssetMenu(fileName = "PersonDescription", menuName = "ScriptableObjects/PersonDescription", order = 2)]
public class PersonDescription : ScriptableObject
{
    public RaceType  m_Race;
    public ClassType m_Class;
    public LandType  m_Land;
}
