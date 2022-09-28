// Created by Aaron Goss, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerFramework
{
    /// <summary>
    /// Moves an object back to its original position if it falls off the world.
    /// </summary>
    public class FallRespawner : MonoBehaviour
    {
        /// <summary>
        /// The object's original position, set at Start().
        /// </summary>
        [SerializeField] private Vector3 originalPosition;
        /// <summary>
        /// The 'respawn floor'. This object will be moved back to its original position if it falls below this height.
        /// </summary>
        [SerializeField] private int respawnHeight = -5;

        private void Start()
        {
            // Store this object's position so it can be accessed later.
            originalPosition = transform.position;
        }

        private void Update()
        {
            // If this object's Y position is lower than the respawnHeight value...
            if (transform.position.y < respawnHeight)
            {
                // ...then move the object to its original position.
                MoveObjectToOriginalPosition();
            }
        }

        /// <summary>
        /// Moves this object to its original position.
        /// </summary>
        private void MoveObjectToOriginalPosition()
        {
            // Zero this object's velocity if it has a rigidbody.
            if (TryGetComponent(out Rigidbody rbody))
            {
                rbody.velocity = Vector3.zero;
            }
            else if (TryGetComponent(out Rigidbody2D rbody2D))
            {
                rbody2D.velocity = Vector2.zero;
            }

            // Move the object to its original position.
            transform.position = originalPosition;
        }
    }
}
