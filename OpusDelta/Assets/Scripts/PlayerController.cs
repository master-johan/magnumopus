using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField]*/ private Animator animator;
    [SerializeField] private BoxCollider feetCollider;
    private CharacterController cc;
    private bool isGrounded;
    float gravity;

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

        if (isGrounded)
        {
            gravity = 0;
        }
        else
        {
            gravity = -9.82f * Time.deltaTime;
        }



        if (direction.sqrMagnitude > 0)
        {
            Vector3 movement = new Vector3(direction.x, gravity, direction.y);
            cc.Move(movement * 2 * Time.deltaTime);
        }

        CheckIfGrounded();
    }

    private bool CheckIfGrounded()
    {
        throw new NotImplementedException();
    }
}
