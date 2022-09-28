// Created by Aaron Goss 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerFramework
{
    public enum ObjectType { Undefined, Character, Collectable }

    /// <summary>
    /// A class that we can use to spawn different kinds of characters and collectables.
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private bool spawnOnEnable = true;
        [SerializeField] private GameObject gameObjectToSpawn;
        [SerializeField] private ObjectType gameObjectType;

        private void OnEnable()
        {
            if (spawnOnEnable)
            {
                switch (gameObjectType)
                {
                    case ObjectType.Undefined:
                        break;
                    case ObjectType.Character:
                        PlatformerEvents.OnSpawnCharacters += SpawnGameObject;
                        break;
                    case ObjectType.Collectable:
                        PlatformerEvents.OnSpawnCollectables += SpawnGameObject;
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnDisable()
        {
            if (spawnOnEnable)
            {
                switch (gameObjectType)
                {
                    case ObjectType.Undefined:
                        break;
                    case ObjectType.Character:
                        PlatformerEvents.OnSpawnCharacters -= SpawnGameObject;
                        break;
                    case ObjectType.Collectable:
                        PlatformerEvents.OnSpawnCollectables -= SpawnGameObject;
                        break;
                    default:
                        break;
                }
            }
        }

        public void SpawnGameObject()
        {
            GameObject newObject = Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity);

            switch (gameObjectType)
            {
                case ObjectType.Character:
                    PlatformerCharacterController newCharacter = newObject.GetComponent<PlatformerCharacterController>();

                    PlatformerEvents.OnCharacterSpawned(newCharacter);
                    break;
                case ObjectType.Collectable:
                    Collectable newCollectable = newObject.GetComponent<Collectable>();

                    PlatformerEvents.OnCollectableSpawned(newCollectable);
                    break;
                default:
                    Debug.LogError("Invalid object type spawned. Game Object [" + newObject.name + "] is set as of [" + gameObjectType + "] type.");
                    break;
            }
        }
    }
}
