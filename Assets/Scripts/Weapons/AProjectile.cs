using GameScripts.PlayerCharacter;
using GameSystems.PlayerCharacter;
using UnityEngine;

namespace GameScripts.Weapons
{
    public class AProjectile : MonoBehaviour
    {
        protected float damage;
        protected float speed;

        protected Direction direction;

        protected Vector3 startPosition;

        public void SetProperties(float damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }
    }
}