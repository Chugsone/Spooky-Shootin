using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 20f;
    public float lifeTime = 3f;

    public bool movesUpwards = false;
    public int damage = 1;
    private Rigidbody2D rb2d;

    private void Start()
    {
        Destroy(gameObject, lifeTime);

        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            Vector2 travelDirection = movesUpwards ? transform.up : transform.right;
            rb2d.linearVelocity = travelDirection * speed;
        }
    }

    private void Update()
    {
        if (rb2d == null)
        {
            Vector3 localMoveDir = movesUpwards ? Vector3.up : Vector3.right;
            transform.Translate(localMoveDir * speed * Time.deltaTime, Space.Self);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
