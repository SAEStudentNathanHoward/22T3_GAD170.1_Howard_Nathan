using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NathanHoward
{
    /// <summary>
    /// This class holds functionality for scene transition and reloading this scene to restart the game.
    /// </summary>
    public class SceneRestarter : MonoBehaviour
    {
        // Declaration of the string variable used to load scenes
        [Header("Scene Loader")]
        [SerializeField] public string restartThisScene;

        private void LoadScene()
        {
            // Using Scenemanger to load the required scene
            SceneManager.LoadScene(restartThisScene);
        }

        private void Update()
        {
            // Checking the R key for a press
            if (Input.GetKeyDown(KeyCode.R))
            {
                LoadScene();
            }
        }
    }
}
