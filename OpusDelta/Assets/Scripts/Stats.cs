using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;

    public float maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        PotionsManager.instance.onPotionsUsed += OnPotionsUsed;
    }

    void OnPotionsUsed()
    {
        if(health >= 100)
        {
            health = 100;
        }
        else
        {
            health += 5;
            Debug.Log(health);
        }
       
    }
}
