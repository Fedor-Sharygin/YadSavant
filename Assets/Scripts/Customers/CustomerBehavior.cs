using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    private PersonDescription m_TargetDescription;
    public void SetTargetDescription(PersonDescription p_TargetDescription)
    {
        m_TargetDescription = p_TargetDescription;
    }
}
