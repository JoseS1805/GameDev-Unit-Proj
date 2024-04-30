using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour
{
    public PlayerDish playerDish; // Reference to the Player Dish

    // Update is called once per frame
    void Update()
    {
        if (playerDish.remainingDishes == 0)
        {
            Debug.Log("5 dishes delivered, game over.");
        }
    }
}
