using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    
    [SerializeField] BoxCollider weaponCollider;
    List<Collider> hitObjects;
    public int test;
    public bool activeAttack;
  
    void Start()
    {
        hitObjects = new List<Collider>();
        weaponCollider = GetComponent<BoxCollider>();
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    

        if (other.gameObject.tag == "EnemySimple"&& !hitObjects.Contains(other) && activeAttack)
        {

            Debug.Log("Enemy Hit" + other.gameObject.tag);
            hitObjects.Add(other);
            
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
