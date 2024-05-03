using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Animator playerAnimator; // Reference to the player's Animator component
    public PlayerDish playerDish; // Reference to the player dish class
    public TeacherController teacher; // Reference to the Teacher
    public string interactKey = "e"; // Key to trigger interaction

    private void Start()
    {
        playerAnimator.SetBool("stopInteraction", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the player dish
        if (other.gameObject.CompareTag("PlayerDish"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerDish.dishesPickedUp++;
            playerAnimator.SetTrigger("startInteraction");

            playerAnimator.SetBool("stopInteraction", false);

            Debug.Log("playing animation, make player dish dissapear");
            Debug.Log("touching dish");
        }
        // Check if the player collides with the teacher
        if (other.gameObject.CompareTag("Teacher"))
        {
            playerAnimator.SetTrigger("startInteraction");

            playerAnimator.SetBool("stopInteraction", false);

            playerDish.remainingDishes -= playerDish.dishesPickedUp;
            playerDish.dishesPickedUp = 0;

            Debug.Log("playing animation, teacher got dish");
            Debug.Log("touhed teacher");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player stops colliding with the player dish
        if (other.gameObject.CompareTag("PlayerDish"))
        {
            Debug.Log("not touching dish");
        }
        // Check if the player stops colliding with the teacher
        if (other.gameObject.CompareTag("Teacher"))
        {
            Debug.Log("not touching teacher");
        }
    }
}