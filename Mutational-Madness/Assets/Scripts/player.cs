using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    [Header("Player Animation Settings")]
    public Animator animator;
    public int weapon;
    public float attackRange;
    public LayerMask Solid;
    public float lastDirection;
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = 1;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if (Mathf.Abs(moveX) > 0.1f)
        {
            lastDirection = Mathf.Sign(moveX);
        }

        Vector2 movement = new Vector2(moveX, moveY);

        rb.velocity = movement * speed;

        animator = GetComponent<Animator>();

        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
        animator.SetInteger("weapon", weapon);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = 2;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

    }
    void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, Solid);
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null && Mathf.Sign(enemy.transform.position.x - transform.position.x) == lastDirection)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}