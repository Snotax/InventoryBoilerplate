using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// UIInventory class
/// This should not be used in production. It is only to demonstrate how it could be done
/// Author: Yannick Laubscher
/// Date: 16.08.2020
/// </summary>
public class PickupHandler : MonoBehaviour
{
    [Header("Inventory Item")]
    [Tooltip("Which item should be picked up")]
    public InventoryItem Item;


    [Header("UI Reference")]
    public TextMeshProUGUI PickupTextLabel;
    public string PickupText = "Press E to pickup";



    void Start()
    {
        if (PickupTextLabel != null)
        {
            PickupTextLabel.text = PickupText;
            PickupTextLabel.enabled = false;
        }

    }

    public void DisplayText()
    {
     
    }

    public void HideText()
    {
        if (PickupTextLabel.enabled)
        {
            PickupTextLabel.enabled = false;
        }
    }
}
