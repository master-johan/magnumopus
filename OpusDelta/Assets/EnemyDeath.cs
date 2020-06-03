using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Stats stats;
    private Animator animator;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stats = gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            if (!once)
            {
                animator.SetBool("Dead", true);
                once = true;
                
            }
           
        }
    }
}
