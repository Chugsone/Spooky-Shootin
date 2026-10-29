using UnityEngine;
using System.Collections;

public class ZombieArm : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform shoulderPoint;

    [Header("Lunge Settings")]
    [SerializeField] private float lungeSpeed = 25f;
    [SerializeField] private float returnSpeed = 15f;
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float pauseAtTargetDuration = 0.05f;
    [SerializeField] private bool trackPlayerDuringLunge = true;

    private bool isAttacking = false;
    private float cooldownTimer = 0f;

    void Start()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (!isAttacking && shoulderPoint != null)
        {
            transform.position = shoulderPoint.position;
        }
        if (cooldownTimer <= 0 && !isAttacking)
        {
            TriggerLunge(); 
        }
    }

    public void TriggerLunge()
    {
        if (!isAttacking && cooldownTimer <= 0 && playerTransform != null && shoulderPoint != null)
        {
            StartCoroutine(LungeRoutine());
        }
    }


    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(10);
            
            isAttacking = false;
        }
    }




    private IEnumerator LungeRoutine()
    {
        isAttacking = true;
        cooldownTimer = attackCooldown;

        while (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) > 0.05f)
        {
            Vector3 targetPosition = trackPlayerDuringLunge ? playerTransform.position : transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, lungeSpeed * Time.deltaTime);
            yield return null;
        }

        if (playerTransform != null) transform.position = playerTransform.position;

        yield return new WaitForSeconds(pauseAtTargetDuration);

        while (shoulderPoint != null && Vector3.Distance(transform.position, shoulderPoint.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, shoulderPoint.position, returnSpeed * Time.deltaTime);
            yield return null;
        }

        if (shoulderPoint != null) transform.position = shoulderPoint.position;
        isAttacking = false;
    }
}
