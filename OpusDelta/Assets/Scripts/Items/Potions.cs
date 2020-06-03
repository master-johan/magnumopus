using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
public class Potions : Item
{
    public GameObject player;

    public override void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base.Use();
        PotionsManager.instance.UsePotion();
        player.GetComponent<Health>().ModifyHealth(40);
        if (player.GetComponent<Health>().currenthealth > 100)
        {
            player.GetComponent<Health>().currenthealth = 100;
        }
        RemoveFromInventory();
    }
}
