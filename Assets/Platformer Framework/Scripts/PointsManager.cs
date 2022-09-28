using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PlatformerFramework
{
    /// <summary>
    /// Shows points on the screen and tracks collected points.
    /// </summary>
    public class PointsManager : MonoBehaviour
    {
        /// <summary>
        /// Our total accumulated points value.
        /// </summary>
        [SerializeField] private int points = 0;

        /// <summary>
        /// A reference to our UI text that shows the points value on the screen.
        /// </summary>
        [SerializeField] private TextMeshProUGUI uiText;

        private void OnEnable()
        {
            // Subscribe to events here.
            PlatformerEvents.OnAddPoints += AddScore;
        }

        private void OnDisable()
        {
            // Unsubscribe from events here.
            PlatformerEvents.OnAddPoints -= AddScore;
        }

        /// <summary>
        /// Adds an amount of points to the total.
        /// </summary>
        /// <param name="amount">The amount of points to add.</param>
        private void AddScore(int amount)
        {
            points += amount;

            // Update our UI text object.
            UpdatePointsUI();
        }

        /// <summary>
        /// Updates our UI text object with the current amount of points.
        /// </summary>
        private void UpdatePointsUI()
        {
            uiText.text = points.ToString();
        }
    }
}
