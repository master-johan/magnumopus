using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 100;
    public float currenthealth;

    public event Action<float> healthPctChanged = delegate { };
    private void OnEnable()
    {
        currenthealth = maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        currenthealth += amount;
        float currentHeathPct = currenthealth / maxHealth;
        healthPctChanged(currentHeathPct);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-10);
        }
    }
}
