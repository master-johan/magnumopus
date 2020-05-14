using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
public class Potions : Item
{
    public override void Use()
    {
        base.Use();
        PotionsManager.instance.UsePotion();
        RemoveFromInventory();
    }
}
