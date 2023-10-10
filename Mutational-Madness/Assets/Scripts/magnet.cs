using UnityEngine;

public class AttractObject : MonoBehaviour
{
    public Transform player;
    public float radius = 5f;
    public float force = 10f;
    public float destroyDelay = 1f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(player.position, transform.position) <= radius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce(direction * force);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player)
        {
            Invoke("DestroyObject", destroyDelay);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
