using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float detectionRange = 5f; // Range at which the enemy detects the player
    public float movementSpeed = 3f; // Speed at which the enemy moves
    public Transform player; // Reference to the player's transform
    public Animator animator; // Reference to the Animator component

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
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * movementSpeed * Time.deltaTime);

            // Update animator parameters based on movement direction
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.magnitude);
        }
        else
        {
            // If the player is not in range, stop the movement animation
            animator.SetFloat("Speed", 0f);
        }
    }
}
