using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocused = false;

    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        //This methos is meant to be overwritten
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);


            if (distance <= radius)
            {


                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
