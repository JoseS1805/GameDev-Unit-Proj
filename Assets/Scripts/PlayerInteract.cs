using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Animator playerAnimator; // Reference to the player's Animator component
    public PlayerDish playerDish; // Reference to the player dish class
    public string interactKey = "e"; // Key to trigger interaction
    public GameObject dish1;

    private bool isTouchingPlayerDish = false; // Flag to track if the player is touching the player dish
    private bool isTouchingTeacher = false; // Flag to track if the player is touching the teacher

    private void Start()
    {
        
        playerAnimator.SetBool("stopInteraction", true);
    }
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            // Check if the player is touching the player dish and the interact key is pressed
            if (isTouchingPlayerDish)
            {
                // Trigger the interact animation
                playerAnimator.SetTrigger("PickDishUp");

                // Disable the player dish sprite picked up
                dish1.GetComponent<SpriteRenderer>().enabled = false;

                playerAnimator.SetBool("stopInteraction", false);

                Debug.Log("playing animation, make player dish dissapear");
            }
            else if (isTouchingTeacher)
            {
                // Trigger the interact animation
                playerAnimator.SetTrigger("TouchingTeacher");

                playerAnimator.SetBool("stopInteraction", false);

                playerDish.remainingDishes--;

                Debug.Log("playing animation, teacher got dish");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the player dish
        if (other.CompareTag("PlayerDish"))
        {
            isTouchingPlayerDish = true;
        }
        // Check if the player collides with the teacher
        if (other.CompareTag("Teacher"))
        {
            isTouchingTeacher = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player stops colliding with the player dish
        if (other.CompareTag("PlayerDish"))
        {
            isTouchingPlayerDish = false;
        }
        // Check if the player stops colliding with the teacher
        if (other.CompareTag("Teacher"))
        {
            isTouchingTeacher = false;
        }
    }
}
