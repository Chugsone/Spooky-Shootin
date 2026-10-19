using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 200f; 

    [Header("Combat Ranges")]
    public float distanceToShoot = 8f; 
    public float distanceToStop = 5f;  
    public float distanceToFlee = 3f;  

    [Header("Weapon Settings")]
    public GameObject bulletPrefab; 
    public Transform firingPoint;   
    public float fireRate = 1f;
    private float timeToFire;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeToFire = 0f;
    }

    public void Update()
    {
        if (!target)
        {
            GetTarget();
            return; 
        }

        if (timeToFire > 0f)
        {
            timeToFire -= Time.deltaTime;
        }

        float currentDistance = Vector2.Distance(target.position, transform.position);

        if (currentDistance <= distanceToShoot)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (!target) 
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        RotateTowardsTargetPhysics();

        Vector2 directionToPlayer = ((Vector2)target.position - (Vector2)transform.position).normalized;
        float currentDistance = Vector2.Distance(target.position, transform.position);

        if (currentDistance < distanceToFlee)
        {
            rb.linearVelocity = -directionToPlayer * speed; 
        }
        else if (currentDistance > distanceToStop)
        {
            rb.linearVelocity = directionToPlayer * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; 
        }
    }

    private void RotateTowardsTargetPhysics()
    {
        Vector2 targetDirection = target.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        float smoothedAngle = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(smoothedAngle);
    }

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            Debug.Log("Shot bruv");
            
            if (bulletPrefab != null && firingPoint != null)
            {
                Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            }

            timeToFire = fireRate; 
        }
    }

    private void GetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
