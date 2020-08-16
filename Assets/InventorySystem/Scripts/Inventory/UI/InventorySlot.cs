using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Object References")]
    [HideInInspector]
    public InventoryItem Item;
    [HideInInspector]
    public Inventory Inventory;

    [Header("Properties")]
    [HideInInspector]
    public int SlotNr;
    private int Amount = 0;


    [Header("UI References")]
    [Tooltip("TMPro Label for the item name")]
    public TextMeshProUGUI NameLabel;
    [Tooltip("TMPro Label for the item amount")]
    public TextMeshProUGUI AmountLabel;
    [Tooltip("Image element reference for the item icon")]
    public Image Icon;

    private Button UseButton;

    [Header("Default Values")]
    [Tooltip("Which icon should be displayed on an empty slot")]
    public Sprite EmptyIcon;

    /// <summary>
    /// Register Use Button and ButtonListener
    /// </summary>
    private void Awake()
    {
        UseButton = GetComponentInChildren<Button>();
        UseButton.onClick.AddListener(this.UseItem);
    }


    /// <summary>
    /// Retrieve the new Item from the Inventory and update the UI
    /// </summary>
    public void UpdateSlot()
    {
        this.Item = Inventory.GetItem(SlotNr).Key;
        if (this.Item != null)
        {
            this.Amount = Inventory.GetItem(SlotNr).Value;
            this.NameLabel.text = Item.Name;
            this.AmountLabel.text = this.Amount.ToString();
            this.Icon.sprite = Item.Icon;
        }
        else
        {
            this.NameLabel.text = "";
            this.AmountLabel.text = "0";
            this.Icon.sprite = EmptyIcon;
        }
    }

    /// <summary>
    /// Call the "Use" function on the inventory item, if the item is not null
    /// </summary>
    public void UseItem()
    {
        if (this.Item != null)
        {
            this.Item.Use();

            //Implement decreasing of items here if needed
            if (this.Item is ConsumableItem)
            {
                Inventory.DecreaseAmount(this.SlotNr);
            }
        }
    }
}
