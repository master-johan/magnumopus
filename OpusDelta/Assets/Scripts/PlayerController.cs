using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*[SerializeField]*/ private Animator animator;
    private CharacterController cc;

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

        if (direction.sqrMagnitude > 0)
        {
            Vector3 movement = new Vector3(direction.x, 0, direction.y);
            cc.Move(movement * 2 * Time.deltaTime);
        }

    }
}
