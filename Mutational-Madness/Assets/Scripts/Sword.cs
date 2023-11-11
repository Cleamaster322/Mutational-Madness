using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackRange = 1f;
    public LayerMask enemyLayer;
    public float lastDirection = 1f; // 1 for right, -1 for left
    public int damage;
    public Player player;

    void Update()
    {
        if (player.animator.GetBool("SwingLeft") == false)
        {
            if (Input.GetMouseButtonDown(0) && player.weapon == 1)
            {

                player.animator.SetBool("SwingLeft", true);
                player.animator.SetBool("SwingRight", true);
            }
        }

            // Update lastDirection based on player's movement
            float horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            lastDirection = Mathf.Sign(horizontalInput);
        }
    }

    public void AttackEnded()
    {
        Attack();
        player.animator.SetBool("SwingLeft", false);
        player.animator.SetBool("SwingRight", false);
    }

    void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);
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
