using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitDamage : MonoBehaviour
{
    public GameObject target;
    public Animator myAnimator;
    public string animatorState;
    public int layerIndex;
    AnimatorStateInfo state;
    AnimatorClipInfo[] animatorClip;
    float wepDamage;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        //myAnimator = transform.root.GetComponent<Animator>();
        wepDamage = gameObject.GetComponentInParent<Stats>().wepDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        state = myAnimator.GetCurrentAnimatorStateInfo(layerIndex);
        animatorClip = myAnimator.GetCurrentAnimatorClipInfo(layerIndex);

        float myTime = myAnimator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.length * state.normalizedTime;

        //Debug.Log(myAnimator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip + target.tag);

       

        if(myAnimator.GetCurrentAnimatorStateInfo(layerIndex).IsName(animatorState) && myTime <= 1)
        {
            if (other.gameObject == target)
            {
                target.GetComponent<Health>().ModifyHealth(-wepDamage);
                //target.GetComponent<Stats>().health -= wepDamage;

                //if(target.GetComponent<Stats>().health <= 0)
                //{
                //    target.GetComponent<Stats>().health = 0;
                //}

                if(target.GetComponent<Health>().currenthealth <= 0)
                {
                    target.GetComponent<Health>().currenthealth = 0;
                }

                Debug.Log(target.GetComponent<Stats>().health);
                //Debug.Log(wepDamage);
                //Debug.Log(target.tag);

            }
        }      
    }
}
