using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WriteYourNameHere
{
    /// <summary>
    /// This class holds all the variables and functionality for moving our character around our game world.
    /// </summary>
    public class SimpleCharacterController : MonoBehaviour
    {
        [SerializeField] private float horizontalInputValue; // The value of our horizontal input axis.
        [SerializeField] private SpriteRenderer spriteRenderer; // Our character's sprite.

        // TODO Movement 1/8: Declare a variable for a reference to our 2D rigidbody, for physics stuff.

        // TODO Movement 2/8: Declare a variable for the speed we can run at in Unity-units-per-second.

        // TODO Movement 3/8: Declare a variable for the strength of our jump.


        private void Update()
        {
            // TODO Movement 4/8: Store our horizontal player input value so we can access it later on.

            // TODO Movement 5/8: Transform our character's position on the X axis. (Reference our stored horizontal input value here!)

            // TODO Movement 6/8: Check if the player presses the "Jump" button (by default, the space bar on the keyboard).

            // TODO Movement 7/8: If they do, then add vertical velocity to our rigidbody to make our character "jump"!

            // TODO Movement 8/8: Add this script to a game object and make a new prefab from it, and explore the level!

            // TODO Movement Final: Add code comments describing what you hope your code is doing throughout this script.

            // TODO Movement Bonus 1: Ensure that our character can only jump if they are "grounded". (Hint: You can use a boolean as a part of this!)

            // TODO Movement Bonus 2: Flip our character's sprite so that it faces left/right if we are moving left/right. (Hint: A SpriteRenderer reference, and changing its FlipX = true/false will help!)

        }
    }
}
