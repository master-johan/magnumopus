using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
public class Potions : Item
{
    public override void Use()
    {
        base.Use();
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().health < 100)
        {
            PotionsManager.instance.UsePotion();
            RemoveFromInventory();
        }

    }
}