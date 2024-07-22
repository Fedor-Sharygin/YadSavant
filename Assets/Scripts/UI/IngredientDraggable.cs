using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientDraggable : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("Movement Properties")]
    [SerializeField]
    private float m_MouseSpeedLimit = 50;
    [SerializeField]
    private float m_ReturnSpeedLimit = 50;

    private bool m_IsDragging = false;
    private Vector3 m_MouseOffset;

    private void Update()
    {
        ClampPosition();

        if (m_IsDragging)
        {
            Vector2 TargetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_MouseOffset;
            Vector2 Direction = (TargetPos - (Vector2)transform.position).normalized;
            Vector2 Velocity = Direction * Mathf.Min(m_MouseSpeedLimit, Vector2.Distance(transform.position, TargetPos) / GlobalUtilities.DeltaTime);
            transform.Translate(Velocity * GlobalUtilities.DeltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, m_ReturnSpeedLimit * GlobalUtilities.DeltaTime);
        }
    }

    private void ClampPosition()
    {
        Vector2 ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log($"Bounds - {ScreenBounds}");
        Vector3 ClampedPos = transform.position;
        ClampedPos.x = Mathf.Clamp(ClampedPos.x, -ScreenBounds.x, ScreenBounds.x);
        ClampedPos.y = Mathf.Clamp(ClampedPos.y, -ScreenBounds.y, ScreenBounds.y);
        transform.position = new Vector3(ClampedPos.x, ClampedPos.y, 0);
        Debug.Log($"Pos - {ClampedPos}");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_MouseOffset = MousePos - (Vector2)transform.position;
        //m_MouseOffset = Input.mousePosition - transform.position;
        m_IsDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ////throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_IsDragging = false;
    }

}
