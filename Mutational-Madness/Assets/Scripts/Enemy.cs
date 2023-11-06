using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject meat;
    public Transform enemy;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(meat, enemy.position, enemy.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
