using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// InventoryItem class
/// Author: Yannick Laubscher
/// Date: 16.08.2020
/// </summary>
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
