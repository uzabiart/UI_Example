using System;
using GameScripts.PlayerCharacter;
using GameSystems.PlayerCharacter;
using UnityEngine;
// ReSharper disable ParameterHidesMember

namespace GameScripts.Weapons
{
    public class TurretProjectile : AProjectile
    {
        private GameObject target;
        [SerializeField] private float lifeSpan = 1;
        private float timeSinceLaunched = 0;

        private float x;
        private float y;
        private float z;
        private void Update()
        {
            timeSinceLaunched += Time.deltaTime;

            if (timeSinceLaunched > lifeSpan)
            {
                Destroy(gameObject);
            }
            if (transform.position != target.transform.position)
            {
                var speedMod = Time.deltaTime * speed;
                Vector3 newVector3 = new(x * speedMod, y * speedMod, z * speedMod);
                transform.position += newVector3;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerCharacterController>().TakeDamage(damage);
                Destroy(gameObject);
            }

        }

        public void SetProperties(float damage, float speed, GameObject target)
        {
            base.SetProperties(damage, speed);
            this.target = target;
            
            
            var pos = transform.position;
            var targetPos = target.transform.position;
            x = targetPos.x - pos.x;
            y = targetPos.y - pos.y;
            z = targetPos.z - pos.z;
        }

    }
}