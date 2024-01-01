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
            
            gameObject.SetActive(false);
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

    public EnemyMemento SaveState()
    {
        EnemyMemento memento = new EnemyMemento
        {
            position = transform.position,
            scale = transform.localScale,
            health = health,
            damage = damage,
            isActive = gameObject.activeSelf
        };

        return memento;
    }

    public void RestoreState(EnemyMemento memento)
    {
        transform.position = memento.position;
        transform.localScale = memento.scale;
        health = memento.health;
        damage = memento.damage;
        gameObject.SetActive(memento.isActive);
    }

}

[System.Serializable]
public class EnemyMemento
{
    public Vector3 position;
    public Vector3 scale;
    public int health;
    public int damage;
    public bool isActive;
}
