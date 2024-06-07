using GameSystems.PlayerCharacter;
using UnityEngine;

namespace Placeable
{
    public class DamageTrigger : PlaceableController
    {
        [SerializeField] private float damage = 10f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            }
            collision.gameObject.GetComponent<PlayerCharacterController>().TakeDamage(damage);
        }
    }
}
