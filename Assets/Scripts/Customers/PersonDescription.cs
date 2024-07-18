using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum RaceType
{
    DWARF,
    ELF,
    HUMAN,
    ORC,
    CELESTIAL,

    DEFAULT
}
[System.Serializable]
public enum ClassType
{
    MAGE,
    WARRIOR,
    DRUID,
    NOBLE,

    DEFAULT
}
[System.Serializable]
public enum LandType
{
    FOREST,
    CITY,
    OCEAN,
    FARM,

    DEFAULT
}


[CreateAssetMenu(fileName = "PersonDescription", menuName = "ScriptableObjects/PersonDescription", order = 2)]
public class PersonDescription : ScriptableObject
{
    public RaceType m_Race;
    public ClassType m_Class;
    public LandType m_Land;
}
