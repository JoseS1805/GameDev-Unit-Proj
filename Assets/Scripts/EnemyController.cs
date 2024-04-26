using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float detectionRange = 1.15f; // Range at which the enemy detects the player
    public float movementSpeed = 2.5f; // Speed at which the enemy moves
    public Transform player; // Reference to the player's transform
    public Animator animator; // Reference to the Animator component
    public PlayerDish playerDish; // Reference to the Player Dish 

    private bool playerInRange = false;

    void Update()
    {
        // Check if the player is within the detection range
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        // If the player is in range, move towards the player and play the appropriate animation
        if (playerInRange)
        {
            // Stop moving if the enemy is touching the player
            if (distanceToPlayer <= 0.9f) // Adjust this value as needed
            {
                animator.SetFloat("Speed", 0f); // Stop the movement animation
            }
            else
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * movementSpeed * Time.deltaTime);

                // Update animator parameters based on movement direction
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
                animator.SetFloat("Speed", direction.magnitude);
            }
        }
        else
        {
            // If the player is not in range, stop the movement animation
            animator.SetFloat("Speed", 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("PlayerDish"))
        {
            // Trigger the bite animation
            animator.SetBool("touchedPlayer", true);
            animator.Play("Attack", 0);

            // Take a bite from the player's dish
            playerDish.remainingBites--;
            Debug.Log(playerDish.GetRemainingBites());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("PlayerDish"))
        {
            // Trigger the bite animation
            animator.SetBool("touchedPlayer", false);
        }
    }
}
