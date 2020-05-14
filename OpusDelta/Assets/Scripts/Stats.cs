using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        PotionsManager.instance.onPotionsUsed += OnPotionsUsed;
    }

    void OnPotionsUsed()
    {
        currentHealth += 5;
        Debug.Log(currentHealth);
    }
}
