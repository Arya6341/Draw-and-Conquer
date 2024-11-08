using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinibiMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        // Play "Run" animation when moving
        if (horizontalMove != 0)
        {
            animator.Play("Run");
        }
        

        // Jump animation and jump logic
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jump", true);
            //animator.Play("Jump");
        }

        // Attack animation when left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Attack");
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
