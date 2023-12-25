using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public double lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    private void Start()
    {
        lifetime = 10.0; // ”становите начальное врем€ жизни пули
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        lifetime -= 0.05; // ”меньшаем врем€ жизни на каждом обновлении

        if (lifetime <= 0) // ѕровер€ем, если врем€ жизни стало нулем или отрицательным
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("wall"))
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
