using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitDamage : MonoBehaviour
{
    public GameObject target;
    public Animator myAnimator;
    public string animatorState;
    
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        //myAnimator = transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        float myTime = myAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length * myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if(myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Melee Attack") && myTime <= 1)
        {
            if (other.gameObject == target)
            {
                target.GetComponent<Stats>().health -= 10;

                if(target.GetComponent<Stats>().health <= 0)
                {
                    target.GetComponent<Stats>().health = 0;
                }
                Debug.Log(target.GetComponent<Stats>().health);

            }
        }      
    }
}
