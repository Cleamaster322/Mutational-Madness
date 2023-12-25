using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Entity
{
    public GameObject meat;
    public Transform enemy;
    private int speed = 2;
    [Header("Enemy Animation Settings")]
    public Animator animator;
    public int damage;

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

            animator = GetComponent<Animator>();
            animator.SetFloat("moveX", transform.position.x - Player.player.transform.position.x);
        }


    }

    public void OnCollisionStay2D(Collision2D other)
    {

        if (timeBtwShots <= 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(damage);
                timeBtwShots = AttackSpeed;
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    
    
        
}

