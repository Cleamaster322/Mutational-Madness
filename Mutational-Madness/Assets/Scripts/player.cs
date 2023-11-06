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
    public float rot;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = 1;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
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
        animator.SetFloat("rot", rot);

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
        

    } 
}
    
