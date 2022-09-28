// Created by Aaron Goss, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerFramework
{
    public class PlatformerEvents : MonoBehaviour
    {
        public delegate void VoidDelegate();
        public delegate void IntDelegate(int integer);
        public delegate void TransformDelegate(Transform transform);
        public delegate void GameObjectDelegate(GameObject gameObject);
        public delegate void CollectableDelegate(Collectable collectableObject);
        public delegate void PlatformerCharacterControllerDelegate(PlatformerCharacterController platformerCharacterController);

        /// <summary>
        /// To be called when the game begins.
        /// </summary>
        public static VoidDelegate OnGameStarted;

        public static VoidDelegate OnSpawnCharacters;
        public static VoidDelegate OnSpawnCollectables;

        /// <summary>
        /// To be called when the player has reached the level goal, eg a 'Flag'.
        /// </summary>
        public static VoidDelegate OnLevelGoalReached;

        /// <summary>
        /// To be called when you want to reset all characters to their default settings.
        /// </summary>
        public static VoidDelegate OnResetAllCharacters;

        /// <summary>
        /// To be called when you want to reset all collectables to their default settings.
        /// </summary>
        public static VoidDelegate OnResetAllCollectables;

        /// <summary>
        /// To be called when the player earns points towards their score.
        /// </summary>
        public static IntDelegate OnAddPoints;

        /// <summary>
        /// To be called when a new character is instantiated.
        /// </summary>
        public static PlatformerCharacterControllerDelegate OnCharacterSpawned;

        /// <summary>
        /// To be called when a new collectable is instantiated.
        /// </summary>
        public static CollectableDelegate OnCollectableSpawned;

        /// <summary>
        /// To be called when a single character needs to be reset to its default settings.
        /// </summary>
        public static PlatformerCharacterControllerDelegate OnResetCharacter;

        /// <summary>
        /// To be called when a single collectable needs to be reset to its default settings.
        /// </summary>
        public static GameObjectDelegate OnResetCollectable;

        /// <summary>
        /// To be called when a single gameObject needs to be reset to its default settings.
        /// </summary>
        public static GameObjectDelegate OnResetGameObject;
    }
}
