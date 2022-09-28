// Created by Aaron Goss, 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerFramework
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// The characters in the scene.
        /// </summary>
        [SerializeField] private List<PlatformerCharacterController> characters;

        /// <summary>
        /// The collectables in the scene.
        /// </summary>
        [SerializeField] private List<Collectable> collectables;

        private void OnEnable()
        {
            PlatformerEvents.OnGameStarted += InitialiseGame;
            PlatformerEvents.OnCharacterSpawned += AddCharacterToCollection;
            PlatformerEvents.OnCollectableSpawned += AddCollectableToCollection;
        }

        private void OnDisable()
        {
            PlatformerEvents.OnGameStarted -= InitialiseGame;
            PlatformerEvents.OnCharacterSpawned -= AddCharacterToCollection;
            PlatformerEvents.OnCollectableSpawned -= AddCollectableToCollection;
        }

        private void Start()
        {
            PlatformerEvents.OnGameStarted?.Invoke();
        }

        private void InitialiseGame()
        {
            PlatformerEvents.OnSpawnCharacters?.Invoke();
            PlatformerEvents.OnSpawnCollectables?.Invoke();
            PlatformerEvents.OnResetAllCharacters?.Invoke();
        }

        /// <summary>
        /// Adds a new character to the list of characters in the scene.
        /// </summary>
        /// <param name="newCharacter">The character to be added.</param>
        private void AddCharacterToCollection(PlatformerCharacterController newCharacter)
        {
            // Store a reference to our new object.
            characters.Add(newCharacter);
        }

        /// <summary>
        /// Adds a new collectable to the list of collectables in the scene.
        /// </summary>
        /// <param name="newCollectable">The collectable to be added.</param>
        private void AddCollectableToCollection(Collectable newCollectable)
        {
            // Store a reference to our new object.
            collectables.Add(newCollectable);
        }
    }
}
