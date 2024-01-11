using UnityEditor;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //class for sword to work properly. Animating, damaging and sounding.
    public float attackRange = 2f;
    public LayerMask enemyLayer;
    public float lastDirection = 1f; // 1 for right, -1 for left
    public int damage;
    public Player player;
    public AudioClip swordAttackSound; 
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        swordAttackSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gamesound/sword_attack.wav"); // Добавлено
        audioSource.clip = swordAttackSound;
        audioSource.volume = (MusicManager.instance.GetGameVolume()/1.6f);
    }

    void Update()
    {
        if (player.animator.GetBool("SwingLeft") == false)
        {
            if (Input.GetMouseButtonDown(0) && player.weapon == 1)
            {

                player.animator.SetBool("SwingLeft", true);
                player.animator.SetBool("SwingRight", true);
                audioSource.Play();
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
