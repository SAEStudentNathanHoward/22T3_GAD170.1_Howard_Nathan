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
        [SerializeField] private string loadThisScene;

        private void LoadScene()
        {
            // Using Scenemanger to load the required scene
            SceneManager.LoadScene(loadThisScene);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Setting the scene on a collision to "Breif1" - ask Aaron about SceneManager.GetActiveScene()
            loadThisScene = "Brief1";
            LoadScene();

            // TODO Ask AAron about setting limits via camera?
            // TODO Loader Bonus 1: Modify your load scene method so that you can write any string or int level and it will load that. (Hint: Adding parameters to it might help!)
            // TODO Loader Bonus 2: Add a reference to your second scene (or any scenes you want) so that a second (or more) level can be loaded!

        }
    }
}
