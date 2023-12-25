using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : Entity
{
    public float speed = 5f;
    private Rigidbody2D rb;
    [Header("Player Animation Settings")]
    public Animator animator;
    public int weapon;
    public int radius;
    public float rot;
    public int flesh;
    public static Player player;
    public int isMoving;

    private void Awake()
    {
        player = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = 2;
        rot = 1;
        flesh = 0;
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if (moveX != 0 || moveY != 0)
        {
            isMoving = 1;
        }
        else if (moveX == 0 || moveY == 0)
        {
            isMoving = 0;
        }

            if (Mathf.Abs(moveX) > 0)
        {
            rot = moveX;
        }
        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed;

        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
        animator.SetInteger("weapon", weapon);
        animator.SetInteger("moving", isMoving);
        animator.SetFloat("rot", rot);

        Collider2D[] meatColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D meatCollider in meatColliders)
        {
            if (meatCollider.gameObject.CompareTag("Meat"))
            {
                meatCollider.GetComponent<Magnet>().Attract(this);
            }
        }
    }
}
    
