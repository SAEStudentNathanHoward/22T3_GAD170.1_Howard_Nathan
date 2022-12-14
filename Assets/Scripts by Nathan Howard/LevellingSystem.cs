using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using NathanHoward;

namespace NathanHoward
{
    public class LevellingSystem : MonoBehaviour
    {
        // Declaration of the variables within this code.
        private int currentXp;
        private int currentLevel;
        private int levelUpXp;
        public bool isExpGain = false;

        // Referencing the SimpleCharacterControler script to allow usage of its variables.
        public SimpleCharacterController scripts;

        public void Start()
        {
            // Setting and showing the starting level stats.
            //currentLevel = 1;
            //currentXp = 0;
            levelUpXp = currentLevel * 100;

            //Debugging out the values.
            Debug.Log("Curent Level = " + currentLevel);
            Debug.Log("Current XP = " + currentXp);
            Debug.Log("Xp needed for Lvl up = " + levelUpXp);
            
        }
        // Created a new class to handle our collision with a coin
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Checking if the player has colided with the player.
            if (collision.tag == "Coins")
            {
                //Adding random number between 50 to 100 to currentXp.
                currentXp += Random.Range(50, 100);
                Debug.Log("New Current Xp = " + currentXp);
                collision.gameObject.SetActive(false);
            }
        }

        // Created an Update class to constantly check for keypress and xp.
        private void Update()
        {
            //Was here for testing script - Setting the "Return" key as a boolean for the purpose of checking key press .
            //isExpGain = Input.GetButtonDown("Submit");
               
                //Checking for level up.
                if (currentXp > levelUpXp)
                {
                    //Adding 1 to the player level.
                    currentLevel = currentLevel + 1;
                    
                    //Debugging out new values.
                    Debug.Log("LEVEL UP");
                    Debug.Log("Your new level is " + currentLevel);
                    Debug.Log("Current XP = " + currentXp);
                    
                    //Setting new values for next level and debugging it out.
                    levelUpXp = currentLevel * 100;
                    Debug.Log("XP needed for Lvl up = " + levelUpXp);

                    //Adjusting runSpeed and jumpStrength and debugging out.
                    scripts.runSpeed = (float)(scripts.runSpeed + 1.5);
                    scripts.jumpStrength = (float)(scripts.jumpStrength + 1.5);
                    Debug.Log("Current run speed = " + scripts.runSpeed);
                    Debug.Log("Current jump strength = " + scripts.jumpStrength);
                }
        }
    }
}
