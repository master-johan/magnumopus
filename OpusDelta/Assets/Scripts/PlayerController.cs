﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField]*/ private Animator animator;
    private CharacterController cc;
    [SerializeField] [Range(3, 10)] private float gravityValue = 7;
    float gravity;

    public float speed = 2;

    Vector2 direction = new Vector2();
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    void Update()
    {
        
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

       

        direction.Normalize();

        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);
        animator.SetBool("Moving", direction.sqrMagnitude > 0);

        if (cc.isGrounded)
        {
            gravity = 0;
           
        }
        else
        {
            gravity = -gravityValue * Time.deltaTime;
            Vector3 gravityMove = new Vector3(0, gravity, 0);
            cc.Move(gravityMove);
            
        }

        if (direction.sqrMagnitude > 0 || !cc.isGrounded)
        {
            Vector3 movement = transform.worldToLocalMatrix.MultiplyVector(new Vector3(direction.x, 0, direction.y));
            cc.Move(movement * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attacking");
            Attack();
        }


    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
