using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        string currentKeycode = Input.inputString;

        if (int.TryParse(currentKeycode, out int result))
        {
            if (result > 0 && result < 11)
            {
                if (slots[result - 1].item != null)
                {
                    slots[result - 1].UseItem();
                }
            }
        }


        //switch (currentKeycode)
        //{
        //    case inputNumber:
        //        if (slots[0].item != null)
        //        {
        //            slots[0].UseItem();
        //        }
        //        break;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (slots[0].item != null)
        //    {
        //        slots[0].UseItem();
        //    }
        //}
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
