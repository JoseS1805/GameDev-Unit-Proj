using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDishController : MonoBehaviour
{
    public int initialBites = 5; // Initial number of bites
    private int remainingBites; // Remaining number of bites

    // Start is called before the first frame update
    void Start()
    {
        remainingBites = initialBites;
    }

    // Function to take a bite
    public void TakeBite()
    {
        // Decrement remaining bites when the player takes a bite
        remainingBites--;

        // Check if all bites are gone
        if (remainingBites <= 0)
        {
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
