using System;
using System.Collections;
using System.Collections.Generic;
using GameScripts.PlayerCharacter;
using GameSystems.PlayerCharacter;
using UnityEngine;
// ReSharper disable ParameterHidesMember

namespace GameScripts.Weapons
{
    public class Projectile : AProjectile
    {
        void OnTriggerEnter(Collider other)
        {
            // Sprawdzamy, czy obiekt, z kt�rym nast�pi�a kolizja, to wrogowie
            if (other.CompareTag("Enemy"))
            {
                // Pobieramy komponent zdrowia wroga (je�li istnieje) i zadajemy obra�enia
                EnemyController enemyHealth = other.GetComponent<EnemyController>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }

            }
        }

        private void Start()
        {
            startPosition = transform.position;
            direction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacterController>().direction;
        }

        private void Update()
        {
            if (Vector3.Distance(startPosition, transform.position) >= 50)
            {
                Destroy(gameObject);
            }

            if (direction == Direction.RIGHT)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else if (direction == Direction.LEFT)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            else if (direction == Direction.UP)
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
            else if (direction == Direction.DOWN)
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            }

           

        }




    }
}