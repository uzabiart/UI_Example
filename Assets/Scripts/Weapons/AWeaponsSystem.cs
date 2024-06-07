using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.Weapons
{
    public class AWeaponsSystem : MonoBehaviour
    {
        [SerializeField] protected Weapon currentWeapon;
        
        [SerializeField] private GameObject projectile;
        
        protected float timeSienceLastShoot = Mathf.Infinity;

        protected void Update()
        {

            timeSienceLastShoot += Time.deltaTime;
            
        }

        public IEnumerator Shoot(GameObject target = null)
        {
            var fireRate = currentWeapon.FireRate;
            if (timeSienceLastShoot < fireRate) yield break;

            timeSienceLastShoot = 0;

            var damage = currentWeapon.Damage;
            var projectiles = currentWeapon.Projectiles;
            var projectileSpeed = currentWeapon.ProjectileSpeed;

            for (int i = 0; i < projectiles; i++)
            {
                var newProjectile = Instantiate(projectile);
                newProjectile.transform.position = transform.position;
                if (target != null)
                {
                    newProjectile.GetComponent<TurretProjectile>().SetProperties(damage, projectileSpeed, target);
                }
                else
                {
                    newProjectile.GetComponent<Projectile>().SetProperties(damage, projectileSpeed);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }   
}
