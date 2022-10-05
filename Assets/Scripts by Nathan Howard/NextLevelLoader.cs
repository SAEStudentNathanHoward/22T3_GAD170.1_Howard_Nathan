using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NathanHoward
{
    public class NextLevelLoader : MonoBehaviour
    {
        [Header("Scene Loader")]
        [SerializeField] private string loadThisScene;

        private void LoadScene()
        {
            // Using Scenemanger to load the required scene
            SceneManager.LoadScene(loadThisScene);
        }

        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision");
            // Setting the scene on a collision to "Breif1" - ask Aaron about SceneManager.GetActiveScene()
            loadThisScene += 1;
            LoadScene();

            // TODO Ask AAron about setting limits via camera?
            // TODO Loader Bonus 1: Modify your load scene method so that you can write any string or int level and it will load that. (Hint: Adding parameters to it might help!)
            // TODO Loader Bonus 2: Add a reference to your second scene (or any scenes you want) so that a second (or more) level can be loaded!

        }
    }
}
