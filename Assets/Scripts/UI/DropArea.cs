using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropArea : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{
    private bool m_PointerIsIn = false;
    private bool m_AreaFull = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_PointerIsIn = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        m_PointerIsIn = false;
    }
    public void IngredientReleased(Transform p_IngredientTransform)
    {
        if (!m_PointerIsIn || m_AreaFull)
        {
            return;
        }

        p_IngredientTransform.SetParent(transform);
        m_AreaFull = true;
        p_IngredientTransform.GetComponent<Selectable>().interactable = false;
        p_IngredientTransform.GetComponent<DraggableObject>().DisableDrag();
    }
}
