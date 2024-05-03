using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDish : MonoBehaviour
{
    public int initialDishes = 5; // Initial number of bites
    public int remainingDishes; // Remaining number of bites
    public int dishesPickedUp; // Dishes picked up by Player
    public PlayerInteract playerInteract;
    public TeacherController teacher;

    public bool touchingPlayer = false;

    void Start()
    {
        remainingDishes = initialDishes;
        dishesPickedUp = 0;
    }
}
