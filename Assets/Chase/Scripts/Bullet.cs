using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifeTime = 3f; 

    private Rigidbody2D rb;
    [SerializeField] private AudioClip hitSound;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector2 directionToPlayer = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;

            rb.linearVelocity = directionToPlayer * speed;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            rb.linearVelocity = transform.up * speed;
        }
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
