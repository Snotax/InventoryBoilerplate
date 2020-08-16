using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Items/Consumable")]
public class ConsumableItem : InventoryItem
{
    public int HealAmount = 0;
    public int StaminaHealAmount = 0;


    public override void Use()
    {
        base.Use();
        /*  SAMPLE CODE 
         *  if(HealAmount > 0)
           {
               FindObjectOfType<Player>().Heal(HealAmount);
           }
           if(StaminaHealAmount > 0)
           {
            FindObjectOfType<Player>().HealStamina(StaminaHealAmount);
           }
           */
    }

}
