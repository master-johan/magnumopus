using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Stats stats;
    private Animator animator;
    [SerializeField] BoxCollider collider;
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
                //float temp = collider.size.y;
                //collider.size.y(collider.size.z);

                collider.size = new Vector3(collider.size.x, collider.size.z, collider.size.y);
                collider.center = new Vector3(0, 0.30f, 0);
                once = true;
                
            }
           
        }
    }
}
