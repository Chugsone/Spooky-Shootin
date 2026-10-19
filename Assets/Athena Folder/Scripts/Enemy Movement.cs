using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float stopDistance = 1.5f;
    public float backUpDistance = 1.5f;

    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            moveDirection = (target.position - transform.position).normalized;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > stopDistance)
            {
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
            else if (distance < backUpDistance)
            {
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * -1;
            }
        }
    }
}
