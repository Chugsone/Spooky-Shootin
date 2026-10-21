using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float knockbackDuration = 0.15f;
    private bool isKnockedBack = false;

    public GameObject Player;
    public float speed;
    public float distanceBetween;
    private float distance;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isKnockedBack || Player == null) return;

        distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < distanceBetween)
        {
            // Calculate direction toward the player
            Vector2 direction = (Player.transform.position - transform.position).normalized;

            rb.linearVelocity = direction * speed;
        }
        else
        {
            // Stop moving if the player is too far away
            rb.linearVelocity = Vector2.zero;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            StartCoroutine(ApplyKnockBack(direction));
        }
    }

     IEnumerator ApplyKnockBack(Vector2 direction)
    {
        isKnockedBack = true;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockbackDuration);

        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
