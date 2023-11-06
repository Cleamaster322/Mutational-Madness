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

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid); 
        
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }

            Destroy(gameObject);

        }

        transform.Translate(Vector3.up * speed * Time.deltaTime); 
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime = lifetime - 0.05;
        }

    }
}
