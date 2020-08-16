using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    UIInventory inv;

    void Awake()
    {
        inv = GetComponentInParent<UIInventory>();
    }

    public void OnDrop(PointerEventData ev)
    {
        var oSlot = ev.pointerDrag.gameObject.GetComponentInParent<InventorySlot>();
        var nSlot = ev.pointerCurrentRaycast.gameObject.GetComponentInParent<InventorySlot>();

        if (oSlot != null && oSlot.Item != null)
        {
            try
            {
                var item = oSlot.Item;
                if (nSlot.Item != null && nSlot.Item.Name.Equals(item.Name))
                {
                    this.inv.Inventory.RemoveItem(item);
                    this.inv.Inventory.IncrementAmount(nSlot.SlotNr);
                }
                else if (nSlot.Item == null)
                {
                    nSlot.Item = item;
                    oSlot.Item = null;

                    item.SlotNr = nSlot.SlotNr;
                }

                inv.RefreshInventory();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
