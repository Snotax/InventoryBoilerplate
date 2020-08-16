using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private InventorySlot invSlot;
    private Canvas canvas;
    private CanvasGroup cg;

    void Awake()
    {
        invSlot = GetComponentInParent<InventorySlot>();
        canvas = invSlot.GetComponentInParent<Canvas>();
        cg = invSlot.GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData ev)
    {
        if (invSlot.Item != null && invSlot.Item != null)
        {
            var rt = transform as RectTransform;
            //rt.anchoredPosition += ev.delta / canvas.scaleFactor;
            rt.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData ev)
    {
        transform.localPosition = Vector3.zero;
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.alpha = .6f;
        cg.blocksRaycasts = false;
    }
}
