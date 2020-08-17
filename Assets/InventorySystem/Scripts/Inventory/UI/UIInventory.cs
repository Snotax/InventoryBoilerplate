using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIInventory class
/// Author: Yannick Laubscher
/// Date: 16.08.2020
/// </summary>
public class UIInventory : MonoBehaviour
{

    [Header("References")]
    [Tooltip("Which inventory should be managed here")]
    public Inventory Inventory;

    [Header("UI")]
    [Tooltip("Prefab for the inventory slot")]
    public GameObject InventorySlotPrefab;
    [Tooltip("Where should the inventory be populated")]
    public GameObject InventoryParent;

    ///Reference to all inventory Slots of this inventory
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();


    private void Awake()
    {
        this.InitializeInventory();
        Inventory.OnInventoryChanged += RefreshInventory;
    }

    /// <summary>
    /// Create InventorySlot prefabs for each possible Inventory Slot
    /// </summary>
    private void InitializeInventory()
    {
        for (var i = 0; i < Inventory.Size; i++)
        {
            var obj = GameObject.Instantiate(InventorySlotPrefab, InventoryParent.transform);
            // Set slot number
            var invSlot = obj.GetComponent<InventorySlot>();
            invSlot.SlotNr = i;
            invSlot.Item = null;
            invSlot.Inventory = this.Inventory;
            inventorySlots.Add(invSlot);
        }
    }

    public void RefreshInventory(object sender, EventArgs ev)
    {
        this.RefreshInventory();
    }

    /// <summary>
    /// Call the update method on each inventory slot
    /// </summary>
    public void RefreshInventory()
    {
        inventorySlots.ForEach(invSlot => invSlot.UpdateSlot());
    }
}
