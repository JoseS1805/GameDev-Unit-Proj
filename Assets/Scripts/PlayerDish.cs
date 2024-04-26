using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDish : MonoBehaviour
{
    public int initialBites = 25; // Initial number of bites
    public int remainingBites; // Remaining number of bites
    public PlayerController player;

    void Start()
    {
        remainingBites = initialBites;
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    // Function to get remaining bites
    public int GetRemainingBites()
    {
        return remainingBites;
    }
}
