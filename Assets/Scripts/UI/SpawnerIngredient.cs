using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerIngredient : MonoBehaviour
{
    [SerializeField]
    private GameObject m_IngredientPrefab;
    public void OnIngredientReleased(Transform _p_IngredientTransform)
    {
        if (transform.childCount > 0)
        {
            return;
        }

        var Ingred = GameObject.Instantiate(m_IngredientPrefab, transform);
    }

    public void EnableIngredientDrag()  => transform.GetChild(0).GetComponent<DraggableObject>().EnableDrag();
    public void DisableIngredientDrag() => transform.GetChild(0).GetComponent<DraggableObject>().DisableDrag();
}
