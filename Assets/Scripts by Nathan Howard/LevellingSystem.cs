using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WriteYourNameHere;

namespace NathanHoward
{
    public class LevellingSystem : MonoBehaviour
    {
        // Declaration of the variables within this code.
        private int currentXp;
        private int currentLevel;
        private int levelUpXp;
        public bool isExpGain = false;

        private float newRunSpeed;
        private float newJumpStrength;

        private void Start()
        {
            // Setting and showing the starting level stats.
            currentLevel = 1;
            currentXp = 0;
            levelUpXp = currentLevel * 100;

            //Debugging out the values.
            Debug.Log("Curent Level = " + currentLevel);
            Debug.Log("Current XP = " + currentXp);
            Debug.Log("Xp needed for Lvl up = " + levelUpXp);

        }
        // Created an Update class to constantly check for keypress and xp.
        private void Update()
        {
            //Setting the "Return" key as a boolean for the purpose of checking key press .
            isExpGain = Input.GetButtonDown("Submit");

            //Checking if the key is pressed.
            if (isExpGain == true)
            {
                //Adding random number between 50 to 100 to currentXp.
                currentXp = currentXp + Random.Range(50, 100);
                Debug.Log("New Current Xp = " + currentXp);
                
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

                    // TODO XP Bonus: Adjust our character's stats ("runSpeed" and/or "jumpStrength") based on their level. (Hint: You'll need a reference to the SimpleCharacterController script!)
                    //Adjusting runSpeed and jumpStrength

                    Debug.Log("Current run speed = " + newRunSpeed);
                    Debug.Log("Current jump strength = " + newJumpStrength);
                }
            }
        }
    }
}
