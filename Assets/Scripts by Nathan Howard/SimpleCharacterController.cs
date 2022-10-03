using NathanHoward;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NathanHoward
{

    /// <summary>
    /// This class holds all the variables and functionality for moving our character around our game world.
    /// </summary>
    public class SimpleCharacterController : MonoBehaviour
    {
        [SerializeField] private float horizontalInputValue; // The value of our horizontal input axis.
        [SerializeField] private SpriteRenderer spriteRenderer; // Our character's sprite.

        // Declaration of the variables within the code - it is referenced in the Unity Inspector
        [Header("References and Stats")]
        [SerializeField] private Rigidbody2D rBody2D;
        
        // Declaration of stats used by this script and the LevellingSystem script.
        public float runSpeed = 2;
        public float jumpStrength = 2;

        // Declaration of the boolean used to check if the character is jumping.
        private bool isJumping = false;

        private void Update()
        {
            // Storing the X axis input
            horizontalInputValue = Input.GetAxisRaw("Horizontal");
            
            // Move the character across the X axis based on input and runSpeed stat
            transform.position += new Vector3(horizontalInputValue * runSpeed, 0, 0) * Time.deltaTime;
            
            // Checking if the player is pressing the Spacebar to jump
            isJumping = Input.GetButtonDown("Jump");

            // If the player is jumping then add velocity to its Y axis - Note: This only works if the player is not in the air already due to rBody2D cod in if statement
            if (isJumping && rBody2D.velocity.y == 0f)
            { 
                // Creating vertical velocity to make the character "jump"
                    rBody2D.velocity = Vector2.up * jumpStrength;
            }

            // Code to check if the player is moving left or right and face the character sprite that direction
            if (horizontalInputValue > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontalInputValue < 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
