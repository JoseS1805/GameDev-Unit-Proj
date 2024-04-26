using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 3.25f;
    public float runningSpeed = 4.5f;
    public bool isRunning;
    public Rigidbody2D rb;
    public Animator animator;


    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(inputX, inputY).normalized;

        isRunning = Input.GetKey(KeyCode.LeftShift);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("isRunning", isRunning);

        Movement(movement, isRunning);
    }

    private void Movement(Vector2 movement, bool isRunning)
    {
        float speed = isRunning ? runningSpeed : walkingSpeed;
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}