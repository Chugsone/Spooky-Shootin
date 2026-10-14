using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0035f;
    private Rigidbody2D rb;

    public float distanceToShoot = 5f;
    public float distanceToStop = 2f;

    public float fireRate;
    public float timeToFire;

    public Transform firingPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(target.position, transform.position) <= distanceToStop)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if(timeToFire <= 0f)
        {
            Debug.Log("Shot bruv");
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
        {
            rb.linearVelocity = transform.up * speed;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            target = null;
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
