using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : ScriptableObject
{
    public string Name = "";
    public Sprite Icon;
    [HideInInspector]
    public int SlotNr = 0;


    public virtual void Use()
    {

    }
}
