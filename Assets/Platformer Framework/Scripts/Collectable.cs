// Created by Aaron Goss, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerFramework
{
    /// <summary>
    /// An object that can be collected, and grants points if it is.
    /// </summary>
    public class Collectable : MonoBehaviour
    {
        /// <summary>
        /// The amount of points to grant if collected.
        /// </summary>
        [SerializeField] private int pointsValue = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Invoke the OnAddPoints event to add points to the total accumulated points.
            PlatformerEvents.OnAddPoints?.Invoke(pointsValue);

            // Set this gameObject to inactive once it has been "collected".
            gameObject.SetActive(false);
        }
    }
}
