using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NathanHoward
{
    /// <summary>
    /// This class holds functionality for scene transition and reloading this scene to restart the game.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        // Declaration of the string variable used to load scenes
        [Header("Scene Loader")]
        [SerializeField] public string loadThisScene;

        private void LoadScene()
        {
            // Using Scenemanger to load the required scene
            SceneManager.LoadScene(loadThisScene);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //
            if (collision.tag == "Player")
            {
                // Setting the scene on a collision to "Breif1" - ask Aaron about SceneManager.GetActiveScene()
                loadThisScene = "Brief1 - Level 1";
                LoadScene();
            }
        }
    }
}
