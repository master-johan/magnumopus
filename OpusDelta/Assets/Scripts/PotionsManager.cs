using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsManager : MonoBehaviour
{
    #region Singleton
    public static PotionsManager instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPotionsUsed();
    public OnPotionsUsed onPotionsUsed;

    public void UsePotion()
    {
        if (onPotionsUsed != null)
        {
            onPotionsUsed.Invoke();
        }
    }
}
