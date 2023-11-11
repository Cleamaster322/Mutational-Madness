using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Entity
{
    public GameObject meat;
    public Transform enemy;
    private int speed = 2;

    private float timeBtwShots;
    public float AttackSpeed;


    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(meat, enemy.position, enemy.rotation);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.player.transform.position, speed * Time.deltaTime);
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {

        if (timeBtwShots <= 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(1);
                timeBtwShots = AttackSpeed;
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    
    
        
}

