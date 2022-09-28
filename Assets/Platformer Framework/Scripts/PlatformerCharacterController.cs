// Created by Aaron Goss, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerFramework
{
    /// <summary>
    /// A character controller suitable for a 2D platform game.
    /// </summary>
    public class PlatformerCharacterController : MonoBehaviour
    {
        // Some references to this character's components.
        private Rigidbody2D rbody2D;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        // The character's movement variables.
        private LayerMask groundLayerMask;
        private float horizontalMovementValue = 0f;
        private bool isGrounded = false;
        private bool isJumpButtonHeld = false;

        [SerializeField] private float runSpeed = 3f;
        [SerializeField] private float jumpStrength = 10f;

        private void OnEnable()
        {
            // Subscribe to these events.
            PlatformerEvents.OnGameStarted += Initialise;
        }

        private void OnDisable()
        {
            // Unsubscribe from these events.
            PlatformerEvents.OnGameStarted -= Initialise;
        }

        private void Start()
        {
            // Initialise our character.
            Initialise();
        }

        private void Update()
        {
            // Set our horizontal movement value to the directional keys that the player is pressing.
            horizontalMovementValue = Input.GetAxisRaw("Horizontal");

            // Flip our sprite along a vertical 'mirror line' so that it 'faces' the correct direction.
            // If the player is trying to move left...
            if (horizontalMovementValue < 0f && spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
            // ...or right.
            else if (horizontalMovementValue > 0f && spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }

            // Set our animator's Speed parameter so that Alan's run animation plays.
            animator.SetFloat("Speed", Mathf.Abs(horizontalMovementValue));

            // Transform this object's position on the X axis (horizontally)
            // at a rate of "moveSpeed" units every second (by default, 3 units per second).
            transform.position += Time.deltaTime * runSpeed * new Vector3(horizontalMovementValue, 0);

            // If the player presses "Jump" (by default, the space bar on the keyboard)...
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                // ...set some animation and control parameters...
                isJumpButtonHeld = true;
                animator.SetBool("IsJumping", true);
                isGrounded = false;

                // ...then add vertical velocity to make their character "jump"!
                rbody2D.velocity = new Vector3(rbody2D.velocity.x, jumpStrength);
            }

            // If the player releases the "Jump" button...
            if (Input.GetButtonUp("Jump"))
            {
                // ...tell the game that the player is not trying to jump any more.
                isJumpButtonHeld = false;
            }
        }

        // Our physics update.
        private void FixedUpdate()
        {
            // Check if this object is colliding with any other object at its feet.
            // If it is...
            if (Physics2D.OverlapCircle(transform.position, 0.1f, groundLayerMask))
            {
                // ...then tell the game that it should be treated as being "grounded".
                isGrounded = true;

                // If the player is not holding the jump button...
                if (!isJumpButtonHeld)
                {
                    // ...then tell the animator to stop playing the jump animation.
                    animator.SetBool("IsJumping", false);
                }
            }
            // If we are not colliding...
            else
            {
                // ...then tell the game that this object is airborne.
                isGrounded = false;
            }
        }

        /// <summary>
        /// Set up some initial on-spawn values.
        /// </summary>
        private void Initialise()
        {
            // Set up some references to our Rigidbody2D, SpriteRenderer, and Animator,
            // and tell this character what the ground is.
            if (rbody2D == null) rbody2D = GetComponent<Rigidbody2D>();
            if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (animator == null) animator = GetComponentInChildren<Animator>();
            if (groundLayerMask != 8) groundLayerMask = 8;
        }
    }
}
