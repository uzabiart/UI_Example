using System;
using System.Collections;
using System.Collections.Generic;
using GameScripts.UI;
using GameScripts.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace GameScripts.PlayerCharacter
{
    public class PlayerWeaponsSystem : AWeaponsSystem
    {
        //private Weapon currentWeapon;
        [SerializeField] private WeaponSlot[] weaponSlots;

        //[SerializeField] private GameObject projectile;
        private GameObject player;

        //private float timeSienceLastShoot = Mathf.Infinity;
        private void Start()
        {
            currentWeapon = weaponSlots[0]._Weapon;
            weaponSlots[0].gameObject.GetComponent<Image>().color = Color.green;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private new void Update()
        {
            base.Update(); 
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(Shoot());
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchWeapon(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchWeapon(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchWeapon(2);
            }
        }

        private void SwitchWeapon(int i)
        {
            currentWeapon = weaponSlots[i]._Weapon;
            foreach (WeaponSlot weaponSlot in weaponSlots)
            {
                weaponSlot.gameObject.GetComponent<Image>().color = Color.white;
            }
            weaponSlots[i].gameObject.GetComponent<Image>().color = Color.green;
        }

        /*private IEnumerator Shoot()
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
                newProjectile.GetComponent<Projectile>().SetProperties(damage, projectileSpeed);
                yield return new WaitForSeconds(0.1f);
            }
        }*/
        
    }
}

















