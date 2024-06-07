using System.Collections;
using System.Collections.Generic;
using GameScripts.Weapons;
using UnityEngine;

public class TurretController : PlaceableController
{   
    [SerializeField] private float turretRange = 5f;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        var enemyPosition = enemy.transform.position;
        if (Vector3.Distance(this.transform.position, enemyPosition) <= turretRange)
        {
            transform.LookAt(enemyPosition);
            StartCoroutine(gameObject.GetComponent<AWeaponsSystem>().Shoot(enemy));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
