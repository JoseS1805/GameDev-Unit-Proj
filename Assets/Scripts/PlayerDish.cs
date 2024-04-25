using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDish : MonoBehaviour
{
    public int initialBites = 25; // Initial number of bites
    private int remainingBites; // Remaining number of bites
    public PlayerController player;

    void Start()
    {
        remainingBites = initialBites;
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    public void TakeBite()
    {
        // Decrement remaining bites when the player takes a bite
        remainingBites--;

        // Check if all bites are gone
        if (remainingBites <= 0)
        {
            Debug.Log("No more bites");
            // Restart level or trigger game over
            // Implement your logic here
        }
    }

    // Function to get remaining bites
    public int GetRemainingBites()
    {
        return remainingBites;
    }
}
