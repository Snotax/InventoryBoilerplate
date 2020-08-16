using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDataGenerator : MonoBehaviour
{
    public List<InventoryItem> Items = new List<InventoryItem>();

    public Inventory Inventory;

    void Start()
    {
        Items.ForEach(ii =>
        {
            Inventory.AddItem(ii);
        }
        );
    }

}
