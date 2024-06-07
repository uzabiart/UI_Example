using System.Collections;
using UnityEngine;

namespace GameSystems.PlayerCharacter
{
     public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed = 1;
        [SerializeField] private float jumpPower = 1;
        [SerializeField] private float jumpTime = 0.2f;
        [SerializeField] float health, maxHealth = 100f;

        [SerializeField] private StatusBar healthBar;

        public Direction direction;

        private bool grouned = false;

        public float RotationSpeed => rotationSpeed; 

        private void Awake()
        {
            healthBar.UpdateBar(health, maxHealth);
        }
        
        private void Update()
        {
            //var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); //Input system 
            //characterController.SimpleMove(input * speed);

            if (Input.GetKey(KeyCode.W))
            {
                Move(0, 1);
                SetRotation(0);
                direction = Direction.UP;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                Move(0, -1);
                SetRotation(-180);
                direction = Direction.DOWN;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                Move(-1, 0);
                SetRotation(-90);
                direction = Direction.LEFT;
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                Move(1, 0);
                SetRotation(90);
                direction = Direction.RIGHT;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grouned)
                {
                    StartCoroutine(Jump());
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                grouned = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                grouned = false;
            }
        }

        private void Move(float x, float z)
        {
            transform.position += new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        }

        private void SetRotation(float rotation)
        {
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
        
        private IEnumerator Jump()
        {
            var waitTime = jumpTime / 10;
            for (int i = 0; i < 10; i++)
            {
                transform.position += new Vector3(0, jumpPower / 10, 0);
                yield return new WaitForSeconds(waitTime);
            }
        }

        public void TakeDamage(float damageAmount)
        {
            health -= damageAmount;
            healthBar.UpdateBar(health, maxHealth);
        }
    }

     public enum Direction
     {
         LEFT, RIGHT, UP, DOWN
     }
}