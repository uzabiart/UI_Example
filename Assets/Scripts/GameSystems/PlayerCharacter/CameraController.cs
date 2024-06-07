using System.Collections;
using System.Collections.Generic;
using GameSystems.PlayerCharacter;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

namespace GameScripts.PlayerCharacter
{
    public class CameraController : MonoBehaviour
    {
        private GameObject player;
        [SerializeField] private float cameraSpeed = 1;
        private PlayerCharacterController playerCharacterController;
    
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerCharacterController = player.GetComponent<PlayerCharacterController>();
        }
    
        void Update()
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 position = transform.position;
            var xGap = playerPosition.x - position.x;
            var zGap = playerPosition.z - position.z;
            transform.position = new Vector3(position.x + xGap * Time.deltaTime * cameraSpeed, 20,
                position.z + zGap * Time.deltaTime * cameraSpeed);

        }
    }
}