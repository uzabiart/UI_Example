using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] float health, maxHealth = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] bool regeneration;
    public float regenerationRate = 10.0f;

    [SerializeField] private StatusBar healthBar;

    private bool grouned = false;


    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<StatusBar>();
        healthBar.UpdateBar(health, maxHealth);
        if (regeneration == true)
        {
            StartCoroutine(TakeHealth());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"Current health {health}, damage dealt {damageAmount}");
        healthBar.UpdateBar(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
       
    }

    IEnumerator TakeHealth()
    {

        while (true) 
        {

            yield return new WaitForSeconds(regenerationRate);

            if (health < 30)
                {

                    health += 5;
                    Debug.Log($"healed by 5, current Healt {health}");
                    healthBar.UpdateBar(health, maxHealth);
                } 
        }

    }



}

