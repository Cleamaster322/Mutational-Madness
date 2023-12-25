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
        lifetime = 10.0; // ���������� ��������� ����� ����� ����
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        lifetime -= 0.05; // ��������� ����� ����� �� ������ ����������

        if (lifetime <= 0) // ���������, ���� ����� ����� ����� ����� ��� �������������
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
