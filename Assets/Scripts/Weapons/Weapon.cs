using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.Weapons
{
    [CreateAssetMenu(menuName = "Weapon", order = 1, fileName = "Weapon")]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private string weaponName = "Weapon";
        [SerializeField] private Sprite weaponImage;
        [SerializeField] private float damage = 1f;
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private int projectiles = 1;
        [SerializeField] private float projectileSpeed = 1;

        public string WeaponName => weaponName;

        public Sprite WeaponImage => weaponImage;
        
        public float Damage => damage;

        public float FireRate => fireRate;

        public int Projectiles => projectiles;

        public float ProjectileSpeed => projectileSpeed;
    }   
}
