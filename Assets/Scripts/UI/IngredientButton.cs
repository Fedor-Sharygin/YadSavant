using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    private Button m_Button;
    private void Awake()
    {
        m_Button = GetComponent<Button>();
    }
}
