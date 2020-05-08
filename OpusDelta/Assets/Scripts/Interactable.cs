using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocused = false;

    Transform player;


    void Update()
    {
        if (isFocused)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("INTERACT");
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
