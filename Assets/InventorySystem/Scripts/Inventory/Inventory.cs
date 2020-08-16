using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Properties")]
    public int Size = 10;

    public event EventHandler OnInventoryChanged;

    /// <summary>
    /// KeyValuePair: InventoryItem, Amount
    /// </summary>
    private Dictionary<InventoryItem, int> inventory = new Dictionary<InventoryItem, int>();


    /// <summary>
    /// Add a new Item to the inventory
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(InventoryItem item)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] = inventory[item] + 1;
        }
        else if (inventory.Count < Size)
        {
            item.SlotNr = getFirstFreeSlotNr();
            inventory.Add(item, 1);
        }
        this.OnInventoryChanged(this, new EventArgs());
    }

    /// <summary>
    /// Increase the amount of 1 inv item
    /// </summary>
    /// <param name="slotNr"></param>
    public void IncrementAmount(int slotNr)
    {
        var ii = GetItem(slotNr);
        inventory[ii.Key] = ii.Value + 1;
        this.OnInventoryChanged(this, new EventArgs());
    }

    /// <summary>
    /// Decrease the amount of 1 inv item
    /// </summary>
    /// <param name="slotNr"></param>
    public void DecreaseAmount(int slotNr)
    {
        var ii = GetItem(slotNr);
        var value = ii.Value - 1;
        if (value == 0)
        {
            RemoveItem(ii.Key);
        }
        else
        {
            inventory[ii.Key] = ii.Value - 1;
        }
        this.OnInventoryChanged(this, new EventArgs());
    }

    /// <summary>
    /// Remove item from inventory
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(InventoryItem item)
    {
        inventory.Remove(item);
        this.OnInventoryChanged(this, new EventArgs());
    }

    /// <summary>
    /// Return an InventoryItem from the innventory by SlotNr.
    /// </summary>
    /// <param name="slotNr"></param>
    /// <returns></returns>
    public KeyValuePair<InventoryItem, int> GetItem(int slotNr)
    {
        return inventory.SingleOrDefault(el => el.Key.SlotNr == slotNr);
    }

    private int getFirstFreeSlotNr()
    {
        for (int i = 0; i <= this.Size; i++)
        {
            if (!this.inventory.Any(s => s.Key.SlotNr == i))
            {
                return i;
            }
        }
        return inventory.Count;
    }
}
