using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackScript : MonoBehaviour
{
    
    BoxCollider weaponCollider;
    List<Collider> hitObjects;
    public bool activeAttack;
    float wepDamage;
  
    void Start()
    {
        hitObjects = new List<Collider>();
        weaponCollider = GetComponent<BoxCollider>();
        wepDamage = gameObject.GetComponentInParent<Stats>().wepDamage;
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "EnemySimple" && !other.isTrigger && !hitObjects.Contains(other) && activeAttack)
        {
            
            //Debug.Log("Enemy Hit" + other.gameObject.tag);
            hitObjects.Add(other);
            other.gameObject.GetComponent<Stats>().health -= wepDamage;

            //Debug.Log(hitObjects.Count);
            Debug.Log(other.gameObject.GetComponent<Stats>().health);
        }
      
    }

    public void StartAttack()
    {
        Debug.Log("Start Attack");
        hitObjects.Clear();
        activeAttack = true;
    }

    public void StopAttack()
    {
        activeAttack = false;
    }


}
