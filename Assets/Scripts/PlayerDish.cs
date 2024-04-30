using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDish : MonoBehaviour
{
    public int initialDishes = 5; // Initial number of bites
    public int remainingDishes; // Remaining number of bites
    public PlayerController player;

    public bool touchingPlayer = false;

    void Start()
    {
        remainingDishes = initialDishes;
    }

    // Function to get remaining bites
    public int GetRemainingBites()
    {
        return remainingDishes;
    }
}
