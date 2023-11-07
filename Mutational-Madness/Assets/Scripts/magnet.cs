using UnityEngine;

public class AttractObject : MonoBehaviour
{
    public Player player;
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
        if (Vector2.Distance(player.transform.position, transform.position) <= radius)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.AddForce(direction * force);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player.transform)
        {
            Invoke("DestroyObject", destroyDelay);
            player.flesh = player.flesh + 1;
            player.fleshcounter.text = ""+player.flesh;
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
